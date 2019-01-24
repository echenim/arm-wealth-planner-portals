using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PortalAPI.Domain;
using PortalAPI.Domain.Models.Identity;
using PortalAPI.Extensions;
using PortalAPI.Magration;
using PortalAPI.Midleware.Contracts;
using PortalAPI.Midleware.Implementations;
using PortalAPI.Utilities;
using Swashbuckle.AspNetCore.Swagger;

namespace PortalAPI
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
            #region register CORS implementation

            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().Build();
                });
            });

            #endregion register CORS implementation

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddAuthorization();

            #region register database connectionstring

            //services.AddDbContext<MigDbContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("ArmInvestmentConnection")));

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ArmInvestmentConnection")));

            #endregion register database connectionstring

            #region register identity user and role class

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            #endregion register identity user and role class

            #region service register

            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IProductCategoryService, ProductCategoryService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductFeatureService, ProductFeatureService>();
            services.AddTransient<IProductKeyBenefitService, ProductKeyBenefitService>();
            services.AddTransient<IProductPerformanceService, ProductPerformanceService>();
            services.AddTransient<IApplicationGroupManager, ApplicationGroupManager>();

            #endregion service register

            #region authentication  for token

            var appSettingsSection = Configuration.GetSection("API_SECRET_KEY");
            var key = Encoding.ASCII.GetBytes(appSettingsSection.Value);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = "https://arminvestmentcenter.com/token",
                        ValidIssuer = "https://arminvestmentcenter.com/token",
                        RequireExpirationTime = true
                    };
                });

            #endregion authentication  for token

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "ARM INVESTMENT MANANGER API", Version = "v1" });
            });
            services.ConfigureSwaggerGen(options =>
            {
                options.OperationFilter<SwaggerAuthorizationHeaderParameterOperationFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("EnableCORS");
            app.UseStaticFiles();

            #region add identity authentication

            // app.UseIdentity();
            app.UseAuthentication();

            #endregion add identity authentication

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebApiExceptionHandler();

            app.UseHttpsRedirection();
            app.UseWebApiExceptionHandler();
            app.UseMvc();
            app.UseSwagger(
                d => app.UseSwaggerUI(
                    c =>
                    {
                        //  c.RoutePrefix = "swagger";
                        c.SwaggerEndpoint("../swagger/v1/swagger.json", "ARM INVESTMENT MANANGER API Docs");
                        // c.ShowExtensions();
                    }
                )
            );
        }
    }
}