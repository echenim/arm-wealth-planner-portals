using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portal.ViewModel;
using Portal.Business.Contracts;
using Portal.Business.Utilities;
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

        public AccountController(
            IUserService userService,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            IPasswordHasher<ApplicationUser> passwordHasher,
            IHostingEnvironment hostingEnvironment,
            IArmOneManager armOneManager
            )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;
            _hostingEnvironment = hostingEnvironment;
            _userService = userService;
            _armOneManager = armOneManager;
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
            var isValiedUser = _userManager.Users.SingleOrDefault(s => s.UserName.Equals(model.Username)
                                                                     || s.MembershipNumber.Equals(model.Username));
            if (isValiedUser != null)
            {
                if (isValiedUser.IsCustomerOrStaff.ToLower().Equals("External".ToLower()))
                {
                    var result = _signInManager.PasswordSignInAsync(isValiedUser, "102Solutionx$#@", true, true).Result;
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "Client" });
                    }
                }

                if (isValiedUser.IsCustomerOrStaff.ToLower().Equals("Internal".ToLower()))
                {
                    var result = _signInManager.PasswordSignInAsync(isValiedUser, model.Password, true, true).Result;
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                    }
                }
            }
            else
            {
                var result = _armOneManager.GetCustomerInformation(model.Username, model.Password);
                if (result != null)
                {
                    var user = new ApplicationUser();
                    user.CustomerOnboardingDate = DateTime.Now;
                    user.IsCustomerOrStaff = "External";
                    user.FirstName = result.FirstName;
                    user.LastName = result.LastName;
                    user.Email = result.Email;
                    user.NewOrOld = "Old";
                    user.MembershipNumber = result.MembershipNumber;
                    user.UserNameAlternative = result.AltUsername;

                    var profileUserResult = _userManager.CreateAsync(user, "102Solutionx$#@").Result;
                    if (profileUserResult.Succeeded)
                    {
                        var valiedUser = _userManager.Users.SingleOrDefault(s => s.Email.Equals(user.Email));
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
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private ApplicationUser IfMemberShipNumberIsEmptyUpdateRecord(ApplicationUser user, string membershipnumber)
        {
            var userObj = _userManager.FindByEmailAsync(user.Email).Result;
            userObj.MembershipNumber = membershipnumber;
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