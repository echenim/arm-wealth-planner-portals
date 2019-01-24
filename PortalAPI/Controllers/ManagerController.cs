using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PortalAPI.Domain.Models.Identity;
using PortalAPI.Midleware.Contracts;
using PortalAPI.Utilities;
using PortalAPI.ViewModels;

namespace PortalAPI.Controllers
{
    public class ManagerController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly AppSettings _appSettings;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IApplicationGroupManager _application;

        public ManagerController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager,
            IConfiguration configuration,
            IOptions<AppSettings> appSettings,
            IPasswordHasher<ApplicationUser> passwordHasher,
            IHostingEnvironment hostingEnvironment,
            IApplicationGroupManager application
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _appSettings = appSettings.Value;
            _passwordHasher = passwordHasher;
            _hostingEnvironment = hostingEnvironment;
            _application = application;
        }

        [HttpGet]
        [Route("roles")]
        public IActionResult FetchRole()
        {
            var roles = _roleManager.Roles;
            return Ok(roles);
        }

        [HttpPost]
        [Route("rolescreate")]
        public IActionResult FetchGroupRole([FromBody] ApplicationRole model)
        {
            if (model != null)
            {
                var roles = _roleManager.CreateAsync(model).Result;
                return Ok(roles);
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("groups")]
        public IActionResult FetchGroup()
        {
            var roles = _application.Groups();
            return Ok(roles);
        }

        [HttpPost]
        [Route("groupscreate")]
        public IActionResult AddGroup([FromBody] ApplicationGroup model)
        {
            if (model != null)
            {
                var roles = _application.CreateGroup(model);
                return Ok(roles);
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("assignroletogroup")]
        public IActionResult AddRoleGroup([FromBody] RoleGroupView model)
        {
            if (model != null)
            {
                var roles = _application.SetGroupRoles(model.GroupId, model.RoleId);
                return Ok(roles);
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("assignusertogroup")]
        public IActionResult AddUserGroup([FromBody] AssignUserToGroupView model)
        {
            if (model != null)
            {
                var roles = _application.SetUserGroups(model.UserId, model.groupname);
                return Ok(roles);
            }

            return BadRequest();
        }
    }
}