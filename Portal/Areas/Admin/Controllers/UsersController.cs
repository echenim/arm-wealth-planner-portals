﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portal.Areas.Admin.ViewModels;
using Portal.Domain.Models.Identity;
using Portal.Business.Contracts;
using Portal.Business.Utilities;
using Portal.Domain.ViewModels;
using Portal.Domain.Models;
using Microsoft.AspNetCore.Authorization;

namespace Portal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IApplicationGroupManager _groupManager;
        private readonly IUserService _service;

        private readonly IPersonManager _personManager;

        public UsersController(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IApplicationGroupManager groupManager,
            IPersonManager personManager,
        IUserService service)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _service = service;
            _groupManager = groupManager;
            _personManager = personManager;
        }

        [Authorize(Roles = "Sub-Administrator,Administrator")]
        public IActionResult Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? page
        )
        {
            ViewData["ControllerName"] = "ADMIN/CUSTOMERS/LIST";

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
                _service.Get(s => s.Name.Contains(searchString))
                    .OrderBy(s => s.Name)
                : _service.Get().OrderBy(s => s.Name);

            int pageSize = 20;

            return View(PaginatedList<ViewModelInternalUser>.Create(data.AsQueryable(), page ?? 1, pageSize));
        }

        [Authorize(Roles = "Sub-Administrator,Administrator")]
        public IActionResult Add()
        {
            var internalUser = new InternalUserViewModel();
            internalUser.AvailableRoles.Add(new SelectListItem
            {
                Text = "--select--",
                Value = string.Empty
            });

            var permissionCollection = _groupManager.Groups().OrderBy(s => s.Name);
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
        [Authorize(Roles = "Sub-Administrator,Administrator")]
        public IActionResult Add(InternalUserViewModel models)
        {
            if (ModelState.IsValid)
            {
                var personObj = new Person
                {
                    FirstName = models.FirstName,
                    LastName = models.LastName,
                    Email = models.Email,
                    IsCustomer = false,
                    Gender = "Non"
                };

                var isPersonResult = _personManager.Save(personObj);
                if (isPersonResult.Succeed)
                {
                    var user = new ApplicationUser
                    {
                        Email = models.Email,
                        UserName = models.Email,
                        PersonId = isPersonResult.TObj.Id
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
            }

            return View(models);
        }

        [Authorize(Roles = "Sub-Administrator,Administrator")]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) return RedirectToAction("Index");

            var user = _userManager.FindByIdAsync(id).Result;
            var internalUser = new EditInternalUserViewModel
            {
                Email = user.Email,
            };
            internalUser.AvailableRoles.Add(new SelectListItem
            {
                Text = "--select--",
                Value = string.Empty
            });

            var permissionCollection = _groupManager.Groups().OrderBy(s => s.Name);
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
        public IActionResult Edit(EditInternalUserViewModel models)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByIdAsync(models.Id.ToString()).Result;

                user.Email = models.Email;

                var result = _userManager.UpdateAsync(user).Result;

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