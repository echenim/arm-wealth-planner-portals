using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using PortalAPI.Domain.Models.Identity;

namespace PortalAPI.Midleware.Contracts
{
    public interface IApplicationGroupManager
    {
        IQueryable<ApplicationGroup> Groups();

        IdentityResult CreateGroup(ApplicationGroup group);

        IdentityResult SetGroupRoles(long groupId, params string[] roleNames);

        IdentityResult SetUserGroups(long userId, params string[] groupIds);

        IdentityResult RefreshUserGroupRoles(long userId);

        IdentityResult DeleteGroup(long groupId);

        IdentityResult UpdateGroup(ApplicationGroup group);

        IdentityResult ClearUserGroups(long userId);

        IEnumerable<ApplicationGroup> GetUserGroups(long userId);

        IEnumerable<ApplicationRole> GetGroupRoles(long groupId);

        IEnumerable<ApplicationUser> GetGroupUsers(long groupId);

        IEnumerable<ApplicationGroupRole> GetUserGroupRoles(long userId);

        ApplicationGroup FindById(long id);
    }
}