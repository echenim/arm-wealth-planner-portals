using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain.ViewModels
{
    public class KycStatus
    {
        public string Email { get; set; }
        public string MembershipNumber { get; set; }
        public bool Status { get; set; }
    }
}