using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Business.ViewModels
{
    public class FeedbackResponse
    {
        public int MembershipNumber { get; set; }
        public string TrackingID { get; set; }
        public string Status { get; set; }
        public string StatusMessage { get; set; }
    }
}
