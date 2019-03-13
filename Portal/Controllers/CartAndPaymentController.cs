﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal.Business.Contracts;
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

        public CartAndPaymentController(ICartManager cartManager,
            IPersonManager personManager, IGeneratorsManager generatorsManager,
            IUserService userService,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            IPasswordHasher<ApplicationUser> passwordHasher,
            IHostingEnvironment hostingEnvironment,
            IArmOneManager armOneManager)
        {
            _cartManager = cartManager;
            _personManager = personManager;
            _generatorsManager = generatorsManager;

            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;
            _hostingEnvironment = hostingEnvironment;
            _userService = userService;
            _armOneManager = armOneManager;
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
                data.Person = _personManager.Get(s => s.Email.Equals(User.Identity.Name))
                    .SingleOrDefault();
            }

            ShowCartInformation();

            return View("_checkout", data);
        }

        [HttpGet]
        public IActionResult Process(string trnxnumber, string amount)
        {
            if (!string.IsNullOrEmpty(trnxnumber))
            {
                var trn_number = long.Parse(trnxnumber);
                var orderAndPurchaseStatus = "Succeed";
                _cartManager.UpdateStatus(trnxnumber, orderAndPurchaseStatus);
            }

            return RedirectToAction("Index", "Dashboard", new { area = "Client" });
        }

        public IActionResult PaymentStatus()
        {
            return View();
        }

        public IActionResult ExpressinOfInterest()
        {
            return View();
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
                var isPersonResult = _personManager.Save(personObj);
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
                            return RedirectToAction("CheckOut", "CartAndPayment");
                        }
                        else
                        {
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