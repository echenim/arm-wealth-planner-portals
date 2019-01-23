using PortalAPI.Midleware.BaseStore.Contracts.Base;
using PortalAPI.Domain.Models.Identity;

namespace PortalAPI.Midleware.BaseStore.Contracts
{
    internal interface IUserStoreBase : IEntitySet<ApplicationUser>, IQueryableEntity<ApplicationUser>
      , IGetById<ApplicationUser>, IFind<ApplicationUser>
    {
    }
}