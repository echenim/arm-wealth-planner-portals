using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Domain.Models.Identity
{
    public class ApplicationUser : IdentityUser<long>
    {
        public ApplicationUser() : base()
        {
        }

        [Required]
        [ForeignKey(nameof(Person))]
        public long PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}