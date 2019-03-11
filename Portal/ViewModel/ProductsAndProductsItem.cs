using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Portal.Domain.Models;

namespace Portal.ViewModel
{
    public class ProductsAndProductsItem
    {
        public int ProductId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ProductName { get; set; }
        public string State { get; set; }

        public Products ProductsObj { get; set; }
        public List<ProductsAndItems> Items { get; set; }
    }

    public class ProductsAndItems
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CartItems
    {
        public long Id { get; set; }

        [Required]
        public string IpIdentifier { get; set; }

        public string EmailIdentifier { get; set; }

        public int ProductId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
    }
}