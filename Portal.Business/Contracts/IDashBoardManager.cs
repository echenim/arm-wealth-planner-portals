using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Business.Contracts.Base;
using Portal.Business.Implementations;
using Portal.Domain.Models;
using Portal.Domain.Models.Identity;

namespace Portal.Business.Contracts
{
    public interface IDashBoardManager
    {
        int GetOrders(Func<PurchaseOrders, bool> predicate = null);

        decimal GetSales(Func<PurchaseOrders, bool> predicate = null);

        int GetExpressionOfInterest(Func<PurchaseOrders, bool> predicate = null);

        int GetCustomers(Func<ApplicationUser, bool> predicate = null);

        IQueryable<PurchaseOrders> GetRecentOrders(Func<PurchaseOrders, bool> predicate = null);
    }
}