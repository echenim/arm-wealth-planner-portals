using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain.ViewModels
{
    public class PersonView
    {
        public long Id { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public string Tel { get; set; }

        public string Address { get; set; }

        public string BioetricVerificationNumber { get; set; }

        public bool IsCustomer { get; set; }

        public string PortalOnBoarding { get; set; }

        public DateTime OnCreated { get; set; }

        public string FullName { get; set; }
        public string MembershipNo { get; set; }
    };
}