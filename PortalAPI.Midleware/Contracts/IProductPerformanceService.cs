using PortalAPI.Midleware.Contracts.Base;
using PortalAPI.Domain.Models;

namespace PortalAPI.Midleware.Contracts
{
    public interface IProductPerformanceService : ICreate<ProductPerformance>, IEdit<ProductPerformance>,
        IFind<ProductPerformance>, IFetch<ProductPerformance>, IDelete<ProductPerformance>
    {
    }
}