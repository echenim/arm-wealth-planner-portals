using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Portal.Areas.Admin.ViewModels;
using Portal.Business.Contracts;
using Portal.Business.Utilities;

namespace Portal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrdersController : Controller
    {
        private readonly IOrdersAndSalesService _ordersAndSalesService;

        public OrdersController(IOrdersAndSalesService ordersAndSalesService)
        {
            _ordersAndSalesService = ordersAndSalesService;
        }

        public IActionResult Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? page
            )
        {
            ViewData["ControllerName"] = "Admin/Orders";

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

            var orders = !String.IsNullOrEmpty(searchString) ?
                _ordersAndSalesService.Get(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                                && s.CartNumber.Equals(searchString))
                .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Customer)
                : _ordersAndSalesService.Get(s => !s.Product.ProductTypes.Equals("Expression of Interest"))
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Customer);

            var list = orders.Select(item => new OrdersView
            {
                Id = (int)item.Id,
                Product = item.Product.Name,
                Category = item.Product.ProductCategory.Name,
                Customer = item.Customer.FullName,
                CustNo = item.Customer.MembershipNumber,
                Amount = TransfromerManager.DecimalHumanizedX(item.Amount),
                TransactionDate = item.OrderDate.ToString(),
                CartNumber = item.CartNumber,
                TransactionNumber = item.PaymentTransactionNumber,
                TransactionStatus = item.TransactionStatus,
                AddToCartDate = TransfromerManager.DateHumanized(item.AddToCartDate),
                Date = item.OrderDate.ToString()
            })
                .ToList();

            int pageSize = 20;

            return View(PaginatedList<OrdersView>.Create(list.AsQueryable(), page ?? 1, pageSize));
        }

        public IActionResult Interest(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? page
            )
        {
            ViewData["ControllerName"] = "Admin/Expression Of Interest";

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

            var orders = !String.IsNullOrEmpty(searchString) ?
                _ordersAndSalesService.Get(s => s.Product.ProductTypes.Equals("Expression of Interest")
                                                && s.CartNumber.Equals(searchString))
                .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Customer)
                : _ordersAndSalesService.Get(s => s.Product.ProductTypes.Equals("Expression of Interest"))
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Customer);

            var list = orders.Select(item => new OrdersView
            {
                Id = (int)item.Id,
                Product = item.Product.Name,
                Category = item.Product.ProductCategory.Name,
                Customer = item.Customer.FullName,
                CustNo = item.Customer.MembershipNumber,
                Amount = TransfromerManager.DecimalHumanizedX(item.Amount),
                AddToCartDate = TransfromerManager.DateHumanized(item.AddToCartDate),
                Date = item.OrderDate.ToString()
            })
                .ToList();

            int pageSize = 20;

            return View(PaginatedList<OrdersView>.Create(list.AsQueryable(), page ?? 1, pageSize));
        }
    }
}