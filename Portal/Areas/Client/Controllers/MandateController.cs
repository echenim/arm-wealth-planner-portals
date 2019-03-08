using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Portal.Domain;
using Portal.Services;
using Portal.Business.Contracts;
using Portal.Business.TestServices;
using Portal.Business.ViewModels;
using Microsoft.Extensions.Caching.Memory;

namespace Portal.Areas.Client.Controllers
{
    [Area("Client")]
    public class MandateController : Controller
    {
        public string _webRootPath;
        public string _contentRootPath;
        public readonly IHostingEnvironment _hostingEnvironment;
        public JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

        public readonly ILogger<DashboardController> _logger;
        public readonly IConfiguration _configuration;

        private readonly IArmOneServiceConfigManager _configSettingManager;
        public TestArmClientServices _clientService;

        public ApplicationDbContext db;
        public ClientRepository _client;

        private readonly IMemoryCache _cache;

        public MandateController(IHostingEnvironment hostingEnvironment, IArmOneServiceConfigManager configManager,
                                    ILogger<DashboardController> logger, IConfiguration configuration,
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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Setup()
        {
            var model = new BuyViewModel();

            var _user = _cache.Get<AuthenticateResponse>("ArmUser");
            if (_user == null)
            {
                TempData["SessionTimeOut"] = $@"You have been logged out due to inactivity. 
                                                Please login to gain access.";
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            try
            {
                List<ProductSummary> getSummaries = new List<ProductSummary>();
                var accountsResponse = _client.GetAccountSummary(_user.MembershipKey);
                var balanceResponse = _client.GetTotalAccountBalance(_user.MembershipKey);

                if (accountsResponse != null && balanceResponse != null)
                {
                    foreach (var item in accountsResponse.Summaries)
                    {
                        var summaries = new ProductSummary();
                        summaries.ProductName = item.ProductName;
                        summaries.ProductCode = item.ProductCode;
                        summaries.Currency = item.Currency;
                        summaries.AccruedInterest = item.AccruedInterest;
                        summaries.CurrentBalance = item.CurrentBalance;

                        getSummaries.Add(summaries);
                    }

                    model.TotalBalance = balanceResponse.TotalBalance;
                    model.Summaries = getSummaries;
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = ViewBag.Message = ex.Message;
                Utilities.ProcessError(ex, _contentRootPath);
                _logger.LogError(null, ex, ex.Message);
            }

            return View(model);
        }
        
        public IActionResult Manage()
        {
            var model = new BuyViewModel();

            var _user = _cache.Get<AuthenticateResponse>("ArmUser");
            if (_user == null)
            {
                TempData["SessionTimeOut"] = $@"You have been logged out due to inactivity. 
                                                Please login to gain access.";
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            try
            {
                var debitquery = db.DDebit.Where(s => s.CustomerId == _user.MembershipKey.ToString()).AsQueryable();

                var listOfDebits = debitquery != null ? debitquery.ToList() : null;

                List<ProductSummary> getSummaries = new List<ProductSummary>();
                
                var accountsResponse = _client.GetAccountSummary(_user.MembershipKey);
                var balanceResponse = _client.GetTotalAccountBalance(_user.MembershipKey);

                if (accountsResponse != null && balanceResponse != null)
                {
                    foreach (var item in accountsResponse.Summaries)
                    {
                        var summaries = new ProductSummary();
                        summaries.ProductName = item.ProductName;
                        summaries.ProductCode = item.ProductCode;
                        summaries.Currency = item.Currency;
                        summaries.AccruedInterest = item.AccruedInterest;
                        summaries.CurrentBalance = item.CurrentBalance;

                        getSummaries.Add(summaries);
                    }

                    model.TotalBalance = balanceResponse.TotalBalance;
                    model.Summaries = getSummaries;
                    model.GetDirectDebit = listOfDebits;
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = ViewBag.Message = ex.Message;
                Utilities.ProcessError(ex, _contentRootPath);
                _logger.LogError(null, ex, ex.Message);
            }
            return View(model);
        }
    }
}