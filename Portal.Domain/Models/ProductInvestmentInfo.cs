using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Portal.Domain.Models
{
    public class ProductInvestmentInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Products))]
        public int ProductId { get; set; }

        [Required]
        public string Sections { get; set; }

        [Required]
        public string Abs { get; set; }

        public string RangOrCost { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime OnCreated { get; set; }

        public Products Products { get; set; }
    }
}