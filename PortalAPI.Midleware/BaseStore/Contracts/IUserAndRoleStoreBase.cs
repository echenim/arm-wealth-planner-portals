using System.Collections.Generic;
using PortalAPI.Domain.Models.Identity;
using PortalAPI.Midleware.BaseStore.Contracts.Base;

namespace PortalAPI.Midleware.BaseStore.Contracts
{
    internal interface IUserAndRoleStoreBase : IEntitySet<ApplicationUserRole>, IQueryableEntity<ApplicationUserRole>
     , IEdit<ApplicationUserRole>, IGetById<ApplicationUserRole>
    {
        void RemoveFromRoles(string userId);

        void AddToRoles(string userId, List<string> roleId);
    }
}