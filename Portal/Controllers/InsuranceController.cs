﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portal.Business.Contracts;
using Portal.Helpers;

namespace Portal.Controllers
{
    public class InsuranceController : Controller
    {
        private readonly IProductManager _productManager;

        public InsuranceController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public IActionResult Index()
        {
            var data = _productManager.Get(s => s.ProductCategory.Name.Equals("Insurance")).OrderBy(s => s.Name);
            return View(data);
        }

        public IActionResult Details(int id)
        {
            var data = new RenderProductViewHelper(_productManager).Get("Insurance", id);

            if (data != null)
            {
                return View("_details", data);
            }

            return RedirectToAction("Index");
        }
    }
}