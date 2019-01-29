using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Portal.Areas.Admin.ViewModels;
using Portal.Business.Contracts;
using Portal.Business.Utilities;

namespace Portal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SalesController : Controller
    {
        private readonly IOrdersAndSalesService _ordersAndSalesService;

        public SalesController(IOrdersAndSalesService ordersAndSalesService)
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
            ViewData["ControllerName"] = "Admin/SALES";

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

            var sales = !String.IsNullOrEmpty(searchString) ?
                _ordersAndSalesService.Sales(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                                && s.CartNumber.Equals(searchString))
                .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Customer)
                : _ordersAndSalesService.Sales(s => !s.Product.ProductTypes.Equals("Expression of Interest"))
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Customer);

            var list = sales.Select(item => new OrdersView
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

        public IActionResult AllTime(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? page
            )
        {
            ViewData["ControllerName"] = "ADMIN/REPORTS/SALES/ALL-TIME";

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

            var sales = !String.IsNullOrEmpty(searchString) ?
                _ordersAndSalesService.Sales(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                                && s.CartNumber.Equals(searchString))
                .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Customer)
                : _ordersAndSalesService.Sales(s => !s.Product.ProductTypes.Equals("Expression of Interest"))
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Customer);

            var totalIn = sales.Sum(s => s.Amount);
            ViewData["Totals"] = TransfromerManager.DecimalHumanizedX(totalIn);
            var list = sales.Select(item => new OrdersView
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

        public IActionResult LastYear(
           string sortOrder,
           string currentFilter,
           string searchString,
           int? page
           )
        {
            ViewData["ControllerName"] = "ADMIN/REPORTS/SALES/LAST YEAR";

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

            var sales = !String.IsNullOrEmpty(searchString) ?
                _ordersAndSalesService.Sales(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                                && s.CartNumber.Equals(searchString)
                                                  && s.AddToCartDate.Date.ToString("yyyy").Equals(DateTime.Now.Date.AddYears(-1).ToString("yyyy")))
                .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Customer)
                : _ordersAndSalesService.Sales(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                    && s.AddToCartDate.Date.ToString("yyyy").Equals(DateTime.Now.Date.AddYears(-1).ToString("yyyy")))
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Customer);

            var totalIn = sales.Sum(s => s.Amount);
            ViewData["Totals"] = TransfromerManager.DecimalHumanizedX(totalIn);
            var list = sales.Select(item => new OrdersView
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

        public IActionResult LastMonth(
           string sortOrder,
           string currentFilter,
           string searchString,
           int? page
           )
        {
            ViewData["ControllerName"] = "ADMIN/REPORTS/SALES/LAST-MONTH";

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

            var sales = !String.IsNullOrEmpty(searchString) ?
                _ordersAndSalesService.Sales(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                                && s.CartNumber.Equals(searchString)
                                                  && s.AddToCartDate.Date.ToString("MM/yyyy").Equals(DateTime.Now.Date.AddMonths(-1).ToString("MM/yyyy")))
                .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Customer)
                : _ordersAndSalesService.Sales(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                                    && s.AddToCartDate.Date.ToString("MM/yyyy").Equals(DateTime.Now.Date.AddMonths(-1).ToString("MM/yyyy")))
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Customer);

            var totalIn = sales.Sum(s => s.Amount);
            ViewData["Totals"] = TransfromerManager.DecimalHumanizedX(totalIn);
            var list = sales.Select(item => new OrdersView
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

        public IActionResult LastSevenDays(
           string sortOrder,
           string currentFilter,
           string searchString,
           int? page
           )
        {
            ViewData["ControllerName"] = "ADMIN/REPORTS/SALES/LAST-7-DAYS";

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

            var sales = !String.IsNullOrEmpty(searchString) ?
                _ordersAndSalesService.Sales(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                                && s.CartNumber.Equals(searchString)
                                                  && s.AddToCartDate.Date > DateTime.Now.Date.AddDays(-8))
                .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Customer)
                : _ordersAndSalesService.Sales(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                                    && s.AddToCartDate.Date > DateTime.Now.Date.AddDays(-8))
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Customer);

            var totalIn = sales.Sum(s => s.Amount);
            ViewData["Totals"] = TransfromerManager.DecimalHumanizedX(totalIn);
            var list = sales.Select(item => new OrdersView
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

        public IActionResult SelectedPeriod(
           string sortOrder,
           string currentFilter,
           string searchString,
           int? page
           )
        {
            ViewData["ControllerName"] = "ADMIN/REPORTS/SALES/SELECTED PERIOD";

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

            var sales = !String.IsNullOrEmpty(searchString) ?
                _ordersAndSalesService.Sales(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                                && s.CartNumber.Equals(searchString))
                .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Customer)
                : _ordersAndSalesService.Sales(s => !s.Product.ProductTypes.Equals("Expression of Interest"))
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Customer);

            var totalIn = sales.Sum(s => s.Amount);
            ViewData["Totals"] = TransfromerManager.DecimalHumanizedX(totalIn);
            var list = sales.Select(item => new OrdersView
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
    }
}