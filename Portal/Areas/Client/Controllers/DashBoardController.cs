using System;
using System.Collections.Generic;
using System.Linq;

//using Portal.Areas.Client.ViewModels;
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
using Portal.Domain.ViewModels;

namespace Portal.Areas.Client.Controllers
{
    [Area("Client")]
    [AutoValidateAntiforgeryToken]
    public class DashboardController : Controller
    {
        public string _webRootPath;
        public string _contentRootPath;
        public readonly IHostingEnvironment _hostingEnvironment;

        //public readonly AppSettings _appSettings;
        public JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

        //public ArmClientServices _clientService;
        public readonly ILogger<DashboardController> _logger;

        public readonly IConfiguration _configuration;

        //test
        private readonly IArmOneServiceConfigManager _configSettingManager;

        private readonly IPersonManager _personManager;

        public TestArmClientServices _clientService;

        public ApplicationDbContext db;
        public ClientRepository _client;

        private readonly IMemoryCache _cache;

        public DashboardController(IHostingEnvironment hostingEnvironment,
                                    ILogger<DashboardController> logger, IConfiguration configuration,
                                    IMemoryCache cache, ApplicationDbContext _db, IArmOneServiceConfigManager configManager,
                                    IPersonManager personmanager)
        {
            _hostingEnvironment = hostingEnvironment;
            _webRootPath = _hostingEnvironment.WebRootPath;
            _contentRootPath = _hostingEnvironment.ContentRootPath;

            _logger = logger;
            _configuration = configuration;

            _configSettingManager = configManager;
            _personManager = personmanager;

            _clientService = new TestArmClientServices(_configSettingManager, _contentRootPath);
            _client = new ClientRepository(_configSettingManager, _contentRootPath);

            db = _db;
            _cache = cache;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new AccountStatementViewModel();
            var person = _personManager.Get(s => s.Email.Equals(User.Identity.Name)).FirstOrDefault();

            var _user = _cache.Get<AuthenticateResponse>("ArmUser");

            if (_user == null && person == null)
            {
                TempData["SessionTimeOut"] = $@"You have been logged out due to inactivity.
                                                Please login to gain access.";
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else if (_user == null && person != null)
            {
                var client = new AuthenticateResponse();

                client.EmailAddress = person.Email;
                client.FirstName = person.FirstName;
                client.LastName = person.LastName;
                client.MembershipKey = person.MemberShipNo;
                client.FullName = person.FullName;

                _user = client;

                _cache.Set<AuthenticateResponse>("ArmUser", _user, new MemoryCacheEntryOptions()
                                                                .SetSlidingExpiration(TimeSpan.FromMinutes(20))
                                                                .SetAbsoluteExpiration(TimeSpan.FromHours(1)));
            }

            try
            {
                var customer = _client.GetUserProfile(_user.MembershipKey); 

                List<ProductDetails> getSummaries = new List<ProductDetails>();
                List<decimal> sumOfAccruedInterests = new List<decimal>();

                //get account summary
                var accountsResponse = _client.GetAccountSummary(_user.MembershipKey);

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
                        summaries.PendingTransaction = item.PendingTransaction;

                        getSummaries.Add(summaries);
                        sumOfAccruedInterests.Add(summaries.AccruedInterest);
                    }

                    model.Summaries = getSummaries;
                }

                //get last transactions
                var transactions = _client.LoadLastTransactions(_user, accountsResponse, 6);

                List<ProductTransactions> getTransactions = new List<ProductTransactions>();
                if (transactions != null && transactions.Count > 0)
                {
                    foreach (var item in transactions)
                    {
                        var product = new ProductTransactions();
                        product.MarketValue = item.MarketValue;
                        product.Description = item.Description;
                        product.TransactionDate = item.TransactionDate;
                        product.TransactionType = item.TransactionType;
                        product.Amount = item.Amount;
                        product.UnitPrice = item.UnitPrice;
                        product.FundCode = item.FundCode;
                        product.Units = item.Units;

                        getTransactions.Add(product);
                    }

                    model.Transactions = getTransactions;
                }

                //get total balance
                var totalBalanceRequest = new TotalBalanceRequest
                {
                    MembershipNumber = Convert.ToInt32(_user.MembershipKey)
                };
                var totalBalanceResponse = _clientService.GetTotalBalance(totalBalanceRequest);

                if (totalBalanceResponse != null)
                {
                    model.TotalBalance = totalBalanceResponse.TotalBalance;
                }

                List<ProductItems> getItems = new List<ProductItems>();
                if (customer.ProductItems != null)
                {
                    foreach (var productitems in customer.ProductItems)
                    {
                        var product = new ProductItems();
                        product.ProductName = productitems.ProductName;
                        product.ProductCode = productitems.ProductCode;

                        getItems.Add(product);
                    }
                    model.SelectProductName = getItems;
                }

                var accruedInterests = sumOfAccruedInterests.Sum();
                ViewBag.SumAccruedInterest = accruedInterests;
            }
            catch (Exception ex)
            {
                //_cache.Set("error", ex.Message);
                TempData["message"] = ViewBag.Message = ex.Message;
                Utilities.ProcessError(ex, _contentRootPath);
                _logger.LogError(null, ex, ex.Message);
            }
            return View(model);
        }

        public IActionResult FundPriceHistory(string fundCode)
        {
            try
            {
                //var fHistoryResponse = _client.GetFundPriceHistory(fundCode);
                var fHistoryResponse = _client.GetFundPrices(fundCode);
                return Json(fHistoryResponse);
            }
            catch (Exception ex)
            {
                TempData["message"] = ViewBag.Message = ex.Message;
                Utilities.ProcessError(ex, _contentRootPath);
                _logger.LogError(null, ex, ex.Message);
            }
            return View();
        }

        public IActionResult FundYieldHistory(string fundCode = "ARMMMF")
        {
            try
            {
                var yieldResponse = _client.GetYieldHistory(fundCode);
                return Json(yieldResponse);
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