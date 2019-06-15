using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using Portal.Domain.Models;
using Portal.Services;

namespace Portal.Areas.Client.Controllers
{
    [Area("Client")]
    public class RedemptionController : Controller
    {
        public string _webRootPath;
        public string _contentRootPath;
        public readonly IHostingEnvironment _hostingEnvironment;
        public JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

        public readonly ILogger<RedemptionController> _logger;
        public readonly IConfiguration _configuration;

        private readonly IArmOneServiceConfigManager _configSettingManager;
        public TestArmClientServices _clientService;

        public ApplicationDbContext db;
        public ClientRepository _client;

        private readonly IMemoryCache _cache;

        public RedemptionController(IHostingEnvironment hostingEnvironment, IArmOneServiceConfigManager configManager,
                                    ILogger<RedemptionController> logger, IConfiguration configuration,
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

        public IActionResult Initiate()
        {
            var model = new AccountStatementViewModel();
            var _user = _cache.Get<AuthenticateResponse>("ArmUser");
            if (_user == null)
            {
                TempData["SessionTimeOut"] = $@"You have been logged out due to inactivity. 
                                                Please login to gain access.";
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            try
            {
                List<ProductDetails> getSummaries = new List<ProductDetails>();
                var getClientSummary = _client.GetAccountSummary(_user.MembershipKey);

                if (getClientSummary!= null)
                {
                    foreach (var item in getClientSummary.Summaries)
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
                    model.TotalBalance = getClientSummary.TotalBalance;
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

        [HttpGet]
        public IActionResult AjaxSendOtp(string action = "Redemption")
        {
            var _user = _cache.Get<AuthenticateResponse>("ArmUser");
            if (_user == null)
            {
                TempData["SessionTimeOut"] = $@"You have been logged out due to inactivity. 
                                                Please login to gain access.";
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            //var _sessionID = "fb2e77d.47a0479900504cb3ab4a1f626d174d2d";
            var _sessionID = HttpContext.Session.Id;

            try
            {
                var OtpRequest = new SendOtpRequest
                {
                    CustomerReference = _user.MembershipKey.ToString(),
                    SessionId = _sessionID,
                    CustomerAction = action
                };
                var OtpResponse = _clientService.SendOtp(OtpRequest);

                return Json(OtpResponse);
            }
            catch (Exception ex)
            {
                TempData["message"] = ViewBag.Message = ex.Message;
                Utilities.ProcessError(ex, _contentRootPath);
                _logger.LogError(null, ex, ex.Message);
            }
            return View();
        }

        [HttpPost]
        public IActionResult PostRedemption([FromBody] AccountStatementViewModel model)
        {
            var _user = _cache.Get<AuthenticateResponse>("ArmUser");
            if (_user == null)
            {
                TempData["SessionTimeOut"] = $@"You have been logged out due to inactivity. 
                                                Please login to gain access.";
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            var _sessionID = HttpContext.Session.Id;

            try
            {
                var redeemedProducts = "RedeemedProducts::";
                var json = JsonConvert.SerializeObject(model.Product);
                var list = JsonConvert.DeserializeObject<List<RedemptionProduct>>(json);
                foreach (var item in list)
                {
                    redeemedProducts += "ProductCode:" + item.ProductCode + ";";
                    redeemedProducts += "Amount:" + item.Amount + ";";
                };

                Redemption redemption = new Redemption
                {
                    CustomerReference = _user.MembershipKey.ToString(),
                    RedeemedProducts = redeemedProducts,
                    Amount = model.TotalAmount,
                    Reason = model.Reason,
                    ReasonOther = model.ReasonOthers
                };

                db.Redemptions.Add(redemption);
                db.SaveChanges();
                
                var accountsResponse = _client.GetAccountSummary(_user.MembershipKey);

                VerifyOtpRequest OtpRequest = new VerifyOtpRequest { OtpCode = model.Otp, SessionId = _sessionID.ToString() };

                var reRequest = new RedemptionRequest
                {
                    MembershipNumber = _user.MembershipKey.ToString(),
                    Products = model.Product,
                    TotalAmount = model.TotalAmount,
                    VerifyOtp = OtpRequest,
                    Source = "Client Portal"
                };
                var reResponse = _clientService.Redemption(reRequest);

                if (reResponse != null)
                {
                    return Json(reResponse);
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.ExpectationFailed, "No response from the server.");
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