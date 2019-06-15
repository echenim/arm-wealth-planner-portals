using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Business.ViewModels
{
    public class YieldHistoryResponse
    {
        [JsonProperty("Yields")]
        public List<Yields> Yields { get; set; }

        public YieldHistoryResponse()
        {
            Yields = new List<Yields>();
        }
    }

    public class Yields
    {
        [JsonProperty("FundName")]
        public string FundName { get; set; }

        [JsonProperty("FundCode")]
        public string FundCode { get; set; }

        [JsonProperty("EffectiveYield")]
        public decimal EffectiveYield { get; set; }

        [JsonProperty("PriceDate")]
        public DateTime PriceDate { get; set; }
    }
}
