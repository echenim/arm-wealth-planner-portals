using System;
using System.Collections.Generic;

namespace Portal.Business.ViewModels
{ 
    public class AdditionalInvRequest : BaseRequest
    {
        public string CustomerReference { get; set; }
        public string CustomerName { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }

        public List<OrderPayments> OrderPayments { get; set; }
        public List<PaymentItem> PaymentItems { get; set; }

        public AdditionalInvRequest()
        {
            OrderPayments = new List<OrderPayments>();
            PaymentItems = new List<PaymentItem>();
        }
    }

    public class OrderPayments
    {
        public string PaymentMethod { get; set; }
        public string PaymentReference { get; set; }
        public string PaymentLogId { get; set; }
        public Decimal Amount { get; set; }
        public string PaymentChannel { get; set; }
        public DateTime PaymentDate { get; set; }
        public string ReceiptNo { get; set; }
    }

    public class PaymentItem
    {
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public Decimal ItemAmount { get; set; }
    }
}
