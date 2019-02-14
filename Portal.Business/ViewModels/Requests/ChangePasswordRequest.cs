namespace Portal.Business.ViewModels
{
    public class ChangePasswordRequest : BaseRequest
    {
        public int MembershipKey { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
