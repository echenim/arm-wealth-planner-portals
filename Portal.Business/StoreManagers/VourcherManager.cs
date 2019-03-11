using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Portal.Business.Contracts;
using Portal.Domain;
using Portal.Domain.Models;

namespace Portal.Business.StoreManagers
{
    public class VourcherManager : IVourcherManager
    {
        private readonly ApplicationDbContext _context;

        public VourcherManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public Vouchering Save(Vouchering model)
        {
            _context.Vouchering.Add(model);
            _context.SaveChanges();
            return model;
        }

        public IQueryable<Vouchering> Get(Func<Vouchering, bool> predicate = null)
            => (predicate != null
                    ? _context.Vouchering.Include(s => s.Product).Include(s => s.Product.ProductCategory).Where(predicate)
                    : _context.Vouchering.Include(s => s.Product).Include(s => s.Product.ProductCategory)
                        .OrderBy(s => s.ExpiringDate).ThenBy(s => s.VoucherCode).AsNoTracking())
                .AsQueryable();

        public Vouchering Edit(Vouchering model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return model;
        }
    }
}