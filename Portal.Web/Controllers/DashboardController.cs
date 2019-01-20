using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Portal.Web.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewData["ControllerName"] = "Admin/Dashboard";
            return View();
        }
    }
}