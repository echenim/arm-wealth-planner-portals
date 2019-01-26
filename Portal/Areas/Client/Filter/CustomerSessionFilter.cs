//using ARMClientPortal.Extensions;
//using ARMClientPortal.Models;
//using Portal.Areas.Client.Services;
//using ARMClientPortal.ViewModels;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.AspNetCore.Routing;
//using Microsoft.Extensions.Options;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.Extensions.Caching.Distributed;
//using Microsoft.Extensions.Configuration;
//using System.Net;

//namespace Portal.Areas.Client.Filter
//{
//    public class CustomerSessionFilter : IActionFilter
//    {
//        protected AppSettings _appSettings { get; set; }
//        private string _contentRootPath;
//        private readonly IDistributedCache _cache;
//        private readonly DistributedCacheEntryOptions _cacheEntryOptions;
//        public readonly IHostingEnvironment _hostingEnvironment;
//        public ArmClientService _clientService;
//        public readonly IConfiguration _configuration;

//        public CustomerSessionFilter(IOptions<AppSettings> appSettings, IHostingEnvironment hostingEnvironment, IDistributedCache cache, IConfiguration configuration)
//        {
//            _appSettings = appSettings.Value;
//            _cache = cache;

//            _cacheEntryOptions = new DistributedCacheEntryOptions()
//               .SetSlidingExpiration(TimeSpan.FromMinutes(30))
//               .SetAbsoluteExpiration(TimeSpan.FromMinutes(30));

//            _contentRootPath = _hostingEnvironment.ContentRootPath;

//            _clientService = new ArmClientService(_appSettings, _contentRootPath, _configuration);
//        }

//        public void OnActionExecuted(ActionExecutedContext context)
//        {
//            var customer = context.HttpContext.Session.Get<AuthenticateResponse>("ArmUser");

//            // check if a new session id was generated
//            var user = context.HttpContext.User;

//            if (!customer.IsTcAgreed)
//            {
//                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Account" }, { "action", "TcAgreed" } });
//            }
//            else if (customer.IsSysGenerated)
//            {
//                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Account" }, { "action", "ChangePassword" } });
//            }
//            else if (String.IsNullOrEmpty(customer.SecurityQuestion))
//            {
//                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Account" }, { "action", "AddQuestion" } });
//            }
//            else
//            {
//                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Dashboard" }, { "action", "Index" } });
//            }
//        }

//        public void OnActionExecuting(ActionExecutingContext context)
//        {
//            var tokenExists = context.HttpContext.Request.QueryString.HasValue;
//            var stringedTokenVal = _cache.Get<string>("Token");
//            if (tokenExists)
//            {
//                var tokenstring = context.HttpContext.Request.QueryString.Value;
//                int firstIndex = "?Token=".LastIndexOf('=') + 1;
//                int lastIndex = tokenstring.IndexOf("&") - firstIndex;
//                var splitToken = tokenstring.Substring(firstIndex, lastIndex);
//                stringedTokenVal = splitToken;
//                _cache.Set("Token", stringedTokenVal, _cacheEntryOptions);
//            }

//            var armCust = _cache.Get<ArmOneValidateCookieResponse>("armOneUser");
//            var customer = context.HttpContext.Session.Get<AuthenticateResponse>("ArmUser");
//            var session = context.HttpContext.Session;
//            var sessionToken = context.HttpContext.Session.Get<string>("SessionToken");
//            var customer2 = _cache.Get<ArmOneAuthResponse>("ArmOne" + sessionToken);
//            bool isOnArmOne = _cache.Get<bool>("isOnArmOne");

//            if (!string.IsNullOrEmpty(stringedTokenVal))
//            {
//                var tokenres = _cache.Get<ArmOneAuthTokenResponse>("authreq");

//                var authValidateSessionResponse = new ArmOneValidateSessionResponse();
//                var authValidateSessionRequest = new ArmOneValidateSessionRequest
//                {
//                    Channel = "Client_Portal"
//                };
//                authValidateSessionResponse = _clientService.ArmOneValidateSession(authValidateSessionRequest, stringedTokenVal, tokenres.CustomerReference);

//                var statuscode = Enum.Parse(typeof(HttpStatusCode), authValidateSessionResponse.StatusCode.ToString());
//                var validateSession = (statuscode.Equals(HttpStatusCode.OK)) ? true : false;

//                if (!validateSession || tokenres == null)
//                {
//                    var decrypt = new SecureCredentials();
//                    var tokenreq = new ArmOneAuthTokenRequest
//                    {
//                        Username = decrypt.DecryptCredentials(_appSettings.ArmOneTokenUsername),
//                        Password = decrypt.DecryptCredentials(_appSettings.ArmOneTokenPassword),
//                        EmailAddress = decrypt.DecryptCredentials(_appSettings.ArmOneTokenEmail)
//                    };

//                    tokenres = _clientService.ArmOneAuthToken(tokenreq);
//                    _cache.Set("authreq", tokenres, _cacheEntryOptions);

//                    if (tokenres.ResponseCode == "00")
//                    {
//                        var validateCookieRes = new ArmOneValidateCookieResponse();
//                        var validateCookieReq = new ArmOneValidateCookieRequest
//                        {
//                            Channel = "Client_Portal"
//                        };
//                        validateCookieRes = _clientService.ArmOneValidateCookie(validateCookieReq, stringedTokenVal, tokenres.CustomerReference);

//                        if (validateCookieRes.ResponseCode == "00")
//                        {
//                            _cache.Set("armOneUser", validateCookieRes, _cacheEntryOptions);
//                        }
//                    }
//                }
//            }
//            else
//            {
//                // check if a new session id was generated
//                var user = context.HttpContext.User;

//                if (customer == null && customer2 == null)
//                {
//                    context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//                    context.HttpContext.Session.Clear();
//                    context.HttpContext.Response.Cookies.Delete(".ClientPortal.Session");
//                    context.HttpContext.Response.Cookies.Delete(".AspNetCore.ClientPortalMiddlewareInstance");
//                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Account" },
//                    { "action", "Login" } });
//                }
//            }
//        }
//    }
//}