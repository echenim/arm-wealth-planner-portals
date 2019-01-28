using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Portal.Areas.Admin.ViewModels;
using Portal.Business.Contracts;

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

        public IActionResult Index()
        {
            ViewData["ControllerName"] = "Admin/Orders";

            var list = new List<OrdersView>();
            var orders = _ordersAndSalesService.Get(s => s.Product.ProductTypes.Equals("Enter Amount")
                        || s.Product.ProductTypes.Equals("Fixed Amount"))
                .OrderByDescending(s => s.AddToCartDate).ThenBy(s => s.Customer);

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
            var orders = _ordersAndSalesService.Get(s => s.Product.ProductTypes.Equals("Expression of Interest"))
                .OrderByDescending(s => s.OrderDate).ThenBy(s => s.Customer);

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