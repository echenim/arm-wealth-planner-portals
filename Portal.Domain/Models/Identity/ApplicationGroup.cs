using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Domain.Models.Identity
{
    public class ApplicationGroup
    {
        public ApplicationGroup()
        {
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
            Description = description.ToLower();
            Owner = owner;
        }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public string Owner { get; set; }

        public ICollection<ApplicationGroupRole> ApplicationRoles { get; set; }
        public ICollection<ApplicationUserGroup> ApplicationUsers { get; set; }
    }
}