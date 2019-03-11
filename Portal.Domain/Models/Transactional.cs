using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Portal.Domain.Models
{
    public class Transactional
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [ForeignKey(nameof(TransQIdenfier))]
        public long TransactionNo { get; set; }

        [Required]
        public string ItemOwner { get; set; }

        [Required]
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(15)]
        public string OrderAndPurchaseStatus { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public virtual Products Product { get; set; }
        public virtual TransQIdenfier TransQIdenfier { get; set; }
    }
}