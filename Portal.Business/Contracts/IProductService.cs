using Portal.Business.Contracts.Base;
using Portal.Domain.Models;

namespace Portal.Business.Contracts
{
    public interface IProductService : ICreate<Products>, IEdit<Products>,
        IFind<Products>, IFetch<Products>, IDelete<Products>
    {
    }
}