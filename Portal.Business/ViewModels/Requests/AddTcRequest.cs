namespace Portal.Business.ViewModels
{
    public class AddTcRequest : BaseRequest
    {
        public int MembershipKey { get; set; }
        public bool IsTcAgreed { get; set; }
    }
}
