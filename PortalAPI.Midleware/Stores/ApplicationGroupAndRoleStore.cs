using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using PortalAPI.Domain.Models.Identity;
using PortalAPI.Midleware.BaseStore;

namespace PortalAPI.Midleware.Stores
{
    internal class ApplicationGroupAndRoleStore
    {
        private bool _disposed;
        private GroupRoleStoreBase _groupRoleStoreBase;

        public DbContext Context
        {
            get;
            private set;
        }

        public ApplicationGroupAndRoleStore(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException("context");
            _groupRoleStoreBase = new GroupRoleStoreBase(context);
        }

        public IQueryable<ApplicationGroupRole> GroupRole => this._groupRoleStoreBase.EntitySet;

        public void Create(ApplicationGroupRole entity)
        {
            this.ThrowIfDisposed();
            if (entity == null)
            {
                throw new ArgumentNullException("role");
            }
            this._groupRoleStoreBase.Create(entity);
            this.Context.SaveChanges();
        }

        public void Update(ApplicationGroupRole entity)
        {
            this.ThrowIfDisposed();
            if (entity == null)
            {
                throw new ArgumentNullException("group");
            }
            this._groupRoleStoreBase.Update(entity);
            this.Context.SaveChanges();
        }

        public void Delete(ApplicationGroupRole entity)
        {
            this.ThrowIfDisposed();
            if (entity == null)
            {
                throw new ArgumentNullException("group");
            }
            this._groupRoleStoreBase.Delete(entity);
            this.Context.SaveChanges();
        }

        public ApplicationGroupRole FindById(string id) => this._groupRoleStoreBase.GetById(id);

        public Task<ApplicationGroupRole> FindByIdAsync(string id) => this._groupRoleStoreBase.GetByIdAsync(id);

        public IQueryable<ApplicationGroupRole> Group => this._groupRoleStoreBase.EntitySet;

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
            this._groupRoleStoreBase = null;
        }
    }
}