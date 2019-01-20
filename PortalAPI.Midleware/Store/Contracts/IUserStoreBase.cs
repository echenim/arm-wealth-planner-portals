using PortalAPI.Midleware.Store.Contracts.Base;
using PortalAPI.Domain.Models.Identity;

namespace PortalAPI.Midleware.Store.Contracts
{
    internal interface IUserStoreBase : IEntitySet<ApplicationUser>, IQueryableEntity<ApplicationUser>
      , IGetById<ApplicationUser>, IFind<ApplicationUser>
    {
    }
}