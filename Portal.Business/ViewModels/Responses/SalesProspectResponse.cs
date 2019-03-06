using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Business.ViewModels
{
    public class SalesProspectResponse
    {
        public int ProspectCode { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
    }
}
