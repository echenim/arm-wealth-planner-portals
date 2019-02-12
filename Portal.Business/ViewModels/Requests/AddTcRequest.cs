using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Business.ViewModels
{
    public class AddTcRequest : BaseRequest
    {
        public int MembershipKey { get; set; }
        public bool IsTcAgreed { get; set; }
    }
}
