using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portal.Business.Contracts;
using Portal.Domain.Models;

namespace Portal.Controllers
{
    public class UtilsController : Controller
    {
        private readonly IPersonManager _personManager;

        public UtilsController(IPersonManager personManager)
        {
            _personManager = personManager;
        }

        public Person Information(string email)
        {
            return _personManager.Get(s => s.Email.ToLower().Equals(email.ToLower())).SingleOrDefault();
        }
    }
}