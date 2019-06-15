using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Portal.Domain.Models
{
    public class Vouchering
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(13)]
        public string VoucherCode { get; set; }

        [Required]
        [MaxLength(40)]
        public string VourcherPin { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ExpiringDate { get; set; }

        public virtual Products Product { get; set; }
    }
}