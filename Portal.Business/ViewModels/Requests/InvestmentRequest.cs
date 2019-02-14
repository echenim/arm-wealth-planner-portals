using System.Collections.Generic;

namespace Portal.Business.ViewModels
{
    public class InvestmentRequest : BaseRequest
    {
        public int CustomerReference { get; set; }
        public string CustomerName { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public List<PaymentItems> PaymentItems { get; set; }
        public OrderPayment OrderPayment { get; set; }

        public InvestmentRequest()
        {
            PaymentItems = new List<PaymentItems>();
            OrderPayment = new OrderPayment();
        }
    }

    public class PaymentItems
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal ItemAmount { get; set; }
    }

    public class OrderPayment
    {
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentLogId { get; set; }
        public string PaymentReference { get; set; }
    }
}
