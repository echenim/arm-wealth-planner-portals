﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Areas.Client.ViewModels
{
    public class ArmOneChangePasswordRequest : BaseRequest
    {
        public string Channel { get; set; }
        public Boolean IsReset { get; set; }
        public int MembershipKey { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
