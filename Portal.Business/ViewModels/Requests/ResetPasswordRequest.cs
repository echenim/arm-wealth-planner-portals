using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Business.ViewModels
{
    public class ResetPasswordRequest : BaseRequest
    {
        public string Username { get; set; }
        public string EmailAddress { get; set; }
    }
}
