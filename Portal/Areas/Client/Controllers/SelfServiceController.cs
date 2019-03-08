using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
    public class SelfServiceController : Controller
    {
        public string _webRootPath;
        public string _contentRootPath;
        public readonly IHostingEnvironment _hostingEnvironment;
        public JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

        public readonly ILogger<SelfServiceController> _logger;
        public readonly IConfiguration _configuration;

        private readonly IArmOneServiceConfigManager _configSettingManager;
        public TestArmClientServices _clientService;

        public ApplicationDbContext db;
        public ClientRepository _client;

        private readonly IMemoryCache _cache;

        public SelfServiceController(IHostingEnvironment hostingEnvironment, IArmOneServiceConfigManager configManager,
                                    ILogger<SelfServiceController> logger, IConfiguration configuration,
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

        public IActionResult EmbassyLetter()
        {            
            var modelview = new EmbassyLetterViewModel();
            var _user = _cache.Get<AuthenticateResponse>("ArmUser");
            if (_user == null)
            {
                TempData["SessionTimeOut"] = $@"You have been logged out due to inactivity. 
                                                Please login to gain access.";
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            //return View("EmbassyLetter", modelview);
            return View(modelview);
        }

        [HttpPost]
        public IActionResult EmbassyLetter(EmbassyLetterViewModel model)
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
                    TempData["invalidForm"] = ViewBag.Message = "Error! Incorrect form details.";
                    return View(model);
                }

                var response = _client.SendEmbassyLetter(model, _user);

                if (response != null && response.TrackingID != null)
                {
                    TempData["message"] = true;
                    var msg = "Success: " + response.StatusMessage + "your tracking ID is: " + response.TrackingID;
                    model.SuccessMessage = msg;
                }
                else
                {
                    TempData["message"] = false;
                    model.ErrorMessage = response.StatusMessage;
                }

            }
            catch (Exception ex)
            {
                TempData["message"] = false;
                model.ErrorMessage = ex.Message;
                Utilities.ProcessError(ex, _contentRootPath);
                _logger.LogError(null, ex, ex.Message);
            }
            
            return View(model);
        }

        [HttpPost]
        public IActionResult TrackService(EmbassyLetterViewModel modelview)
        {         
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
                }

                //model.RequestStatuses = getStatus;
                var serializeStatus = JsonConvert.SerializeObject(getStatus);
                TempData["TrackService"] = serializeStatus;

                return RedirectToAction("EmbassyLetter", "SelfService");
            }
            catch (Exception ex)
            {
                Utilities.ProcessError(ex, _contentRootPath);
                _logger.LogError(null, ex, ex.Message);
            }
            return View();
        }

        public IActionResult AccountValidation(ClientUpdateViewModel model)
        {
            var _user = _cache.Get<AuthenticateResponse>("ArmUser");
            if (_user == null)
            {
                TempData["SessionTimeOut"] = $@"You have been logged out due to inactivity. 
                                                Please login to gain access.";
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View(model);
        }    

        [HttpPost]
        public async Task<IActionResult> AccountValidation(IFormFileCollection files, ClientUpdateViewModel viewmodel)
        {
            var model = new ClientUpdateTemp();
            var _user = _cache.Get<AuthenticateResponse>("ArmUser");
            if (_user == null)
            {
                TempData["SessionTimeOut"] = $@"You have been logged out due to inactivity. 
                                                Please login to gain access.";
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            try
            {
                if (files != null)
                {
                    int index = 0;
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                            byte[] fileBytes = null;
                            using (var fileStream = file.OpenReadStream())
                            using (var ms = new MemoryStream())
                            {
                                fileStream.CopyTo(ms);
                                fileBytes = ms.ToArray();
                            }

                            if (index == 0)
                            {
                                model.Passport = fileBytes;
                            }
                            else if (index == 1)
                            {
                                model.Signature = fileBytes;
                            }
                            else if (index == 2)
                            {
                                model.Thumbprint = fileBytes;
                            }
                            else if (index == 3)
                            {
                                model.ValidID = fileBytes;
                            }

                            index++;
                        }
                    }
                    model.MembershipNumber = _user.MembershipKey;
                    model.EvaluationStatus = "";
                    model.ProgressStatus = "Pending";
                    model.TaxNumber = viewmodel.TaxNumber;
                    model.Jurisdiction = viewmodel.Jurisdiction;
                    model.IsKYCApproved = false;
                    model.IsPassportApproved = false;
                    model.IsSignatureApproved = false;
                    model.IsThumbprintApproved = false;
                    model.IsValidIdApproved = false;
                    model.DateUpdated = DateTime.Now;

                    //check if client already has a record in the table 
                    var clientquery = db.ClientUpdateTemps.Where(s => s.MembershipNumber.Equals(_user.MembershipKey)).FirstOrDefault();

                    if (clientquery != null)
                    {
                        db.ClientUpdateTemps.Update(model);
                        await db.SaveChangesAsync();

                        var msg = "Success: your details have been updated!";
                        viewmodel.SuccessMessage = msg;
                        //TempData["message"] = ViewBag.Message = msg;
                        TempData["message"] = true;
                        //return RedirectToAction("ClientUpdate", "SelfService", viewmodel.SuccessMessage);
                        return AccountValidation(viewmodel);
                    }
                    else
                    {
                        db.ClientUpdateTemps.Add(model);
                        await db.SaveChangesAsync();

                        var msg = "Success: your details have been updated!";
                        viewmodel.SuccessMessage = msg;
                        TempData["message"] = true;
                        //return RedirectToAction("ClientUpdate", "SelfService", viewmodel);
                        return AccountValidation(viewmodel);
                    }
                }
            }
            catch (Exception ex)
            {
                viewmodel.ErrorMessage = ex.Message;
                TempData["message"] = false;
                Utilities.ProcessError(ex, _contentRootPath);
                _logger.LogError(null, ex, ex.Message);
            }

            return View();
        }

        public IActionResult AccountInformation()
        {
            var model = new AccountDetailViewModel();
            var _user = _cache.Get<AuthenticateResponse>("ArmUser");
            if (_user == null)
            {
                TempData["SessionTimeOut"] = $@"You have been logged out due to inactivity. 
                                                Please login to gain access.";
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            try
            {
                var customer = _client.GetUserProfile(_user.MembershipKey);
                if (customer != null && customer.MembershipNumber > 0)
                {
                    model.FullName = customer.FullName;
                    model.MembershipNumber = customer.MembershipNumber;
                    model.PhoneNumber = customer.PhoneNumber;
                    model.MobileNumber = customer.MobileNumber;
                    model.EmailAddress = customer.EmailAddress;
                    model.Address = customer.Address;
                    model.State = customer.State;
                    model.Country = customer.Country;
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