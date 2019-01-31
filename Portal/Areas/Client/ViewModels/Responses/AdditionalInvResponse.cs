using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Areas.Client.ViewModels
{
    public class AdditionalInvResponse
    {
        public string PaymentLogId { get; set; }
        public int Status { get; set; }
        public string StatusMessage { get; set; }
    }
}
