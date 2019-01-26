using System;
using System.Linq;
using Portal.Business.Contracts;
using Portal.Domain;
using Portal.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Portal.Business.Implementations
{
    public class ProductPerformanceService : IProductPerformanceService
    {
        private readonly ApplicationDbContext _context;

        public ProductPerformanceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ProductPerformance Save(ProductPerformance model)
        {
            _context.ProductPerformance.Add(model);
            model.Id = _context.SaveChanges();
            return model;
        }

        public ProductPerformance Edit(ProductPerformance model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return model;
        }

        public ProductPerformance FindById(Func<ProductPerformance, bool> predicate)
            => _context.ProductPerformance.Find(predicate);

        public IQueryable<ProductPerformance> Get(Func<ProductPerformance, bool> predicate = null)
            => predicate != null
                ? _context.ProductPerformance.Where(predicate: predicate).AsQueryable()
                : _context.ProductPerformance.AsQueryable();

        public ProductPerformance Delete(ProductPerformance model)
        {
            _context.Entry(model).State = EntityState.Deleted;
            _context.SaveChanges();
            return model;
        }
    }
}