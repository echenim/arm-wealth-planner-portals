using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARMClientPortal.ViewModels
{
    public class TotalBalanceRequest : BaseRequest
    {
        public int MembershipNumber { get; set; }
    }
}
