using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Areas.Client.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Portal.Areas.Client.Extensions;
using Portal.Domain;
using Portal.Services;
using Portal.Business.Contracts;
using Portal.Business.TestServices;
using Portal.Business.ViewModels;

namespace Portal.Areas.Client.Controllers
{
    [Area("Client")]
    public class BuyController : Controller
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

        public BuyController(IHostingEnvironment hostingEnvironment, IArmOneServiceConfigManager configManager,
                                    ILogger<DashboardController> logger, IConfiguration configuration,
                                    IDistributedCache cache, ApplicationDbContext _db)
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
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddInvestment()
        {
            var model = new AccountStatementViewModel();
            var _user = new AuthenticateResponse
            {
                MembershipKey = 1007435,
                EmailAddress = "gbadebo.ayan@gmail.com",
                FirstName = "Funmilayo",
                LastName = "Adeyemi",
                FullName = "Funmilayo Ruth Adeyemi",
            };

            try
            {
                List<ProductDetails> getSummaries = new List<ProductDetails>();
                var accountsRequest = new SummaryRequest
                {
                    MembershipNumber = _user.MembershipKey
                };
                var accountsResponse = _clientService.GetAccountSummary(accountsRequest);

                if (accountsResponse != null)
                {
                    foreach (var item in accountsResponse.Summaries)
                    {
                        var summaries = new ProductDetails();
                        summaries.ProductName = item.ProductName;
                        summaries.ProductCode = item.ProductCode;
                        summaries.Currency = item.Currency;
                        summaries.AccruedInterest = item.AccruedInterest;
                        summaries.CurrentBalance = item.CurrentBalance;

                        getSummaries.Add(summaries);
                    }

                    model.Summaries = getSummaries;
                }

                var totalBalanceRequest = new TotalBalanceRequest
                {
                    MembershipNumber = _user.MembershipKey
                };
                var totalBalanceResponse = _clientService.GetTotalBalance(totalBalanceRequest);

                if (totalBalanceResponse != null)
                {
                    model.TotalBalance = totalBalanceResponse.TotalBalance;
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

        public IActionResult NewInvestment()
        {
            var model = new AccountStatementViewModel();
            var _user = new AuthenticateResponse
            {
                MembershipKey = 1007435,
                EmailAddress = "gbadebo.ayan@gmail.com",
                FirstName = "Funmilayo",
                LastName = "Adeyemi",
                FullName = "Funmilayo Ruth Adeyemi",
            };

            try
            {
                List<ProductDetails> getSummaries = new List<ProductDetails>();
                var accountsRequest = new SummaryRequest
                {
                    MembershipNumber = _user.MembershipKey
                };
                var accountsResponse = _clientService.GetAccountSummary(accountsRequest);

                if (accountsResponse != null)
                {
                    foreach (var item in accountsResponse.Summaries)
                    {
                        var summaries = new ProductDetails();
                        summaries.ProductName = item.ProductName;
                        summaries.ProductCode = item.ProductCode;
                        summaries.Currency = item.Currency;
                        summaries.AccruedInterest = item.AccruedInterest;
                        summaries.CurrentBalance = item.CurrentBalance;

                        getSummaries.Add(summaries);
                    }

                    model.Summaries = getSummaries;
                    model.TotalBalance = accountsResponse.TotalBalance;

                    var funds = new Dictionary<string, string>()
                    {
                        { "AGF", "ARM Aggressive Growth Fund" },
                        { "ARMDF", "ARM Discovery Fund" },
                        { "ARMEF", "ARM Ethical Fund" },
                        { "ARMMMF", "ARM Money Market Fund" }
                    };

                    var myfunds = new Dictionary<string, string>();

                    foreach (var prod in accountsResponse.Summaries)
                    {
                        myfunds.Add(prod.ProductCode, prod.ProductName);
                    }

                    var diff = funds.Except(myfunds).Concat(myfunds.Except(funds));
                    Dictionary<string, string> result = diff.ToDictionary(x => x.Key, x => x.Value);
                    model.Products = result;
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = ViewBag.Message = ex.Message;
                Utilities.ProcessError(ex, _contentRootPath);
                _logger.LogError(null, ex, ex.Message);
            }
            return View();
        }
    }
}