using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Business.ViewModels
{
    public class SubAccountsResponse
    {
        public string CustomerReference { get; set; }
        public string StatusMessage { get; set; }
        public int Status { get; set; }
        public List<AccountDetail> AccountDetails { get; set; }

        public SubAccountsResponse()
        {
            AccountDetails = new List<AccountDetail>();
        }
    }

    public class AccountDetail
    {
        public string AccountName { get; set; }
        public string RmName { get; set; }
        public string CurrencySymbol { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string CompanyName { get; set; }
        public string CustomerName { get; set; }
        public string AccountType { get; set; }
        public string MembershipNumber { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal AccruedInterest { get; set; }
    }
}
