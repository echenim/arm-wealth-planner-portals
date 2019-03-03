using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Portal.Domain.Models.Identity;

namespace Portal.Domain.Models
{
    public class PurchaseOrders
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [ForeignKey(nameof(Person))]
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

        public string OrderDate { get; set; }

        public virtual Person Person { get; set; }
        public virtual Products Product { get; set; }
    }
}