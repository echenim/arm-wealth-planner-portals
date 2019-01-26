using Portal.Business.Contracts.Base;
using Portal.Domain.Models;

namespace Portal.Business.Contracts
{
    public interface IProductPerformanceService : ICreate<ProductPerformance>, IEdit<ProductPerformance>,
        IFind<ProductPerformance>, IFetch<ProductPerformance>, IDelete<ProductPerformance>
    {
    }
}