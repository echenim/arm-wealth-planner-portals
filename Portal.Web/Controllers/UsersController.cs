using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portal.Web.ViewModels;
using PortalAPI.Domain.Models.Identity;
using PortalAPI.Midleware.Contracts;

namespace Portal.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IUserService _service;

        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,
            IUserService service)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _service = service;
        }

        public IActionResult Index()
        {
            ViewData["ControllerName"] = "Admin/User";

            //var data = _userManager.Users.Where(s => s.IsCustomerOrStaff.Equals("internal"))
            //    .OrderBy(s => s.FirstName).ThenBy(s => s.MembershipNumber);

            //var list = data.Select(item => new InternalUserView
            //{
            //    Id = item.Id,
            //    Name = item.FullName,
            //    Email = item.Email,
            //})
            //    .ToList();

            var list = _service.Get();

            return View(list);
        }

        public IActionResult Add()
        {
            var internalUser = new InternalUserViewModel();
            internalUser.AvailableRoles.Add(new SelectListItem
            {
                Text = "--select--",
                Value = string.Empty
            });

            var roleCollection = _roleManager.Roles.OrderBy(s => s.Name);
            foreach (var item in roleCollection)
            {
                internalUser.AvailableRoles.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Name
                });
            }

            return View(internalUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(InternalUserViewModel models)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    FirstName = models.FirstName,
                    LastName = models.LastName,
                    Email = models.Email,
                    UserName = models.Email,
                    IsCustomerOrStaff = "internal"
                };

                var result = _userManager.CreateAsync(user: user, password: models.Password).Result;
                if (result.Succeeded)
                {
                    var resultFromAddingUserToRole = _userManager.AddToRoleAsync(user: user, role: models.Roles).Result;
                    if (resultFromAddingUserToRole.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }

            return View(models);
        }
    }
}