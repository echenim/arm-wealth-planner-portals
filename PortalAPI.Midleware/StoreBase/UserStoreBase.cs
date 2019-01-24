using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortalAPI.Domain.Models.Identity;

namespace PortalAPI.Midleware.StoreBase
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
            private set;
        }

        public DbSet<ApplicationUserRole> UserRoleDbEntitySet
        {
            get;
            private set;
        }

        public IQueryable<ApplicationUser> EntitySet
        {
            get
            {
                return this.DbEntitySet;
            }
        }

        public IQueryable<ApplicationUserRole> UserRoleEntitySet
        {
            get
            {
                return this.UserRoleDbEntitySet;
            }
        }

        public UserStoreBase(DbContext context)
        {
            this.Context = context;
            this.DbEntitySet = context.Set<ApplicationUser>();
            this.UserRoleDbEntitySet = context.Set<ApplicationUserRole>();
        }

        public void Create(ApplicationUser entity)
        {
            this.DbEntitySet.Add(entity);
        }

        public void Create(ApplicationUserRole entity)
        {
            this.UserRoleDbEntitySet.Add(entity: entity);
        }

        public void Create(ApplicationUserRole[] entity)
        {
            this.UserRoleDbEntitySet.AddRange(entity);
        }

        public void Delete(ApplicationUser entity)
        {
            this.DbEntitySet.Remove(entity);
        }

        public void Delete(ApplicationUserRole entity)
        {
            this.UserRoleDbEntitySet.Remove(entity);
        }

        public void Delete(ApplicationUserRole[] entity)
        {
            this.UserRoleDbEntitySet.RemoveRange(entity);
        }

        public virtual Task<ApplicationUser> GetByIdAsync(object id)
        {
            return this.DbEntitySet.FindAsync(new object[] { id });
        }

        public virtual ApplicationUser GetById(object id)
        {
            return this.DbEntitySet.Find(new object[] { id });
        }

        public virtual void Update(ApplicationUser entity)
        {
            if (entity != null)
            {
                this.Context.Entry<ApplicationUser>(entity).State = EntityState.Modified;
            }
        }
    }
}