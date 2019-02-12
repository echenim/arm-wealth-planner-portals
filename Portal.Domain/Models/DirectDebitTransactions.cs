using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Domain.Models
{
    public class DirectDebitTransactions
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public string ArmVendorUsername { get; set; }
        public string ArmCustomerId { get; set; }
        public string ArmCustomerName { get; set; }
        public decimal ArmDdAmt { get; set; }
        public DateTime ArmStartDate { get; set; }
        public string ArmFrequency { get; set; }
        public string ArmDdNotiUrl { get; set; }
        public string ArmPaymentParams { get; set; }
        public string ArmHash { get; set; }
        public string ArmXmlData { get; set; }
    }
}
