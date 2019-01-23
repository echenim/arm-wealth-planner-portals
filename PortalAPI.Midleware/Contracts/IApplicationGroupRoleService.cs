using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalAPI.Domain.Models.Identity;
using PortalAPI.Midleware.Contracts.Base;

namespace PortalAPI.Midleware.Contracts
{
    public interface IApplicationGroupRoleService
    {
        IQueryable<ApplicationRole> Roles { get; }

        Task<ApplicationRole> FindByIdAsync(string id);

        ApplicationRole FindById(string id);

        Task<ApplicationRole> FindByNameAsync(string groupName);
    }
}