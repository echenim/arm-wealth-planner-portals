using Microsoft.AspNetCore.Mvc;

namespace Portal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuditTrailController : Controller
    {
        public IActionResult Index()
        {
            ViewData["ControllerName"] = "ADMIN/AUDIT TRAIL by DEBO";
            ViewBag.Alexia = "test on alexia";
            return View();
        }

        public IActionResult Edit()
        {
            ViewData["ControllerName"] = "ADMIN/AUDIT-ALEXIA/EDIT";
            return View();
        }
    }
}