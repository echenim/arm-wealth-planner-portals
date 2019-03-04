﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            var data = !String.IsNullOrEmpty(searchString)
                ? _userManager.Users.Include(s => s.Person).Where(s => s.Person.IsCustomer == true)
                    .Where(s => s.Person.FullName.Contains(searchString))
                //  .OrderBy(s => s.Person.FullName).ThenBy(s => s.Person.MembershipNo)
                : _userManager.Users.Include(s => s.Person).Where(s => s.Person.IsCustomer == true);
            //  .OrderBy(s => s.Person.FullName).ThenBy(s => s.Person.MembershipNo);

            var list = data.Select(item => new ExternalUserView
            {
                Id = item.Id,
                Name = item.Person.FullName,
                Email = item.Email,
                // MembershipNumber = item.Person.MembershipNo,
                Status = item.Person.PortalOnBoarding
            })
                .ToList();

            int pageSize = 20;

            return View(PaginatedList<ExternalUserView>.Create(list.AsQueryable(), page ?? 1, pageSize));
        }

        public IActionResult AllTime(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? page
        )
        {
            ViewData["ControllerName"] = "ADMIN/CUSTOMERS/ALL-TIME";

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
                _userManager.Users.Include(s => s.Person).Where(s => s.Person.IsCustomer == true)
                    .Where(s => s.Person.FullName.Contains(searchString))
                // .OrderBy(s => s.Person.FullName).ThenBy(s => s.Person.MembershipNo)
                : _userManager.Users.Include(s => s.Person).Where(s => s.Person.IsCustomer == true);
            //  .OrderBy(s => s.Person.FullName).ThenBy(s => s.Person.MembershipNo);

            var list = data.Select(item => new ExternalUserView
            {
                Id = item.Id,
                Name = item.Person.FullName,
                Email = item.Email,
                //   MembershipNumber = item.Person.MembershipNo,
                Status = item.Person.PortalOnBoarding
            })
                .ToList();

            ViewData["Totals"] = data.Count();

            int pageSize = 20;

            return View("_all", PaginatedList<ExternalUserView>.Create(list.AsQueryable(), page ?? 1, pageSize));
        }

        public IActionResult LastYear(
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

            var data = !String.IsNullOrEmpty(searchString)
                ? _userManager.Users.Include(s => s.Person).Where(s => s.Person.IsCustomer == true)
                    .Where(s => s.Person.FullName.Contains(searchString))
                // .OrderBy(s => s.Person.FullName).ThenBy(s => s.Person.MembershipNo)
                : _userManager.Users.Include(s => s.Person).Where(s => s.Person.IsCustomer == true);
            //   .OrderBy(s => s.Person.FullName).ThenBy(s => s.Person.MembershipNo);

            var list = data.Select(item => new ExternalUserView
            {
                Id = item.Id,
                Name = item.Person.FullName,
                Email = item.Email,
                //  MembershipNumber = item.Person.MembershipNo,
                Status = item.Person.PortalOnBoarding
            })
                .ToList();

            int pageSize = 20;

            return View(PaginatedList<ExternalUserView>.Create(list.AsQueryable(), page ?? 1, pageSize));
        }

        public IActionResult LastMonth(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? page
        )
        {
            ViewData["ControllerName"] = "ADMIN/CUSTOMERS/LAST-MONTH";

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

            var data = !String.IsNullOrEmpty(searchString)
                ? _userManager.Users.Include(s => s.Person).Where(s => s.Person.IsCustomer == true)
                    .Where(s => s.Person.FullName.Contains(searchString))
                //  .OrderBy(s => s.Person.FullName).ThenBy(s => s.Person.MembershipNo)
                : _userManager.Users.Include(s => s.Person).Where(s => s.Person.IsCustomer == true);
            // .OrderBy(s => s.Person.FullName).ThenBy(s => s.Person.MembershipNo);

            var list = data.Select(item => new ExternalUserView
            {
                Id = item.Id,
                Name = item.Person.FullName,
                Email = item.Email,
                // MembershipNumber = item.Person.MembershipNo,
                Status = item.Person.PortalOnBoarding
            })
                .ToList();
            int pageSize = 20;

            return View(PaginatedList<ExternalUserView>.Create(list.AsQueryable(), page ?? 1, pageSize));
        }

        public IActionResult LastSevenDays(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? page
        )
        {
            ViewData["ControllerName"] = "ADMIN/CUSTOMERS/LAST-SEVEN-DAYS";

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

            var data = !String.IsNullOrEmpty(searchString)
                ? _userManager.Users.Include(s => s.Person).Where(s => s.Person.IsCustomer == true)
                    .Where(s => s.Person.FullName.Contains(searchString))
                //  .OrderBy(s => s.Person.FullName).ThenBy(s => s.Person.MembershipNo)
                : _userManager.Users.Include(s => s.Person).Where(s => s.Person.IsCustomer == true);
            //  .OrderBy(s => s.Person.FullName).ThenBy(s => s.Person.MembershipNo);

            var list = data.Select(item => new ExternalUserView
            {
                Id = item.Id,
                Name = item.Person.FullName,
                Email = item.Email,
                //  MembershipNumber = item.Person.MembershipNo,
                Status = item.Person.PortalOnBoarding
            })
                .ToList();

            int pageSize = 20;

            return View(PaginatedList<ExternalUserView>.Create(list.AsQueryable(), page ?? 1, pageSize));
        }

        public IActionResult SelectedPeriod(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? page
        )
        {
            ViewData["ControllerName"] = "ADMIN/CUSTOMERS/SELECTED-PERIOD";

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
                _userManager.Users.Include(s => s.Person).Where(s => s.Person.IsCustomer == true)
                    .Where(s => s.Person.FullName.Contains(searchString))
                  // .OrderBy(s => s.Person.FullName).ThenBy(s => s.Person.MembershipNo)
                  : _userManager.Users.Include(s => s.Person).Where(s => s.Person.IsCustomer == true);
            // .OrderBy(s => s.Person.FullName).ThenBy(s => s.Person.MembershipNo);

            var list = data.Select(item => new ExternalUserView
            {
                Id = item.Id,
                Name = item.Person.FullName,
                Email = item.Email,
                //  MembershipNumber = item.Person.MembershipNo,
                Status = item.Person.PortalOnBoarding
            })
                .ToList();

            int pageSize = 20;

            return View(PaginatedList<ExternalUserView>.Create(list.AsQueryable(), page ?? 1, pageSize));
        }
    }
}