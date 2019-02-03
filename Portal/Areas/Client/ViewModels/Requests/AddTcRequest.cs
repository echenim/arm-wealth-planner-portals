using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Areas.Client.ViewModels
{
    public class AddTcRequest : BaseRequest
    {
        public int MembershipKey { get; set; }
        public bool IsTcAgreed { get; set; }
    }
}
