using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Domain.Models;

namespace Portal.ViewModel
{
    public class ProductsAndProductsItem
    {
        public Products ProductsObj { get; set; }
        public List<ProductsAndItems> Items { get; set; }
    }

    public class ProductsAndItems
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}