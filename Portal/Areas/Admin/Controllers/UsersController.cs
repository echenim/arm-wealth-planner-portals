using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portal.Areas.Admin.ViewModels;
using Portal.Domain.Models.Identity;
using Portal.Business.Contracts;

namespace Portal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IApplicationGroupManager _groupManager;
        private readonly IUserService _service;

        public UsersController(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager, 
            IApplicationGroupManager groupManager,
            IUserService service)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _service = service;
            _groupManager = groupManager;
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

            var permissionCollection = _groupManager.Groups().OrderBy(s=>s.Name);
            foreach (var item in permissionCollection)
            {
                internalUser.AvailableRoles.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
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
                  
                    var resultFromAssigningPermission = _groupManager.SetUserGroups(user.Id, models.Roles);
                    if (resultFromAssigningPermission.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }

            return View(models);
        }
    }
}