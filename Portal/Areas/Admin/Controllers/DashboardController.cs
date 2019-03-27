﻿using System;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.Areas.Admin.ViewModels;
using Portal.Business.Contracts;
using Portal.Business.Utilities;
using Portal.Domain.Models;
using Portal.Domain.ViewModels;

namespace Portal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly ICartManager _manager;
        private readonly IPersonManager _personManager;

        public DashboardController(ICartManager manager, IPersonManager personManager)
        {
            _manager = manager;
            _personManager = personManager;
        }

        [Authorize]
        public IActionResult Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? page
            )
        {
            ViewData["ControllerName"] = "ADMIN/DASHBOARD";

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
            //var expression = ReturnExpressionOfInterest(searchString);
            var customer = ReturnCustomer(searchString);

            var dashboard = new DashBoardView();
            dashboard.RecentOrders = ReturnPurchese(searchString).OrderByDescending(s => s.OrderDate).Take(50).ToList();
            dashboard.Customers = TransfromerManager.IntegerHuamanized(customer);
            dashboard.Sales = TransfromerManager.DecimalHumanizedX(sales);
            dashboard.Orders = TransfromerManager.IntegerHuamanized(orders);
            // dashboard.ExpressionOfINterest = TransfromerManager.IntegerHuamanized(expression);

            return View(dashboard);
        }

        /// <summary>
        /// return order purhes by using an inline if-else to filter data
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        private IQueryable<Transactional> ReturnPurchese(string searchString)
            => !String.IsNullOrEmpty(searchString) && searchString.Equals("This Month") ?
            _manager.Get(s => s.OrderDate.Date.ToString("MM/yyyy")
                                              .Equals(DateTime.Now.Date.ToString("MM/yyyy")))
            : !String.IsNullOrEmpty(searchString) && searchString.Equals("Last Month") ?
                _manager.Get(s => s.OrderDate.Date.ToString("MM/yyyy")
                                                  .Equals(DateTime.Now.Date.AddMonths(-1).ToString("MM/yyyy")))
            : !String.IsNullOrEmpty(searchString) && searchString.Equals("This year") ?
                    _manager.Get(s => s.OrderDate.Date.ToString("yyyy")
                                                      .Equals(DateTime.Now.Date.ToString("yyyy")))
                    : _manager.Get();

        /// <summary>
        /// return sales by using inline if-else to perform filter
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        private decimal ReturnSales(string searchString)
            => !String.IsNullOrEmpty(searchString) && searchString.Equals("This Month") ?
            _manager.Get(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                   && s.OrderDate != null && s.OrderDate.Date.ToString("MM/yyyy")
                                       .Equals(DateTime.Now.Date.ToString("MM/yyyy"))).Select(s => s.Amount).Sum()
            : !String.IsNullOrEmpty(searchString) && searchString.Equals("Last Month") ?
                _manager.Get(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                       && s.OrderDate != null && s.OrderDate.Date.ToString("MM/yyyy")
                                           .Equals(DateTime.Now.Date.AddMonths(-1).ToString("MM/yyyy"))).Select(s => s.Amount).Sum()
                : !String.IsNullOrEmpty(searchString) && searchString.Equals("This year") ?
                    _manager.Get(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                           && s.OrderDate != null && s.OrderDate.Date.ToString("yyyy")
                                               .Equals(DateTime.Now.Date.ToString("yyyy"))).Select(s => s.Amount).Sum()
                    : _manager.Get(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                             && s.OrderDate != null).Select(s => s.Amount).Sum();

        /// <summary>
        /// return orders by using an inline if-else to filter data
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        private int ReturnOrders(string searchString)
            => !String.IsNullOrEmpty(searchString) && searchString.Equals("This Month") ?
            _manager.Get(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                    && s.OrderDate.Date.ToString("MM/yyyy")
                                        .Equals(DateTime.Now.Date.ToString("MM/yyyy"))).Count()

            : !String.IsNullOrEmpty(searchString) && searchString.Equals("Last Month") ?
                _manager.Get(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                        && s.OrderDate.Date.ToString("MM/yyyy")
                                            .Equals(DateTime.Now.Date.AddMonths(-1).ToString("MM/yyyy"))).Count()

                : !String.IsNullOrEmpty(searchString) && searchString.Equals("This year") ?
                    _manager.Get(s => !s.Product.ProductTypes.Equals("Expression of Interest")
                                            && s.OrderDate.Date.ToString("MM/yyyy")
                                                .Equals(DateTime.Now.Date.AddMonths(-6).ToString("MM/yyyy"))).Count()
                    : _manager.Get(s => !s.Product.ProductTypes.Equals("Expression of Interest")).Count();

        /// <summary>
        /// return expresion of interest by using an inline if-else to filter data
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        //private int ReturnExpressionOfInterest(string searchString)
        //    => !String.IsNullOrEmpty(searchString) && searchString.Equals("This Month") ?
        //    _manager.Get(s => !s.Product.ProductTypes.Equals("Expression of Interest")
        //                                          && s.AddToCartDate.Date.ToString("MM/yyyy")
        //                                              .Equals(DateTime.Now.Date.ToString("MM/yyyy")))
        //    : !String.IsNullOrEmpty(searchString) && searchString.Equals("Last Month") ?
        //        _manager.GetExpressionOfInterest(s => !s.Product.ProductTypes.Equals("Expression of Interest")
        //                                              && s.AddToCartDate.Date.ToString("MM/yyyy")
        //                                                  .Equals(DateTime.Now.Date.AddMonths(-1).ToString("MM/yyyy")))
        //        : !String.IsNullOrEmpty(searchString) && searchString.Equals("This year") ?
        //            _manager.GetExpressionOfInterest(s => !s.Product.ProductTypes.Equals("Expression of Interest")
        //                                                  && s.AddToCartDate.Date.ToString("yyyy")
        //                                                      .Equals(DateTime.Now.Date.ToString("yyyy")))
        //            : _manager.GetExpressionOfInterest(s => !s.Product.ProductTypes.Equals("Expression of Interest"));

        /// <summary>
        /// return customer by using an inline if-else to filter data
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        private int ReturnCustomer(string searchString)
            => !String.IsNullOrEmpty(searchString) && searchString.Equals("This Month") ?
                _personManager.Get(s => s.OnCreated.Date.ToString("MM/yyyy")
                                                          .Equals(DateTime.Now.Date.ToString("MM/yyyy"))).Count()
                : !String.IsNullOrEmpty(searchString) && searchString.Equals("Last Month") ?
                    _personManager.Get(s => s.OnCreated.Date.ToString("MM/yyyy")
                                                              .Equals(DateTime.Now.Date.AddMonths(-1).ToString("MM/yyyy"))).Count()
                    : !String.IsNullOrEmpty(searchString) && searchString.Equals("This year") ?
                        _personManager.Get(s => s.OnCreated.Date.ToString("yyyy")
                                                                  .Equals(DateTime.Now.Date.ToString("yyyy"))).Count()
                        : _personManager.Get().Count();
    }
}