using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using PortalAPI.Utilities;
using PortalAPI.ViewModels;
using PortalAPI.Domain.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace PortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagerController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IHostingEnvironment _hostingEnvironment;

        public UserManagerController(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IConfiguration configuration,
            IOptions<AppSettings> appSettings,
            IPasswordHasher<ApplicationUser> passwordHasher,
            IHostingEnvironment hostingEnvironment
        )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        [Route("read")]
        // [Authorize(Roles = "admin:can:view")]
        public IActionResult Read()
        {
            var list = _userManager.Users.OrderBy(s => s.Email);
            var _list = list.Select(item => new UserView
            {
                Id = item.Id,
                Name = item.FullName,
                Email = item.Email,
                KindOfUser = item.IsCustomerOrStaff
            })
                .ToList();
            return Ok(_list);
        }
    }
}