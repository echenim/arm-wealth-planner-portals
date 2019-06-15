using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Business.ViewModels
{
    public class PriceHistoryResponse
    {
        [JsonProperty("Prices")]
        public List<Price> Prices { get; set; }

        public PriceHistoryResponse()
        {
            Prices = new List<Price>();
        }
    }

    public class FundPrices
    {
        [JsonProperty("FundPrice")]
        public List<FactFundPrice> FundPrice { get; set; }

        public FundPrices()
        {
            FundPrice = new List<FactFundPrice>();
        }
    }

    public class FactFundPrice
    {
        [JsonProperty("PriceKey")]
        public int PriceKey { get; set; }

        [JsonProperty("ProducteKey")]
        public int ProductKey { get; set; }

        [JsonProperty("BidPrice")]
        public decimal BidPrice { get; set; }

        [JsonProperty("OfferPrice")]
        public decimal OfferPrice { get; set; }

        [JsonProperty("NavPrice")]
        public decimal NavPrice { get; set; }

        [JsonProperty("PriceDate")]
        public DateTime PriceDate { get; set; }

        [JsonProperty("ProductCode")]
        public string ProductCode { get; set; }
    }
}
