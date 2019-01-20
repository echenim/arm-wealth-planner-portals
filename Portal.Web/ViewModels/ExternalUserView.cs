using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Web.ViewModels
{
    public class ExternalUserView
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string MembershipNumber { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string AltUserName { get; set; }
    }
}