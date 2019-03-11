using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Domain.Models;

namespace Portal.Domain.ViewModels
{
    public class CartDetailView
    {
        public IQueryable<Transactional> ItemsInCart { get; set; }
        public long ItemCount => ItemsInCart.Count();
    }
}