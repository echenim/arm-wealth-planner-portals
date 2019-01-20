using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortalAPI.Midleware.Contracts;

namespace Portal.Web.Controllers
{
    public class SettingsController : Controller
    {
        private readonly IProductCategoryService _categoryService;

        public SettingsController(IProductCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewRoles()
        {
            return View();
        }

        public IActionResult ViewPermission()
        {
            return View();
        }

        public IActionResult ViewProductCategory()
        {
            var list = _categoryService.Get();

            return View(list);
        }

        public IActionResult AddProductCategory()
        {
            return View("_AddProductCategory");
        }
    }
}