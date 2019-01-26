using Portal.Domain.Models;
using Portal.Business.Contracts.Base;

namespace Portal.Business.Contracts
{
    public interface IProductCategoryService : ICreate<ProductCategory>, IEdit<ProductCategory>,
        IFind<ProductCategory>, IFetch<ProductCategory>, IDelete<ProductCategory>
    {
    }
}