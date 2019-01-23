using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortalAPI.Domain.Models.Identity;
using PortalAPI.Midleware.BaseStore;

namespace PensionManager.Business.Stores
{
    internal class ApplicationUserAndGroupStore
    {
        private bool _disposed;
        private UserGroupStoreBase _userGroupStore;

        public DbContext Context
        {
            get;
            private set;
        }

        public ApplicationUserAndGroupStore(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException("context");
            _userGroupStore = new UserGroupStoreBase(context);
        }

        public IQueryable<ApplicationUserGroup> UserGroup => _userGroupStore.EntitySet;

        public void Create(ApplicationUserGroup entity)
        {
            this.ThrowIfDisposed();
            if (entity == null)
            {
                throw new ArgumentNullException("role");
            }
            this._userGroupStore.Create(entity);
            this.Context.SaveChanges();
        }

        public void Update(ApplicationUserGroup entity)
        {
            this.ThrowIfDisposed();
            if (entity == null)
            {
                throw new ArgumentNullException("group");
            }
            this._userGroupStore.Update(entity);
            this.Context.SaveChanges();
        }

        public void Delete(ApplicationUserGroup entity)
        {
            this.ThrowIfDisposed();
            if (entity == null)
            {
                throw new ArgumentNullException("group");
            }
            this._userGroupStore.Delete(entity);
            this.Context.SaveChanges();
        }

        public ApplicationUserGroup FindById(string id)
        {
            this.ThrowIfDisposed();
            return this._userGroupStore.GetById(id);
        }

        public Task<ApplicationUserGroup> FindByIdAsync(string id)
        {
            this.ThrowIfDisposed();
            return this._userGroupStore.GetByIdAsync(id);
        }

        public IQueryable<ApplicationUserGroup> Group => this._userGroupStore.EntitySet;

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
            this._userGroupStore = null;
        }
    }
}