﻿using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Areas.Client.Filter
{
    public class AngularAntiforgeryCookieResultFilter : ResultFilterAttribute
    {
        private IAntiforgery antiforgery;
        public AngularAntiforgeryCookieResultFilter(IAntiforgery antiforgery)
        {
            this.antiforgery = antiforgery;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ViewResult)
            {
                var tokens = antiforgery.GetAndStoreTokens(context.HttpContext);
                context.HttpContext.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken, new CookieOptions() { HttpOnly = false });
            }
        }
    }
}
