using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portal.Areas.Client.Models;
using Portal.Business.Contracts;
using Portal.Domain.Models;
using Portal.Domain.ViewModels;
using Portal.Helpers;
using Portal.ViewModel;

namespace Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly ICartManager _cartManager;
        private readonly IGeneratorsManager _generatorsManager;

        public HomeController(IProductManager productManager, ICartManager cartManager, IGeneratorsManager generatorsManager)
        {
            _productManager = productManager;
            _cartManager = cartManager;
            _generatorsManager = generatorsManager;
        }

        public IActionResult Index()
        {
            var data = _productManager.Get().OrderBy(s => s.Name);
            ShowCartInformation();
            return View(data);
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