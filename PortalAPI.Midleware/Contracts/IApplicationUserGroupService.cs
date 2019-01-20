using System;
using System.Collections.Generic;
using System.Text;
using PortalAPI.Domain.Models.Identity;
using PortalAPI.Midleware.Contracts.Base;

namespace PortalAPI.Midleware.Contracts
{
    public interface IApplicationUserGroupService : ICreate<ApplicationUserGroup>, IEdit<ApplicationUserGroup>,
        IFind<ApplicationUserGroup>, IFetch<ApplicationUserGroup>, IDelete<ApplicationUserGroup>
    {
    }
}