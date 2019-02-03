using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Areas.Client.ViewModels
{
    public class SummaryResponse
    {
        public Decimal TotalBalance { get; set; }
        public List<Summaries> Summaries { get; set; }

        public SummaryResponse()
        {
            Summaries = new List<Summaries>();
        }
    }

    public class Summaries
    {
        public string ProductName { get; set; }
        public string AccountName { get; set; }
        public string Currency { get; set; }
        public string AccountStatus { get; set; }
        public string ProductCode { get; set; }
        public Decimal CurrentPrice { get; set; }
        public Decimal CurUnits { get; set; }
        public Decimal MarketValue { get; set; }
        public Decimal CurrentBalance { get; set; }
        public Decimal AccruedInterest { get; set; }
        public string AccountExecutive { get; set; }
        public Decimal PendingTransaction { get; set; }
    }
}
