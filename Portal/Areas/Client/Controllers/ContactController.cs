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

        public ContactController(IHostingEnvironment hostingEnvironment, IArmOneServiceConfigManager configManager,
                                    ILogger<ContactController> logger, IConfiguration configuration,
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

        public IActionResult Location()
        {
            var _user = new AuthenticateResponse
            {
                MembershipKey = 1007435,
                EmailAddress = "gbadebo.ayan@gmail.com",
                FirstName = "Funmilayo",
                LastName = "Adeyemi",
                FullName = "Funmilayo Ruth Adeyemi",
            };

            if (_user == null)
            {
                TempData["SessionTimeOut"] = "You have been logged out due to inactivity. Please login to gain access.";
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        public IActionResult FindInvestmentCenter()
        {
            var _user = new AuthenticateResponse
            {
                MembershipKey = 1007435,
                EmailAddress = "gbadebo.ayan@gmail.com",
                FirstName = "Funmilayo",
                LastName = "Adeyemi",
                FullName = "Funmilayo Ruth Adeyemi",
            };

            if (_user == null)
            {
                TempData["SessionTimeOut"] = "You have been logged out due to inactivity. Please login to gain access.";
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        public IActionResult Feedback()
        {
            var _user = new AuthenticateResponse
            {
                MembershipKey = 1007435,
                EmailAddress = "gbadebo.ayan@gmail.com",
                FirstName = "Funmilayo",
                LastName = "Adeyemi",
                FullName = "Funmilayo Ruth Adeyemi",
            };

            if (_user == null)
            {
                TempData["SessionTimeOut"] = "You have been logged out due to inactivity. Please login to gain access.";
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Feedback(FeedbackViewModel model)
        {
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
                    var msg = "Success: " + fbResponse.StatusMessage + "Your previous message was sent successfully. Please take note of your Tracking Number:" + fbResponse.TrackingID;
                    TempData["message"] = ViewBag.Message = msg;
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
    }
}