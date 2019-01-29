using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Portal.Areas.Admin.ViewModels;
using Portal.Business.Contracts;
using Portal.Business.Utilities;
using Portal.Domain.ViewModels;

namespace Portal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IDashBoardManager _manager;

        public DashboardController(IDashBoardManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? page
            )
        {
            ViewData["ControllerName"] = "Admin/Dashboard";

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

            var sales = ReturnSales(searchString);
            var orders = ReturnOrders(searchString);
            var expression = ReturnExpressionOfInterest(searchString);
            var customer = ReturnCustomer(searchString);

            var dashboard = new DashBoardView();
            dashboard.RecentOrders = ReturnPurchese(searchString).OrderByDescending(s => s.AddToCartDate).Take(50).ToList();
            dashboard.Customers = TransfromerManager.IntegerHuamanized(customer);
            dashboard.Sales = TransfromerManager.DecimalHumanizedX(sales);
            dashboard.Orders = TransfromerManager.IntegerHuamanized(orders);
            dashboard.ExpressionOfINterest = TransfromerManager.IntegerHuamanized(expression);

            return View(dashboard);
        }

        private IQueryable<PurchaseOrderViewModel> ReturnPurchese(string searchString)
        {
            return !String.IsNullOrEmpty(searchString) && searchString.Equals("This Month") ?
                _manager.GetRecentOrders(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                        && s.AddToCartDate.Date.ToString("MM/yyyy")
                                            .Equals(DateTime.Now.Date.ToString("MM/yyyy")))

                : !String.IsNullOrEmpty(searchString) && searchString.Equals("Last Month") ?
                    _manager.GetRecentOrders(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                            && s.AddToCartDate.Date.ToString("MM/yyyy")
                                                .Equals(DateTime.Now.Date.AddMonths(-1).ToString("MM/yyyy")))

                    : !String.IsNullOrEmpty(searchString) && searchString.Equals("This year") ?
                        _manager.GetRecentOrders(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                                && s.AddToCartDate.Date.ToString("MM/yyyy")
                                                    .Equals(DateTime.Now.Date.AddMonths(-6).ToString("MM/yyyy")))
                        : _manager.GetRecentOrders(s => !s.Product.ProductTypes.Equals("Expression of Interest"));
        }

        private decimal ReturnSales(string searchString) => !String.IsNullOrEmpty(searchString) && searchString.Equals("This Month") ?
            _manager.GetSales(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                   && s.OrderDate.HasValue && s.AddToCartDate.Date.ToString("MM/yyyy")
                                       .Equals(DateTime.Now.Date.ToString("MM/yyyy")))

            : !String.IsNullOrEmpty(searchString) && searchString.Equals("Last Month") ?
                _manager.GetSales(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                       && s.OrderDate.HasValue && s.AddToCartDate.Date.ToString("MM/yyyy")
                                           .Equals(DateTime.Now.Date.AddMonths(-1).ToString("MM/yyyy")))

                : !String.IsNullOrEmpty(searchString) && searchString.Equals("This year") ?
                    _manager.GetSales(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                           && s.OrderDate.HasValue && s.AddToCartDate.Date.ToString("MM/yyyy")
                                               .Equals(DateTime.Now.Date.AddMonths(-6).ToString("MM/yyyy")))
                    : _manager.GetSales(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                             && s.OrderDate.HasValue);

        private int ReturnOrders(string searchString)
            => !String.IsNullOrEmpty(searchString) && searchString.Equals("This Month") ?
            _manager.GetOrders(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                    && s.AddToCartDate.Date.ToString("MM/yyyy")
                                        .Equals(DateTime.Now.Date.ToString("MM/yyyy")))

            : !String.IsNullOrEmpty(searchString) && searchString.Equals("Last Month") ?
                _manager.GetOrders(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                        && s.AddToCartDate.Date.ToString("MM/yyyy")
                                            .Equals(DateTime.Now.Date.AddMonths(-1).ToString("MM/yyyy")))

                : !String.IsNullOrEmpty(searchString) && searchString.Equals("This year") ?
                    _manager.GetOrders(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                            && s.AddToCartDate.Date.ToString("MM/yyyy")
                                                .Equals(DateTime.Now.Date.AddMonths(-6).ToString("MM/yyyy")))
                    : _manager.GetOrders(s => !s.Product.ProductTypes.Equals("Expression of Interest"));

        private int ReturnExpressionOfInterest(string searchString) => !String.IsNullOrEmpty(searchString) && searchString.Equals("This Month") ?
            _manager.GetExpressionOfInterest(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                                  && s.AddToCartDate.Date.ToString("MM/yyyy")
                                                      .Equals(DateTime.Now.Date.ToString("MM/yyyy")))

            : !String.IsNullOrEmpty(searchString) && searchString.Equals("Last Month") ?
                _manager.GetExpressionOfInterest(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                                      && s.AddToCartDate.Date.ToString("MM/yyyy")
                                                          .Equals(DateTime.Now.Date.AddMonths(-1).ToString("MM/yyyy")))

                : !String.IsNullOrEmpty(searchString) && searchString.Equals("This year") ?
                    _manager.GetExpressionOfInterest(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                                          && s.AddToCartDate.Date.ToString("MM/yyyy")
                                                              .Equals(DateTime.Now.Date.AddMonths(-6).ToString("MM/yyyy")))
                    : _manager.GetExpressionOfInterest(s => !s.Product.ProductTypes.Equals("Expression of Interest"));

        private int ReturnCustomer(string searchString)
            => !String.IsNullOrEmpty(searchString) && searchString.Equals("This Month") ?
                _manager.GetCustomers(s => s.IsCustomerOrStaff.Equals("External")
                                                      && s.CustomerOnboardingDate.Date.ToString("MM/yyyy")
                                                          .Equals(DateTime.Now.Date.ToString("MM/yyyy")))

                : !String.IsNullOrEmpty(searchString) && searchString.Equals("Last Month") ?
                    _manager.GetCustomers(s => s.IsCustomerOrStaff.Equals("External")
                                                          && s.CustomerOnboardingDate.Date.ToString("MM/yyyy")
                                                              .Equals(DateTime.Now.Date.AddMonths(-1).ToString("MM/yyyy")))

                    : !String.IsNullOrEmpty(searchString) && searchString.Equals("This year") ?
                        _manager.GetCustomers(s => s.IsCustomerOrStaff.Equals("External")
                                                              && s.CustomerOnboardingDate.Date.ToString("MM/yyyy")
                                                                  .Equals(DateTime.Now.Date.AddMonths(-6).ToString("MM/yyyy")))
                        : _manager.GetCustomers(s => s.IsCustomerOrStaff.Equals("External"));
    }
}