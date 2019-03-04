using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Portal.Domain.Models
{
    public class MemberShip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [ForeignKey(nameof(Person))]
        public long PersonId { get; set; }

        [Required]
        [MaxLength(15)]
        public string Number { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime OnCreated { get; set; }

        public virtual Person Person { get; set; }
    }
}