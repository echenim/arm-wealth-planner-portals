using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Areas.Client.ViewModels
{
    public class LastTransactionRequest : BaseRequest
    {
        public int MembershipNumber { get; set; }
        public string ProductCode { get; set; }
        public int Count { get; set; }
    }
}
