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
            dashboard.RecentOrders = _manager.GetRecentOrders().Take(20).ToList();
            dashboard.Customers = _manager.GetCustomers();
            dashboard.Sales = _manager.GetSales();
            dashboard.Orders = _manager.GetOrders();
            dashboard.ExpressionOfINterest = _manager.GetExpressionOfInterest();

            return View(dashboard);
        }
    }
}