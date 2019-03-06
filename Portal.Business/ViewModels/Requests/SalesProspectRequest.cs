using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Business.ViewModels
{
    public class SalesProspectRequest : BaseRequest
    {
        public string Title { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string OtherNames { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public string BvnNumber { get; set; }
    }
}
