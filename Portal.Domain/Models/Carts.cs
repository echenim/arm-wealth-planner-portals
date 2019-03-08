using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Portal.Domain.Models
{
    public class Carts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string Identifier { get; set; }

        [Required]
        [ForeignKey(nameof(Products))]
        public int ProductId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(8)]
        public string Status { get; set; }

        [Required]
        public DateTime OnCartDateTime { get; set; }

        public virtual Products Products { get; set; }
    }
}