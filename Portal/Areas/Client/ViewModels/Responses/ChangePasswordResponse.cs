using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Areas.Client.ViewModels
{
    public class ChangePasswordResponse
    {
        public int MembershipKey { get; set; }
        public string Status { get; set; }
        public string StatusMessage { get; set; }
    }
}
