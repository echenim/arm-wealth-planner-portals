using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portal.Areas.Client.Models;
using Portal.Business.Contracts;
using Portal.Helpers;
using Portal.ViewModel;

namespace Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductManager _productManager;

        public HomeController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public IActionResult Index()
        {
            var data = _productManager.Get().OrderBy(s => s.Name);
            return View(data);
        }
    }
}