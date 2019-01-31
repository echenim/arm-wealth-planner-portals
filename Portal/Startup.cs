using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portal.Areas.Client.Filter;
using Portal.Business.Contracts;
using Portal.Business.Implementations;
using Portal.Business.StoreManagers;
using Microsoft.Extensions.Logging;
using Portal.Domain;
using Portal.Domain.Models.Identity;
using System.Collections.Generic;
using System.Globalization;
using Portal.Areas.Client.Models;

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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-NZ");
                options.SupportedCultures = new List<CultureInfo> { new CultureInfo("en-US"), new CultureInfo("en-NZ") };
                options.RequestCultureProviders.Clear();
            });
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("ArmInvestmentConnection")));
            //services.AddDefaultIdentity<IdentityUser>()
            //    .AddDefaultUI(UIFramework.Bootstrap4)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            #region register database connectionstring

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ArmInvestmentConnection")));

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");

            services.AddMvc(options =>
            {
                options.Filters.AddService(typeof(AngularAntiforgeryCookieResultFilter));
            });
            services.AddTransient<AngularAntiforgeryCookieResultFilter>();


            #endregion register database connectionstring

            #region register identity user and role class

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            #endregion register identity user and role class

            #region service register

            services.AddTransient<IProductCategoryService, ProductCategoryService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductFeatureService, ProductFeatureService>();
            services.AddTransient<IProductKeyBenefitService, ProductKeyBenefitService>();
            services.AddTransient<IProductPerformanceService, ProductPerformanceService>();
            services.AddTransient<IOrdersAndSalesService, OrdersAndSalesService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDashBoardManager, DashBoardManager>();
            services.AddTransient<IApplicationGroupManager, ApplicationGroupManager>();

            #endregion service register
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
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

                routes.MapRoute(
                    name: "DebitStatus",
                    template: "{area:exists}/DebitStatus/{au?}",
                    defaults: new { controller = "Buy", action = "DebitStatus" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");                
            });
        }
    }
}