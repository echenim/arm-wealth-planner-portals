using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Areas.Client.ViewModels
{
    public class AuthenticateRequest : BaseRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
