using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Portal.Business.Contracts;
using Portal.Business.Utilities;
using Portal.Domain.Models;

namespace Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IErmOneManager _ermOneManager;

        public HomeController(IErmOneManager ermOneManager)
        {
            _ermOneManager = ermOneManager;
        }

        public IActionResult Index()
        {
            var i = _ermOneManager.GetCustomerInformation("myron.echenim@gmail.com", "103Solution123445");
            var k = i;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}