using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Business.ViewModels
{
    public class SalesNewCustomerResponse
    {
        public string PaymentLogId { get; set; }
        public int Status { get; set; }
        public string StatusMessage { get; set; }
        public int MembershipNumber { get; set; }
    }
}
