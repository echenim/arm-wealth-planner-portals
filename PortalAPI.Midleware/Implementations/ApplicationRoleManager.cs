using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortalAPI.Domain;
using PortalAPI.Domain.Models.Identity;
using PortalAPI.Midleware.Stores;

namespace PortalAPI.Midleware.Implementations
{
    internal class ApplicationRoleManager
    {
        private readonly ApplicationRoleStore _roleStore;

        public ApplicationRoleManager(ApplicationDbContext db)
        {
            _roleStore = new ApplicationRoleStore(db);
        }

        public IQueryable<ApplicationRole> Role(Func<ApplicationRole, bool> predicate = null)
            => predicate != null
                ? _roleStore.Roles.Where(predicate: predicate).AsQueryable()
                : _roleStore.Roles.AsQueryable();

        public ApplicationRole FindById(long predicate)
            => _roleStore.FindById(predicate);
    }
}