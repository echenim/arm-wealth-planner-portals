using Portal.Domain.Models;
using Portal.Business.Contracts.Base;

namespace Portal.Business.Contracts
{
    public interface IOrdersAndSalesService : IFetch<PurchaseOrders>, IFind<PurchaseOrders>, ICreate<PurchaseOrders>
    {
    }
}