using System;
using System.Collections.Generic;
using System.Text;
using PortalAPI.Domain.Models;
using PortalAPI.Midleware.Contracts.Base;

namespace PortalAPI.Midleware.Contracts
{
    public interface IOrdersAndSalesService : IFetch<PurchaseOrders>, IFind<PurchaseOrders>, ICreate<PurchaseOrders>
    {
    }
}