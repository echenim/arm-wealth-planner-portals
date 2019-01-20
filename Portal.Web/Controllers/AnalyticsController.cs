using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Portal.Web.Controllers
{
    public class AnalyticsController : Controller
    {
        public IActionResult Index()
        {
            ViewData["ControllerName"] = "Admin/Analytics";
            return View();
        }
    }
}