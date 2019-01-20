using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Portal.Web.ViewModels;
using PortalAPI.Domain.Models;
using PortalAPI.Domain.ModelView;
using PortalAPI.Midleware.Contracts;

namespace Portal.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _product;
        private readonly IProductCategoryService _categoryService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ProductsController(IProductService product, IProductCategoryService categoryService,
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
                    Description = item.Description
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
                var product = new Products
                {
                    Id = models.Id,
                    Name = models.Name,
                    ProductCategoryId = models.ProductCategory,
                    Description = models.Description,
                    StartFrom = models.StartFrom,
                    IsExpressionOfInterest = models.IsExpressionOfInterest
                };

                if (models.UploadProductImage.Length > 0)
                {
                    var file = models.UploadProductImage;
                    var extension = file.ContentType.Replace("image/", ".");
                    var filename = $"{Guid.NewGuid().ToString().Replace("-", "")}{extension}";

                    product.Image = filename;
                    var result = _product.Save(product);
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
    }
}