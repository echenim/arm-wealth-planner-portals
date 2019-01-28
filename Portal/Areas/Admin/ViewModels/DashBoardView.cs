using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Domain.Models;

namespace Portal.Areas.Admin.ViewModels
{
    public class DashBoardView
    {
        public decimal Sales { get; set; }
        public long Orders { get; set; }
        public long Customers { get; set; }
        public long ExpressionOfINterest { get; set; }
        public List<PurchaseOrders> RecentOrders { get; set; }
    }
}