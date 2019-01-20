using System;
using System.Collections.Generic;
using System.Text;
using PortalAPI.Domain.Models.Identity;
using PortalAPI.Midleware.Contracts.Base;

namespace PortalAPI.Midleware.Contracts
{
    public interface IApplicationGroupRoleService : ICreate<ApplicationGroupRole>, IEdit<ApplicationGroupRole>,
        IFind<ApplicationGroupRole>, IFetch<ApplicationGroupRole>, IDelete<ApplicationGroupRole>
    {
    }
}