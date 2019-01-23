using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using PortalAPI.Domain.Models.Identity;

namespace PortalAPI.Domain.Models
{
    public class PurchaseOrders
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [ForeignKey(nameof(Customer))]
        public long CustomerId { get; set; }

        [Required]
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [MaxLength(40)]
        public string CartNumber { get; set; }

        [Required]
        public DateTime AddToCartDate { get; set; }

        [MaxLength(150)]
        public string PaymentTransactionNumber { get; set; }

        [Required]
        [MaxLength(15)]
        public string TransactionStatus { get; set; }

        public DateTime? OrderDate { get; set; }

        public virtual ApplicationUser Customer { get; set; }
        public virtual Products Product { get; set; }
    }
}