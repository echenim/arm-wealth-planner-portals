using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain.ViewModels
{
    public class CartModelView
    {
        public int Id { get; set; }
        public string CartNumber { get; set; }
        public string TransactionNumber { get; set; }
        public string TransactionStatus { get; set; }
        public string TransactionDate { get; set; }
        public string Customer { get; set; }
        public long CustomerId { get; set; }
        public string CustNo { get; set; }
        public string Product { get; set; }
        public string Category { get; set; }

        public string Amount { get; set; }
        public string AddToCartDate { get; set; }
    }
}