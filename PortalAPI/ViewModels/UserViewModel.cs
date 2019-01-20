﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalAPI.ViewModels
{
    public class UserViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AltUsername { get; set; }
        public string IsCustomerOrStaff { get; set; }
        public string MembershipNumbe { get; set; }
    }
}