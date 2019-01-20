using PortalAPI.Domain.Models;
using PortalAPI.Midleware.Contracts.Base;

namespace PortalAPI.Midleware.Contracts
{
    public interface IProductCategoryService : ICreate<ProductCategory>, IEdit<ProductCategory>,
        IFind<ProductCategory>, IFetch<ProductCategory>, IDelete<ProductCategory>
    {
    }
}