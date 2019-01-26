//using System.Linq;
//using System.Threading.Tasks;

//using Microsoft.EntityFrameworkCore;
//using PensionManager.Domain.ModelsDbViews;

//namespace PensionManager.Business.BaseStore
//{
//   internal class FunctionAndCorrespondingUserRoleCountStoreBase
//    {
//        public DbContext Context{get;}
//        public DbSet<FunctionAndCorrespondingUserRoleCount> DbEntitySet { get; set; }

//        public FunctionAndCorrespondingUserRoleCountStoreBase(DbContext context)
//        {
//            this.Context = context;
//            this.DbEntitySet = context.Set<FunctionAndCorrespondingUserRoleCount>();
//        }

//        public IQueryable<FunctionAndCorrespondingUserRoleCount> EntitySet => this.DbEntitySet;

//        public FunctionAndCorrespondingUserRoleCount GetById(object id) => this.DbEntitySet.Find(new object[] { id });

//        public Task<FunctionAndCorrespondingUserRoleCount> GetByIdAsync(object id)
//            => this.DbEntitySet.FindAsync(new object[] { id });

//        public FunctionAndCorrespondingUserRoleCount FindByName(string name) => DbEntitySet.FirstOrDefault(s =>
//            s.Name.ToUpper().Equals(name.ToUpper()));

//        public Task<FunctionAndCorrespondingUserRoleCount> FindByNameAsync(string name) => DbEntitySet.FirstOrDefaultAsync(s =>
//            s.Name.ToUpper().Equals(name.ToUpper()));

//    }
//}