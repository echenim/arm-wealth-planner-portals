﻿using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Portal.Areas.Admin.ViewModels;
using Portal.Business.Contracts;
using Portal.Business.Utilities;
using Portal.Domain.Models;

namespace Portal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SalesController : Controller
    {
        private readonly IOrdersAndSalesService _ordersAndSalesService;

        private readonly IHostingEnvironment _hostingEnvironment;

        public SalesController(IOrdersAndSalesService ordersAndSalesService,
            IHostingEnvironment hostingEnvironment)
        {
            _ordersAndSalesService = ordersAndSalesService;
            _hostingEnvironment = hostingEnvironment;
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

            var totalIn = sales.Sum(s => s.Amount);

            var groupByCartNumber = sales.GroupBy(s =>
                    new
                    {
                        CartNum = s.CartNumber,
                        Customer = s.Customer.FullName,
                        TranStatus = s.TransactionStatus,
                        TransDate = s.OrderDate
                    })
                .Select(gr => new
                {
                    Id = gr.Key.CartNum,
                    Customer = gr.Key.Customer,
                    TranStatus = gr.Key.TranStatus,
                    TransDate = gr.Key.TransDate,
                    TotalAmount = gr.Sum(s => s.Amount)
                });

            var list = groupByCartNumber.Select(item => new OrdersGroupView
            {
                CartNumber = item.Id,
                Customer = item.Customer,
                TransactionStatus = item.TranStatus,
                TransactionDate = item.TransDate,
                TotalAmount = TransfromerManager.DecimalHumanizedX(item.TotalAmount),
                SoldItems = sales.Where(s => s.CartNumber.Equals(item.Id)).ToList()
            });

            ViewData["Totals"] = TransfromerManager.DecimalHumanizedX(totalIn);

            int pageSize = 20;

            return View(PaginatedList<OrdersGroupView>.Create(list.AsQueryable(), page ?? 1, pageSize));
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

            var groupByCartNumber = sales.GroupBy(s =>
                    new
                    {
                        CartNum = s.CartNumber,
                        Customer = s.Customer.FullName,
                        TranStatus = s.TransactionStatus,
                        TransDate = s.OrderDate
                    })
                .Select(gr => new
                {
                    Id = gr.Key.CartNum,
                    Customer = gr.Key.Customer,
                    TranStatus = gr.Key.TranStatus,
                    TransDate = gr.Key.TransDate,
                    TotalAmount = gr.Sum(s => s.Amount)
                });

            var list = groupByCartNumber.Select(item => new OrdersGroupView
            {
                CartNumber = item.Id,
                Customer = item.Customer,
                TransactionStatus = item.TranStatus,
                TransactionDate = item.TransDate,
                TotalAmount = TransfromerManager.DecimalHumanizedX(item.TotalAmount),
                SoldItems = sales.Where(s => s.CartNumber.Equals(item.Id)).ToList()
            });

            ViewData["Totals"] = TransfromerManager.DecimalHumanizedX(totalIn);

            int pageSize = 20;

            return View(PaginatedList<OrdersGroupView>.Create(list.AsQueryable(), page ?? 1, pageSize));
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
                _ordersAndSalesService.Sales(s => s.OrderDate != null
                                                && s.CartNumber.Equals(searchString)
                                                  && s.AddToCartDate.Date.ToString("yyyy").Equals(DateTime.Now.Date.AddYears(-1).ToString("yyyy")))
                .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Customer)
                : _ordersAndSalesService.Sales(s => s.OrderDate != null
                    && s.AddToCartDate.Date.ToString("yyyy").Equals(DateTime.Now.Date.AddYears(-1).ToString("yyyy")))
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Customer);

            var totalIn = sales.Sum(s => s.Amount);

            var groupByCartNumber = sales.GroupBy(s =>
                    new
                    {
                        CartNum = s.CartNumber,
                        Customer = s.Customer.FullName,
                        TranStatus = s.TransactionStatus,
                        TransDate = s.OrderDate
                    })
                .Select(gr => new
                {
                    Id = gr.Key.CartNum,
                    Customer = gr.Key.Customer,
                    TranStatus = gr.Key.TranStatus,
                    TransDate = gr.Key.TransDate,
                    TotalAmount = gr.Sum(s => s.Amount)
                });

            var list = groupByCartNumber.Select(item => new OrdersGroupView
            {
                CartNumber = item.Id,
                Customer = item.Customer,
                TransactionStatus = item.TranStatus,
                TransactionDate = item.TransDate,
                TotalAmount = TransfromerManager.DecimalHumanizedX(item.TotalAmount),
                SoldItems = sales.Where(s => s.CartNumber.Equals(item.Id)).ToList()
            });

            ViewData["Totals"] = TransfromerManager.DecimalHumanizedX(totalIn);

            ViewData["Product"] = sales.Select(s => s.Product.Name).Distinct();
            ViewData["ProductCategory"] = sales.Select(s => s.Product.ProductCategory.Name).Distinct();

            int pageSize = 20;

            return View(PaginatedList<OrdersGroupView>.Create(list.AsQueryable(), page ?? 1, pageSize));
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

            var groupByCartNumber = sales.GroupBy(s =>
                    new
                    {
                        CartNum = s.CartNumber,
                        Customer = s.Customer.FullName,
                        TranStatus = s.TransactionStatus,
                        TransDate = s.OrderDate
                    })
                .Select(gr => new
                {
                    Id = gr.Key.CartNum,
                    Customer = gr.Key.Customer,
                    TranStatus = gr.Key.TranStatus,
                    TransDate = gr.Key.TransDate,
                    TotalAmount = gr.Sum(s => s.Amount)
                });

            var list = groupByCartNumber.Select(item => new OrdersGroupView
            {
                CartNumber = item.Id,
                Customer = item.Customer,
                TransactionStatus = item.TranStatus,
                TransactionDate = item.TransDate,
                TotalAmount = TransfromerManager.DecimalHumanizedX(item.TotalAmount),
                SoldItems = sales.Where(s => s.CartNumber.Equals(item.Id)).ToList()
            });

            ViewData["Totals"] = TransfromerManager.DecimalHumanizedX(totalIn);
            var product = sales.Select(s => s.Product.Name).Distinct();
            ViewData["Product"] = product;
            //    ViewData["ProductCategory"] = sales.Select(s => s.Product.ProductCategory.Name).Distinct();

            int pageSize = 20;

            return View(PaginatedList<OrdersGroupView>.Create(list.AsQueryable(), page ?? 1, pageSize));
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

            var groupByCartNumber = sales.GroupBy(s =>
                    new
                    {
                        CartNum = s.CartNumber,
                        Customer = s.Customer.FullName,
                        TranStatus = s.TransactionStatus,
                        TransDate = s.OrderDate
                    })
                .Select(gr => new
                {
                    Id = gr.Key.CartNum,
                    Customer = gr.Key.Customer,
                    TranStatus = gr.Key.TranStatus,
                    TransDate = gr.Key.TransDate,
                    TotalAmount = gr.Sum(s => s.Amount)
                });

            var list = groupByCartNumber.Select(item => new OrdersGroupView
            {
                CartNumber = item.Id,
                Customer = item.Customer,
                TransactionStatus = item.TranStatus,
                TransactionDate = item.TransDate,
                TotalAmount = TransfromerManager.DecimalHumanizedX(item.TotalAmount),
                SoldItems = sales.Where(s => s.CartNumber.Equals(item.Id)).ToList()
            });

            ViewData["Totals"] = TransfromerManager.DecimalHumanizedX(totalIn);

            int pageSize = 20;

            return View(PaginatedList<OrdersGroupView>.Create(list.AsQueryable(), page ?? 1, pageSize));
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

            var groupByCartNumber = sales.GroupBy(s =>
                    new
                    {
                        CartNum = s.CartNumber,
                        Customer = s.Customer.FullName,
                        TranStatus = s.TransactionStatus,
                        TransDate = s.OrderDate
                    })
                .Select(gr => new
                {
                    Id = gr.Key.CartNum,
                    Customer = gr.Key.Customer,
                    TranStatus = gr.Key.TranStatus,
                    TransDate = gr.Key.TransDate,
                    TotalAmount = gr.Sum(s => s.Amount)
                });

            var list = groupByCartNumber.Select(item => new OrdersGroupView
            {
                CartNumber = item.Id,
                Customer = item.Customer,
                TransactionStatus = item.TranStatus,
                TransactionDate = item.TransDate,
                TotalAmount = TransfromerManager.DecimalHumanizedX(item.TotalAmount),
                SoldItems = sales.Where(s => s.CartNumber.Equals(item.Id)).ToList()
            });

            ViewData["Totals"] = TransfromerManager.DecimalHumanizedX(totalIn);

            int pageSize = 20;

            return View(PaginatedList<OrdersGroupView>.Create(list.AsQueryable(), page ?? 1, pageSize));
        }

        public async Task<IActionResult> OnPostExport(string productCategoryName, string productName, string searchPeriod)
        {
            var sWebRootFolder = _hostingEnvironment.WebRootPath;
            var sFileName = @"SalesReport.xlsx";
            var URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, sFileName);
            var file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            var memory = new MemoryStream();

            /*
             * filter sales report by parameters if any
             * I used the ternary operator to make my code short  *
             */
            var sales = !string.IsNullOrEmpty(productName)
                ? ReturnFilteredSales(productCategoryName, searchPeriod)
                    .Where(s => s.Product.Name.Equals(productName)) :
                ReturnFilteredSales(productCategoryName, searchPeriod);

            using (var fs = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook;
                workbook = new XSSFWorkbook();
                var excelSheet = workbook.CreateSheet("Demo");
                var row = excelSheet.CreateRow(0);
                row.CreateCell(0).SetCellValue("Date");
                row.CreateCell(1).SetCellValue("TransactionNumber");
                row.CreateCell(2).SetCellValue("Customer");
                row.CreateCell(3).SetCellValue("Product");
                row.CreateCell(4).SetCellValue("Category");
                row.CreateCell(5).SetCellValue("Amount");
                var sn = 0;
                foreach (var item in sales)
                {
                    sn = sn + 1;
                    row = excelSheet.CreateRow(sn);
                    row.CreateCell(0).SetCellValue(item.OrderDate);
                    row.CreateCell(1).SetCellValue(item.CartNumber);
                    row.CreateCell(2).SetCellValue(item.Customer.FullName);
                    row.CreateCell(3).SetCellValue(item.Product.Name);
                    row.CreateCell(4).SetCellValue(item.Product.ProductCategory.Name);
                    row.CreateCell(5).SetCellValue(item.Amount.ToString());
                }

                workbook.Write(fs);
            }
            using (var stream = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);
        }

        /// <summary>
        /// filter report using parameter presented
        /// </summary>
        /// <param name="productCategoryName"></param>
        /// <param name="searchPeriod"></param>
        /// <returns></returns>
        private IQueryable<PurchaseOrders> ReturnFilteredSales(string productCategoryName, string searchPeriod)
            => searchPeriod.Equals("lastServenDays") ? LastSevenDays(productCategoryName)
            : searchPeriod.Equals("lastMonth") ? LastMonth(productCategoryName)
            : searchPeriod.Equals("lastYear") ? LastYear(productCategoryName)
            : AllTime(productCategoryName);

        #region sales filtered report

        /// <summary>
        /// if productCategoryName is not null or empty
        /// filter will the product category for all time else return unfiltered records for all tmes
        /// </summary>
        /// <param name="productCategoryName">productCategoryName</param>
        /// <returns>querable collecgtion</returns>
        private IQueryable<PurchaseOrders> AllTime(string productCategoryName)
        {
            return !String.IsNullOrEmpty(productCategoryName) ? _ordersAndSalesService.Sales(s => s.OrderDate != null
                     && s.Product.ProductCategory.Name.Equals(productCategoryName))
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Customer)
                : _ordersAndSalesService.Sales(s => s.OrderDate != null)
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Customer);
        }

        /// <summary>
        /// if productCategoryName is not null or empty
        /// filter will the product category for last year else return unfiltered records for last year
        /// </summary>
        /// <param name="productCategoryName">productCategoryName</param>
        /// <returns>querable collecgtion</returns>
        private IQueryable<PurchaseOrders> LastYear(string productCategoryName)
        {
            return !String.IsNullOrEmpty(productCategoryName)
                ? _ordersAndSalesService.Sales(s =>
                        s.OrderDate != null && s.Product.ProductCategory.Name.Equals(
                                                productCategoryName)
                                            && s.AddToCartDate.Date.ToString("yyyy")
                                                .Equals(DateTime.Now.Date.AddYears(-1)
                                                    .ToString("yyyy")))
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Customer)
                : _ordersAndSalesService.Sales(s =>
                           s.OrderDate != null && s.AddToCartDate.Date.ToString("yyyy")
                               .Equals(DateTime.Now.Date.AddYears(-1).ToString("yyyy")))
                        .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Customer);
        }

        /// <summary>
        /// if productCategoryName is not null or empty
        /// filter will the product category for last month else return unfiltered records for last month
        /// </summary>
        /// <param name="productCategoryName">productCategoryName</param>
        /// <returns>querable collecgtion</returns>
        private IQueryable<PurchaseOrders> LastMonth(string productCategoryName)
        {
            return !String.IsNullOrEmpty(productCategoryName)
                ? _ordersAndSalesService.Sales(s =>
                        s.OrderDate != null && s.Product.ProductCategory.Name.Equals(productCategoryName)
                                            && s.AddToCartDate.Date.ToString("MM/yyyy")
                                                .Equals(DateTime.Now.Date.AddMonths(-1).ToString("MM/yyyy")))
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Customer)
                : _ordersAndSalesService.Sales(s =>
                           s.OrderDate != null && s.AddToCartDate.Date.ToString("MM/yyyy")
                               .Equals(DateTime.Now.Date.AddMonths(-1).ToString("MM/yyyy")))
                        .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Customer);
        }

        /// <summary>
        /// if productCategoryName is not null or empty
        /// filter will the product category for last seven days else return unfiltered records for seven days
        /// </summary>
        /// <param name="productCategoryName">productCategoryName</param>
        /// <returns>querable collecgtion</returns>
        private IQueryable<PurchaseOrders> LastSevenDays(string productCategoryName)
        {
            return !String.IsNullOrEmpty(productCategoryName)
                ? _ordersAndSalesService
                    .Sales(s =>
                        !string.IsNullOrEmpty(s.OrderDate) && s.Product.ProductCategory.Name.Equals(productCategoryName)
                                                           && s.AddToCartDate.Date > DateTime.Now.Date.AddDays(-8))
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Customer)
                : _ordersAndSalesService
                    .Sales(s => !string.IsNullOrEmpty(s.OrderDate) &&
                                s.AddToCartDate.Date > DateTime.Now.Date.AddDays(-8))
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Customer);
        }

        #endregion sales filtered report
    }
}