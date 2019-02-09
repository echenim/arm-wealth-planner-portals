using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Business.ViewModels
{
    public class LastTransactionResponse
    {
        public List<LastTransactions> LastTransactions { get; set; }

        public LastTransactionResponse()
        {
            LastTransactions = new List<LastTransactions>();
        }
    }

    public class LastTransactions
    {
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public Decimal Amount { get; set; }
        public Decimal Units { get; set; }
        public Decimal UnitPrice { get; set; }
        public string FundCode { get; set; }
        public Decimal MarketValue { get; set; }
        public string Description { get; set; }
    }
}
