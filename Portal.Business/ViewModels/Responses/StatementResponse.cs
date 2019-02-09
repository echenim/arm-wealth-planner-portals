using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Business.ViewModels
{
    public class StatementResponse
    {
        public List<Transactions> Transactions { get; set; }
        public StatementResponse()
        {
            Transactions = new List<Transactions>();
        }
    }

    public class Transactions
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
