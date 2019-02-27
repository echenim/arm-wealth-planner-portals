using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Business.Contracts;
using Portal.Domain;
using Portal.Domain.Models;

namespace Portal.Util
{
    public static class UserInformtion
    {
        public static Person UserName(string email)
        {
            return new ApplicationDbContext().Person.SingleOrDefault(s => s.Email.ToLower().Equals(email.ToLower()));
        }
    }
}