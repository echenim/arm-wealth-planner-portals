using PortalAPI.Domain.Models.Identity;
using PortalAPI.Midleware.Store.Contracts.Base;

namespace PortalAPI.Midleware.Store.Contracts
{
    internal interface IGroupRoleStoreBase : IEntitySet<ApplicationGroupRole>, IQueryableEntity<ApplicationGroupRole>
        , ICreate<ApplicationGroupRole>, IEdit<ApplicationGroupRole>, IDelete<ApplicationGroupRole>, IGetById<ApplicationGroupRole>
    {
    }
}