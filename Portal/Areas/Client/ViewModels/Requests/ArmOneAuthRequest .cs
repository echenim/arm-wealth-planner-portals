using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Areas.Client.ViewModels
{
    public class ArmOneAuthRequest
    {
        public string Membershipkey { get; set; }
        public string Password { get; set; }
        public string Channel { get; set; }
        public string RedirectURL { get; set; }
    }
}
