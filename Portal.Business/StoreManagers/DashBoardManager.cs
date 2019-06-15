//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.EntityFrameworkCore;
//using Portal.Business.Contracts;
//using Portal.Business.Utilities;
//using Portal.Domain;
//using Portal.Domain.Models;
//using Portal.Domain.Models.Identity;
//using Portal.Domain.ViewModels;

//namespace Portal.Business.StoreManagers
//{
//    public class DashBoardManager : IDashBoardManager
//    {
//        private readonly ApplicationDbContext _context;

//        public DashBoardManager(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public int GetOrders(Func<Transactional, bool> predicate = null)
//            => predicate != null ? _context.PurchaseOrders.Include(s => s.Product).Where(predicate).Count()
//                : _context.PurchaseOrders.Include(s => s.Product).Count();

//        public decimal GetSales(Func<Transactional, bool> predicate = null)
//            => predicate != null ? _context.PurchaseOrders.Include(s => s.Product).Where(predicate).Sum(s => s.Amount)
//                : _context.PurchaseOrders.Include(s => s.Product).Sum(s => s.Amount);

//        public int GetExpressionOfInterest(Func<Transactional, bool> predicate = null)
//            => predicate != null ? _context.PurchaseOrders.Include(s => s.Product).Where(predicate).Count()
//                : _context.PurchaseOrders.Include(s => s.Product).Count();

//        public int GetCustomers(Func<Person, bool> predicate = null)
//            => predicate != null ? _context.Users.Where(predicate).Where(s => s.Person.IsCustomer == true).Count()
//                : _context.Users.Where(s => s.Person.IsCustomer == true).Count();

//    }
//}