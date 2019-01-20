using PortalAPI.Domain.Models.Identity;
using PortalAPI.Midleware.Store.Contracts.Base;

namespace PortalAPI.Midleware.Store.Contracts
{
    internal interface IGroupStore : IEntitySet<ApplicationGroup>, IQueryableEntity<ApplicationGroup>
        , ICreate<ApplicationGroup>, IEdit<ApplicationGroup>, IDelete<ApplicationGroup>, IGetById<ApplicationGroup>
    {
    }
}