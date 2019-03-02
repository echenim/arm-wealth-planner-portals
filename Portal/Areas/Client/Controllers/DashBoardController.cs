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
        public TestArmClientServices _clientService;

        public ApplicationDbContext db;
        public ClientRepository _client;

        public DashboardController(IHostingEnvironment hostingEnvironment,
                                    ILogger<DashboardController> logger, IConfiguration configuration,
                                    IDistributedCache cache, ApplicationDbContext _db, IArmOneServiceConfigManager configManager)
        {
            _hostingEnvironment = hostingEnvironment;
            _webRootPath = _hostingEnvironment.WebRootPath;
            _contentRootPath = _hostingEnvironment.ContentRootPath;

            _logger = logger;
            _configuration = configuration;

            //_appSettings = appSettings.Value;
            _configSettingManager = configManager;

            //_clientService = new ArmClientServices(_appSettings, _contentRootPath, _configuration);
            _clientService = new TestArmClientServices(_configSettingManager, _contentRootPath);
            _client = new ClientRepository(_configSettingManager, _contentRootPath);

            db = _db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new AccountStatementViewModel();

            //_user is expected to contain client details. mock data for model.
            var _user = new AuthenticateResponse
            {
                MembershipKey = 1006979,//1007435,
                EmailAddress = "tolu.olusakin@gmail.com",//"gbadebo.ayan@gmail.com",
                FirstName = "Tolulope",
                LastName = "Olusakin",
                FullName = "Olusakin Tolulope S"//"Funmilayo Ruth Adeyemi",
            };

            try
            {
                var customer = _client.GetUserProfile(_user.MembershipKey);

                List<ProductDetails> getSummaries = new List<ProductDetails>();
                List<decimal> sumOfAccruedInterests = new List<decimal>();

                //get account summary
                var accountsRequest = new SummaryRequest
                {
                    MembershipNumber = _user.MembershipKey
                };
                //var accountsResponse = _clientService.GetAccountSummary(accountsRequest);
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
                    MembershipNumber = _user.MembershipKey
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
                //HttpContext.Session.Set("error", ex.Message);
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