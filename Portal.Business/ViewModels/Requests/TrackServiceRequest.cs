namespace Portal.Business.ViewModels
{
    public class TrackServiceRequest : BaseRequest
    {
        public int MembershipNumber { get; set; }
        public string TrackingNumber { get; set; }
        public string RequestType { get; set; }
    }
}
