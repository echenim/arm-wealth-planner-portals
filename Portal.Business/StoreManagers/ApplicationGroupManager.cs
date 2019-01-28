using System;
using System.Collections.Generic;
using System.Linq;
using Portal.Domain;
using Microsoft.AspNetCore.Identity;
using Portal.Domain.Models.Identity;
using Portal.Business.Contracts;
using Portal.Business.Stores;

namespace Portal.Business.StoreManagers
{
    public class ApplicationGroupManager : IApplicationGroupManager
    {
        private readonly ApplicationDbContext _db;
        private readonly ApplicationGroupStore _groupStore;
        private readonly ApplicationUserManager _userManager;
        private readonly ApplicationRoleManager _roleManager;

        public ApplicationGroupManager(ApplicationDbContext db)
        {
            _db = db;
            _groupStore = new ApplicationGroupStore(_db);
            _roleManager = new ApplicationRoleManager(_db);
            _userManager = new ApplicationUserManager(_db);
            ;
        }

        public IQueryable<ApplicationGroup> Groups() => _groupStore.Groups;

        public IdentityResult CreateGroup(ApplicationGroup group)
        {
            _groupStore.Create(group);
            return IdentityResult.Success;
        }

        public IdentityResult SetGroupRoles(long groupId, params string[] roleNames)
        {
            // Clear all the roles associated with this group:
            var thisGroup = this.FindById(groupId);
            thisGroup.ApplicationRoles.Clear();
            _db.SaveChanges();

            // Add the new roles passed in:
            var newRoles = _roleManager.Role(s => roleNames.Any(n => n == s.Name));
            foreach (var role in newRoles)
            {
                thisGroup.ApplicationRoles.Add(new ApplicationGroupRole { ApplicationGroupId = groupId, ApplicationRoleId = role.Id });
            }
            _db.SaveChanges();

            // Reset the roles for all affected users:
            foreach (var groupUser in thisGroup.ApplicationUsers)
            {
                this.RefreshUserGroupRoles(groupUser.ApplicationUserId);
            }
            return IdentityResult.Success;
        }

        public IdentityResult SetUserGroups(long userId, params string[] groupIds)
        {
            // Clear current group membership:
            var currentGroups = this.GetUserGroups(userId);
            foreach (var group in currentGroups)
            {
                group.ApplicationUsers
                    .Remove(group.ApplicationUsers.FirstOrDefault(gr => gr.ApplicationUserId == userId));
            }
            _db.SaveChanges();

            // Add the user to the new groups:
            foreach (var groupId in groupIds)
            {
                var id = long.Parse(groupId);
                var newGroup = this.FindById(id);
                newGroup.ApplicationUsers.Add(new ApplicationUserGroup { ApplicationUserId = userId, ApplicationGroupId = id });
            }
            _db.SaveChanges();

            this.RefreshUserGroupRoles(userId);
            return IdentityResult.Success;
        }

        public IdentityResult RefreshUserGroupRoles(long userId)
        {
            var user = _userManager.FindById(userId);
            if (user == null)
            {
                throw new ArgumentNullException("User");
            }
            // Remove user from previous roles:
            var oldUserRoles = _userManager.GetRoles(userId);
            if (oldUserRoles.Any())
            {
                _userManager.RemoveFromRoles(userId, oldUserRoles.ToArray());
            }

            // Find teh roles this user is entitled to from group membership:
            var newGroupRoles = this.GetUserGroupRoles(userId);

            // Get the damn role names:
            var allRoles = _roleManager.Role().ToList();
            var addTheseRoles = allRoles.Where(r => newGroupRoles.Any(gr => gr.ApplicationRoleId == r.Id));
            var roleNames = addTheseRoles.Select(n => n.Name).ToArray();

            // Add the user to the proper roles
            _userManager.AddToRoles(userId, roleNames);

            return IdentityResult.Success;
        }

        public IdentityResult DeleteGroup(long groupId)
        {
            var group = this.FindById(groupId);
            if (group == null)
            {
                throw new ArgumentNullException("User");
            }

            var currentGroupMembers = this.GetGroupUsers(groupId).ToList();
            // remove the roles from the group:
            group.ApplicationRoles.Clear();

            // Remove all the users:
            group.ApplicationUsers.Clear();

            // Remove the group itself:
            _db.ApplicationGroup.Remove(group);

            _db.SaveChanges();

            // Reset all the user roles:
            foreach (var user in currentGroupMembers)
            {
                this.RefreshUserGroupRoles(user.Id);
            }
            return IdentityResult.Success;
        }

        public IdentityResult UpdateGroup(ApplicationGroup group)
        {
            _groupStore.Update(group);
            foreach (var groupUser in group.ApplicationUsers)
            {
                this.RefreshUserGroupRoles(groupUser.ApplicationUserId);
            }
            return IdentityResult.Success;
        }

        public IdentityResult ClearUserGroups(long userId)
        {
            return this.SetUserGroups(userId, new string[] { });
        }

        public IEnumerable<ApplicationGroup> GetUserGroups(long userId)
        {
            var result = new List<ApplicationGroup>();
            var userGroups = (from g in this.Groups()
                              where g.ApplicationUsers.Any(u => u.ApplicationUserId == userId)
                              select g).ToList();
            return userGroups;
        }

        public IEnumerable<ApplicationRole> GetGroupRoles(long groupId)
        {
            var grp = _db.ApplicationGroup.FirstOrDefault(g => g.Id == groupId);
            var roles = _roleManager.Role().ToList();
            var groupRoles = from r in roles
                             where grp.ApplicationRoles.Any(ap => ap.ApplicationRoleId == r.Id)
                             select r;
            return groupRoles;
        }

        public IEnumerable<ApplicationUser> GetGroupUsers(long groupId)
        {
            var group = this.FindById(groupId);
            var users = new List<ApplicationUser>();
            foreach (var groupUser in group.ApplicationUsers)
            {
                var user = _db.Users.Find(groupUser.ApplicationUserId);
                users.Add(user);
            }
            return users;
        }

        public IEnumerable<ApplicationGroupRole> GetUserGroupRoles(long userId)
        {
            var userGroups = this.GetUserGroups(userId);
            var userGroupRoles = new List<ApplicationGroupRole>();
            foreach (var group in userGroups)
            {
                userGroupRoles.AddRange(group.ApplicationRoles.ToArray());
            }
            return userGroupRoles;
        }

        public ApplicationGroup FindById(long id)
        {
            return _groupStore.FindById(id);
        }
    }
}