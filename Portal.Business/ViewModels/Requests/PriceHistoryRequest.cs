using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Business.ViewModels
{
    public class PriceHistoryRequest : BaseRequest
    {
        public string FundCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } 
    }
}
