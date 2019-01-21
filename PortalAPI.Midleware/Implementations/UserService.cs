using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PortalAPI.Domain;
using PortalAPI.Domain.Models.Identity;
using PortalAPI.Domain.ViewModels;
using PortalAPI.Midleware.Contracts;

namespace PortalAPI.Midleware.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<InternalUserView> Get(Func<InternalUserView, bool> predicate = null)
        {
            if (predicate != null)
            {
                var list = UserRoleView.AsEnumerable().Where(predicate: predicate).AsQueryable();
                return list;
            }

            var llist = UserRoleView.AsQueryable();
            return llist;
        }

        public InternalUserView FindById(Func<InternalUserView, bool> predicate)
            => UserRoleView.AsEnumerable().Where(predicate: predicate).SingleOrDefault();

        /// <summary>
        ///
        /// </summary>
        private IQueryable<InternalUserView> UserRoleView
            => (from users in _context.Users
                join usersrole in _context.UserRoles
                       on users.Id equals usersrole.UserId
                join roles in _context.Roles
                     on usersrole.RoleId equals roles.Id
                select new InternalUserView
                {
                    Id = users.Id,
                    Name = users.FullName,
                    Role = roles.Name,
                    Email = users.Email
                });
    }
}