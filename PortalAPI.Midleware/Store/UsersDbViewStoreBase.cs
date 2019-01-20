using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using PortalAPI.Domain.DbView;

namespace PortalAPI.Midleware.Store
{
    internal class UsersDbViewStoreBase
    {
        public DbContext Context
        {
            get;
            private set;
        }

        public DbSet<UsersDbViewModel> DbEntitySet
        {
            get;
            set;
        }

        public IQueryable<UsersDbViewModel> EntitySet => this.DbEntitySet;

        public UsersDbViewStoreBase(DbContext context)
        {
            this.Context = context;
            this.DbEntitySet = context.Set<UsersDbViewModel>();
        }

        public UsersDbViewModel FindByName(string name) => DbEntitySet.FirstOrDefault(s =>
            s.Name.ToUpper().Equals(name.ToUpper()));

        public Task<UsersDbViewModel> FindByNameAsync(string name) => DbEntitySet.FirstOrDefaultAsync(s =>
            s.Name.ToUpper().Equals(name.ToUpper()));

        public Task<UsersDbViewModel> GetByIdAsync(object id) => this.DbEntitySet.FindAsync(new object[] { id });

        public UsersDbViewModel GetById(object id) => this.DbEntitySet.Find(new object[] { id });
    }
}