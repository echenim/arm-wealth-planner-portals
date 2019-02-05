using Portal.Business.Contracts.Base;
using Portal.Domain.Models;

namespace Portal.Business.Contracts
{
    public interface IProductFeatureManager : ICreate<ProductFeatures>, IEdit<ProductFeatures>,
        IFind<ProductFeatures>, IFetch<ProductFeatures>, IDelete<ProductFeatures>
    {
    }
}