//using System;
//using System.Linq;
//using System.Threading.Tasks;
//using PensionManager.Business.BaseStore;
//using PortalAPI.Domain;
//using PortalAPI.Domain.Models.Identity;

//namespace PensionManager.Business.Stores
//{
//    internal class ApplicationUserStore : IDisposable
//    {
//        private bool _disposed;
//        private UserStoreBase _userStore;

//        private ApplicationDbContext _applicationDbContext;

//        public ApplicationUserStore(ApplicationDbContext context)
//        {
//            _applicationDbContext = context ?? throw new ArgumentNullException(nameof(context));
//            _userStore = new UserStoreBase(_applicationDbContext);
//        }

//        public IQueryable<ApplicationUser> Users
//        {
//            get { return _userStore.EntitySet; }
//        }

//        public Task<ApplicationUser> FindByIdAsync(string id)
//        {
//            ThrowIfDisposed();
//            return _userStore.GetByIdAsync(id);
//        }

//        public ApplicationUser FindById(string id)
//        {
//            ThrowIfDisposed();
//            return _userStore.GetById(id);
//        }

//        //public Task<ApplicationUser> FindByNameAsync(string name)
//        //{
//        //    ThrowIfDisposed();
//        //    return _userStore.FindByNameAsync(name);
//        //}

//        //public ApplicationUser FindByName(string name)
//        //{
//        //    return _userStore.FindByName(name);
//        //}

//        // DISPOSE STUFF: ===============================================

//        public bool DisposeContext
//        {
//            get;
//            set;
//        }

//        private void ThrowIfDisposed()
//        {
//            if (_disposed)
//            {
//                throw new ObjectDisposedException(GetType().Name);
//            }
//        }

//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }

//        protected virtual void Dispose(bool disposing)
//        {
//            if (DisposeContext && disposing)
//            {
//                _applicationDbContext?.Dispose();
//            }
//            _disposed = true;
//            _applicationDbContext = null;
//            _userStore = null;
//        }
//    }
//}