using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace Portal.Web
{
    public class Program
    {
        private static string _environmentName;

        public static void Main(string[] args)
        {
            CreateSeriaLogger();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging(
                    (hostingContext, config)
                        =>
                    {
                        config.ClearProviders();
                        _environmentName = hostingContext.HostingEnvironment
                            .EnvironmentName;
                    })
                .UseStartup<Startup>();

        public static void CreateSeriaLogger()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{_environmentName}.json", optional: true, reloadOnChange: true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            string connectionString = configuration.GetValue<string>("ConnectionStrings:SerilogConnectionString");
            //var connectionString = "Data Source = (local); Initial Catalog = HHMDb; User ID = sa; Password = Qw3rty";
            var tableName = "Logs";
            var columnOption = new ColumnOptions();
            columnOption.Store.Remove(StandardColumn.MessageTemplate);
            columnOption.AdditionalDataColumns = new Collection<DataColumn>
            {
                new DataColumn {DataType = typeof (string), ColumnName = "Controller"},
                new DataColumn {DataType = typeof (string), ColumnName = "Action"},
                new DataColumn {DataType = typeof (string), ColumnName = "CRUD_Action"},
                new DataColumn {DataType = typeof (string), ColumnName = "UserID"},
                new DataColumn {DataType = typeof (string), ColumnName = "BeforeData"},
                new DataColumn {DataType = typeof (string), ColumnName = "AfterData"}
            };
            //Log.Logger = new LoggerConfiguration()
            //    .MinimumLevel.Information()
            //    .MinimumLevel.Override("SerilogDemo", LogEventLevel.Information)
            //    .WriteTo.MSSqlServer(connectionString, tableName, columnOptions: columnOption)
            //    .CreateLogger();
        }
    }
}