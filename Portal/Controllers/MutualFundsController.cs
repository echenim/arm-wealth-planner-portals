using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Business.Contracts;
using Portal.Domain.Models;
using Portal.Helpers;
using Portal.ViewModel;

namespace Portal.Controllers
{
    public class MutualFundsController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly ICartManager _cartManager;
        private readonly IGeneratorsManager _generatorsManager;

        public MutualFundsController(IProductManager productManager, ICartManager cartManager, IGeneratorsManager generatorsManager)
        {
            _productManager = productManager;
            _cartManager = cartManager;
            _generatorsManager = generatorsManager;
        }

        public IActionResult Index()
        {
            var data = _productManager.Get(s => s.ProductCategory.Name.Equals("Mutual Funds")).OrderBy(s => s.Name);
            ShowCartInformation();
            return View(data);
        }

        public IActionResult Details(int id)
        {
            var identitifier = _generatorsManager.UserSessionManagerForTrackingActivities();
            ShowCartInformation();
            if (id > 0)
            {
                var data = new RenderProductViewHelper(_productManager).Get("Mutual Funds", id);
                data.ProductId = id;

                if (data != null)
                {
                    return View("_details", data);
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitToCart(ProductsAndProductsItem model)
        {
            var identitifier = _generatorsManager.UserSessionManagerForTrackingActivities();
            ShowCartInformation();
            if (ModelState.IsValid)
            {
                var carts = new Transactional
                {
                    ProductId = model.ProductId,
                    /*I used the null checker to check if the user name is null pass the
                     identitier number which is the session tracking number*/
                    ItemOwner = User.Identity.Name ?? identitifier,
                    TransactionNo = long.Parse(identitifier),
                    Amount = model.Amount,
                    OrderAndPurchaseStatus = "InCart",
                    OrderDate = DateTime.UtcNow
                };

                var result = _cartManager.Save(carts);
                if (result.Id > 0)
                {
                    return RedirectToAction("Carts", "CartAndPayment");
                }
            }

            return RedirectToAction($"Details/{model.ProductId}", "MutualFunds");
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