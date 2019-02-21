using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portal.Business.Contracts;
using Portal.ViewModel;

namespace Portal.Controllers
{
    public class StoreController : Controller
    {
        private readonly IProductManager _productManager;

        public StoreController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Product()
        {
            return View();
        }

        public IActionResult Items(string id)
        {
            var resultObj = new ItemView();
            if (!string.IsNullOrEmpty(id))
            {
                var Id = int.Parse(id);
                var data = _productManager.Get(s => s.Id == Id).SingleOrDefault();
                if (data != null)
                {
                    resultObj.Id = data.Id;
                    resultObj.ProductName = data.Name;
                    resultObj.ProductCategory = data.ProductCategory.Name;
                    resultObj.Description = data.Description;
                    resultObj.Feature = data.Features;
                    resultObj.Benefit = data.Benefits;
                    resultObj.InvestmentManagement = data.InvestmentManagement;
                    resultObj.HowToBegin = data.HowToBegin;
                    resultObj.MoreInformation = data.MoreInformation;
                    resultObj.ProductTypes = data.ProductTypes;
                }
            }

            return View("Items", resultObj);
        }
    }
}