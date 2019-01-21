using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Portal.Web.ViewModels
{
    public class InternalUserViewModel
    {
        public InternalUserViewModel()
            => AvailableRoles = new List<SelectListItem>();

        public long Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Roles { get; set; }

        public List<SelectListItem> AvailableRoles { get; set; }
    }
}