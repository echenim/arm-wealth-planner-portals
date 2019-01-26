using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.AspNetCore.Antiforgery;

namespace Portal.Areas.Client.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetAntiforgeryToken(this HttpContext httpContext)
        {
            var antiforgery = (IAntiforgery)httpContext.RequestServices.GetService(typeof(IAntiforgery));
            var tokenSet = antiforgery.GetAndStoreTokens(httpContext);
            string fieldName = tokenSet.FormFieldName;
            string requestToken = tokenSet.RequestToken;
            return requestToken;
        }
    }
}