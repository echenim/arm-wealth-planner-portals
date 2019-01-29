using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Portal.Areas.Admin.ViewModels;
using Portal.Business.Contracts;

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

        public IActionResult Index()
        {
            ViewData["ControllerName"] = "Admin/Dashboard";

            var dashboard = new DashBoardView();
            dashboard.RecentOrders = _manager.GetRecentOrders().OrderByDescending(s => s.AddToCartDate).Take(20).ToList();
            dashboard.Customers = _manager.GetCustomers(s => s.IsCustomerOrStaff.Equals("External"));
            dashboard.Sales = _manager.GetSales(s => !s.Product.ProductTypes.Equals("Expression of Interest"));
            dashboard.Orders = _manager.GetOrders(s => !s.Product.ProductTypes.Equals("Expression of Interest"));
            dashboard.ExpressionOfINterest = _manager.GetExpressionOfInterest();

            return View(dashboard);
        }
    }
}