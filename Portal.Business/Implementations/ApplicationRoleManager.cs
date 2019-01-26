using System;
using System.Linq;
using Portal.Domain;
using Portal.Domain.Models.Identity;
using Portal.Business.Stores;

namespace Portal.Business.Implementations
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