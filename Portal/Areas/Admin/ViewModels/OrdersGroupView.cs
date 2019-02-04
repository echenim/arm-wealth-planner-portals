using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Domain.Models;

namespace Portal.Areas.Admin.ViewModels
{
    public class OrdersGroupView
    {
        public string CartNumber { get; set; }
        public string TransactionStatus { get; set; }
        public string TransactionDate { get; set; }
        public string Customer { get; set; }
        public string CustNo { get; set; }
        public string TotalAmount { get; set; }
        public List<PurchaseOrders> SoldItems { get; set; }
    }
}