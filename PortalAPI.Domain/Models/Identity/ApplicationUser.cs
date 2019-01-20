﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalAPI.Domain.Models.Identity
{
    public class ApplicationUser : IdentityUser<long>
    {
        public ApplicationUser() : base()
        {
        }

        [MaxLength(20)]
        public string UserNameAlternative { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(10)]
        public string IsCustomerOrStaff { get; set; }

        [MaxLength(20)]
        public string MembershipNumber { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}