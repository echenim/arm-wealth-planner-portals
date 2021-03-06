﻿using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Portal.Business.Contracts;
using Portal.Business.StoreManagers;
using Microsoft.Extensions.Logging;
using Portal.Business.Utilities;
using Portal.Domain;
using Portal.Domain.Models.Identity;

namespace Portal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});

            //services.Configure<RequestLocalizationOptions>(options =>
            //{
            //    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-NZ");
            //    options.SupportedCultures = new List<CultureInfo> { new CultureInfo("en-US"), new CultureInfo("en-NZ") };
            //    options.RequestCultureProviders.Clear();
            //});

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            #region register database connectionstring

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ArmInvestmentConnection")));

            //services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            //services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");

            //services.AddMvc(options =>
            //{
            //    options.Filters.AddService(typeof(AngularAntiforgeryCookieResultFilter));
            //});
            //services.AddTransient<AngularAntiforgeryCookieResultFilter>();

            #endregion register database connectionstring

            #region register identity user and role class

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            #endregion register identity user and role class

            #region service register

            services.AddTransient<IProductCategoryManager, ProductCategoryManager>();
            services.AddTransient<IProductManager, ProductManager>();
            services.AddTransient<IPersonManager, PersonManager>();
            services.AddTransient<IOrdersAndSalesManager, OrdersAndSalesManager>();
            services.AddTransient<IUserService, UserManagers>();
            services.AddTransient<IDashBoardManager, DashBoardManager>();
            services.AddTransient<IApplicationGroupManager, ApplicationGroupManager>();
            services.AddTransient<IArmOneManager, ArmOneManager>();

            services.AddTransient<UserUtils>();

            #endregion service register

            #region register configuration_settings & ArmOneAPI

            services.AddSingleton<IArmOneServiceConfigManager>(Configuration
                .GetSection("ErmOneServiceConfigManager")
                .Get<ArmOneServiceConfigManager>());

            services.AddTransient<IArmOneManager, ArmOneManager>();

            #endregion register configuration_settings & ArmOneAPI
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var build = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            loggerFactory.AddFile("logs/armclientportal-{Date}.txt");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"Liber")),
                RequestPath = new PathString("/Liber")
            });

            app.UseRequestLocalization();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                );

                routes.MapRoute(
                    name: "PaymentStatus",
                    template: "{area:exists}/PaymentStatus/{au?}",
                    defaults: new { controller = "Buy", action = "PaymentStatus" });

                //routes.MapRoute(
                //    name: "DebitStatus",
                //    template: "{area:exists}/{controller=Buy}/{action=DebitStatus}/{au?}",
                //    defaults: new { area = "Client", controller = "Buy", action = "DebitStatus" });

                routes.MapAreaRoute(
                    name: "DebitStatus",
                    areaName: "Client",
                    template: "Client/{controller=Buy}/{action=DebitStatus}/{au?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}