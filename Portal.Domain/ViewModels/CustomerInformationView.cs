using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain.ViewModels
{
    public class CustomerInformationView
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public string MemberShipNumber { get; set; }
        public string UserName { get; set; }
        public string AlterUserName { get; set; }
        public string Email { get; set; }
    }
}