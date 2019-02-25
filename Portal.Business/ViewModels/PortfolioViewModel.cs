using System;
using System.Collections.Generic;
using Portal.Domain.Models;

namespace Portal.Business.ViewModels
{
    public class PortfolioViewModel
    {
        public DateTime? ArmStartDate { get; set; }
        public DateTime? ArmEndDate { get; set; }
        public string ArmTransactionType { get; set; }
        public string ArmProductCode { get; set; }
    }

    public class AccountStatementViewModel
    {
        public string ProductCode { get; set; }
        public string TransactionType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ProductName { get; set; }

        public List<ProductItems> SelectProductName { get; set; }
        public List<ProductTransactions> Transactions { get; set; }
        public ProductDetails ProductDetails { get; set; }
        public List<ProductDetails> Summaries { get; set; }
        public Decimal TotalBalance { get; set; }
        public Dictionary<string, string> Products { get; set; }

        public CustomerDetail CustomerDetails { get; set; }

        public ProcessPayments ProcessPayments { get; set; }
        //public DirectDebitTransactions DirectDebit { get; set; }

        //PrintStatement
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string CurrentTimeStamp { get; set; }

        //Redemption
        public string Otp { get; set; }
        public Decimal TotalAmount { get; set; }
        public string Reason { get; set; }
        public string ReasonOthers { get; set; }
        public List<RedemptionProduct> Product { get; set; }

        public AccountStatementViewModel()
        {
            SelectProductName = new List<ProductItems>();
            Transactions = new List<ProductTransactions>();
            ProductDetails = new ProductDetails();
            Summaries = new List<ProductDetails>();
            Product = new List<RedemptionProduct>();
            CustomerDetails = new CustomerDetail();
        }
    }

    public class FamilyAccountsViewModel
    {
        public string StatusMessage { get; set; }
        public int Status { get; set; }
        public List<AccountDetail> AccountDetails { get; set; }

        public FamilyAccountsViewModel()
        {
            AccountDetails = new List<AccountDetail>();
        }
    }

    public class PrintPDF
    {
        public string productCode { get; set; }
        public string transactionType { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
    }

    public class ProductItems
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
    }

    public class ProductDetails
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string Currency { get; set; }
        public Decimal AccruedInterest { get; set; }
        public Decimal CurrentBalance { get; set; }
        public Decimal PendingTransaction { get; set; }
    }

    public class ProductTransactions
    {
        public Decimal MarketValue { get; set; }
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public Decimal Amount { get; set; }
        public Decimal Units { get; set; }
        public Decimal UnitPrice { get; set; }
        public string FundCode { get; set; }
    }


}
