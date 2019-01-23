using PortalAPI.Domain.Models.Identity;
using PortalAPI.Midleware.BaseStore.Contracts.Base;

namespace PortalAPI.Midleware.BaseStore.Contracts
{
    internal interface IGroupRoleStoreBase : IEntitySet<ApplicationGroupRole>, IQueryableEntity<ApplicationGroupRole>
        , ICreate<ApplicationGroupRole>, IEdit<ApplicationGroupRole>, IDelete<ApplicationGroupRole>, IGetById<ApplicationGroupRole>
    {
    }
}