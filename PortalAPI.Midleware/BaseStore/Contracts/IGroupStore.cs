using PortalAPI.Domain.Models.Identity;
using PortalAPI.Midleware.BaseStore.Contracts.Base;

namespace PortalAPI.Midleware.BaseStore.Contracts
{
    internal interface IGroupStore : IEntitySet<ApplicationGroup>, IQueryableEntity<ApplicationGroup>
        , ICreate<ApplicationGroup>, IEdit<ApplicationGroup>, IDelete<ApplicationGroup>, IGetById<ApplicationGroup>
    {
    }
}