using System;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portal.Areas.Admin.ViewModels;
using Portal.Business.Utilities;
using Portal.Domain.Models.Identity;

namespace Portal.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Authorize("admin:can:view")]
    public class CustomersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public CustomersController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? page
            )
        {
            ViewData["ControllerName"] = "ADMIN/CUSTOMERS";

            ViewBag.AreaName = "Roles & Permission";
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["NumberOfUserSortParm"] = sortOrder == "NumberOfUser" ? "numberOfUser" : "NumberOfUser";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var data = !String.IsNullOrEmpty(searchString) ?
                    _userManager.Users.Where(s => s.IsCustomerOrStaff.Equals("external"))
                        .Where(s => s.FullName.Contains(searchString))
                        .OrderBy(s => s.FirstName).ThenBy(s => s.MembershipNumber)
                : _userManager.Users.Where(s => s.IsCustomerOrStaff.Equals("external"))
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

            int pageSize = 20;

            return View(PaginatedList<ExternalUserView>.Create(list.AsQueryable(), page ?? 1, pageSize));
        }
    }
}