//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Portal.Areas.Client.Extensions;
//using ARMClientPortal.Models;
//using ARMClientPortal.ViewModels;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.AspNetCore.Routing;
//using Microsoft.Extensions.Options;

//namespace Portal.Areas.Client.Filter
//{
//    public class AuthenticationFilter : IActionFilter
//    {
//        protected AppSettings _appSettings { get; set; }

//        public AuthenticationFilter(IOptions<AppSettings> appSettings, IHostingEnvironment hostingEnvironment)
//        {
//            _appSettings = appSettings.Value;
//        }

//        public void OnActionExecuted(ActionExecutedContext context)
//        {
//            var customer = context.HttpContext.Session.Get<AuthenticateResponse>("ArmUser");

//            //check if new session id was generated
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
//        { }
//    }
//}