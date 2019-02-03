using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Areas.Client.ViewModels
{
    public class ResetPasswordRequest : BaseRequest
    {
        public string Username { get; set; }
        public string EmailAddress { get; set; }
    }
}
