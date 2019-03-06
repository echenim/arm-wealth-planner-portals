using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Portal.Domain.Models
{
    public class Referrer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [ForeignKey(nameof(Person))]
        public long PersonId { get; set; }

        [Required]
        [EmailAddress]
        public string ReferrerEmail { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime OnCreated { get; set; }

        public virtual Person Person { get; set; }
    }
}