using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal.ViewModel;
using Portal.Business.Contracts;
using Portal.Business.Utilities;
using Portal.Domain.Models;
using Portal.Domain.Models.Identity;
using Microsoft.Extensions.Caching.Memory;
using Portal.Domain.ViewModels;
using Portal.Business.ViewModels;

namespace Portal.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IArmOneManager _armOneManager;
        private readonly IPersonManager _personManager;

        //caching to persist user data
        private readonly IMemoryCache _cache;

        public AccountController(
            IUserService userService,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            IPasswordHasher<ApplicationUser> passwordHasher,
            IHostingEnvironment hostingEnvironment,
            IArmOneManager armOneManager,
            IPersonManager personManager,
            IMemoryCache cache
            )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;
            _hostingEnvironment = hostingEnvironment;
            _userService = userService;
            _armOneManager = armOneManager;
            _personManager = personManager;

            _cache = cache;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModels model)
        {
            if (!ModelState.IsValid) return View(model);
            var isValiedUser = _userManager.Users.Include(s => s.Person)
                .SingleOrDefault(s => s.UserName.Equals(model.Username));
            if (isValiedUser != null)
            {
                var resultCustomer = _signInManager.PasswordSignInAsync(isValiedUser, model.Password, true, true).Result;
                if (resultCustomer.Succeeded)
                {
                    return isValiedUser.Person.IsCustomer
                        ? RedirectToAction("Index", "Home")
                        : RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                }
            }
            else
            {
                var armOneObj = _armOneManager.GetCustomerInformation(model.Username, model.Password);
                if (armOneObj != null)
                {
                    var dataHubObj = _armOneManager.DataHubClientInfo(armOneObj.MembershipNumber, model.Password);

                    var person = new Person
                    {
                        FirstName = armOneObj.FirstName,
                        LastName = armOneObj.LastName,
                        BioetricVerificationNumber = string.Empty,
                        Gender = string.Empty,
                        IsCustomer = true,
                        Email = armOneObj.Email,
                        OnCreated = DateTime.Now.ToUniversalTime(),
                        PortalOnBoarding = "OPB"
                    };

                    var personResult = _personManager.Save(person);
                    if (personResult.Succeed)
                    {
                        var userObj = new ApplicationUser
                        {
                            UserName = armOneObj.Email,
                            Email = armOneObj.Email,
                            PersonId = personResult.TObj.Id
                        };

                        var profileUserResult = _userManager.CreateAsync(userObj, "102Solutionx$#@").Result;
                        if (profileUserResult.Succeeded)
                        {
                            var valiedUser = _userManager.Users.SingleOrDefault(s => s.Email.Equals(userObj.Email));
                            if (valiedUser != null)
                            {
                                var signInResult = _signInManager.PasswordSignInAsync(valiedUser, "102Solutionx$#@", true, true).Result;
                                if (signInResult.Succeeded)
                                {
                                    _cache.Set<CustomerInformationView>("ArmOneUser", armOneObj);
                                    _cache.Set<AuthenticateResponse>("ArmUser", dataHubObj);
                                    return RedirectToAction("Index", "Dashboard", new { area = "Client" });
                                }
                            }
                        }

                        _cache.Set<CustomerInformationView>("ArmOneUser", armOneObj);
                        _cache.Set<AuthenticateResponse>("ArmUser", dataHubObj);
                        return RedirectToAction("Index", "Dashboard", new { area = "Client" });
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            _cache.Remove("ArmUser");
            _cache.Remove("ArmOneUser");
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var onboardToArm = _armOneManager.OnboardNewUsers(model, model.Password);

                if (onboardToArm.ResponseCode.Equals(""))
                {
                    var isPersonResult = _personManager.Save(model);
                    if (isPersonResult.Succeed)
                    {
                        var user = new ApplicationUser
                        {
                            UserName = isPersonResult.TObj.Email,
                            Email = isPersonResult.TObj.Email,
                            PersonId = isPersonResult.TObj.Id
                        };
                        var rs = _userManager.CreateAsync(user, model.Password).Result;
                        if (rs.Succeeded)
                        {
                            var isSignInSuccessful =
                                _signInManager.PasswordSignInAsync(user, model.Password, true, true).Result;
                            if (isSignInSuccessful.Succeeded)
                            {
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                return RedirectToAction("Login", "Account");
                            }
                        }

                        //}
                    }
                }
            }

            return View(model);
        }

        private ApplicationUser IfMemberShipNumberIsEmptyUpdateRecord(ApplicationUser user, string membershipnumber)
        {
            var userObj = _userManager.FindByEmailAsync(user.Email).Result;
            // userObj.MembershipNumber = membershipnumber;
            var result = _userManager.UpdateAsync(userObj).Result;
            return result.Succeeded ? userObj : user;
        }

        private ApplicationUser IfUserDoesNotExitCreateTheUser(ApplicationUser user)
        {
            var password = TransfromerManager.DefaultPassword();
            var result = _userManager.CreateAsync(user, password).Result;
            return result.Succeeded ? _userManager.FindByEmailAsync(user.Email).Result : user;
        }
    }
}