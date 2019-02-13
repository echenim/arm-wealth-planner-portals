using System.Collections.Generic;
using Portal.Domain.ViewModels;

namespace Portal.Areas.Admin.ViewModels
{
    public class DashBoardView
    {
        public string Sales { get; set; }
        public string Orders { get; set; }
        public string Customers { get; set; }
        public string ExpressionOfINterest { get; set; }
        public List<PurchaseOrderViewModel> RecentOrders { get; set; }
    }
}