using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Business.ViewModels
{
    public class PriceHistoryResponse
    {
        public List<Price> Prices { get; set; }

        public PriceHistoryResponse()
        {
            Prices = new List<Price>();
        }
    }

    public class FundPrices
    {
        public List<FactFundPrice> FundPrice { get; set; }

        public FundPrices()
        {
            FundPrice = new List<FactFundPrice>();
        }
    }

    public class FactFundPrice
    {
        public int PriceKey { get; set; }
        public int ProductKey { get; set; }
        public decimal BidPrice { get; set; }
        public decimal OfferPrice { get; set; }
        public decimal NavPrice { get; set; }
        public DateTime PriceDate { get; set; }
        public string ProductCode { get; set; }
    }
}
