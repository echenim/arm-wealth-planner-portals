using Microsoft.AspNetCore.Mvc;
using Portal.Business.Contracts;

namespace Portal.Areas.Admin.Controllers
{
    [Area("Admin")]
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