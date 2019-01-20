using PortalAPI.Domain.Models.Identity;
using PortalAPI.Midleware.Store.Contracts.Base;

namespace PortalAPI.Midleware.Store.Contracts
{
    public interface IRoleStoreBase : IEntitySet<ApplicationRole>, IQueryableEntity<ApplicationRole>
         , IGetById<ApplicationRole>, IFind<ApplicationRole>
    {
    }
}