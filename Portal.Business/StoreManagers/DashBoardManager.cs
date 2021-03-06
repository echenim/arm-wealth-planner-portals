﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Portal.Business.Contracts;
using Portal.Business.Utilities;
using Portal.Domain;
using Portal.Domain.Models;
using Portal.Domain.Models.Identity;
using Portal.Domain.ViewModels;

namespace Portal.Business.StoreManagers
{
    public class DashBoardManager : IDashBoardManager
    {
        private readonly ApplicationDbContext _context;

        public DashBoardManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public int GetOrders(Func<PurchaseOrders, bool> predicate = null)
            => predicate != null ? _context.PurchaseOrders.Include(s => s.Product).Where(predicate).Count()
                : _context.PurchaseOrders.Include(s => s.Product).Count();

        public decimal GetSales(Func<PurchaseOrders, bool> predicate = null)
            => predicate != null ? _context.PurchaseOrders.Include(s => s.Product).Where(predicate).Sum(s => s.Amount)
                : _context.PurchaseOrders.Include(s => s.Product).Sum(s => s.Amount);

        public int GetExpressionOfInterest(Func<PurchaseOrders, bool> predicate = null)
            => predicate != null ? _context.PurchaseOrders.Include(s => s.Product).Where(predicate).Count()
                : _context.PurchaseOrders.Include(s => s.Product).Count();

        public int GetCustomers(Func<ApplicationUser, bool> predicate = null)
            => predicate != null ? _context.Users.Where(predicate).Where(s => s.Person.IsCustomer == true).Count()
                : _context.Users.Where(s => s.Person.IsCustomer == true).Count();

        public IQueryable<PurchaseOrderViewModel> GetRecentOrders(Func<PurchaseOrders, bool> predicate = null)
        {
            var resultingData = new List<PurchaseOrderViewModel>();

            var data = predicate != null
                ? _context.PurchaseOrders
                    .Include(s => s.Person)
                    .Include(s => s.Product).Include(s => s.Product.ProductCategory)
                    .Where(predicate: predicate)
                    .AsQueryable()
                : _context.PurchaseOrders
                    .Include(s => s.Person)
                    .Include(s => s.Product).Include(s => s.Product.ProductCategory)
                    .AsQueryable();

            foreach (var item in data)
            {
                resultingData.Add(new PurchaseOrderViewModel
                {
                    Id = item.Id,
                    Customer = item.Person.FullName,
                    ProductCateogry = item.Product.ProductCategory.Name,
                    ProductName = item.Product.Name,
                    ProductType = item.Product.ProductTypes,
                    AddToCartDateInHuman = TransfromerManager.DateHumanized(item.AddToCartDate),
                    AddToCartDate = item.AddToCartDate,
                    Amount = TransfromerManager.DecimalHuamanized(item.Amount),
                    Quantity = item.Quantity,
                    CartNumber = item.CartNumber,
                    OrderDateInHuman = item.OrderDate,
                    PaymentTransactionNumber = item.PaymentTransactionNumber,
                    TransactionStatus = item.TransactionStatus
                });
            }

            return resultingData.AsQueryable();
        }
    }
}