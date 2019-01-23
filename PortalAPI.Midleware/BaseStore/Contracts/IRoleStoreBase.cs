using PortalAPI.Domain.Models.Identity;
using PortalAPI.Midleware.BaseStore.Contracts.Base;

namespace PortalAPI.Midleware.BaseStore.Contracts
{
    public interface IRoleStoreBase : IEntitySet<ApplicationRole>, IQueryableEntity<ApplicationRole>
         , IGetById<ApplicationRole>, IFind<ApplicationRole>
    {
    }
}