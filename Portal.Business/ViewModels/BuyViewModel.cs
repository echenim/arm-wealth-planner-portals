using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARMClientPortal.ViewModels.DB;
using Portal.Domain.ViewModels.Client.DB;

namespace Portal.Business.ViewModels
{
    public class BuyViewModel
    {
        public Decimal TotalAmount { get; set; }
        public Dictionary<Orders, Orders> Orders { get; set; }
        //public ProcessPayments Transactions { get; set; }

        public List<ProductSummary> Summaries { get; set; }
        public Decimal TotalBalance { get; set; }
        public List<DDebit> GetDirectDebit { get; set; }

        public string Amount { get; set; }
        public DateTime StartDate { get; set; }
        public string Frequency { get; set; }
        public string ProductCode { get; set; }

        public BuyViewModel()
        {
            Orders = new Dictionary<Orders, Orders>();
            Summaries = new List<ProductSummary>();
            GetDirectDebit = new List<DDebit>();
        }
    }

    public class Investment
    {
        public Decimal TotalAmount { get; set; }
        public Dictionary<string, Decimal> Orders { get; set; }

        public Investment()
        {
            Orders = new Dictionary<string, Decimal>();
        }
    }

    public class NewInvestment
    {
        public Decimal TotalAmount { get; set; }
        public Dictionary<string, Decimal> Orders { get; set; }

        public NewInvestment()
        {
            Orders = new Dictionary<string, Decimal>();
        }
    }

    public class Buy
    {
        public Decimal TotalAmount { get; set; }
        public Dictionary<string, Decimal> Orders { get; set; }

        public Buy()
        {
            Orders = new Dictionary<string, Decimal>();
        }
    }

    public class SetUp
    {
        public string ProductCode { get; set; }
        public string Amount { get; set; }
        public DateTime StartDate { get; set; }
        public string Frequency { get; set; }
    }

    public class ProductSummary
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string Currency { get; set; }
        public Decimal AccruedInterest { get; set; }
        public Decimal CurrentBalance { get; set; }
    }

    public class Orders
    {
        public string ProductName { get; set; }
        public int Amount { get; set; }
    }

    public class Transaction
    {
        public string Action { get; set; }
        public string ArmVendorUserName { get; set; }
        public string ArmTranxID { get; set; }
        public int ArmTranxAmount { get; set; }
        public int ArmCustomerID { get; set; }
        public string ArmCustomerName { get; set; }
        public string ArmTranxCurr { get; set; }
        public string ArmTranxNotiUrl { get; set; }
        public string ArmXmlData { get; set; }
        public string ArmPaymentParams { get; set; }
        public string PaymentRequest { get; set; }
    }
}
