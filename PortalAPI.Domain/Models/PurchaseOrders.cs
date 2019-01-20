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
        public DateTime OrderDate { get; set; }

        public virtual ApplicationUser Customer { get; set; }
        public virtual Products Product { get; set; }
    }
}