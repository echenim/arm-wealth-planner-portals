using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Portal.Domain;
using Portal.Domain.Models;
using Portal.Business.Contracts;

namespace Portal.Business.StoreManagers
{
    public class OrdersAndSalesManager : IOrdersAndSalesManager
    {
        private readonly ApplicationDbContext _context;

        public OrdersAndSalesManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<PurchaseOrders> Get(Func<PurchaseOrders, bool> predicate = null)
            => predicate != null
                ? _context.PurchaseOrders
                    .Include(s => s.Person)
                    .Include(s => s.Product).Include(s => s.Product.ProductCategory)
                    .Where(predicate: predicate)
                    .AsQueryable()
                : _context.PurchaseOrders
                    .Include(s => s.Person)
                    .Include(s => s.Product).Include(s => s.Product.ProductCategory)
                    .AsQueryable();

        public IQueryable<PurchaseOrders> Sales(Func<PurchaseOrders, bool> predicate = null)
            => (predicate != null
                ? _context.PurchaseOrders
                    .Include(s => s.Person)
                    .Include(s => s.Product).Include(s => s.Product.ProductCategory)
                    .Where(predicate: predicate)
                    .AsQueryable()
                : _context.PurchaseOrders
                    .Include(s => s.Person)
                    .Include(s => s.Product).Include(s => s.Product.ProductCategory)
                    .AsQueryable()).Where(s => s.OrderDate != null
                                               && s.TransactionStatus.Equals("Succeed"));

        public PurchaseOrders FindById(Func<PurchaseOrders, bool> predicate)
            => _context.PurchaseOrders.Find(predicate);

        public PurchaseOrders Save(PurchaseOrders model)
        {
            _context.PurchaseOrders.Add(model);
            model.Id = _context.SaveChanges();
            return model;
        }

        public async void Edit(string cartId)
        {
            var sql = $"UPDATE PurchaseOrders SET TransactionStatus='Succeed' WHERE CartNumber={cartId}";
            await _context.Database.ExecuteSqlCommandAsync(sql: sql);
        }
    }
}