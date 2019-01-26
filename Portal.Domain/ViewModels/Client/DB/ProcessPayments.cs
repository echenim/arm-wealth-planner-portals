using System;
using System.Collections.Generic;

namespace ARMClientPortal.ViewModels.DB
{
    public partial class ProcessPayments
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public string ArmVendorUserName { get; set; }
        public string ArmTranxId { get; set; }
        public string ArmTranxAmount { get; set; }
        public string ArmCustomerId { get; set; }
        public string ArmCustomerName { get; set; }
        public string ArmTranxCurr { get; set; }
        public string ArmTranxNotiUrl { get; set; }
        public string ArmXmlData { get; set; }
        public string ArmPaymentParams { get; set; }
        public string PaymentRequest { get; set; }
        public string ArmHash { get; set; }
    }
}
