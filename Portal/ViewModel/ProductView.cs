using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Domain.Models;

namespace Portal.ViewModel
{
    public class ProductView
    {
        public Products Products { get; set; }
        public IEnumerable<Products> ProductsList { get; set; }
    }
}