using System;
using System.Collections.Generic;
using System.Text;
using PortalAPI.Domain.Models;
using PortalAPI.Domain.Models.Identity;
using PortalAPI.Midleware.Contracts.Base;

namespace PortalAPI.Midleware.Contracts
{
    public interface IApplicationGroupService : ICreate<ApplicationGroup>, IEdit<ApplicationGroup>,
        IFind<ApplicationGroup>, IFetch<ApplicationGroup>, IDelete<ApplicationGroup>
    {
    }
}