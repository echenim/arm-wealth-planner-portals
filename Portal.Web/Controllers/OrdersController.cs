﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portal.Web.ViewModels;
using PortalAPI.Midleware.Contracts;

namespace Portal.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersAndSalesService _ordersAndSalesService;

        public OrdersController(IOrdersAndSalesService ordersAndSalesService)
        {
            _ordersAndSalesService = ordersAndSalesService;
        }

        public IActionResult Index()
        {
            ViewData["ControllerName"] = "Admin/Orders";

            var list = new List<OrdersView>();
            var orders = _ordersAndSalesService.Get(s => s.Product.IsExpressionOfInterest.Equals("No"))
                .OrderByDescending(s => s.OrderDate).ThenBy(s => s.Id);

            foreach (var item in orders)
            {
                list.Add(new OrdersView
                {
                    Id = (int)item.Id,
                    Product = item.Product.Name,
                    Category = item.Product.ProductCategory.Name,
                    Customer = item.Customer.FullName,
                    CustNo = item.Customer.MembershipNumber,
                    Amount = item.Amount.ToString("N1", CultureInfo.InvariantCulture),
                    TransactionDate = item.OrderDate.ToString(),
                    CartNumber = item.CartNumber,
                    TransactionNumber = item.PaymentTransactionNumber,
                    TransactionStatus = item.TransactionStatus,
                    AddToCartDate = $"{item.AddToCartDate:dd MMM yyyy  hh:mm tt}",
                    Date = item.OrderDate.ToString()
                });
            }

            return View(list);
        }

        public IActionResult Interest()
        {
            ViewData["ControllerName"] = "Admin/Expression Of Interest";

            var list = new List<OrdersView>();
            var orders = _ordersAndSalesService.Get(s => s.Product.IsExpressionOfInterest.Equals("Yes"))
                .OrderByDescending(s => s.OrderDate).ThenBy(s => s.Id);

            foreach (var item in orders)
            {
                list.Add(new OrdersView
                {
                    Id = (int)item.Id,
                    Product = item.Product.Name,
                    Category = item.Product.ProductCategory.Name,
                    Customer = item.Customer.FullName,
                    CustNo = item.Customer.MembershipNumber,
                    Amount = item.Amount.ToString("N1", CultureInfo.InvariantCulture),
                    AddToCartDate = $"{item.AddToCartDate}",
                    Date = item.OrderDate.ToString()
                });
            }

            return View(list);
        }
    }
}