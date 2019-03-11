using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Portal.Business.Contracts;
using Portal.Domain;
using Portal.Domain.Models;
using Portal.Domain.ViewModels;

namespace Portal.Business.StoreManagers
{
    public class CartManager : ICartManager
    {
        private readonly ApplicationDbContext _context;

        public CartManager(ApplicationDbContext context)
            => _context = context;

        public Transactional Save(Transactional model)
        {
            _context.Add(model);
            _context.SaveChanges();

            return model;
        }

        public TransQIdenfier TrnxGenerator()
        {
            var trnsIdGenerator = new TransQIdenfier();
            trnsIdGenerator.Owner = "Mark";
            _context.Add(trnsIdGenerator);
            _context.SaveChanges();

            return trnsIdGenerator;
        }

        public Transactional Edit(Transactional model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return model;
        }

        public Transactional Delete(Transactional model)
        {
            _context.Entry(model).State = EntityState.Deleted;
            _context.SaveChanges();
            return model;
        }

        public IQueryable<Transactional> Get(Func<Transactional, bool> predicate = null)
            => (predicate != null ? _context.Transactional.Include(s => s.Product).Where(predicate: predicate)
                : _context.Transactional.Include(s => s.Product).AsNoTracking()).AsQueryable();

        public CartView GetCart(Func<Transactional, bool> predicate = null)
        {
            var data = (predicate != null ? _context.Transactional.Include(s => s.Product).Where(predicate: predicate)
                : _context.Transactional.Include(s => s.Product).AsNoTracking()).AsQueryable();

            var result = new CartView();
            result.CartCollection = data.AsEnumerable();
            result.SubTotal = result.CartCollection.Where(s => s.Product.ProductTypes.Equals("Enter Amount")).Sum(s => s.Amount);
            return result;
        }

        public void CartUpdateWithEmail(string email, string session)
        {
            var commandText = $"UPDATE Transactional SET ItemOwner=@ItemOwne WHERE TransactionNo='{session}'";
            var name = new SqlParameter("@ItemOwne", email);
            _context.Database.ExecuteSqlCommand(commandText, name);
        }
    }
}