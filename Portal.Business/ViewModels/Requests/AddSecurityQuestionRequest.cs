namespace Portal.Business.ViewModels
{
    public class AddSecurityQuestionRequest : BaseRequest
    {
        public string MembershipNumber { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
    }
}