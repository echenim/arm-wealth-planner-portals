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
    public class CustomersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public CustomersController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            ViewData["ControllerName"] = "Admin/Customers";

            var data = _userManager.Users.Where(s => s.IsCustomerOrStaff.Equals("external"))
                .OrderBy(s => s.FirstName).ThenBy(s => s.MembershipNumber);

            var list = data.Select(item => new ExternalUserView
            {
                Id = item.Id,
                Name = item.FullName,
                Email = item.Email,
                MembershipNumber = item.MembershipNumber,
                Status = "Pending",
                AltUserName = item.UserNameAlternative
            })
                .ToList();

            return View(list);
        }

        public IActionResult Test()
        {
            ViewData["ControllerName"] = "Admin/Customers";
            return View();
        }
    }
}