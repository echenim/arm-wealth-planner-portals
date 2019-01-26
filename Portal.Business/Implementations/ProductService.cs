using System;
using System.Linq;
using Portal.Business.Contracts;
using Portal.Domain;
using Portal.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Portal.Business.Implementations
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Products Save(Products model)
        {
            _context.Products.Add(model);
            model.Id = _context.SaveChanges();
            return model;
        }

        public Products Edit(Products model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return model;
        }

        public Products FindById(Func<Products, bool> predicate)
            => _context.Products.Find(predicate);

        public IQueryable<Products> Get(Func<Products, bool> predicate = null)
            => predicate != null
                ? _context.Products.Include(s => s.ProductCategory).Where(predicate: predicate).AsQueryable()
                : _context.Products.Include(s => s.ProductCategory).AsQueryable();

        public Products Delete(Products model)
        {
            _context.Entry(model).State = EntityState.Deleted;
            _context.SaveChanges();
            return model;
        }
    }
}