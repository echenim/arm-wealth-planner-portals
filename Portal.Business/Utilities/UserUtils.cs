using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Business.Contracts;
using Portal.Domain.Models;
using Portal.Domain.ViewModels;

namespace Portal.Business.Utilities
{
    public class UserUtils
    {
        private readonly IPersonManager _manager;

        public UserUtils(IPersonManager manager)
            => _manager = manager;

        public PersonView GetUser(string email)
        {
            var person = new PersonView();
            var n = _manager.Get(s => s.Email.ToLower().Equals(email.ToLower())).SingleOrDefault();
            return person;
        }
    }
}