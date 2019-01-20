using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using PortalAPI.Domain.Models.Identity;

namespace PortalAPI.Midleware.Store
{
    internal class UserStoreBase
    {
        public DbContext Context
        {
            get;
            private set;
        }

        public DbSet<ApplicationUser> DbEntitySet
        {
            get;
            set;
        }

        public IQueryable<ApplicationUser> EntitySet => this.DbEntitySet;

        public UserStoreBase(DbContext context)
        {
            this.Context = context;
            this.DbEntitySet = context.Set<ApplicationUser>();
        }

        public Task<ApplicationUser> GetByIdAsync(object id) => this.DbEntitySet.FindAsync(new object[] { id });

        public ApplicationUser GetById(object id) => this.DbEntitySet.Find(new object[] { id });
    }
}