using System.IO;
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
using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            #region session to persist state over specific time

            services.AddDistributedMemoryCache();
            services.AddSession(s => s.IdleTimeout = TimeSpan.FromHours(2));

            //services.AddDistributedMemoryCache();
            ////services.AddSession(options =>
            ////{
            ////    // Set a short timeout for easy testing.
            ////    options.Cookie.Name = ".ClientPortal.Session";
            ////    options.IdleTimeout = TimeSpan.FromMinutes(30);
            ////    options.Cookie.HttpOnly = true;
            ////});

            ////services.AddAuthentication(options =>
            ////{
            ////    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            ////})
            ////.AddCookie(options =>
            ////{
            ////    options.LoginPath = new PathString("/Account/Login/");
            ////    options.LogoutPath = new PathString("/Account/Logoff");
            ////    options.AccessDeniedPath = new PathString("/Guest/Index");
            ////});

            ////services.AddMemoryCache(options =>
            ////{
            ////    options.ExpirationScanFrequency = TimeSpan.FromMinutes(5);
            ////});

            #endregion session to persist state over specific time

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

            services.AddTransient<IVourcherManager, VourcherManager>();
            services.AddTransient<IProductCategoryManager, ProductCategoryManager>();
            services.AddTransient<IProductManager, ProductManager>();
            services.AddTransient<IPersonManager, PersonManager>();
            services.AddTransient<IOrdersAndSalesManager, OrdersAndSalesManager>();
            services.AddTransient<ICartManager, CartManager>();
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

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddSingleton<IGeneratorsManager>(Configuration
            //    .GetSection("GeneratorsManager")
            //    .Get<GeneratorsManager>());

            services.AddTransient<IGeneratorsManager, GeneratorsManager>();

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
            }

            loggerFactory.AddFile("logs/armclientportal-{Date}.txt");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //  app.UseCookiePolicy();

            app.UseSession();
            app.UseAuthentication();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"Liber")),
                RequestPath = new PathString("/Liber")
            });

            // app.UseRequestLocalization();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                );
            });
        }
    }
}