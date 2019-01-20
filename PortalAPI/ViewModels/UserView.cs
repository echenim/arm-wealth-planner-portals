using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalAPI.ViewModels
{
    public class UserView
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string KindOfUser { get; set; }
    }
}