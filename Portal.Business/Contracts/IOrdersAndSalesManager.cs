﻿using System;
using System.Collections.Generic;
using System.Linq;
using Portal.Domain.Models;
using Portal.Business.Contracts.Base;

namespace Portal.Business.Contracts
{
    public interface IOrdersAndSalesManager : IFetch<PurchaseOrders>, IFind<PurchaseOrders>, ICreate<PurchaseOrders>
    {
        IQueryable<PurchaseOrders> Sales(Func<PurchaseOrders, bool> predicate = null);

        void Edit(string cartId);

        IQueryable<PurchaseOrders> PersonBuyHistory(long personId);
    }
}