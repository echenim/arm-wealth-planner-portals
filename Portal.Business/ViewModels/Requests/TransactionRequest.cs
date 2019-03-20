using System;
using System.Collections.Generic;

namespace Portal.Business.ViewModels
{
    public class TransactionRequest : BaseRequest
    {
        public string CustomerReference { get; set; }
        public string CustomerName { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public List<paymentItems> PaymentItems { get; set; }
        public orderPayment OrderPayment { get; set; }

        public TransactionRequest()
        {
            PaymentItems = new List<paymentItems>();
            OrderPayment = new orderPayment();
        }
    }

    public class paymentItems
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public Decimal ItemAmount { get; set; }
    }

    public class orderPayment
    {
        public Decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentLogId { get; set; }
        public string PaymentReference { get; set; }
    }
}