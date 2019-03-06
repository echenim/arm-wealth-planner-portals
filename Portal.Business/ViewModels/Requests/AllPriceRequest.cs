using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Business.ViewModels
{
    public class AllPriceRequest : BaseRequest
    {
        public DateTime PriceDate { get; set; }
    }
}
