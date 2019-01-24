using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using PortalAPI.Domain.Models.Identity;
using PortalAPI.Midleware.StoreBase;

namespace PortalAPI.Midleware.Stores
{
    internal class ApplicationGroupStore : IDisposable
    {
        private bool _disposed;
        private GroupStoreBase _groupStore;

        public ApplicationGroupStore(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this.Context = context;
            this._groupStore = new GroupStoreBase(context);
        }

        public IQueryable<ApplicationGroup> Groups
        {
            get
            {
                return this._groupStore.EntitySet;
            }
        }

        public DbContext Context
        {
            get;
            private set;
        }

        public virtual void Create(ApplicationGroup group)
        {
            this.ThrowIfDisposed();
            if (group == null)
            {
                throw new ArgumentNullException("group");
            }
            this._groupStore.Create(group);
            this.Context.SaveChanges();
        }

        public virtual async Task CreateAsync(ApplicationGroup group)
        {
            this.ThrowIfDisposed();
            if (group == null)
            {
                throw new ArgumentNullException("group");
            }
            this._groupStore.Create(group);
            await this.Context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(ApplicationGroup group)
        {
            this.ThrowIfDisposed();
            if (group == null)
            {
                throw new ArgumentNullException("group");
            }
            this._groupStore.Delete(group);
            await this.Context.SaveChangesAsync();
        }

        public virtual void Delete(ApplicationGroup group)
        {
            this.ThrowIfDisposed();
            if (group == null)
            {
                throw new ArgumentNullException("group");
            }
            this._groupStore.Delete(group);
            this.Context.SaveChanges();
        }

        public Task<ApplicationGroup> FindByIdAsync(long roleId)
        {
            this.ThrowIfDisposed();
            return this._groupStore.GetByIdAsync(roleId);
        }

        public ApplicationGroup FindById(long roleId)
        {
            this.ThrowIfDisposed();
            return this._groupStore.GetById(roleId);
        }

        public ApplicationGroup FindByName(string groupName)
        {
            return _groupStore.EntitySet.SingleOrDefault(s => s.Name.Equals(groupName));
        }

        public virtual async Task UpdateAsync(ApplicationGroup group)
        {
            this.ThrowIfDisposed();
            if (group == null)
            {
                throw new ArgumentNullException("group");
            }
            this._groupStore.Update(group);
            await this.Context.SaveChangesAsync();
        }

        public virtual void Update(ApplicationGroup group)
        {
            this.ThrowIfDisposed();
            if (group == null)
            {
                throw new ArgumentNullException("group");
            }
            this._groupStore.Update(group);
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
            this._groupStore = null;
        }
    }
}