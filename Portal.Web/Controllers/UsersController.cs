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

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(InternalUserViewModel models)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                var result = _userManager.CreateAsync(user: user).Result;
                if (result.Succeeded)
                {
                    var resultFromAddingUserToRole = _userManager.AddToRoleAsync(user: user, role: models.Roles).Result;
                    if (resultFromAddingUserToRole.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }

            return View();
        }
    }
}