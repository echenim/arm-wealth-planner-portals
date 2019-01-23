using System;
using System.Linq;
using System.Threading.Tasks;
using PortalAPI.Domain;
using PortalAPI.Domain.Models.Identity;
using PortalAPI.Midleware.BaseStore;

namespace PensionManager.Business.Stores
{
    internal class ApplicationRoleStore : IDisposable
    {
        private bool _disposed;
        private RoleStoreBase _roleStore;
        private ApplicationDbContext _applicationDbContext;

        public ApplicationRoleStore(ApplicationDbContext context)
        {
            _applicationDbContext = context ?? throw new ArgumentNullException(nameof(context));
            _roleStore = new RoleStoreBase(context);
        }

        public IQueryable<ApplicationRole> Roles => _roleStore.EntitySet;

        public Task<ApplicationRole> FindByIdAsync(string id)
        {
            ThrowIfDisposed();
            return _roleStore.GetByIdAsync(id);
        }

        public ApplicationRole FindById(string id)
        {
            ThrowIfDisposed();
            return _roleStore.GetById(id);
        }

        public Task<ApplicationRole> FindByNameAsync(string name)
        {
            ThrowIfDisposed();

            return _roleStore.FindByNameAsync(name);
        }

        public ApplicationRole FindByName(string name)
        {
            return _roleStore.FindByName(name);
        }

        // DISPOSE STUFF: ===============================================

        public bool DisposeContext
        {
            get;
            set;
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (DisposeContext && disposing)
            {
                _applicationDbContext?.Dispose();
            }
            _disposed = true;
            _applicationDbContext = null;
            _roleStore = null;
        }
    }
}