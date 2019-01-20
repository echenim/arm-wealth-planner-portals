using PortalAPI.Domain.Models.Identity;
using PortalAPI.Midleware.Store.Contracts.Base;

namespace PortalAPI.Midleware.Store.Contracts
{
    internal interface IUserGroupStoreBase : IEntitySet<ApplicationUserGroup>, IQueryableEntity<ApplicationUserGroup>
        , ICreate<ApplicationUserGroup>, IEdit<ApplicationUserGroup>, IDelete<ApplicationUserGroup>, IGetById<ApplicationUserGroup>
    {
    }
}