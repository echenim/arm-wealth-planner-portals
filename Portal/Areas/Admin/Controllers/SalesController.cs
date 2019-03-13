using System;
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
using Portal.Domain.ViewModels;

namespace Portal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SalesController : Controller
    {
        private readonly IOrdersAndSalesManager _ordersAndSalesService;

        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ICartManager _cartManager;

        public SalesController(IOrdersAndSalesManager ordersAndSalesService,
            IHostingEnvironment hostingEnvironment, ICartManager cartManager)
        {
            _ordersAndSalesService = ordersAndSalesService;
            _hostingEnvironment = hostingEnvironment;
            _cartManager = cartManager;
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
            var list = !String.IsNullOrEmpty(searchString) ?
                _cartManager.Get(s => s.TransactionNo.Equals(long.Parse(searchString)) && s.OrderAndPurchaseStatus.Equals("Succeed"))
                : _cartManager.Get(s => s.OrderAndPurchaseStatus.Equals("Succeed")).OrderBy(s => s.OrderDate).ThenBy(s => s.ItemOwner);

            var totalIn = list.Sum(s => s.Amount);
            var countIn = list.LongCount();

            ViewData["Totals"] = TransfromerManager.DecimalHumanizedX(totalIn);
            ViewData["Counts"] = TransfromerManager.IntegerHuamanized(countIn);

            int pageSize = 20;

            return View(PaginatedList<Transactional>.Create(list.AsQueryable(), page ?? 1, pageSize));
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
                .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName)
                : _ordersAndSalesService.Sales(s => !s.Product.ProductTypes.Equals("Expression of Interest"))
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName);

            var totalIn = sales.Sum(s => s.Amount);
            var countIn = sales.LongCount();
            ViewData["Totals"] = TransfromerManager.DecimalHumanizedX(totalIn);
            ViewData["Counts"] = TransfromerManager.IntegerHuamanized(countIn);

            var groupByCartNumber = sales.GroupBy(s =>
                    new
                    {
                        CartNum = s.CartNumber,
                        Customer = s.Person.FullName,
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

            ViewData["Product"] = sales.Select(s => s.Product.Name).Distinct();
            ViewData["ProductCategory"] = sales.Select(s => s.Product.ProductCategory.Name).Distinct();

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
                .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName)
                : _ordersAndSalesService.Sales(s => s.OrderDate != null
                    && s.AddToCartDate.Date.ToString("yyyy").Equals(DateTime.Now.Date.AddYears(-1).ToString("yyyy")))
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName);

            var totalIn = sales.Sum(s => s.Amount);
            var countIn = sales.LongCount();
            ViewData["Totals"] = TransfromerManager.DecimalHumanizedX(totalIn);
            ViewData["Counts"] = TransfromerManager.IntegerHuamanized(countIn);

            var groupByCartNumber = sales.GroupBy(s =>
                    new
                    {
                        CartNum = s.CartNumber,
                        Customer = s.Person.FullName,
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
                .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName)
                : _ordersAndSalesService.Sales(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                                    && s.AddToCartDate.Date.ToString("MM/yyyy").Equals(DateTime.Now.Date.AddMonths(-1).ToString("MM/yyyy")))
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName);

            var totalIn = sales.Sum(s => s.Amount);
            var countIn = sales.LongCount();
            ViewData["Totals"] = TransfromerManager.DecimalHumanizedX(totalIn);
            ViewData["Counts"] = TransfromerManager.IntegerHuamanized(countIn);

            var groupByCartNumber = sales.GroupBy(s =>
                    new
                    {
                        CartNum = s.CartNumber,
                        Customer = s.Person.FullName,
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

            ViewData["Product"] = sales.Select(s => s.Product.Name).Distinct();
            ViewData["ProductCategory"] = sales.Select(s => s.Product.ProductCategory.Name).Distinct();

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
                .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName)
                : _ordersAndSalesService.Sales(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                                    && s.AddToCartDate.Date > DateTime.Now.Date.AddDays(-8))
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName);

            var totalIn = sales.Sum(s => s.Amount);
            var countIn = sales.LongCount();
            ViewData["Totals"] = TransfromerManager.DecimalHumanizedX(totalIn);
            ViewData["Counts"] = TransfromerManager.IntegerHuamanized(countIn);

            var groupByCartNumber = sales.GroupBy(s =>
                    new
                    {
                        CartNum = s.CartNumber,
                        Customer = s.Person.FullName,
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

            ViewData["Product"] = sales.Select(s => s.Product.Name).Distinct();
            ViewData["ProductCategory"] = sales.Select(s => s.Product.ProductCategory.Name).Distinct();

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
                .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName)
                : _ordersAndSalesService.Sales(s => !s.Product.ProductTypes.Equals("Expression of Interest"))
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName);

            var totalIn = sales.Sum(s => s.Amount);
            var countIn = sales.LongCount();
            ViewData["Totals"] = TransfromerManager.DecimalHumanizedX(totalIn);
            ViewData["Counts"] = TransfromerManager.IntegerHuamanized(countIn);

            var groupByCartNumber = sales.GroupBy(s =>
                    new
                    {
                        CartNum = s.CartNumber,
                        Customer = s.Person.FullName,
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

            ViewData["Product"] = sales.Select(s => s.Product.Name).Distinct();
            ViewData["ProductCategory"] = sales.Select(s => s.Product.ProductCategory.Name).Distinct();

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
                var excelSheet = workbook.CreateSheet(searchPeriod);
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
                    row.CreateCell(2).SetCellValue(item.Person.FullName);
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
            => !string.IsNullOrEmpty(productCategoryName) && searchPeriod.Equals("lastServenDays") ?
                LastSevenDays(s => s.TransactionStatus.Equals("Succeed") && s.Product.ProductCategory.Name.Equals(productCategoryName)
                                   && s.AddToCartDate.Date > DateTime.Now.Date.AddDays(-8)) :
                string.IsNullOrEmpty(productCategoryName) && searchPeriod.Equals("lastServenDays") ? LastSevenDays()
                    :
                !string.IsNullOrEmpty(productCategoryName) && searchPeriod.Equals("lastMonth") ?
                    LastMonth(s => s.TransactionStatus.Equals("Succeed") && s.Product.ProductCategory.Name.Equals(productCategoryName)
                                         && s.AddToCartDate.Date.ToString("MM/yyyy").Equals(DateTime.Now.Date.AddMonths(-1).ToString("MM/yyyy"))) :
                    string.IsNullOrEmpty(productCategoryName) && searchPeriod.Equals("lastMonth") ? LastMonth()
                        :
                        !string.IsNullOrEmpty(productCategoryName) && searchPeriod.Equals("lastYear") ?
                            LastYear(s => s.TransactionStatus.Equals("Succeed") && s.Product.ProductCategory.Name.Equals(productCategoryName)
                                     && s.AddToCartDate.Date.ToString("yyyy").Equals(DateTime.Now.Date.AddYears(-1).ToString("yyyy"))) :
                            string.IsNullOrEmpty(productCategoryName) && searchPeriod.Equals("lastYear") ? LastYear()
                               :
                !string.IsNullOrEmpty(productCategoryName)
                ? AllTime(s => s.TransactionStatus.Equals("Succeed") && s.Product.ProductCategory.Name.Equals(productCategoryName))
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
                   s.TransactionStatus.Equals("Succeed") && s.AddToCartDate.Date.ToString("yyyy")
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
                    s.TransactionStatus.Equals("Succeed") && s.AddToCartDate.Date.ToString("MM/yyyy")
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
                    .Sales(s => s.TransactionStatus.Equals("Succeed") &&
                                s.AddToCartDate.Date > DateTime.Now.Date.AddDays(-8))
                    .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Person.FullName);
        }

        #endregion sales filtered report
    }
}