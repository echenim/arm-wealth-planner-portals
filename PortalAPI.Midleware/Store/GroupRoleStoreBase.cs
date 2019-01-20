using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using PortalAPI.Domain.Models.Identity;

namespace PortalAPI.Midleware.Store
{
    internal class GroupRoleStoreBase
    {
        public DbContext Context { get; }

        public DbSet<ApplicationGroupRole> DbEntitySet { get; set; }

        public GroupRoleStoreBase(DbContext context)
        {
            this.Context = context;
            this.DbEntitySet = context.Set<ApplicationGroupRole>();
        }

        public IQueryable<ApplicationGroupRole> EntitySet => this.DbEntitySet;

        public void Create(ApplicationGroupRole entity) => this.DbEntitySet.Add(entity);

        public void Update(ApplicationGroupRole entity)
        {
            if (entity != null)
            {
                Context.Entry<ApplicationGroupRole>(entity).State = EntityState.Modified;
            }
        }

        public void Delete(ApplicationGroupRole entity) => this.DbEntitySet.Remove(entity);

        public ApplicationGroupRole GetById(object id) => this.DbEntitySet.Find(new object[] { id });

        public Task<ApplicationGroupRole> GetByIdAsync(object id) => this.DbEntitySet.FindAsync(new object[] { id });
    }
}