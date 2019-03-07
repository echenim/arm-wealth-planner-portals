using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public UserUtils(IPersonManager manager, IMemoryCache cache)
        {
            _manager = manager;
            _cache = cache;
        }

        public PersonView GetUser(string email)
        {
            var person = new PersonView();
            var n = _manager.Get(s => s.Email.ToLower().Equals(email.ToLower())).SingleOrDefault();
            return person;
        }

        public AuthenticateResponse GetDataHubUser()
        {
            var person = _cache.Get<AuthenticateResponse>("ArmUser");
            return person;
        }
    }
}