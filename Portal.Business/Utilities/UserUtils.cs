using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Portal.Business.Contracts;
using Portal.Business.ViewModels;
using Portal.Domain.Models;
using Portal.Domain.ViewModels;

namespace Portal.Business.Utilities
{
    public class UserUtils
    {
        private readonly IPersonManager _manager;
        private readonly IMemoryCache _cache;

        private IHttpContextAccessor _contextAccessor;
        private HttpContext _context { get { return _contextAccessor.HttpContext; } }

        public UserUtils(IPersonManager manager, IMemoryCache cache, IHttpContextAccessor contextAccessor)
        {
            _manager = manager;
            _cache = cache;
            _contextAccessor = contextAccessor;
        }

        public PersonView GetUser(string email)
        {
            var person = new PersonView();
            var n = _manager.Get(s => s.Email.ToLower().Equals(email.ToLower())).SingleOrDefault();
            return person;
        }

        public AuthenticateResponse GetDataHubUser()
        {
            var client = new AuthenticateResponse();
            var person = _cache.Get<AuthenticateResponse>("ArmUser");

            if (_context.User.Identity.IsAuthenticated)
            {
                var user = _manager.Get(s => s.Email.Equals(_context.User.Identity.Name)).FirstOrDefault();
                if (user != null)
                {
                    client.EmailAddress = user.Email;
                    client.FirstName = user.FirstName;
                    client.LastName = user.LastName;
                    client.MembershipKey = user.MemberShipNo;
                    client.FullName = user.FullName;
                }               
            }
            
            return person ?? client;
        }
    }
}