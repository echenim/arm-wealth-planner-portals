using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortalAPI.Utilities;
using PortalAPI.Domain.Models.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

using PortalAPI.Domain.Models.Identity;
using PortalAPI.Utilities;

namespace PortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionManagerController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly AppSettings _appSettings;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        private readonly IHostingEnvironment _hostingEnvironment;

        public PermissionManagerController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager,
            IConfiguration configuration,
            IOptions<AppSettings> appSettings,
            IPasswordHasher<ApplicationUser> passwordHasher,
            IHostingEnvironment hostingEnvironment
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _appSettings = appSettings.Value;
            _passwordHasher = passwordHasher;
            _hostingEnvironment = hostingEnvironment;
        }
    }
}