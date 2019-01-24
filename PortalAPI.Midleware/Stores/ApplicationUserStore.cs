using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortalAPI.Domain.Models.Identity;
using PortalAPI.Midleware.StoreBase;

namespace PortalAPI.Midleware.Stores
{
    internal class ApplicationUserStore : IDisposable
    {
        private bool _disposed;
        private UserStoreBase _userStore;

        public ApplicationUserStore(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this.Context = context;
            this._userStore = new UserStoreBase(context);
        }

        public IQueryable<ApplicationUser> Users
        {
            get
            {
                return this._userStore.EntitySet;
            }
        }

        public IQueryable<ApplicationUserRole> UserGroup
        {
            get
            {
                return this._userStore.UserRoleEntitySet;
            }
        }

        public DbContext Context
        {
            get;
            private set;
        }

        public virtual void Create(ApplicationUser user)
        {
            this.ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            this._userStore.Create(user);
            this.Context.SaveChanges();
        }

        public virtual void AddToRoles(ApplicationUserRole userRole)
        {
            this._userStore.Create(userRole);
        }

        public virtual void AddToRoles(ApplicationUserRole[] userRole)
        {
            this._userStore.Create(userRole);
        }

        public virtual async Task CreateAsync(ApplicationUser user)
        {
            this.ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            this._userStore.Create(user);
            await this.Context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(ApplicationUser user)
        {
            this.ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            this._userStore.Delete(user);
            await this.Context.SaveChangesAsync();
        }

        public virtual void Delete(ApplicationUser user)
        {
            this.ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            this._userStore.Delete(user);
            this.Context.SaveChanges();
        }

        public virtual void RemoveFromRoles(ApplicationUserRole user)
        {
            this.ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            this._userStore.Delete(user);
            this.Context.SaveChanges();
        }

        public virtual void RemoveFromRoles(ApplicationUserRole[] user)
        {
            this.ThrowIfDisposed();
            if (user.Any())
            {
                throw new ArgumentNullException("user");
            }
            this._userStore.Delete(user);
            this.Context.SaveChanges();
        }

        public virtual void RemoveFromRoles(long userid, ApplicationUserRole[] oldUserRoles)
        {
            this.ThrowIfDisposed();
            this._userStore.Delete(oldUserRoles);
            this.Context.SaveChanges();
        }

        public IQueryable<ApplicationUserRole> GetRoles(long userId)
        {
            return this._userStore.UserRoleEntitySet.Where(s => s.UserId == userId);
        }

        public Task<ApplicationUser> FindByIdAsync(long userId)
        {
            this.ThrowIfDisposed();
            return this._userStore.GetByIdAsync(userId);
        }

        public ApplicationUser FindById(long userId)
        {
            this.ThrowIfDisposed();
            return this._userStore.GetById(userId);
        }

        public ApplicationUser FindByName(string userName)
        {
            return _userStore.EntitySet.SingleOrDefault(s => s.UserName.Equals(userName));
        }

        public virtual async Task UpdateAsync(ApplicationUser user)
        {
            this.ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            this._userStore.Update(user);
            await this.Context.SaveChangesAsync();
        }

        public virtual void Update(ApplicationUser user)
        {
            this.ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            this._userStore.Update(user);
            this.Context.SaveChanges();
        }

        // DISPOSE STUFF: ===============================================

        public bool DisposeContext
        {
            get;
            set;
        }

        private void ThrowIfDisposed()
        {
            if (this._disposed)
            {
                throw new ObjectDisposedException(this.GetType().Name);
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.DisposeContext && disposing && this.Context != null)
            {
                this.Context.Dispose();
            }
            this._disposed = true;
            this.Context = null;
            this._userStore = null;
        }
    }
}