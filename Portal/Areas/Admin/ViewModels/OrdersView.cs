using System.Collections.Generic;
using Portal.Domain.Models;
using Portal.Domain.ViewModels;

namespace Portal.Areas.Admin.ViewModels
{
    public class OrdersView
    {
        public int Id { get; set; }
        public string CartNumber { get; set; }
        public string TransactionNumber { get; set; }
        public string TransactionStatus { get; set; }
        public string TransactionDate { get; set; }
        public string Customer { get; set; }
        public string CustNo { get; set; }
        public string Product { get; set; }
        public string Category { get; set; }
        public string Amount { get; set; }
        public string Date { get; set; }
        public string AddToCartDate { get; set; }
    }

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