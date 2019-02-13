﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portal.Business.Contracts;
using Portal.Domain.Models;

namespace Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArmOneManager _ermOneManager;

        public HomeController(IArmOneManager ermOneManager)
        {
            _ermOneManager = ermOneManager;
        }

        public IActionResult Index()
        {
            //var i = _ermOneManager.GetCustomerInformation("myron.echenim@gmail.com", "103Solution123445");
            //var k = i;
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