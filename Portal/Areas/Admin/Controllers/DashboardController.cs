using Microsoft.AspNetCore.Mvc;

namespace Portal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewData["ControllerName"] = "Admin/Dashboard";
            return View();
        }
    }
}