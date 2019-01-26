using Microsoft.AspNetCore.Mvc;

namespace Portal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AnalyticsController : Controller
    {
        public IActionResult Index()
        {
            ViewData["ControllerName"] = "Admin/Analytics";
            return View();
        }

        public IActionResult add()
        {
            ViewData["ControllerName"] = "Admin/Analytics";
            return View();
        }
    }
}