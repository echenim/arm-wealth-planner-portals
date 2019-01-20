using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalAPI.ViewModels
{
    public class LoginResponseViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public string Token { get; set; }
        public bool IsLoginSuccessful { get; set; }
    }
}