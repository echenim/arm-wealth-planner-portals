using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Domain.Models;
using Portal.Domain.ViewModels;

namespace Portal.Areas.Admin.ViewModels
{
    public class DashBoardView
    {
        public decimal Sales { get; set; }
        public long Orders { get; set; }
        public long Customers { get; set; }
        public long ExpressionOfINterest { get; set; }
        public List<PurchaseOrderViewModel> RecentOrders { get; set; }
    }
}