using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Portal.Business.Contracts;
using Portal.Business.TestServices;
using Portal.Business.ViewModels;
using Portal.Domain;
using Portal.Services;

namespace Portal.Areas.Client.Controllers
{
    [Area("Client")]
    public class CalculatorsController : Controller
    {
        public string _webRootPath;
        public string _contentRootPath;
        public readonly IHostingEnvironment _hostingEnvironment;
        public JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

        public readonly ILogger<CalculatorsController> _logger;
        public readonly IConfiguration _configuration;

        private readonly IArmOneServiceConfigManager _configSettingManager;
        public TestArmClientServices _clientService;

        public ApplicationDbContext db;
        public ClientRepository _client;

        private readonly IMemoryCache _cache;

        public CalculatorsController(IHostingEnvironment hostingEnvironment, IArmOneServiceConfigManager configManager,
                                    ILogger<CalculatorsController> logger, IConfiguration configuration,
                                    IMemoryCache cache, ApplicationDbContext _db)
        {
            _hostingEnvironment = hostingEnvironment;
            _webRootPath = _hostingEnvironment.WebRootPath;
            _contentRootPath = _hostingEnvironment.ContentRootPath;

            _logger = logger;
            _configuration = configuration;

            _configSettingManager = configManager;

            _clientService = new TestArmClientServices(_configSettingManager, _contentRootPath);
            _client = new ClientRepository(_configSettingManager, _contentRootPath);

            db = _db;
            _cache = cache;
        }

        public IActionResult InvestmentGoalCalculator()
        {
            var _user = _cache.Get<AuthenticateResponse>("ArmUser");
            if (_user == null)
            {
                TempData["SessionTimeOut"] = $@"You have been logged out due to inactivity. 
                                                Please login to gain access.";
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View();
        }

        public IActionResult SavingsPlanCalculator()
        {
            var _user = _cache.Get<AuthenticateResponse>("ArmUser");
            if (_user == null)
            {
                TempData["SessionTimeOut"] = $@"You have been logged out due to inactivity. 
                                                Please login to gain access.";
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View();
        }
    }
}