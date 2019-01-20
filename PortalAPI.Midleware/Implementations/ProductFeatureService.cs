using System;
using System.Linq;
using PortalAPI.Midleware.Contracts;
using PortalAPI.Domain;
using PortalAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace PortalAPI.Midleware.Implementations
{
    public class ProductFeatureService : IProductFeatureService
    {
        private readonly ApplicationDbContext _context;

        public ProductFeatureService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ProductFeatures Save(ProductFeatures model)
        {
            _context.ProductFeatures.Add(model);
            model.Id = _context.SaveChanges();
            return model;
        }

        public ProductFeatures Edit(ProductFeatures model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return model;
        }

        public ProductFeatures FindById(Func<ProductFeatures, bool> predicate)
            => _context.ProductFeatures.Find(predicate);

        public IQueryable<ProductFeatures> Get(Func<ProductFeatures, bool> predicate = null)
            => predicate != null
                ? _context.ProductFeatures.Where(predicate: predicate).AsQueryable()
                : _context.ProductFeatures.AsQueryable();

        public ProductFeatures Delete(ProductFeatures model)
        {
            _context.Entry(model).State = EntityState.Deleted;
            _context.SaveChanges();
            return model;
        }
    }
}