using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using PortalAPI.Domain.Models.Identity;

namespace PortalAPI.Midleware.BaseStore
{
    internal class GroupStoreBase
    {
        public DbContext Context
        {
            get;
        }

        public GroupStoreBase(DbContext context)
        {
            this.Context = context;
            this.DbEntitySet = context.Set<ApplicationGroup>();
        }

        public DbSet<ApplicationGroup> DbEntitySet
        {
            get;
            set;
        }

        public IQueryable<ApplicationGroup> EntitySet
        {
            get
            {
                return this.DbEntitySet;
            }
        }

        public void Create(ApplicationGroup entity) => this.DbEntitySet.Add(entity);

        public void Update(ApplicationGroup entity)
        {
            if (entity != null)
            {
                Context.Entry<ApplicationGroup>(entity).State = EntityState.Modified;
            }
        }

        public void Delete(ApplicationGroup entity) => this.DbEntitySet.Remove(entity);

        public ApplicationGroup GetById(object id) => this.DbEntitySet.Find(new object[] { id });

        public Task<ApplicationGroup> GetByIdAsync(object id) => this.DbEntitySet.FindAsync(new object[] { id });
    }
}