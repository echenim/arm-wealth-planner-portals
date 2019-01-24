using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortalAPI.Domain;
using PortalAPI.Domain.Models.Identity;
using PortalAPI.Midleware.Stores;

namespace PortalAPI.Midleware.Implementations
{
    internal class ApplicationUserManager
    {
        private readonly ApplicationUserStore _userStore;
        private readonly ApplicationDbContext _db;

        public ApplicationUserManager(ApplicationDbContext db)
         => _userStore = new ApplicationUserStore(db);

        public IQueryable<ApplicationUser> Get(Func<ApplicationUser, bool> predicate = null)
            => predicate != null
                ? _userStore.Users.Where(predicate: predicate).AsQueryable()
                : _userStore.Users.AsQueryable();

        public ApplicationUser FindById(long userid)
            => _userStore.FindById(userId: userid);

        public IQueryable<ApplicationUserRole> GetRoles(long userId)
            => _userStore.GetRoles(userId: userId);

        public void RemoveFromRoles(long userId, ApplicationUserRole[] oldRole)
            => _userStore.RemoveFromRoles(userId, oldRole);

        public void AddToRoles(long userId, string[] roleNames)
        {
            var roleArray = new List<ApplicationUserRole>();

            if (!roleNames.Any()) return;
            roleArray.AddRange(roleNames.Select(role => long.Parse(role))
                .Select(roleId => new ApplicationUserRole
                {
                    UserId = userId,
                    RoleId = roleId
                }));

            this._userStore.AddToRoles(roleArray.ToArray());
        }
    }
}