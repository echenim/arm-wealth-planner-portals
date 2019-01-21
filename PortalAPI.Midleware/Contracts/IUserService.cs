using System;
using System.Collections.Generic;
using System.Text;
using PortalAPI.Domain.ViewModels;
using PortalAPI.Midleware.Contracts.Base;

namespace PortalAPI.Midleware.Contracts
{
    public interface IUserService : IFetch<InternalUserView>, IFind<InternalUserView>
    {
    }
}