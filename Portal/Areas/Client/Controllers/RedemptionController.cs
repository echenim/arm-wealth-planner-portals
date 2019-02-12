using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Portal.Areas.Client.Controllers
{
    public class RedemptionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}