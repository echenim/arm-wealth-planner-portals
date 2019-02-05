using System;
using System.Linq;
using Portal.Business.Contracts;
using Portal.Domain;
using Portal.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Portal.Business.StoreManagers
{
    public class ProductKeyBenefitManager : IProductKeyBenefitManager
    {
        private readonly ApplicationDbContext _context;

        public ProductKeyBenefitManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public ProductKeyBenefit Save(ProductKeyBenefit model)
        {
            _context.ProductKeyBenefit.Add(model);
            model.Id = _context.SaveChanges();
            return model;
        }

        public ProductKeyBenefit Edit(ProductKeyBenefit model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return model;
        }

        public ProductKeyBenefit FindById(Func<ProductKeyBenefit, bool> predicate)
            => _context.ProductKeyBenefit.Find(predicate);

        public IQueryable<ProductKeyBenefit> Get(Func<ProductKeyBenefit, bool> predicate = null)
            => predicate != null
                ? _context.ProductKeyBenefit.Where(predicate: predicate).AsQueryable()
                : _context.ProductKeyBenefit.AsQueryable();

        public ProductKeyBenefit Delete(ProductKeyBenefit model)
        {
            _context.Entry(model).State = EntityState.Deleted;
            _context.SaveChanges();
            return model;
        }
    }
}