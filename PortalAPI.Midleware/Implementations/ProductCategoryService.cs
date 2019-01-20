using System;
using System.Linq;
using PortalAPI.Midleware.Contracts;
using PortalAPI.Domain;
using PortalAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace PortalAPI.Midleware.Implementations
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly ApplicationDbContext _context;

        public ProductCategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ProductCategory Save(ProductCategory model)
        {
            _context.ProductCategory.Add(model);
            model.Id = _context.SaveChanges();
            return model;
        }

        public ProductCategory Edit(ProductCategory model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return model;
        }

        public ProductCategory FindById(Func<ProductCategory, bool> predicate)
            => _context.ProductCategory.Find(predicate);

        public IQueryable<ProductCategory> Get(Func<ProductCategory, bool> predicate = null)
            => predicate != null
                ? _context.ProductCategory.Where(predicate: predicate).AsQueryable()
                : _context.ProductCategory.AsQueryable();

        public ProductCategory Delete(ProductCategory model)
        {
            _context.Entry(model).State = EntityState.Deleted;
            _context.SaveChanges();
            return model;
        }
    }
}