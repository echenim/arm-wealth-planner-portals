using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Events;

namespace Portal.Web.Extensions
{
    public static class GlobalExceptionHandlerExtension
    {
        public static IApplicationBuilder UseWebApiExceptionHandler(this IApplicationBuilder app)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd");
            var _logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("SerilogDemo", LogEventLevel.Error)
                .WriteTo.File($"ErrorLog/log_{timestamp}.txt")
                .CreateLogger();
            return app.UseExceptionHandler(HandleApiException(_logger));
        }

        public static Action<IApplicationBuilder> HandleApiException(Serilog.ILogger logger)
        {
            return appBuilder =>
            {
                appBuilder.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (exceptionHandlerFeature != null)
                    {
                        logger.Error(exceptionHandlerFeature.Error, exceptionHandlerFeature.Error.Message + '\n');
                    }

                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
                });
            };
        }
    }
}