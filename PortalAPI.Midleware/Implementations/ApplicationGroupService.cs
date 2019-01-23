using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PortalAPI.Domain;
using PortalAPI.Domain.Models;
using PortalAPI.Domain.Models.Identity;
using PortalAPI.Midleware.Contracts;

namespace PortalAPI.Midleware.Implementations
{
    public class ApplicationGroupService : IApplicationGroupService
    {
        private readonly ApplicationDbContext _context;

        public ApplicationGroupService(ApplicationDbContext context)
            => _context = context;

        public IQueryable<ApplicationGroup> Groups => _context.ApplicationGroup;

        /// <summary>
        /// fetch Permission Grouping
        /// </summary>
        /// <param name="predicate">filter will properties</param>
        /// <returns>return object collection</returns>
        public IQueryable<ApplicationGroup> UserGroup(Func<ApplicationGroup, bool> predicate = null)
            => predicate != null
                ? _context.ApplicationGroup.Where(predicate: predicate).AsQueryable()
                : _context.ApplicationGroup.AsQueryable();

        /// <summary>
        /// find specific user group by the group id
        /// </summary>
        /// <param name="predicate">s=>s.id==parameter</param>
        /// <returns>user group object</returns>
        public ApplicationGroup FindUserGroupById(Func<ApplicationGroup, bool> predicate)
            => _context.ApplicationGroup.Find(predicate);

        /// <summary>
        /// this method will return userid and the groupid they elong to
        /// </summary>
        /// <param name="predicate">either supply the userid or groupid</param>
        /// <returns>return collection</returns>
        public IQueryable<ApplicationUserGroup> UserIdMappedToGroupId(Func<ApplicationUserGroup, bool> predicate = null)
            => predicate != null ?
                _context.ApplicationUserGroup.Where(predicate).AsQueryable()
                          : _context.ApplicationUserGroup.AsQueryable();

        /// <summary>
        /// register new user group name
        /// </summary>
        /// <param name="model">user group information</param>
        /// <returns></returns>
        public ApplicationGroup CreateUserGroup(ApplicationGroup model)
        {
            _context.ApplicationGroup.Add(model);
            var id = _context.SaveChanges();
            model.Id = id;
            return model;
        }

        public IdentityResult DeleteGroup(long groupId)
        {
            var group = _context.ApplicationGroup.Find(groupId);
            if (group == null)
            {
                throw new ArgumentNullException("User");
            }

            var currentGroupMembers = UserIdMappedToGroupId(s => s.ApplicationGroupId == groupId).ToList();
            // remove the roles from the group:
            group.ApplicationRoles.Clear();

            // Remove all the users:
            group.ApplicationUsers.Clear();

            // Remove the group itself:
            _context.ApplicationGroup.Remove(group);

            _context.SaveChanges();

            // Reset all the user roles:
            foreach (var user in currentGroupMembers)
            {
                this.RefreshUserGroupRoles(user.ApplicationUserId);
            }
            return IdentityResult.Success;
        }

        public IdentityResult UpdateGroup(ApplicationGroup group)
        {
            _context.Entry<ApplicationGroup>(group).State = EntityState.Modified;
            _context.SaveChanges();

            foreach (var groupUser in group.ApplicationUsers)
            {
                this.RefreshUserGroupRoles(groupUser.ApplicationUserId);
            }
            return IdentityResult.Success;
        }

        public IEnumerable<ApplicationGroup> GetUserGroup(long userId)
        {
            var result = new List<ApplicationGroup>();
            var userGroups = (from g in this.Groups
                              where g.ApplicationUsers.Any(u => u.ApplicationUserId == userId)
                              select g).ToList();
            return userGroups;
        }

        public IEnumerable<ApplicationRole> GetGroupRoles(long groupId)
        {
            var grp = _context.ApplicationGroup.FirstOrDefault(g => g.Id == groupId);
            var roles = _context.Roles.ToList();
            var groupRoles = from r in roles
                             where grp.ApplicationRoles.Any(ap => ap.ApplicationRoleId == r.Id)
                             select r;
            return groupRoles;
        }

        public IEnumerable<ApplicationGroupRole> GetUserGroupRoles(long userId)
        {
            var userGroups = GetUserGroups(userId);
            var userGroupRoles = new List<ApplicationGroupRole>();
            foreach (var group in userGroups)
            {
                userGroupRoles.AddRange(group.ApplicationRoles.ToArray());
            }
            return userGroupRoles;
        }

        public IdentityResult SetUserGroups(long userId, long groupId)
        {
            // Clear current group membership:
            var currentGroups = GetUserGroups(userId);
            foreach (var group in currentGroups)
            {
                // _context.ApplicationUserGroup.Remove(group);
                group.ApplicationUsers
                    .Remove(group.ApplicationUsers.FirstOrDefault(gr => gr.ApplicationUserId == userId));
            }
            _context.SaveChanges();

            var newGroup = _context.ApplicationGroup.Find(groupId);

            newGroup.ApplicationUsers.Add(new ApplicationUserGroup
            {
                ApplicationUserId = userId,
                ApplicationGroupId = groupId
            });
            _context.SaveChanges();

            this.RefreshUserGroupRoles(userId);
            return IdentityResult.Success;
        }

        public IdentityResult SetAssignRoleToUserGroup(long groupId, params string[] roleNames)
        {
            /**
             * search if the this user group exist*
             * clear all role information tied to this user group
             * if no user has been mapped to this user group
             */
            var thisUserGroup = Groups.Where(s => s.Id == groupId).SingleOrDefault();
            thisUserGroup.ApplicationRoles.Clear();
            _context.SaveChanges();

            /*
             *assign the role to the new created user group*
             */
            var newRole = _context.Roles.Where(r => roleNames.Any(s => s == r.Name));

            foreach (var roles in newRole)
            {
                thisUserGroup.ApplicationRoles.Add(new ApplicationGroupRole
                {
                    ApplicationGroupId = groupId,
                    ApplicationRoleId = roles.Id
                });
            }
            _context.SaveChanges();

            var userMappedToUserGroup = thisUserGroup.ApplicationUsers;
            foreach (var groupUsersbelongTo in userMappedToUserGroup)
            {
                RefreshUserGroupRoles(groupUsersbelongTo.ApplicationGroupId);
            }

            return IdentityResult.Success;
        }

        public IdentityResult RefreshUserGroupRoles(long userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                throw new ArgumentNullException("User");
            }
            // Remove user from previous roles:
            var oldUserRoles = _context.UserRoles.Where(s => s.UserId == userId);
            if (oldUserRoles.Any())
            {
                _context.UserRoles.FromSql($"DELETE FROM ApplicationUserRoles WHERE UserId ='{userId}'");
                _context.SaveChanges();
            }

            // Find teh roles this user is entitled to from group membership:
            var newGroupRoles = GetUserGroupRoles(userId);

            //Get the roles name
            var allRoles = _context.Roles.ToList();
            var addTheseRoles = allRoles.Where(r => newGroupRoles.Any(gr => gr.ApplicationRoleId == r.Id));
            var roleNames = addTheseRoles.Select(n => n.Name).ToArray();

            // Add the user to the proper roles
            AssignRolesToUser(userId: userId, roleId: roleNames.ToList());

            return IdentityResult.Success;
        }

        public IEnumerable<ApplicationGroup> GetUserGroups(long userId)
        {
            var result = new List<ApplicationGroup>();
            var userGroups = (from g in this.Groups
                              where g.ApplicationUsers.Any(u => u.ApplicationUserId == userId)
                              select g).ToList();
            return userGroups;
        }

        public void AssignRolesToUser(long userId, List<string> roleId)
        {
            foreach (var item in roleId)
            {
                var userRole = new ApplicationUserRole
                {
                    UserId = userId,
                    RoleId = long.Parse(item)
                };
                _context.UserRoles.Add(userRole);
                _context.SaveChanges();
            }
        }
    }
}