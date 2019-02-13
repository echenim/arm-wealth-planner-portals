using System;

namespace Portal.Domain.ViewModels
{
    public class PurchaseOrderViewModel
    {
        public long Id { get; set; }
        public string Customer { get; set; }
        public string ProductCateogry { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public string Amount { get; set; }
        public int Quantity { get; set; }
        public string CartNumber { get; set; }
        public string AddToCartDateInHuman { get; set; }
        public DateTime AddToCartDate { get; set; }
        public string PaymentTransactionNumber { get; set; }
        public string TransactionStatus { get; set; }
        public string OrderDateInHuman { get; set; }
    }
}