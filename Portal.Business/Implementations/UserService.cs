using System;
using System.Linq;
using Portal.Domain;
using Portal.Domain.ViewModels;
using Portal.Business.Contracts;

namespace Portal.Business.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<ViewModelInternalUser> Get(Func<ViewModelInternalUser, bool> predicate = null)
        {
            if (predicate != null)
            {
                var list = UserRoleView.AsEnumerable().Where(predicate: predicate).AsQueryable();
                return list;
            }

            var llist = UserRoleView.AsQueryable();
            return llist;
        }

        public ViewModelInternalUser FindById(Func<ViewModelInternalUser, bool> predicate)
            => UserRoleView.AsEnumerable().Where(predicate: predicate).SingleOrDefault();

        /// <summary>
        ///
        /// </summary>
        private IQueryable<ViewModelInternalUser> UserRoleView
            => (from users in _context.Users
                join usersrole in _context.UserRoles
                       on users.Id equals usersrole.UserId
                join roles in _context.Roles
                     on usersrole.RoleId equals roles.Id
                select new ViewModelInternalUser
                {
                    Id = users.Id,
                    Name = users.FullName,
                    Role = roles.Name,
                    Email = users.Email,
                    IsActive = users.LockoutEnabled ? "Yes" : "No"
                });
    }
}