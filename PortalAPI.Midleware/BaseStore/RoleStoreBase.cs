using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using PortalAPI.Domain.Models.Identity;

namespace PortalAPI.Midleware.BaseStore
{
    internal class RoleStoreBase
    {
        public DbContext Context
        {
            get;
            private set;
        }

        public DbSet<ApplicationRole> DbEntitySet
        {
            get;
            set;
        }

        public IQueryable<ApplicationRole> EntitySet => this.DbEntitySet;

        public RoleStoreBase(DbContext context)
        {
            this.Context = context;
            this.DbEntitySet = context.Set<ApplicationRole>();
        }

        public ApplicationRole FindByName(string name) => DbEntitySet.FirstOrDefault(s =>
           s.Name.ToUpper().Equals(name.ToUpper()));

        public Task<ApplicationRole> FindByNameAsync(string name) => DbEntitySet.FirstOrDefaultAsync(s =>
            s.Name.ToUpper().Equals(name.ToUpper()));

        public Task<ApplicationRole> GetByIdAsync(object id) => this.DbEntitySet.FindAsync(new object[] { id });

        public ApplicationRole GetById(object id) => this.DbEntitySet.Find(new object[] { id });
    }
}