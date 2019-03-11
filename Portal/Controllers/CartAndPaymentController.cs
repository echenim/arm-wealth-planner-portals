using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portal.Business.Contracts;
using Portal.Helpers;

namespace Portal.Controllers
{
    public class CartAndPaymentController : Controller
    {
        private readonly ICartManager _cartManager;
        private readonly IGeneratorsManager _generatorsManager;

        public CartAndPaymentController(ICartManager cartManager, IGeneratorsManager generatorsManager)
        {
            _cartManager = cartManager;
            _generatorsManager = generatorsManager;
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
            var data = _cartManager.GetCart(s => s.ItemOwner.ToLower()
                                                         .Equals(filter.ToLower()) && s.OrderAndPurchaseStatus.Equals("InCart"));

            ShowCartInformation();

            return View("_checkout", data);
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
    }
}