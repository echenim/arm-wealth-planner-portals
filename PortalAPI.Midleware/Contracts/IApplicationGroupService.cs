using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PortalAPI.Domain.DbView;
using PortalAPI.Domain.Models;
using PortalAPI.Domain.Models.Identity;
using PortalAPI.Midleware.Contracts.Base;

namespace PortalAPI.Midleware.Contracts
{
    public interface IApplicationGroupService
    {
        IQueryable<ApplicationGroup> UserGroup(Func<ApplicationGroup, bool> predicate = null);

        ApplicationGroup FindUserGroupById(Func<ApplicationGroup, bool> predicate);

        IQueryable<ApplicationUserGroup> UserIdMappedToGroupId(Func<ApplicationUserGroup, bool> predicate = null);

        ApplicationGroup CreateUserGroup(ApplicationGroup model);

        IdentityResult DeleteGroup(long groupId);

        IdentityResult UpdateGroup(ApplicationGroup group);

        IEnumerable<ApplicationGroup> GetUserGroup(long userId);

        IEnumerable<ApplicationRole> GetGroupRoles(long groupId);

        IEnumerable<ApplicationGroupRole> GetUserGroupRoles(long userId);

        IdentityResult SetUserGroups(long userId, long groupId);

        IdentityResult SetAssignRoleToUserGroup(long groupId, params string[] roleNames);

        IdentityResult RefreshUserGroupRoles(long userId);

        IEnumerable<ApplicationGroup> GetUserGroups(long userId);

        void AssignRolesToUser(long userId, List<string> roleId);
    }
}