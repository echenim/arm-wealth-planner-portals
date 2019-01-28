using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Portal.Business.Contracts;
using Portal.Domain;
using Portal.Domain.Models;
using Portal.Domain.Models.Identity;

namespace Portal.Business.Implementations
{
    public class DashBoardManager : IDashBoardManager
    {
        private readonly ApplicationDbContext _context;

        public DashBoardManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public int GetOrders(Func<PurchaseOrders, bool> predicate = null)
            => predicate != null ? _context.PurchaseOrders.Where(predicate).Count()
                : _context.PurchaseOrders.Count();

        public decimal GetSales(Func<PurchaseOrders, bool> predicate = null)
            => predicate != null ? _context.PurchaseOrders.Where(predicate).Sum(s => s.Amount)
                : _context.PurchaseOrders.Sum(s => s.Amount);

        public int GetExpressionOfInterest(Func<PurchaseOrders, bool> predicate = null)
            => predicate != null ? _context.PurchaseOrders.Where(predicate).Count()
                : _context.PurchaseOrders.Count();

        public int GetCustomers(Func<ApplicationUser, bool> predicate = null)
            => predicate != null ? _context.Users.Where(predicate).Count()
                : _context.PurchaseOrders.Count();

        public IQueryable<PurchaseOrders> GetRecentOrders(Func<PurchaseOrders, bool> predicate = null)
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
    }
}