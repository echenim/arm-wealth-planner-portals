using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortalAPI.Domain;
using PortalAPI.Domain.Models;
using PortalAPI.Domain.Models.Identity;

namespace PortalAPI.Midleware.Implementations
{
    public class ApplicationGroupRoleService
    {
        private readonly ApplicationGroupRoleService _applicationRoleStore;
        private readonly ApplicationDbContext _context;

        public ApplicationGroupRoleService(ApplicationDbContext context)
        {
            _context = context;
            _applicationRoleStore = new ApplicationGroupRoleService(_context);
        }

        public IQueryable<ApplicationRole> Roles => _applicationRoleStore.Roles;

        public Task<ApplicationRole> FindByIdAsync(string id)
            => _applicationRoleStore.FindByIdAsync(id);

        public ApplicationRole FindById(string id)
            => _applicationRoleStore.FindById(id);

        public Task<ApplicationRole> FindByNameAsync(string groupName)
            => _applicationRoleStore.FindByNameAsync(groupName);
    }
}