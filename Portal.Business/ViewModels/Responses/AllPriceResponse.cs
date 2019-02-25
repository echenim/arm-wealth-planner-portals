using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Business.ViewModels
{
    public class AllPriceResponse
    {
        public List<Price> Prices { get; set; }

        public AllPriceResponse()
        {
            Prices = new List<Price>();
        }
    }

    public class Price
    {
        public string FundName { get; set; }
        public string FundCode { get; set; }
        public decimal BidPrice { get; set; }
        public decimal OfferPrice { get; set; }
        public decimal NavPrice { get; set; }
        public DateTime PriceDate { get; set; }
        public decimal PercentageIncrease { get; set; }
        public string ChangeStatus { get; set; }
    }
}
