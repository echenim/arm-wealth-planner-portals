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
}
