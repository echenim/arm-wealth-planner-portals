using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Business.ViewModels
{
    public class YieldHistoryResponse
    {
        public List<Yields> Yield { get; set; }

        public YieldHistoryResponse()
        {
            Yield = new List<Yields>();
        }
    }

    public class Yields
    {
        public string FundName { get; set; }
        public string FundCode { get; set; }
        public decimal EffectiveYield { get; set; }
        public DateTime PriceDate { get; set; }
    }
}
