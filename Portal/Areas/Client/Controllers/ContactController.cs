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
    public class ContactController : Controller
    {
        public string _webRootPath;
        public string _contentRootPath;
        public readonly IHostingEnvironment _hostingEnvironment;
        public JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

        public readonly ILogger<ContactController> _logger;
        public readonly IConfiguration _configuration;

        private readonly IArmOneServiceConfigManager _configSettingManager;
        public TestArmClientServices _clientService;

        public ApplicationDbContext db;
        public ClientRepository _client;

        private readonly IMemoryCache _cache;

        public ContactController(IHostingEnvironment hostingEnvironment, IArmOneServiceConfigManager configManager,
                                    ILogger<ContactController> logger, IConfiguration configuration,
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

        public IActionResult Location()
        {
            var model = new FeedbackViewModel();
            var _user = _cache.Get<AuthenticateResponse>("ArmUser");
            if (_user == null)
            {
                TempData["SessionTimeOut"] = $@"You have been logged out due to inactivity. 
                                                Please login to gain access.";
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View(model);
        }

        public IActionResult FindInvestmentCenter()
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

        public IActionResult Feedback()
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

        [HttpPost]
        public IActionResult Feedback(FeedbackViewModel model)
        {
            var _user = _cache.Get<AuthenticateResponse>("ArmUser");
            if (_user == null)
            {
                TempData["SessionTimeOut"] = $@"You have been logged out due to inactivity. 
                                                Please login to gain access.";
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["message"] = ViewBag.Message = "Error! Incorrect form details.";
                    return View(model);
                }

                var fbRequest = new FeedbackRequest
                {
                    MembershipNumber = _user.MembershipKey,
                    FirstName = _user.FirstName,
                    LastName = _user.LastName,
                    EmailAddress = _user.EmailAddress,
                    MobileNumber = model.MobileNumber,
                    MessageCategory = model.MessageCategory,
                    Message = model.Message
                };

                var fbResponse = _clientService.SendFeedback(fbRequest);
                if (fbResponse != null && fbResponse.TrackingID != null)
                {
                    var msg = "Success: " + fbResponse.StatusMessage + ":" + fbResponse.TrackingID;
                    TempData["message"] =  msg;
                    return RedirectToAction("Location", "Contact");
                }
                else
                {
                    TempData["message"] = ViewBag.Message = fbResponse.StatusMessage;
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
        public IActionResult TrackService(FeedbackViewModel modelview)
        {
            var trackServiceStatus = new FeedbackViewModel();
            var model = new TrackServiceViewModel();

            var _user = _cache.Get<AuthenticateResponse>("ArmUser");
            if (_user == null)
            {
                TempData["SessionTimeOut"] = $@"You have been logged out due to inactivity. 
                                                Please login to gain access.";
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            try
            {
                model.RequestType = modelview.SelfService.RequestType;
                model.TrackingNumber = modelview.SelfService.TrackingNumber;

                var trRequest = new TrackServiceRequest
                {
                    MembershipNumber = _user.MembershipKey,
                    RequestType = model.RequestType,
                    TrackingNumber = model.TrackingNumber
                };

                List<RequestStatuses> getStatus = new List<RequestStatuses>();
                var trResponse = _clientService.TrackService(trRequest);

                if (trResponse.RequestStatuses != null && trResponse.RequestStatuses.Count > 0)
                {
                    foreach (var req in trResponse.RequestStatuses)
                    {
                        var status = new RequestStatuses();
                        status.MembershipNumber = req.MembershipNumber;
                        status.Remark = req.Remark;
                        status.CurrentStatus = req.CurrentStatus;
                        status.RequestDescription = req.RequestDescription;
                        status.TrackingNumber = req.TrackingNumber;

                        getStatus.Add(status);
                    }

                    model.RequestStatuses = getStatus;
                    
                    trackServiceStatus.SelfService.RequestStatuses = model.RequestStatuses;                    
                }

                var serializeStatus = JsonConvert.SerializeObject(getStatus);
                TempData["TrackService"] = serializeStatus;
                return RedirectToAction("Location", "Contact");
            }
            catch (Exception ex)
            {
                Utilities.ProcessError(ex, _contentRootPath);
                _logger.LogError(null, ex, ex.Message);
            }
            return View();
        }
    }
}