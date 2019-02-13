using System;
using System.Linq;
using Portal.Domain.Models;
using Portal.Domain.Models.Identity;
using Portal.Domain.ViewModels;

namespace Portal.Business.Contracts
{
    public interface IDashBoardManager
    {
        int GetOrders(Func<PurchaseOrders, bool> predicate = null);

        decimal GetSales(Func<PurchaseOrders, bool> predicate = null);

        int GetExpressionOfInterest(Func<PurchaseOrders, bool> predicate = null);

        int GetCustomers(Func<ApplicationUser, bool> predicate = null);

        IQueryable<PurchaseOrderViewModel> GetRecentOrders(Func<PurchaseOrders, bool> predicate = null);
    }
}