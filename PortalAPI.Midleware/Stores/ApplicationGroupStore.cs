using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using PortalAPI.Domain.Models.Identity;
using PortalAPI.Midleware.BaseStore;

namespace PortalAPI.Midleware.Stores
{
    internal class ApplicationGroupStore
    {
        private bool _disposed;
        private GroupStoreBase _groupStore;

        public DbContext Context
        {
            get;
            private set;
        }

        public ApplicationGroupStore(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException("context");
            _groupStore = new GroupStoreBase(context);
        }

        public IQueryable<ApplicationGroup> Group => this._groupStore.EntitySet;

        public void Create(ApplicationGroup entity)
        {
            this.ThrowIfDisposed();
            if (entity == null)
            {
                throw new ArgumentNullException("role");
            }
            this._groupStore.Create(entity);
            this.Context.SaveChanges();
        }

        public void Update(ApplicationGroup entity)
        {
            this.ThrowIfDisposed();
            if (entity == null)
            {
                throw new ArgumentNullException("group");
            }
            this._groupStore.Update(entity);
            this.Context.SaveChanges();
        }

        public void Delete(ApplicationGroup entity)
        {
            this.ThrowIfDisposed();
            if (entity == null)
            {
                throw new ArgumentNullException("group");
            }
            this._groupStore.Delete(entity);
            this.Context.SaveChanges();
        }

        public ApplicationGroup FindById(string id) => this._groupStore.GetById(id);

        public Task<ApplicationGroup> FindByIdAsync(string id) => this._groupStore.GetByIdAsync(id);

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
            this._groupStore = null;
        }
    }
}