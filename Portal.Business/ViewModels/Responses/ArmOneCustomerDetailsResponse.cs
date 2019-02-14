using System;

namespace Portal.Business.ViewModels
{
    public class ArmOneCustomerDetailsResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public int MembershipKey { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Boolean IsAccountActivated { get; set; }
    }
}
