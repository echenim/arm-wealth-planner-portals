using System;
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

        public WhatYouNeedToKNowAboutThisProduct Save(WhatYouNeedToKNowAboutThisProduct model)
        {
            var modelObj = _context.WhatYouNeedToKNowAboutThisProduct.Add(model).Entity;
            _context.SaveChanges();
            return modelObj;
        }

        public ProductInvestmentInfo Save(ProductInvestmentInfo model)
        {
            var modelObj = _context.ProductInvestmentInfo.Add(model).Entity;
            _context.SaveChanges();
            return modelObj;
        }

        public Products Edit(Products model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return model;
        }

        public WhatYouNeedToKNowAboutThisProduct Edit(WhatYouNeedToKNowAboutThisProduct model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return model;
        }

        public ProductInvestmentInfo Edit(ProductInvestmentInfo model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return model;
        }

        public Products FindById(Func<Products, bool> predicate)
            => _context.Products.Find(predicate);

        public IQueryable<Products> Get(Func<Products, bool> predicate = null)
            => predicate != null
                ? _context.Products.Include(s => s.ProductCategory)
                    .Include(s => s.WhatYouNeedToKNowAboutThisProducts)
                    .Include(s => s.ProductInvestmentInfos).Where(predicate: predicate).AsQueryable()
                : _context.Products.Include(s => s.ProductCategory).Include(s => s.WhatYouNeedToKNowAboutThisProducts)
                    .Include(s => s.ProductInvestmentInfos).AsQueryable();

        public IQueryable<WhatYouNeedToKNowAboutThisProduct> Get(int productId)
            => _context.WhatYouNeedToKNowAboutThisProduct.Where(s => s.ProductId.Equals(productId)).OrderBy(s => s.Sections);

        public IQueryable<ProductInvestmentInfo> GetInvestmentInfo(int productId)
            => _context.ProductInvestmentInfo.Where(s => s.ProductId.Equals(productId)).OrderBy(s => s.Sections);

        public Products Delete(Products model)
        {
            _context.Entry(model).State = EntityState.Deleted;
            _context.SaveChanges();
            return model;
        }
    }
}