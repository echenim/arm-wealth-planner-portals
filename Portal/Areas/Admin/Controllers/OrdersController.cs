using System;
using System.Collections.Generic;
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
    public class OrdersController : Controller
    {
        private readonly IOrdersAndSalesManager _ordersAndSalesService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public OrdersController(IOrdersAndSalesManager ordersAndSalesService, IHostingEnvironment hostingEnvironment)
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
                _ordersAndSalesService.Get(s => s.CartNumber.Equals(searchString))
                .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName)
                : _ordersAndSalesService.Get()
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName);

            var list = new List<OrdersView>();
            foreach (var item in orders)
            {
                list.Add(new OrdersView
                {
                    Id = (int)item.Id,
                    Product = item.Product.Name,
                    Category = item.Product.ProductCategory.Name,
                    Customer = item.Person.FullName,
                    CustomerId = item.Person.Id,
                    CustNo = item.Person.MemberShipNo,
                    Amount = TransfromerManager.DecimalHumanizedX(item.Amount),
                    TransactionDate = TransfromerManager.DateHumanized(item.AddToCartDate),
                    CartNumber = item.CartNumber,
                    TransactionNumber = item.PaymentTransactionNumber,
                    TransactionStatus = item.TransactionStatus,
                    AddToCartDate = TransfromerManager.DateHumanized(item.AddToCartDate)
                });
            }

            //var list = orders.Select(item => new OrdersView
            //{
            //    Id = (int)item.Id,
            //    Product = item.Product.Name,
            //    Category = item.Product.ProductCategory.Name,
            //    Customer = item.Customer.FullName,
            //    CustNo = item.Customer.MembershipNumber,
            //    Amount = TransfromerManager.DecimalHumanizedX(item.Amount),
            //    TransactionDate = item.OrderDate.ToString(),
            //    CartNumber = item.CartNumber,
            //    TransactionNumber = item.PaymentTransactionNumber,
            //    TransactionStatus = item.TransactionStatus,
            //    AddToCartDate = TransfromerManager.DateHumanized(item.AddToCartDate),
            //    Date = item.OrderDate.ToString()
            //})
            //    .ToList();

            int pageSize = 20;

            return View(PaginatedList<OrdersView>.Create(list.AsQueryable(), page ?? 1, pageSize));
        }

        public IActionResult OnCorrection(string transactionId)
        {
            if (!string.IsNullOrEmpty(transactionId))
            {
                // var resultsets = _ordersAndSalesService.Get(s => s.CartNumber.Equals(transactionId));
                _ordersAndSalesService.Edit(transactionId);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
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
                .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName)
                : _ordersAndSalesService.Get(s => s.Product.ProductTypes.Equals("Expression of Interest"))
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName);

            var list = orders.Select(item => new OrdersView
            {
                Id = (int)item.Id,
                Product = item.Product.Name,
                Category = item.Product.ProductCategory.Name,
                Customer = item.Person.FullName,
                //CustNo = item.Person.MembershipNo,
                Amount = TransfromerManager.DecimalHumanizedX(item.Amount),
                AddToCartDate = TransfromerManager.DateHumanized(item.AddToCartDate),
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
            ViewData["ControllerName"] = "ADMIN/ORDERS/REPORTS/ALL TIME";

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
                _ordersAndSalesService.Get(s => s.CartNumber.Equals(searchString))
                .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName)
                : _ordersAndSalesService.Get()
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName);

            var totalIn = orders.Count();
            ViewData["Totals"] = TransfromerManager.IntegerHuamanized(totalIn);

            ViewData["Product"] = orders.Select(s => s.Product.Name).Distinct();
            ViewData["ProductCategory"] = orders.Select(s => s.Product.ProductCategory.Name).Distinct();

            var list = orders.Select(item => new OrdersView
            {
                Id = (int)item.Id,
                Product = item.Product.Name,
                Category = item.Product.ProductCategory.Name,
                Customer = item.Person.FullName,
                // CustNo = item.Person.MembershipNo,
                Amount = TransfromerManager.DecimalHumanizedX(item.Amount),
                TransactionDate = item.AddToCartDate.ToString(),
                CartNumber = item.CartNumber,
                TransactionNumber = item.PaymentTransactionNumber,
                TransactionStatus = item.TransactionStatus,
                AddToCartDate = TransfromerManager.DateHumanized(item.AddToCartDate),
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
            ViewData["ControllerName"] = "ADMIN/REPORTS/ORDERS/LAST YEAR";

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
                _ordersAndSalesService.Get(s => s.AddToCartDate.Date.ToString("yyyy").Equals(DateTime.Now.Date.AddYears(-1).ToString("yyyy"))
                                                && s.CartNumber.Equals(searchString))
                .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName)
                : _ordersAndSalesService.Get(s => s.AddToCartDate.Date.ToString("yyyy").Equals(DateTime.Now.Date.AddYears(-1).ToString("yyyy")))
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName);

            var totalIn = orders.Count();
            ViewData["Totals"] = TransfromerManager.IntegerHuamanized(totalIn);
            ViewData["Product"] = orders.Select(s => s.Product.Name).Distinct();
            ViewData["ProductCategory"] = orders.Select(s => s.Product.ProductCategory.Name).Distinct();

            var list = orders.Select(item => new OrdersView
            {
                Id = (int)item.Id,
                Product = item.Product.Name,
                Category = item.Product.ProductCategory.Name,
                Customer = item.Person.FullName,
                // CustNo = item.Person.MembershipNo,
                Amount = TransfromerManager.DecimalHumanizedX(item.Amount),
                TransactionDate = item.AddToCartDate.ToString(),
                CartNumber = item.CartNumber,
                TransactionNumber = item.PaymentTransactionNumber,
                TransactionStatus = item.TransactionStatus,
                AddToCartDate = TransfromerManager.DateHumanized(item.AddToCartDate),
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
            ViewData["ControllerName"] = "ADMIN/REPORTS/ORDERS/LAST-MONTH";

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
                _ordersAndSalesService.Get(s => s.AddToCartDate.Date.ToString("MM/yyyy").Equals(DateTime.Now.Date.AddMonths(-1).ToString("MM/yyyy"))
                                                && s.CartNumber.Equals(searchString))
                .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName)
                : _ordersAndSalesService.Get(s => s.AddToCartDate.Date.ToString("MM/yyyy").Equals(DateTime.Now.Date.AddMonths(-1).ToString("MM/yyyy")))
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName);

            var totalIn = orders.Count();
            ViewData["Totals"] = TransfromerManager.IntegerHuamanized(totalIn);
            ViewData["Product"] = orders.Select(s => s.Product.Name).Distinct();
            ViewData["ProductCategory"] = orders.Select(s => s.Product.ProductCategory.Name).Distinct();

            var list = orders.Select(item => new OrdersView
            {
                Id = (int)item.Id,
                Product = item.Product.Name,
                Category = item.Product.ProductCategory.Name,
                Customer = item.Person.FullName,
                //  CustNo = item.Person.MembershipNo,
                Amount = TransfromerManager.DecimalHumanizedX(item.Amount),
                TransactionDate = item.AddToCartDate.ToString(),
                CartNumber = item.CartNumber,
                TransactionNumber = item.PaymentTransactionNumber,
                TransactionStatus = item.TransactionStatus,
                AddToCartDate = TransfromerManager.DateHumanized(item.AddToCartDate),
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
            ViewData["ControllerName"] = "ADMIN/REPORTS/ORDERS/LAST-7-DAYS";

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
                _ordersAndSalesService.Get(s => s.AddToCartDate.Date > DateTime.Now.Date.AddDays(-8)
                                                && s.CartNumber.Equals(searchString))
                .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName)
                : _ordersAndSalesService.Get(s => s.AddToCartDate.Date > DateTime.Now.Date.AddDays(-8))
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName);

            var totalIn = orders.Count();
            ViewData["Totals"] = TransfromerManager.IntegerHuamanized(totalIn);
            ViewData["Product"] = orders.Select(s => s.Product.Name).Distinct();
            ViewData["ProductCategory"] = orders.Select(s => s.Product.ProductCategory.Name).Distinct();

            var list = orders.Select(item => new OrdersView
            {
                Id = (int)item.Id,
                Product = item.Product.Name,
                Category = item.Product.ProductCategory.Name,
                Customer = item.Person.FullName,
                // CustNo = item.Person.MembershipNo,
                Amount = TransfromerManager.DecimalHumanizedX(item.Amount),
                TransactionDate = item.AddToCartDate.ToString(),
                CartNumber = item.CartNumber,
                TransactionNumber = item.PaymentTransactionNumber,
                TransactionStatus = item.TransactionStatus,
                AddToCartDate = TransfromerManager.DateHumanized(item.AddToCartDate),
                //Date = item.OrderDate.ToString()
            })
                .ToList();

            int pageSize = 20;

            return View(PaginatedList<OrdersView>.Create(list.AsQueryable(), page ?? 1, pageSize));
        }

        public IActionResult SelectedPeriod(
           string sortOrder,
           string currentFilter,
           //string searchString,
           string selectedPeriodValues,
           int? page
           )
        {
            ViewData["ControllerName"] = "ADMIN/REPORTS/ORDERS/SELECTED PERIOD";

            ViewBag.AreaName = "Roles & Permission";
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["NumberOfUserSortParm"] = sortOrder == "NumberOfUser" ? "numberOfUser" : "NumberOfUser";

            //if (searchString != null)
            //{
            //    page = 1;
            //}
            //else
            //{
            //    searchString = currentFilter;
            //}

            var k = selectedPeriodValues;
            //   ViewData["CurrentFilter"] = searchString;

            var orders = !String.IsNullOrEmpty(currentFilter) ?
                _ordersAndSalesService.Get(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                                && s.CartNumber.Equals(currentFilter))
                .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName)
                : _ordersAndSalesService.Get(s => !s.Product.ProductTypes.Equals("Expression of Interest"))
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName);

            var totalIn = orders.Count();
            ViewData["Totals"] = TransfromerManager.IntegerHuamanized(totalIn);
            ViewData["Product"] = orders.Select(s => s.Product.Name).Distinct();
            ViewData["ProductCategory"] = orders.Select(s => s.Product.ProductCategory.Name).Distinct();

            var list = orders.Select(item => new OrdersView
            {
                Id = (int)item.Id,
                Product = item.Product.Name,
                Category = item.Product.ProductCategory.Name,
                Customer = item.Person.FullName,
                CustNo = item.Person.MemberShipNo,
                Amount = TransfromerManager.DecimalHumanizedX(item.Amount),
                TransactionDate = item.AddToCartDate.ToString(),
                CartNumber = item.CartNumber,
                TransactionNumber = item.PaymentTransactionNumber,
                TransactionStatus = item.TransactionStatus,
                AddToCartDate = TransfromerManager.DateHumanized(item.AddToCartDate),
                // Date = item.OrderDate.ToString()
            })
                .ToList();

            int pageSize = 20;

            return View(PaginatedList<OrdersView>.Create(list.AsQueryable(), page ?? 1, pageSize));
        }

        public async Task<IActionResult> OnPostExport(string productCategoryName, string productName, string searchPeriod)
        {
            var sWebRootFolder = _hostingEnvironment.WebRootPath;
            var sFileName = @"OrderReport.xlsx";
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
                var excelSheet = workbook.CreateSheet(searchPeriod);
                var row = excelSheet.CreateRow(0);
                row.CreateCell(0).SetCellValue("Status");
                row.CreateCell(1).SetCellValue("Date");
                row.CreateCell(2).SetCellValue("TransactionNumber");
                row.CreateCell(3).SetCellValue("Customer");
                row.CreateCell(4).SetCellValue("Product");
                row.CreateCell(5).SetCellValue("Category");
                row.CreateCell(6).SetCellValue("Amount");
                var sn = 0;
                foreach (var item in sales)
                {
                    sn = sn + 1;
                    row = excelSheet.CreateRow(sn);
                    row.CreateCell(0).SetCellValue(item.TransactionStatus);
                    row.CreateCell(1).SetCellValue(item.AddToCartDate);
                    row.CreateCell(2).SetCellValue(item.CartNumber);
                    row.CreateCell(3).SetCellValue(item.Person.FullName);
                    row.CreateCell(4).SetCellValue(item.Product.Name);
                    row.CreateCell(5).SetCellValue(item.Product.ProductCategory.Name);
                    row.CreateCell(6).SetCellValue(item.Amount.ToString());
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
            => !string.IsNullOrEmpty(productCategoryName) && searchPeriod.Equals("lastServenDays") ?
                LastSevenDays(s => s.Product.ProductCategory.Name.Equals(productCategoryName)
                                   && s.AddToCartDate.Date > DateTime.Now.Date.AddDays(-8)) :
                string.IsNullOrEmpty(productCategoryName) && searchPeriod.Equals("lastServenDays") ? LastSevenDays()
                    :
                !string.IsNullOrEmpty(productCategoryName) && searchPeriod.Equals("lastMonth") ?
                    LastMonth(s => s.Product.ProductCategory.Name.Equals(productCategoryName)
                                         && s.AddToCartDate.Date.ToString("MM/yyyy").Equals(DateTime.Now.Date.AddMonths(-1).ToString("MM/yyyy"))) :
                    string.IsNullOrEmpty(productCategoryName) && searchPeriod.Equals("lastMonth") ? LastMonth()
                        :
                        !string.IsNullOrEmpty(productCategoryName) && searchPeriod.Equals("lastYear") ?
                            LastYear(s => s.Product.ProductCategory.Name.Equals(productCategoryName)
                                     && s.AddToCartDate.Date.ToString("yyyy").Equals(DateTime.Now.Date.AddYears(-1).ToString("yyyy"))) :
                            string.IsNullOrEmpty(productCategoryName) && searchPeriod.Equals("lastYear") ? LastYear()
                               :
                !string.IsNullOrEmpty(productCategoryName)
                ? AllTime(s => s.Product.ProductCategory.Name.Equals(productCategoryName))
                : AllTime();

        #region sales filtered report

        private IQueryable<PurchaseOrders> AllTime(Func<PurchaseOrders, bool> predicate)
        {
            return _ordersAndSalesService.Sales(predicate)
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName);
        }

        private IQueryable<PurchaseOrders> AllTime()
        {
            return _ordersAndSalesService.Sales(s => s.TransactionStatus.Equals("Succeed"))
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName);
        }

        private IQueryable<PurchaseOrders> LastYear(Func<PurchaseOrders, bool> predicate)
        {
            return _ordersAndSalesService.Sales(predicate)
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName);
        }

        private IQueryable<PurchaseOrders> LastYear()
        {
            return _ordersAndSalesService.Sales(s =>
                    s.AddToCartDate.Date.ToString("yyyy")
                           .Equals(DateTime.Now.Date.AddYears(-1).ToString("yyyy")))
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName);
        }

        private IQueryable<PurchaseOrders> LastMonth(Func<PurchaseOrders, bool> predicate)
        {
            return _ordersAndSalesService.Sales(predicate)
                .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName);
        }

        private IQueryable<PurchaseOrders> LastMonth()
        {
            return _ordersAndSalesService.Sales(s =>
                     s.AddToCartDate.Date.ToString("MM/yyyy")
                            .Equals(DateTime.Now.Date.AddMonths(-1).ToString("MM/yyyy")))
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName);
        }

        private IQueryable<PurchaseOrders> LastSevenDays(Func<PurchaseOrders, bool> predicate)
        {
            return _ordersAndSalesService
                    .Sales(predicate)
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName);
        }

        private IQueryable<PurchaseOrders> LastSevenDays()
        {
            return _ordersAndSalesService
                    .Sales(s =>
                                s.AddToCartDate.Date > DateTime.Now.Date.AddDays(-8))
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName);
        }

        #endregion sales filtered report
    }
}