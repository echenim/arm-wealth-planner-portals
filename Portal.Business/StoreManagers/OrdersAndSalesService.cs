using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Portal.Domain;
using Portal.Domain.Models;
using Portal.Business.Contracts;

namespace Portal.Business.Implementations
{
    public class OrdersAndSalesService : IOrdersAndSalesService
    {
        private readonly ApplicationDbContext _context;

        public OrdersAndSalesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<PurchaseOrders> Get(Func<PurchaseOrders, bool> predicate = null)
            => predicate != null
                ? _context.PurchaseOrders
                    .Include(s => s.Customer)
                    .Include(s => s.Product).Include(s => s.Product.ProductCategory)
                    .Where(predicate: predicate)
                    .AsQueryable()
                : _context.PurchaseOrders
                    .Include(s => s.Customer)
                    .Include(s => s.Product).Include(s => s.Product.ProductCategory)
                    .AsQueryable();

        public PurchaseOrders FindById(Func<PurchaseOrders, bool> predicate)
            => _context.PurchaseOrders.Find(predicate);

        public PurchaseOrders Save(PurchaseOrders model)
        {
            _context.PurchaseOrders.Add(model);
            model.Id = _context.SaveChanges();
            return model;
        }
    }
}