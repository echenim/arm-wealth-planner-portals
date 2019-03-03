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

        public AccountController(
            IUserService userService,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            IPasswordHasher<ApplicationUser> passwordHasher,
            IHostingEnvironment hostingEnvironment,
            IArmOneManager armOneManager,
            IPersonManager personManager
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
            var isValiedUser = _userManager.Users.Include(s => s.Person).SingleOrDefault(s => s.UserName.Equals(model.Username)
                                                                       || s.Person.MembershipNo.Equals(model.Username));
            if (isValiedUser != null)
            {
                if (isValiedUser.Person.IsCustomer)
                {
                    var resultCustomer = _signInManager.PasswordSignInAsync(isValiedUser, "102Solutionx$#@", true, true).Result;
                    if (resultCustomer.Succeeded)
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "Client" });
                    }
                }
                var resultStaff = _signInManager.PasswordSignInAsync(isValiedUser, model.Password, true, true).Result;
                if (resultStaff.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                }
            }
            else
            {
                var armOneObj = _armOneManager.GetCustomerInformation(model.Username, model.Password);
                if (armOneObj != null)
                {
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
                                    return RedirectToAction("Index", "Dashboard", new { area = "Client" });
                                }
                            }
                        }
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Registration()
        {
            return View();
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