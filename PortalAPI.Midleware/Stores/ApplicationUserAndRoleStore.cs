using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortalAPI.Domain.Models.Identity;
using PortalAPI.Midleware.BaseStore;

namespace PortalAPI.Midleware.Stores
{
    internal class ApplicationUserAndRoleStore
    {
        private bool _disposed;
        private UserAndRoleStoreBase _userRoleStore;

        public DbContext Context
        {
            get;
            private set;
        }

        public ApplicationUserAndRoleStore(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException("context");
            _userRoleStore = new UserAndRoleStoreBase(context);
        }

        public IQueryable<ApplicationUserRole> GetRole => _userRoleStore.EntitySet;

        public IQueryable<ApplicationUserRole> GetRoles(string userId) =>
            _userRoleStore.DbEntitySet.Where(s => s.UserId.Equals(userId));

        public void AddToRoles(string userId, List<string> roleId)
        {
            this._userRoleStore.AddToRoles(userId, roleId);
            this.Context.SaveChanges();
        }

        public void Update(ApplicationUserRole entity)
        {
            this.ThrowIfDisposed();
            if (entity == null)
            {
                throw new ArgumentNullException("group");
            }
            this._userRoleStore.Update(entity);
            this.Context.SaveChanges();
        }

        public void Delete(string userId)
        {
            this.ThrowIfDisposed();
            if (userId == null)
            {
                throw new ArgumentNullException("user id");
            }
            this._userRoleStore.RemoveFromRoles(userId);
            this.Context.SaveChanges();
        }

        public ApplicationUserRole FindById(string id)
        {
            this.ThrowIfDisposed();
            return this._userRoleStore.GetById(id);
        }

        public Task<ApplicationUserRole> FindByIdAsync(string id)
        {
            this.ThrowIfDisposed();
            return this._userRoleStore.GetByIdAsync(id);
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
            this._userRoleStore = null;
        }
    }
}