using PortalAPI.Domain.Models.Identity;
using PortalAPI.Midleware.BaseStore.Contracts.Base;

namespace PortalAPI.Midleware.BaseStore.Contracts
{
    internal interface IUserGroupStoreBase : IEntitySet<ApplicationUserGroup>, IQueryableEntity<ApplicationUserGroup>
        , ICreate<ApplicationUserGroup>, IEdit<ApplicationUserGroup>, IDelete<ApplicationUserGroup>, IGetById<ApplicationUserGroup>
    {
    }
}