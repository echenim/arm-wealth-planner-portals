using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortalAPI.Domain.Models.Identity
{
    public class ApplicationGroup
    {
        public ApplicationGroup()
        {
            Id = Guid.NewGuid().ToString().Replace("-", "");
            this.ApplicationRoles = new List<ApplicationGroupRole>();
            this.ApplicationUsers = new List<ApplicationUserGroup>();
        }

        public ApplicationGroup(string name)
            : this()
        {
            this.Name = name;
        }

        public ApplicationGroup(string name, string description)
            : this(name)
        {
            this.Description = description.ToLower();
        }

        public ApplicationGroup(string name, string description, string owner)
            : this(name)
        {
            this.Description = description.ToLower();
            this.Owner = owner;
        }

        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public string Owner { get; set; }

        public virtual ICollection<ApplicationGroupRole> ApplicationRoles { get; set; }
        public virtual ICollection<ApplicationUserGroup> ApplicationUsers { get; set; }
    }
}