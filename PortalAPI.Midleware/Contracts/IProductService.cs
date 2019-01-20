using PortalAPI.Midleware.Contracts.Base;
using PortalAPI.Domain.Models;

namespace PortalAPI.Midleware.Contracts
{
    public interface IProductService : ICreate<Products>, IEdit<Products>,
        IFind<Products>, IFetch<Products>, IDelete<Products>
    {
    }
}