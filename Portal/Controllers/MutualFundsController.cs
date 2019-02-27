using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Portal.Controllers
{
    public class MutualFundsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}