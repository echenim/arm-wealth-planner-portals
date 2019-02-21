using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portal.Areas.Admin.ViewModels;
using Portal.Business.Contracts;
using Portal.Business.Utilities;
using Portal.Domain.Models;
using Portal.Domain.ModelView;

namespace Portal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductManager _product;
        private readonly IProductFeatureManager _productFeature;
        private readonly IProductKeyBenefitManager _benefitService;
        private readonly IProductCategoryManager _categoryService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ProductsController(IProductManager product,
            IProductCategoryManager categoryService,
            IProductFeatureManager productFeature,
            IProductKeyBenefitManager benefitService,
        IHostingEnvironment hostingEnvironment)
        {
            _product = product;
            _benefitService = benefitService;
            _productFeature = productFeature;
            _categoryService = categoryService;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            ViewData["ControllerName"] = "Admin/Products";
            var list = new List<ProductView>();

            var data = _product.Get();
            foreach (var item in data)
            {
                list.Add(new ProductView
                {
                    Id = item.Id,
                    Name = item.Name,
                    ProductCategory = item.ProductCategory.Name,
                    StartFrom = item.StartFrom,
                    Description = item.Description,
                    IsActive = item.IsActive
                });
            }

            return View(list);
        }

        public IActionResult Add()
        {
            ViewData["ControllerName"] = "Admin/Product";

            var productObj = new ProductViewModel();
            productObj.AvailableCategories.Add(new SelectListItem
            {
                Text = "--select--",
                Value = String.Empty
            });
            var productCategoryList = _categoryService.Get().OrderBy(s => s.Name);
            foreach (var item in productCategoryList)
            {
                productObj.AvailableCategories.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }

            return View("_add", productObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ProductViewModel models)
        {
            if (ModelState.IsValid)
            {
                #region product | benefit | feature

                var feature = models.Feature.Replace(FromTinyMc.Head, FromTinyMc.ReplaceWith);
                var product = new Products
                {
                    Id = models.Id,
                    Name = models.Name,
                    ProductCategoryId = models.ProductCategory,
                    Description = models.Description,
                    StartFrom = models.StartFrom,
                    ProductTypes = models.ProductTypes,
                    Features = models.Feature.Replace(FromTinyMc.Breaker, FromTinyMc.ReplaceWith).Replace(FromTinyMc.Head, FromTinyMc.ReplaceWith).Replace(FromTinyMc.End, FromTinyMc.ReplaceWith),
                    Benefits = models.Benefit.Replace(FromTinyMc.Breaker, FromTinyMc.ReplaceWith).Replace(FromTinyMc.Head, FromTinyMc.ReplaceWith).Replace(FromTinyMc.End, FromTinyMc.ReplaceWith),
                    MoreInformation = models.MoreInformation.Replace(FromTinyMc.Breaker, FromTinyMc.ReplaceWith).Replace(FromTinyMc.Head, FromTinyMc.ReplaceWith).Replace(FromTinyMc.End, FromTinyMc.ReplaceWith),
                    InvestmentManagement = models.InvestmentManagement.Replace(FromTinyMc.Breaker, FromTinyMc.ReplaceWith).Replace(FromTinyMc.Head, FromTinyMc.ReplaceWith).Replace(FromTinyMc.End, FromTinyMc.ReplaceWith),
                    HowToBegin = models.HowToBegin.Replace(FromTinyMc.Breaker, FromTinyMc.ReplaceWith).Replace(FromTinyMc.Head, FromTinyMc.ReplaceWith).Replace(FromTinyMc.End, FromTinyMc.ReplaceWith),
                    IsActive = models.IsActive
                };

                #endregion product | benefit | feature

                if (models.UploadProductImage.Length > 0)
                {
                    var file = models.UploadProductImage;
                    var extension = file.ContentType.Replace("image/", ".");
                    var filename = $"{Guid.NewGuid().ToString().Replace("-", "")}{extension}";

                    product.Image = filename;
                    var products = _product.Save(product);

                    var upload = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

                    var filelocation = Path.Combine(upload, filename);
                    using (var filestream = new FileStream(filelocation, FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }

                    return RedirectToAction("Index");
                }
            }
            var productObj = new ProductViewModel();
            productObj.AvailableCategories.Add(new SelectListItem
            {
                Text = "--select--",
                Value = String.Empty
            });
            var productCategoryList = _categoryService.Get().OrderBy(s => s.Name);
            foreach (var item in productCategoryList)
            {
                productObj.AvailableCategories.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }

            return View("_add", productObj);
        }

        public IActionResult Edit()
        {
            return View("_edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductViewModel models)
        {
            if (ModelState.IsValid)
            {
                #region product | benefit | feature

                var product = new Products
                {
                    Id = models.Id,
                    Name = models.Name,
                    ProductCategoryId = models.ProductCategory,
                    Description = models.Description,
                    StartFrom = models.StartFrom,
                    ProductTypes = models.ProductTypes,
                    Features = models.Feature.Replace(FromTinyMc.Head, FromTinyMc.ReplaceWith)
                        .Replace(FromTinyMc.End, FromTinyMc.ReplaceWith),
                    Benefits = models.Benefit.Replace(FromTinyMc.Head, FromTinyMc.ReplaceWith)
                        .Replace(FromTinyMc.End, FromTinyMc.ReplaceWith),
                    MoreInformation = models.MoreInformation.Replace(FromTinyMc.Head, FromTinyMc.ReplaceWith)
                        .Replace(FromTinyMc.End, FromTinyMc.ReplaceWith),
                    InvestmentManagement = models.InvestmentManagement.Replace(FromTinyMc.Head, FromTinyMc.ReplaceWith)
                        .Replace(FromTinyMc.End, FromTinyMc.ReplaceWith),
                    HowToBegin = models.HowToBegin.Replace(FromTinyMc.Head, FromTinyMc.ReplaceWith)
                        .Replace(FromTinyMc.End, FromTinyMc.ReplaceWith),
                    IsActive = models.IsActive
                };

                #endregion product | benefit | feature
            }

            return View("_edit");
        }
    }
}