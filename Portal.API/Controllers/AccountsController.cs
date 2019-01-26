using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Portal.Domain.Models.Identity;
using Portal.API.Utilities;
using Portal.API.ViewModels;

namespace Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly AppSettings _appSettings;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        private readonly IHostingEnvironment _hostingEnvironment;

        public AccountsController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager,
            IConfiguration configuration,
            IOptions<AppSettings> appSettings,
            IPasswordHasher<ApplicationUser> passwordHasher,
            IHostingEnvironment hostingEnvironment
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _appSettings = appSettings.Value;
            _passwordHasher = passwordHasher;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        [Route("findbyusernamefromtokeninformation")]
        public IActionResult FetchByUserNameFromTokenInfomration()
        {
            if (User.Identity is ClaimsIdentity getclaimsinformation)
            {
                var extractedusernamefromtoken = getclaimsinformation.FindFirst(ClaimTypes.Name)?.Value;

                if (!string.IsNullOrEmpty(extractedusernamefromtoken))
                {
                    var userdetail = _userManager.Users
                        .SingleOrDefaultAsync(s => s.UserName.Equals(extractedusernamefromtoken)).Result;

                    if (userdetail != null)
                    {
                        var user = new UserViewModel
                        {
                            Id = userdetail.Id,
                            Email = userdetail.Email,
                            FirstName = userdetail.FirstName,
                            LastName = userdetail.LastName,
                            IsCustomerOrStaff = userdetail.IsCustomerOrStaff
                        };
                        return Ok(user);
                    }
                    else
                    {
                        return BadRequest("no record asssociated with this Id");
                    }
                }
            }

            return BadRequest("Invalid ");
        }

        [HttpGet]
        [Route("currentloginuser")]
        public IActionResult FetchCurrentLoginUserName()
        {
            var currentuser = User.Identity.Name;
            if (currentuser != null)
            {
                if (!string.IsNullOrEmpty(currentuser))
                {
                    var getUserInformation = _userManager.FindByNameAsync(currentuser).Result;

                    if (getUserInformation != null)
                    {
                        var user = new UserViewModel
                        {
                            Id = getUserInformation.Id,
                            Email = getUserInformation.Email,
                            FirstName = getUserInformation.FirstName,
                            LastName = getUserInformation.LastName,
                            IsCustomerOrStaff = getUserInformation.IsCustomerOrStaff
                        };
                        return Ok(user);
                    }
                    else
                    {
                        return BadRequest("no record asssociated with this Id");
                    }
                }

                return BadRequest("Invalid user id");
            }
            return BadRequest("invalid request");
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginViewModel loginModel)
        {
            var response = new LoginResponseViewModel();

            if (ModelState.IsValid)
            {
                var user = _userManager.FindByNameAsync(loginModel.UserName).Result;
                if (user != null)
                {
                    response.Email = user.Email;
                    if (_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginModel.Password) == PasswordVerificationResult.Success)
                    {
                        response.IsLoginSuccessful = true;
                        response.Token = GetToken(user);
                        return Ok(response);
                    }
                    else
                    {
                        return BadRequest("username or password is invalid");
                    }
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

            return BadRequest("User not registeed.");
        }

        [Route("testit")]
        [Authorize]
        [HttpGet]
        public IActionResult TestAutorization()
        {
            var current_user = User.Identity.Name;
            var jwtuser = User.FindFirst("unique_name")?.Value;

            var UserId = User.FindFirst("actort")?.Value;
            // var another = User.Identity.

            var item = "userid : " + UserId + "currentUser : " + current_user + " JwtUser : " + jwtuser;
            return Ok(item + " --- > working");
        }

        [Route("roles")]
        [Authorize]
        [HttpGet]
        public IActionResult AddRole([FromBody]string role)
        {
            if (!string.IsNullOrEmpty(role))
            {
                var rol = new ApplicationRole();
                rol.Name = role;
                var resuslt = _roleManager.CreateAsync(rol).Result;
                if (resuslt.Succeeded)
                {
                    return Ok("done");
                }
                return BadRequest();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult RegisterUser([FromBody]UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.Email.ToLower(),
                    Email = model.Email,
                    IsCustomerOrStaff = model.IsCustomerOrStaff,
                    UserNameAlternative = model.AltUsername,
                    MembershipNumber = model.MembershipNumbe
                };

                #region password setting

                /**
                * if the user type is 1 which is NSE staff, set password to default passsword,
                * since password validation is not required*
                * if the user type is 2 which is Non NSe staff than set password to user defined password
                */
                var userpassword = "105ElectroDynamics%$#@";

                #endregion password setting

                var results = _userManager.CreateAsync(user, userpassword).Result;
                if (results.Succeeded)
                {
                    return Ok(results.Succeeded);
                }
                else
                {
                    return BadRequest(results.Errors);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("edit")]
        public IActionResult EditUser([FromBody]EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByNameAsync(model.Email).Result;
                user.Email = model.Email;
                user.UserName = model.Email;
                user.PhoneNumber = model.PhoneNumber;

                if (user != null)
                {
                    var result = _userManager.UpdateAsync(user).Result;
                    if (result.Succeeded)
                    {
                        var newuserdata = _userManager.FindByNameAsync(model.Email).Result;

                        return Ok("user information updateed successfully");
                    }
                    else
                    {
                        return BadRequest("failed to update user information");
                    }
                }
                else
                {
                    return BadRequest("Invalide user");
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("assignpermission")]
        //  [Authorize(policy: PoliciesName.IsSystemAdminClaims)]
        public IActionResult AssignPermissionToUser([FromBody]UserPermissionViewModel model)
        {
            if (ModelState.IsValid)
            {
                /*
                 * get user information using the user_email
                 */
                var user = _userManager.FindByNameAsync(model.UserName).Result;
                if (user != null)
                {
                    var role = _roleManager.FindByNameAsync(model.PermissionName).Result;
                    if (role != null)
                    {
                        var removepreviousrole = _userManager.RemoveFromRoleAsync(user, role.Name).Result;
                        var result = _userManager.AddToRoleAsync(user, role.Name).Result;
                        if (result.Succeeded)
                        {
                            return Ok(result.Succeeded);
                        }
                    }
                }
            }

            return BadRequest(ModelState);
        }

        //[HttpGet]
        //[Route("getgroupname")]
        //public IActionResult GetRoles()
        //{
        //    var policy_name = new List<RoleRepresentationAsPolicy>();
        //    var roleset = _roleManager.Roles;

        //    if (roleset.Any())
        //    {
        //        foreach (var item in roleset)
        //        {
        //            policy_name.Add(new RoleRepresentationAsPolicy
        //            {
        //                PermissionName = item.Name
        //            });
        //        }

        //        return Ok(policy_name);
        //    }

        //    return BadRequest("invalid request");
        //}

        #region role and claim manangerr

        [HttpPost]
        [Route("setuproles")]
        public IActionResult SetRole([FromBody] RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = new ApplicationRole(model.Name);
                var result = _roleManager.CreateAsync(role).Result;
                if (result.Succeeded)
                {
                    return Ok(result.Succeeded);
                }
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("setup")]
        public async Task<IActionResult> Setup()
        {
            //  var user = await _userManager.FindByNameAsync(User.Identity.Name);

            //var adminRole = _roleManager.FindByNameAsync("Admin").Result;
            //if (adminRole != null)
            //{
            //    //adminRole = new IdentityRole("Admin");
            //    // await _roleManager.CreateAsync(adminRole);

            //    await _roleManager.AddClaimAsync(adminRole, new Claim(ClaimTypes.Role, "can.view"));
            //    await _roleManager.AddClaimAsync(adminRole, new Claim(ClaimTypes.Role, "can:edit"));
            //    await _roleManager.AddClaimAsync(adminRole, new Claim(ClaimTypes.Role, "can:delete"));
            //    await _roleManager.AddClaimAsync(adminRole, new Claim(ClaimTypes.Role, "can:create"));
            //}

            //if (!await userManager.IsInRoleAsync(user, adminRole.Name))
            //{
            //    await userManager.AddToRoleAsync(user, adminRole.Name);
            //}

            //var accountManagerRole = await roleManager.FindByNameAsync("Account Manager");

            //if (accountManagerRole == null)
            //{
            //    accountManagerRole = new IdentityRole("Account Manager");
            //    await roleManager.CreateAsync(accountManagerRole);

            //    await roleManager.AddClaimAsync(accountManagerRole, new Claim(CustomClaimTypes.Permission, "account.manage"));
            //}

            //if (!await userManager.IsInRoleAsync(user, accountManagerRole.Name))
            //{
            //    await userManager.AddToRoleAsync(user, accountManagerRole.Name);
            //}

            return Ok();
        }

        #endregion role and claim manangerr

        #region token generation

        private string GetToken(ApplicationUser user)
        {
            var utcNow = DateTime.UtcNow;
            var allClaimsAssignedToThisUser = UserClaims(user: user);
            var allRoleAssignedToThisUser = UserRole(user: user);

            var claims = new Claim[]
            {
               // new Claim(JwtRegisteredClaimNames.Sub,$"{user.FirstName}{user.LastName}"),
                new Claim(JwtRegisteredClaimNames.Actort, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
              //  new Claim(JwtRegisteredClaimNames.Jti, user.ListedCompanyInfoId.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, utcNow.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email)
            }
            .Union(allClaimsAssignedToThisUser)
                .Union(allRoleAssignedToThisUser);

            //.Union(permission_claims);

            var API_SECRET_KEY = _configuration["API_SECRET_KEY"];

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(API_SECRET_KEY);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = "https://PortalAPIcenter.com/token",
                Issuer = "https://PortalAPIcenter.com/token",
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            // var jwt = new { token = tokenHandler.WriteToken(token), expiration = tokenDescriptor.Expires };
            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// use this method to fetch all the claims assigned to the
        /// specific user
        /// </summary>
        /// <param name="user">ApplicationUser user</param>
        /// <returns></returns>
        private IEnumerable<Claim> UserClaims(ApplicationUser user)
        {
            var claims = _userManager.GetClaimsAsync(user: user).Result;
            return claims;
        }

        private IEnumerable<Claim> UserRole(ApplicationUser user)
        {
            var roles = _userManager.GetRolesAsync(user: user).Result;
            var claims = roles
                .Select(item => new Claim(ClaimTypes.Role, item))
                .ToList();
            return claims;
        }

        #endregion token generation
    }
}