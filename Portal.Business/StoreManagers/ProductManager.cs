﻿using System;
using System.Linq;
using Portal.Business.Contracts;
using Portal.Domain;
using Portal.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Portal.Business.StoreManagers
{
    public class ProductManager : IProductManager
    {
        private readonly ApplicationDbContext _context;

        public ProductManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public Products Save(Products model)
        {
            var r = _context.Products.Add(model).Entity;
            _context.SaveChanges();
            return r;
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