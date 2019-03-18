using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NPOI.OpenXmlFormats.Wordprocessing;
using Portal.Business.Contracts;
using Portal.Business.StoreManagers;
using Portal.Business.ViewModels;
using Portal.Domain.Models;
using Portal.Domain.Models.Identity;
using Portal.Domain.ModelView;
using Portal.Domain.ViewModels;
using Portal.Helpers;
using Portal.ViewModel;

namespace Portal.Controllers
{
    public class CartAndPaymentController : Controller
    {
        private readonly ICartManager _cartManager;
        private readonly IGeneratorsManager _generatorsManager;
        private readonly IPersonManager _personManager;

        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IArmOneManager _armOneManager;
        private readonly IArmOneServiceConfigManager _armOneServiceConfigManager;

        //caching to persist user data
        private readonly IMemoryCache _cache;

        public CartAndPaymentController(
            ICartManager cartManager,
            IPersonManager personManager,
            IGeneratorsManager generatorsManager,
            IUserService userService,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            IPasswordHasher<ApplicationUser> passwordHasher,
            IHostingEnvironment hostingEnvironment,
            IArmOneManager armOneManager,
            IArmOneServiceConfigManager armOneServiceConfigManager,

            IMemoryCache cache)
        {
            _cartManager = cartManager;
            _personManager = personManager;
            _generatorsManager = generatorsManager;
            _armOneServiceConfigManager = armOneServiceConfigManager;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;
            _hostingEnvironment = hostingEnvironment;
            _userService = userService;
            _armOneManager = armOneManager;

            _cache = cache;
        }

        public IActionResult Carts()
        {
            var currentSession = _generatorsManager.UserSessionManagerForTrackingActivities();

            ViewBag.Name = currentSession;
            //check if the user is signed by calling user.identity.name
            //if it return null we then use the session data to tracker and fetch user data
            var filter = User.Identity.Name ?? currentSession;
            var data = _cartManager.GetCart(s => s.ItemOwner.ToLower()
                                                     .Equals(filter.ToLower()) && s.OrderAndPurchaseStatus.Equals("InCart"));

            ShowCartInformation();

            return View("_carts", data);
        }

        public IActionResult CheckOut()
        {
            var _user = _cache.Get<AuthenticateResponse>("ArmUser");
            var currentSession = _generatorsManager.UserSessionManagerForTrackingActivities();

            ViewBag.Name = currentSession;
            //check if the user is signed by calling user.identity.name
            //if it return null we then use the session data to tracker and fetch user data
            var filter = User.Identity.Name ?? currentSession;

            //fetch curent selected products
            var data = _cartManager.GetCart(s => s.ItemOwner.ToLower().Equals(filter.ToLower())
                              && s.OrderAndPurchaseStatus.Equals("InCart"));

            var trnx = (from u in data.CartCollection
                        select u.TransactionNo).Distinct();

            foreach (var item in trnx)
            {
                data.TransactionNo = $"{item}";
            }

            //get customer information if signed in
            var username = User.Identity.Name;

            if (!string.IsNullOrEmpty(username))
            {
                #region fill form for payment

                data.MemberUniqueIdentifier = User.Identity.Name;
                data.FullName = User.Identity.Name;

                data.PaymentGateway = $"{_armOneServiceConfigManager.ArmAggregatorBaseUrl}/Aggregator2/Payment";
                data.XmlPayload = _generatorsManager.ArmXmlData(data.CartCollection.ToList());

                //var toHashed =
                //    $"{data.TransactionNo}{_armOneServiceConfigManager.ArmServiceUsername}{data.Total}{_armOneServiceConfigManager.ReturnUrl}{_armOneServiceConfigManager.ArmMacKey}";
                //data.HashedData = _generatorsManager.HashedValues(toHashed);

                data.VendorUserName = _generatorsManager.DecryptCredentials(_armOneServiceConfigManager.ArmServiceUsername);

                data.ReturnUr = _armOneServiceConfigManager.ReturnUrl;

                #endregion fill form for payment

                data.Person = _personManager.Get(s => s.Email.Equals(User.Identity.Name))
                    .SingleOrDefault();

                data.TransactionParameter = _generatorsManager.GenerateTransactionParameter(data.TransactionNo);

                var tobeHashed = String.Concat(data.TransactionParameter, data.VendorUserName, data.Total.ToString().Replace(".", ""), _armOneServiceConfigManager.ReturnUrl, _armOneServiceConfigManager.ArmMacKey);
                data.HashedData = _generatorsManager.HashedValues(tobeHashed);
            }

            ShowCartInformation();

            return View("_checkout", data);
        }

        [HttpPost]
        [AllowAnonymous]
        [IgnoreAntiforgeryToken(Order = 1001)]
        public IActionResult Processing(IFormCollection files, string au)
        {
            var trResponse = files;
            var transactionRef = trResponse["arm_txnref"];
            var trStatusCode = trResponse["arm_tranx_status_code"];
            var trPayRef = trResponse["arm_payref"];
            var trAmount = trResponse["arm_tranx_amt"];
            var trStatusMsg = trResponse["arm_tranx_status_msg"];
            var trCurrency = trResponse["arm_tranx_curr"];
            var trCustId = trResponse["arm_cust_id"];
            var trPaymentParams = trResponse["arm_payment_params"];

            //if (!User.Identity.IsAuthenticated)
            //{
            //    var result = _personManager.Get(s => s.Email.Equals(trCustId) || s.MemberShipNo.Equals(trCustId)).SingleOrDefault();
            //    if (result != null)
            //    {
            //        var rs = _userManager.Users.Where(s => s.UserName == result.Email);
            //    }
            //}

            ShowCartInformation();
            var tranno = transactionRef.ToString().Replace("ARM", "").Trim();
            if (trStatusCode.Equals("00"))
            {
                UpdateStatus(tranno, "Succeed");
                return RedirectToAction("Index", "Dashboard", new { area = "Client" });
            }
            UpdateStatus(tranno, "Failed");
            ViewBag.Status = trStatusCode;
            ViewBag.Message = trStatusMsg;
            return View("_process");
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

        #region update transaction

        private void UpdateStatus(string transactionno, string status)
        {
            _cartManager.UpdateStatus(transactionno, status);
        }

        #endregion update transaction

        #region

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn(CartView model)
        {
            //  if (!ModelState.IsValid) return View("_checkout", model);
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
                    var dataHubObj = new AuthenticateResponse
                    {
                        FirstName = valiedUserObj.Person.FirstName,
                        LastName = valiedUserObj.Person.LastName,
                        FullName = valiedUserObj.Person.FullName,
                        EmailAddress = valiedUserObj.Person.Email,
                        MembershipKey = Convert.ToInt32(valiedUserObj.Person.MemberShipNo)
                    };

                    _cache.Set<AuthenticateResponse>("ArmUser", dataHubObj, new MemoryCacheEntryOptions()
                                                                .SetSlidingExpiration(TimeSpan.FromMinutes(20))
                                                                .SetAbsoluteExpiration(TimeSpan.FromHours(1)));

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
                                    _cache.Set<CustomerInformationView>("ArmOneUser", armOneObj, new MemoryCacheEntryOptions()
                                                                            .SetSlidingExpiration(TimeSpan.FromMinutes(20))
                                                                            .SetAbsoluteExpiration(TimeSpan.FromHours(1)));

                                    _cache.Set<AuthenticateResponse>("ArmUser", dataHubObj, new MemoryCacheEntryOptions()
                                                                            .SetSlidingExpiration(TimeSpan.FromMinutes(20))
                                                                            .SetAbsoluteExpiration(TimeSpan.FromHours(1)));

                                    return RedirectToAction("CheckOut", "CartAndPayment");
                                }
                            }
                        }
                    }
                }
            }

            return View("_checkout", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cregistration(CartView model)
        {
            // if (!ModelState.IsValid) return View("_checkout", model);
            ShowCartInformation();
            var tracker = HttpContext.Session.GetString("_ArmTracker");
            if (tracker != null)
            {
                _cartManager.CartUpdateWithEmail(model.Email, tracker);
            }

            var personObj = new Person
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                BioetricVerificationNumber = model.BioetricVerificationNumber,
                Address = model.Address,
                Tel = model.Tel,
                Gender = model.Gender,
                IsCustomer = true,
                OnCreated = DateTime.Now.ToUniversalTime(),
                PortalOnBoarding = $"NPB"
            };

            var onboardToArm = _armOneManager.OnboardNewUsers(personObj, model.Password);

            if (onboardToArm.ResponseCode.Equals("00"))
            {
                var dataHubObj = new AuthenticateResponse();
                var armOneObj = _armOneManager.GetCustomerInformation(model.Email, model.Password);
                if (armOneObj.ResponseCode.Equals("00"))
                {
                    dataHubObj = _armOneManager.DataHubClientInfo(armOneObj.MembershipNumber, model.Password);
                }

                var isPersonResult = _personManager.Save(personObj);
                if (isPersonResult.Succeed)
                {
                    if (dataHubObj == null)
                    {
                        dataHubObj.EmailAddress = isPersonResult.TObj.Email;
                        dataHubObj.FirstName = isPersonResult.TObj.FirstName;
                        dataHubObj.LastName = isPersonResult.TObj.LastName;
                        dataHubObj.FullName = isPersonResult.TObj.FullName;
                        dataHubObj.IsActive = isPersonResult.TObj.IsCustomer;
                        dataHubObj.MembershipKey = Convert.ToInt32(isPersonResult.TObj.MemberShipNo);
                    }

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
                            _cache.Set<CustomerInformationView>("ArmOneUser", armOneObj, new MemoryCacheEntryOptions()
                                                                            .SetSlidingExpiration(TimeSpan.FromMinutes(20))
                                                                            .SetAbsoluteExpiration(TimeSpan.FromHours(1)));

                            _cache.Set<AuthenticateResponse>("ArmUser", dataHubObj, new MemoryCacheEntryOptions()
                                                                    .SetSlidingExpiration(TimeSpan.FromMinutes(20))
                                                                    .SetAbsoluteExpiration(TimeSpan.FromHours(1)));

                            return RedirectToAction("CheckOut", "CartAndPayment");
                        }
                        else
                        {
                            _cache.Set<CustomerInformationView>("ArmOneUser", armOneObj, new MemoryCacheEntryOptions()
                                                                            .SetSlidingExpiration(TimeSpan.FromMinutes(20))
                                                                            .SetAbsoluteExpiration(TimeSpan.FromHours(1)));

                            _cache.Set<AuthenticateResponse>("ArmUser", dataHubObj, new MemoryCacheEntryOptions()
                                                                    .SetSlidingExpiration(TimeSpan.FromMinutes(20))
                                                                    .SetAbsoluteExpiration(TimeSpan.FromHours(1)));

                            return RedirectToAction("CheckOut", "CartAndPayment");
                        }
                    }
                }
            }

            return View("_checkout", model);
        }

        #endregion
    }
}