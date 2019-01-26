using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARMClientPortal.ViewModels
{
    public class TrackServiceRequest : BaseRequest
    {
        public int MembershipNumber { get; set; }
        public string TrackingNumber { get; set; }
        public string RequestType { get; set; }
    }
}
