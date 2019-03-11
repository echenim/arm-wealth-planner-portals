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

        private readonly IProductCategoryManager _categoryService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ProductsController(IProductManager product,
            IProductCategoryManager categoryService,
        IHostingEnvironment hostingEnvironment)
        {
            _product = product;
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

                var product = new Products
                {
                    Id = models.Id,
                    Name = models.Name,
                    ProductCategoryId = models.ProductCategory,
                    Description = models.Description,
                    StartFrom = models.StartFrom,
                    ProductTypes = models.ProductTypes,
                    IsActive = models.IsActive,
                    IsVouchering = models.IsVourcher == true ? "Yes" : "No"
                };

                #endregion product | benefit | feature

                if (models.UploadProductImage.Length > 0)
                {
                    var file = models.UploadProductImage;
                    var extension = file.ContentType.Replace("image/", ".");
                    var filename = $"{Guid.NewGuid().ToString().Replace("-", "")}{extension}";

                    product.Image = filename;
                    var products = _product.Save(product);

                    var upload = Path.Combine(Directory.GetCurrentDirectory(), "Liber\\FileArchives");

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
                    IsActive = models.IsActive,
                    IsVouchering = models.IsVourcher == true ? "Yes" : "No"
                };

                #endregion product | benefit | feature
            }

            return View("_edit");
        }

        public IActionResult AddFeatures(int id)
        {
            if (id < 1) return RedirectToAction("Index");
            var product = _product.Get(s => s.Id == id).SingleOrDefault();
            var features = new PropertiesView();
            features.ProductId = id;
            features.ProductName = $"{ product.Name.ToUpper()} ||  {product.ProductCategory.Name.ToUpper()}";

            return View("_properties", features);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddFeatures(PropertiesView model)
        {
            if (ModelState.IsValid)
            {
                var rs = _product.Save(model);
                if (rs.Id > 0)
                {
                    model.Description = string.Empty;
                    return View("_properties", model);
                }
            }

            return View("_properties", model);
        }

        public IActionResult AddInvestmentInfo(int id)
        {
            if (id < 1) return RedirectToAction("Index");
            var product = _product.Get(s => s.Id == id).SingleOrDefault();
            var features = new ProductInvestmentInformationView();
            features.ProductId = id;
            features.ProductName = $"{ product.Name.ToUpper()} ||  {product.ProductCategory.Name.ToUpper()}";

            return View("_investment", features);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddInvestmentInfo(ProductInvestmentInformationView model)
        {
            if (ModelState.IsValid)
            {
                var rs = _product.Save(model);
                if (rs.Id > 0)
                {
                    model.RangOrCost = string.Empty;
                    model.Abs = string.Empty;
                    return View("_investment", model);
                }
            }

            return View("_properties", model);
        }
    }
}