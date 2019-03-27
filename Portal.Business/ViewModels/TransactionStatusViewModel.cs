using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Business.ViewModels
{
    public class TransactionStatusViewModel
    {
        public int Id { get; set; }
        public string TransactionReference { get; set; }
        public string PaymentReference { get; set; }
        public decimal TransactionAmount { get; set; }
        public string TransactionStatusCode { get; set; }
        public string TransactionStatusMessage { get; set; }
        public string TransactionCurrency { get; set; }
        public string CustomerId { get; set; }
        public string PaymentParameters { get; set; }
        public DateTime DateSubmitted { get; set; }
    }
}
