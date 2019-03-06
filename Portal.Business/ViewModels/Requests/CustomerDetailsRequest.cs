using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Business.ViewModels
{
    public class CustomerDetailsRequest : BaseRequest
    {
        public string CustomerReference { get; set; }
        public string ProductCode { get; set; }
    }
}
