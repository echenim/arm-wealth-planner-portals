using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portal.Business.Contracts;
using Portal.Helpers;
using Portal.ViewModel;

namespace Portal.Controllers
{
    public class MutualFundsController : Controller
    {
        private readonly IProductManager _productManager;

        public MutualFundsController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public IActionResult Index()
        {
            var data = _productManager.Get(s => s.ProductCategory.Name.Equals("Mutual Funds")).OrderBy(s => s.Name);
            return View(data);
        }

        public IActionResult Details(int id)
        {
            var data = new RenderProductViewHelper(_productManager).Get("Mutual Funds", id);

            if (data != null)
            {
                return View("_details", data);
            }

            return RedirectToAction("Index");
        }
    }
}