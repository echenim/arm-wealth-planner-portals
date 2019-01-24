using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortalAPI.Domain.Models.Identity;

namespace PortalAPI.Midleware.StoreBase
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
            private set;
        }

        public IQueryable<ApplicationRole> EntitySet => this.DbEntitySet;

        public RoleStoreBase(DbContext context)
        {
            this.Context = context;
            this.DbEntitySet = context.Set<ApplicationRole>();
        }

        public void Create(ApplicationRole entity)
        {
            this.DbEntitySet.Add(entity);
        }

        public void Delete(ApplicationRole entity)
        {
            this.DbEntitySet.Remove(entity);
        }

        public virtual Task<ApplicationRole> GetByIdAsync(object id)
        {
            return this.DbEntitySet.FindAsync(new object[] { id });
        }

        public virtual ApplicationRole GetById(object id)
        {
            return this.DbEntitySet.Find(new object[] { id });
        }

        public virtual void Update(ApplicationRole entity)
        {
            if (entity != null)
            {
                this.Context.Entry<ApplicationRole>(entity).State = EntityState.Modified;
            }
        }
    }
}