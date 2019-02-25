using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
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
    public class PortfolioController : Controller
    {
        public string _webRootPath;
        public string _contentRootPath;
        public readonly IHostingEnvironment _hostingEnvironment;
        public JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

        public readonly ILogger<PortfolioController> _logger;
        public readonly IConfiguration _configuration;

        private readonly IArmOneServiceConfigManager _configSettingManager;
        public TestArmClientServices _clientService;

        public ApplicationDbContext db;
        public ClientRepository _client;

        public PortfolioController(IHostingEnvironment hostingEnvironment, IArmOneServiceConfigManager configManager,
                                    ILogger<PortfolioController> logger, IConfiguration configuration,
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

        //public IActionResult AccountStatement()
        //{
        //    return View();
        //}

        public IActionResult AccountStatement(string code)
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
                List<ProductItems> getItems = new List<ProductItems>();
                var productcode = "";

                var customer = new CustomerDetail();
                customer = _client.GetUserProfile(_user.MembershipKey);

                if (string.IsNullOrEmpty(code))
                {
                    productcode = customer.ProductItems.Select(x => x.ProductCode).FirstOrDefault();
                }
                else
                {
                    productcode = code;
                }

                var accountsResponse = _client.GetAccountSummary(_user.MembershipKey);
                var productDetail = _client.GetProductInAccount(productcode, accountsResponse);

                if (productDetail != null)
                {
                    model.ProductDetails.ProductCode = productDetail.ProductCode;
                    model.ProductDetails.ProductName = productDetail.ProductName;
                    model.ProductDetails.Currency = productDetail.Currency;
                    model.ProductDetails.AccruedInterest = productDetail.AccruedInterest;
                    model.ProductDetails.CurrentBalance = productDetail.CurrentBalance;
                }

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
            }
            catch (Exception ex)
            {
                TempData["message"] = ViewBag.Message = ex.Message;
                Utilities.ProcessError(ex, _contentRootPath);
                _logger.LogError(null, ex, ex.Message);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult AccountStatement()
        {
            return View();
        }
    }
}