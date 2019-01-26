using Microsoft.AspNetCore.Mvc;

namespace Portal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            ViewData["ControllerName"] = "Admin/Sales";
            return View();
        }
    }
}