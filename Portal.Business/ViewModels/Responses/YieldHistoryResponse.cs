using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Business.ViewModels
{
    public class YieldHistoryResponse
    {
        public List<Yields> Yields { get; set; }

        public YieldHistoryResponse()
        {
            Yields = new List<Yields>();
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
