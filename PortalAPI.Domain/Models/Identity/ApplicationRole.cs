﻿using Microsoft.AspNetCore.Identity;

namespace PortalAPI.Domain.Models.Identity
{
    public class ApplicationRole : IdentityRole<long>
    {
        public ApplicationRole() : base()
        {
        }

        public ApplicationRole(string rolename) : base(rolename)
        {
        }

        public ApplicationRole(string rolename, string description, string creationDate) : base(rolename)
        {
        }
    }
}