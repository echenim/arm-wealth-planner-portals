using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Portal.Areas.Client.Extensions;
using Portal.Domain.ModelView;

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
        private readonly ICartManager _cartManager;
        private readonly IGeneratorsManager _generatorsManager;

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
            ICartManager cartManager,
            IGeneratorsManager generatorsManager,

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
            _cartManager = cartManager;
            _generatorsManager = generatorsManager;

            _cache = cache;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            ShowCartInformation();
            return View();
        }

        //will refactor later
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModels model)
        {
            if (!ModelState.IsValid) return View(model);
            ShowCartInformation();
            var tracker = HttpContext.Session.GetString("_ArmTracker");
            if (tracker != null)
            {
                _cartManager.CartUpdateWithEmail(model.Username, tracker);
            }
            var isValiedUser = _userManager.Users.Include(s => s.Person)
                .SingleOrDefault(s => s.UserName.Equals(model.Username));
            if (isValiedUser != null)
            {
                var resultCustomer =
                    _signInManager.PasswordSignInAsync(isValiedUser, model.Password, true, true).Result;
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

                        var profileUserResult = _userManager.CreateAsync(userObj, model.Password).Result;
                        if (profileUserResult.Succeeded)
                        {
                            var valiedUser = _userManager.Users.SingleOrDefault(s => s.Email.Equals(userObj.Email));
                            if (valiedUser != null)
                            {
                                var signInResult = _signInManager
                                    .PasswordSignInAsync(valiedUser, model.Password, true, true).Result;
                                if (signInResult.Succeeded)
                                {
                                    _cache.Set<CustomerInformationView>("ArmOneUser", armOneObj, new MemoryCacheEntryOptions()
                                                                            .SetSlidingExpiration(TimeSpan.FromMinutes(20))
                                                                            .SetAbsoluteExpiration(TimeSpan.FromHours(1)));

                                    _cache.Set<AuthenticateResponse>("ArmUser", dataHubObj, new MemoryCacheEntryOptions()
                                                                            .SetSlidingExpiration(TimeSpan.FromMinutes(20))
                                                                            .SetAbsoluteExpiration(TimeSpan.FromHours(1)));

                                    return RedirectToAction("Index", "Dashboard", new { area = "Client" });
                                }
                            }
                        }
                    }

                    _cache.Set<AuthenticateResponse>("ArmUser", dataHubObj, new MemoryCacheEntryOptions()
                                                           .SetSlidingExpiration(TimeSpan.FromMinutes(20))
                                                           .SetAbsoluteExpiration(TimeSpan.FromHours(1)));

                    //var claims = new[] { new Claim("name", armOneObj.MembershipNumber), new Claim(ClaimTypes.Role, "Client") };
                    //var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                    //HttpContext.Session.Set("ArmUser", dataHubObj);

                    return RedirectToAction("Index", "Dashboard", new { area = "Client" });
                }
            }

            return View();
        }


        [AllowAnonymous]
        public IActionResult SignIn()
        {
            ShowCartInformation();
            return View("_signin");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn(LoginViewModels model)
        {
            if (!ModelState.IsValid) return View("_signin", model);
            ShowCartInformation();
            var tracker = HttpContext.Session.GetString("_ArmTracker");
            if (tracker != null)
            {
                _cartManager.CartUpdateWithEmail(model.Username, tracker);
            }
            var valiedUserObj = _userManager.Users.Include(s => s.Person)
                .SingleOrDefault(s => s.UserName.Equals(model.Username));

            var isUserNameNullable = valiedUserObj?.UserName;
            if (!string.IsNullOrEmpty(isUserNameNullable))
            {
                var resultCustomer =
                    _signInManager.PasswordSignInAsync(valiedUserObj, model.Password, true, true).Result;
                if (resultCustomer.Succeeded)
                {
                    return RedirectToAction("CheckOut", "CartAndPayment");
                }
            }
            else
            {
                var armOneObj = _armOneManager.GetCustomerInformation(model.Username, model.Password);
                if (armOneObj.ResponseCode.Equals("00"))
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

                        var profileUserResult = _userManager.CreateAsync(userObj, model.Password).Result;
                        if (profileUserResult.Succeeded)
                        {
                            var valiedUser = _userManager.Users.SingleOrDefault(s => s.Email.Equals(userObj.Email));
                            if (valiedUser != null)
                            {
                                var signInResult = _signInManager
                                    .PasswordSignInAsync(valiedUser, model.Password, true, true).Result;
                                if (signInResult.Succeeded)
                                {
                                    return RedirectToAction("CheckOut", "CartAndPayment");
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
            _cache.Remove("ArmUser");
            _cache.Remove("ArmOneUser");
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Registration()
        {
            ShowCartInformation();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                ShowCartInformation();
                var tracker = HttpContext.Session.GetString("_ArmTracker");
                if (tracker != null)
                {
                    _cartManager.CartUpdateWithEmail(model.Email, tracker);
                }

                var onboardToArm = _armOneManager.OnboardNewUsers(model, model.Password);

                if (onboardToArm.ResponseCode.Equals("00"))
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

        #region test

        public IActionResult Tregistration()
        {
            ShowCartInformation();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Tregistration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                ShowCartInformation();
                var tracker = HttpContext.Session.GetString("_ArmTracker");
                if (tracker != null)
                {
                    _cartManager.CartUpdateWithEmail(model.Email, tracker);
                }

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
                }
            }

            return View(model);
        }

        #endregion test

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

        #region cartbasket

        public void ShowCartInformation()
        {
            #region available cart

            var currentSession = _generatorsManager.UserSessionManagerForTrackingActivities();
            var cartView = _generatorsManager.ViewCart(User.Identity.Name);

            ViewBag.Name = currentSession;

            ViewData["cartitems"] = cartView.ItemsInCart;
            ViewBag.Count = cartView.ItemCount;

            #endregion available cart
        }

        #endregion cartbasket
    }
}