using System;

namespace Portal.Business.ViewModels
{
    public class ArmOnePasswordResetRequest : BaseRequest
    {
        public string Channel { get; set; }
        public Boolean IsReset { get; set; }
        public string MembershipKey { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
