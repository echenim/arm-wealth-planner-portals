﻿using System;

namespace Portal.Business.ViewModels
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
