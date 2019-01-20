using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portal.Web.ViewModels;
using PortalAPI.Domain.Models.Identity;

namespace Portal.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            ViewData["ControllerName"] = "Admin/User";

            var data = _userManager.Users.Where(s => s.IsCustomerOrStaff.Equals("internal"))
                .OrderBy(s => s.FirstName).ThenBy(s => s.MembershipNumber);

            var list = data.Select(item => new InternalUserView
            {
                Id = item.Id,
                Name = item.FullName,
                Email = item.Email,
            })
                .ToList();

            return View(list);
        }
    }
}