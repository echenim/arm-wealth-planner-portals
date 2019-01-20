using PortalAPI.Midleware.Contracts.Base;
using PortalAPI.Domain.Models;

namespace PortalAPI.Midleware.Contracts
{
    public interface IProductFeatureService : ICreate<ProductFeatures>, IEdit<ProductFeatures>,
        IFind<ProductFeatures>, IFetch<ProductFeatures>, IDelete<ProductFeatures>
    {
    }
}