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
    internal class ApplicationRoleStore : IDisposable
    {
        private bool _disposed;
        private RoleStoreBase _roleStore;

        public ApplicationRoleStore(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this.Context = context;
            this._roleStore = new RoleStoreBase(context);
        }

        public IQueryable<ApplicationRole> Roles
        {
            get
            {
                return this._roleStore.EntitySet;
            }
        }

        public DbContext Context
        {
            get;
            private set;
        }

        public virtual void Create(ApplicationRole role)
        {
            this.ThrowIfDisposed();
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }
            this._roleStore.Create(role);
            this.Context.SaveChanges();
        }

        public virtual async Task CreateAsync(ApplicationRole role)
        {
            this.ThrowIfDisposed();
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }
            this._roleStore.Create(role);
            await this.Context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(ApplicationRole riole)
        {
            this.ThrowIfDisposed();
            if (riole == null)
            {
                throw new ArgumentNullException("riole");
            }
            this._roleStore.Delete(riole);
            await this.Context.SaveChangesAsync();
        }

        public virtual void Delete(ApplicationRole riole)
        {
            this.ThrowIfDisposed();
            if (riole == null)
            {
                throw new ArgumentNullException("riole");
            }
            this._roleStore.Delete(riole);
            this.Context.SaveChanges();
        }

        public Task<ApplicationRole> FindByIdAsync(long roleId)
        {
            this.ThrowIfDisposed();
            return this._roleStore.GetByIdAsync(roleId);
        }

        public ApplicationRole FindById(long roleId)
        {
            this.ThrowIfDisposed();
            return this._roleStore.GetById(roleId);
        }

        public ApplicationRole FindByName(string roleName)
        {
            return _roleStore.EntitySet.SingleOrDefault(s => s.Name.Equals(roleName));
        }

        public virtual async Task UpdateAsync(ApplicationRole role)
        {
            this.ThrowIfDisposed();
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }
            this._roleStore.Update(role);
            await this.Context.SaveChangesAsync();
        }

        public virtual void Update(ApplicationRole role)
        {
            this.ThrowIfDisposed();
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }
            this._roleStore.Update(role);
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
            this._roleStore = null;
        }
    }
}