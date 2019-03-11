using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portal.Areas.Admin.ViewModels;
using Portal.Business.Contracts;
using Portal.Business.Utilities;
using Portal.Domain.Models;

namespace Portal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VourcherManagerController : Controller
    {
        private readonly IVourcherManager _vourcherManager;

        public VourcherManagerController(IVourcherManager vourcherManager)
        {
            _vourcherManager = vourcherManager;
        }

        public IActionResult Index(
           string sortOrder,
           string currentFilter,
           string searchString,
           int? page
           )
        {
            ViewData["ControllerName"] = "Admin/VOUCHER";

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

            var list = _vourcherManager.Get();

            int pageSize = 20;

            return View("_index", PaginatedList<Vouchering>.Create(list.AsQueryable(), page ?? 1, pageSize));
        }
    }
}