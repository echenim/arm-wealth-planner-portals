using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Domain.Models;

namespace Portal.Domain.ViewModels
{
    public class CartView
    {
        public IEnumerable<Transactional> CartCollection { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total => SubTotal - Discount;
    }
}