using Microsoft.AspNetCore.Mvc;

namespace Portal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuditTrailController : Controller
    {
        public IActionResult Index()
        {
            ViewData["ControllerName"] = "ADMIN/AUDIT TRAIL by DEBO";
            return View();
        }
    }
}
