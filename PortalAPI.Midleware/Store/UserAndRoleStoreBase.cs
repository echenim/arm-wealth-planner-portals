using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using PortalAPI.Domain.Models.Identity;

namespace PortalAPI.Midleware.Store
{
    internal class UserAndRoleStoreBase
    {
        public DbContext Context { get; }

        public DbSet<ApplicationUserRole> DbEntitySet { get; set; }

        public UserAndRoleStoreBase(DbContext context)
        {
            this.Context = context;
            this.DbEntitySet = context.Set<ApplicationUserRole>();
        }

        public IQueryable<ApplicationUserRole> EntitySet => this.DbEntitySet;

        public void AddToRoles(string userId, List<string> roleId)
        {
            foreach (var item in roleId)
            {
                var user_role = new ApplicationUserRole
                {
                    UserId = long.Parse(userId),
                    RoleId = long.Parse(item)
                };
                this.DbEntitySet.Add(user_role);
            }
        }

        public void Update(ApplicationUserRole entity)
        {
            if (entity != null)
            {
                Context.Entry<ApplicationUserRole>(entity).State = EntityState.Modified;
            }
        }

        public void RemoveFromRoles(string userId)
        {
            DbEntitySet.FromSql($"DELETE FROM ApplicationUserRoles WHERE UserId ='{userId}'");
        }

        public ApplicationUserRole GetById(object id) => this.DbEntitySet.Find(new object[] { id });

        public Task<ApplicationUserRole> GetByIdAsync(object id) => this.DbEntitySet.FindAsync(new object[] { id });
    }
}