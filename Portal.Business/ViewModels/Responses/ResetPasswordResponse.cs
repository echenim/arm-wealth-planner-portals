namespace Portal.Business.ViewModels
{
    public class ResetPasswordResponse : BaseResponse
    {
        public string FullName { get; set; }
        public int MembershipKey { get; set; }
        public string EmailAddress { get; set; }
        public string NewPassword { get; set; }
    }
}
