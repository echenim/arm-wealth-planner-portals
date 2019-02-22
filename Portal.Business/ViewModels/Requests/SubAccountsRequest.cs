using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Business.ViewModels
{
    public class SubAccountsRequest : BaseRequest
    {
        public string CustomerReference { get; set; }
    }
}
