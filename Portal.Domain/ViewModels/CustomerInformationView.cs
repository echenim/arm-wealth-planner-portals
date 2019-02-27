using System;

namespace Portal.Domain.ViewModels
{
    public class CustomerInformationView
    {
        //public string Id { get; set; }
        //public string OtherName { get; set; }
        //public string UserName { get; set; }
        //public string AlterUserName { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public string MembershipNumber { get; set; }
        public string Email { get; set; }
        public string AltUsername { get; set; }
        public Boolean IsAccountActivated { get; set; }
        public string BvnNumber { get; set; }
        public string Gender { get; set; }
    }
}