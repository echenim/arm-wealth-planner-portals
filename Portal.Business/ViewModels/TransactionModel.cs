using System;

namespace Portal.Business.ViewModels
{
    public class TransactionModel
    {
        public string ArmVendorUserName { get; set; }
        public string ArmTranxID { get; set; }
        public Decimal ArmTranxAmount { get; set; }
        public string ArmCustomerID { get; set; }
        public string ArmCustomerName { get; set; }
        public string ArmTranxCurr { get; set; }
        public string ArmTranxNotiUrl { get; set; }
        public string ArmXmlData { get; set; }
        public string ArmPaymentParams { get; set; }
        public string PaymentRequest { get; set; }
        public string ArmHash { get; set; }
    }

    public class DirectDebitTransactionModel
    {
        public string ArmVendorUserName { get; set; }
        public DateTime ArmStartDate { get; set; }
        public string ArmFrequency { get; set; }
        public string ArmXmlData { get; set; }
        public string ArmPaymentParams { get; set; }
        public string ArmCustomerID { get; set; }
        public string ArmCustomerName { get; set; }
        public string ArmDdNotiUrl { get; set; }
        public decimal ArmDdAmt { get; set; }
        public string ArmHash { get; set; }
    }
}