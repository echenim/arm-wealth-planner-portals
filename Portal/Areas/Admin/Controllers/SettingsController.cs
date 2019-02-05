using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portal.Business.Contracts;
using Portal.Domain.Models.Identity;

namespace Portal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SettingsController : Controller
    {
        private readonly IProductCategoryManager _categoryService;
        private readonly RoleManager<ApplicationRole> _rolemanager;
        private readonly IApplicationGroupManager _groupManager;

        public SettingsController(IProductCategoryManager categoryService,
            RoleManager<ApplicationRole> rolemanager,
            IApplicationGroupManager groupManager
        )
        {
            _categoryService = categoryService;
            _rolemanager = rolemanager;
            _groupManager = groupManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewRoles()
        {
            var role = _rolemanager.Roles.OrderBy(s => s.Name);
            return View(role);
        }

        public IActionResult ViewPermission()
        {
            var data = _groupManager.Groups()
                .Include(s => s.ApplicationRoles)
                .Include(s => s.ApplicationUsers);
            return View("_viewpermission", data);
        }

        public IActionResult CreatePermission()
        {
            ViewData["RoleGroup"] = _rolemanager.Roles.Select(s => s.RoleGroupName).Distinct();
            ViewBag.RolesList = _rolemanager.Roles;
            var groupObj = new ApplicationGroup();
            groupObj.AvailableRoleMaker = _rolemanager.Roles.Select(s => s.RoleGroupName).Distinct().ToList();
            groupObj.AvailableRole = _rolemanager.Roles;
            return View("_managepermission", groupObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePermission(ApplicationGroup applicationgroup,
            params string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                // Create the new Group:
                var result = _groupManager.CreateGroup(applicationgroup);
                if (result.Succeeded)
                {
                    selectedRoles = selectedRoles ?? new string[] { };
                    _groupManager.SetGroupRoles(applicationgroup.Id, selectedRoles);
                    return RedirectToAction("ViewPermission");
                }
                return RedirectToAction("ViewPermission");
            }

            // Otherwise, start over:
            ViewBag.RoleId = new SelectList(
                _rolemanager.Roles.ToList(), "Id", "Name");
            return View(applicationgroup);
        }

        public IActionResult ViewProductCategory()
        {
            var list = _categoryService.Get();

            return View(list);
        }

        public IActionResult AddProductCategory()
        {
            return View("_AddProductCategory");
        }
    }
}