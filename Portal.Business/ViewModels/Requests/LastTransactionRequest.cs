namespace Portal.Business.ViewModels
{
    public class LastTransactionRequest : BaseRequest
    {
        public string MembershipNumber { get; set; }
        public string ProductCode { get; set; }
        public int Count { get; set; }
    }
}