using System;

namespace Portal.Domain.Models
{
    public partial class DirectDebit
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public string ArmVendorUserName { get; set; }
        public int ArmCustomerId { get; set; }
        public string ArmCustomerName { get; set; }
        public int ArmDdAmt { get; set; }
        public DateTime ArmStartDate { get; set; }
        public string ArmFrequency { get; set; }
        public string ArmTranxNotiUrl { get; set; }
        public string ArmPaymentParams { get; set; }
        public string ArmHash { get; set; }
    }
}
