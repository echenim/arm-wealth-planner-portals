using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Business.Contracts;
using Portal.Domain.Models;

namespace Portal.Business.Utilities
{
    public class UserUtils
    {
        private readonly IPersonManager _manager;

        public UserUtils(IPersonManager manager)
            => _manager = manager;

        public Person GetUser(string email)
            => _manager.Get(s => s.Email.ToLower().Equals(email.ToLower())).SingleOrDefault();
    }
}