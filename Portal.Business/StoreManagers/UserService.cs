using System;
using System.Collections.Generic;
using System.Linq;
using Portal.Domain;
using Portal.Domain.ViewModels;
using Portal.Business.Contracts;

namespace Portal.Business.StoreManagers
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
            var users = from usrgr in _context.ApplicationUserGroup
                join gr in _context.ApplicationGroup on usrgr.ApplicationGroupId equals gr.Id
                join usr in _context.Users on usrgr.ApplicationUserId equals usr.Id
                select new
                {
                    id = usr.Id,
                    Name = usr.FullName,
                    Email = usr.Email,
                    
                    Role = gr.Name

                };

            var result = new List<ViewModelInternalUser>();
            foreach (var item in users)
            {
                result.Add(new ViewModelInternalUser
                {
                    Id = item.id,
                    Name = item.Name,
                    Role = item.Role,
                    Email = item.Email
                });
            }

            var list = predicate != null ? result.Where(predicate) : result;

            return list.AsQueryable();
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