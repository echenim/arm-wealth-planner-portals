using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using PortalAPI.Domain.Models.Identity;

namespace PortalAPI.Midleware.Store
{
    internal class UserGroupStoreBase
    {
        public DbContext Context { get; }

        public DbSet<ApplicationUserGroup> DbEntitySet { get; set; }

        public UserGroupStoreBase(DbContext context)
        {
            this.Context = context;
            this.DbEntitySet = context.Set<ApplicationUserGroup>();
        }

        public IQueryable<ApplicationUserGroup> EntitySet => this.DbEntitySet;

        public void Create(ApplicationUserGroup entity) => this.DbEntitySet.Add(entity);

        public void Update(ApplicationUserGroup entity)
        {
            if (entity != null)
            {
                Context.Entry<ApplicationUserGroup>(entity).State = EntityState.Modified;
            }
        }

        public void Delete(ApplicationUserGroup entity) => this.DbEntitySet.Remove(entity);

        public ApplicationUserGroup GetById(object id) => this.DbEntitySet.Find(new object[] { id });

        public Task<ApplicationUserGroup> GetByIdAsync(object id) => this.DbEntitySet.FindAsync(new object[] { id });
    }
}