namespace Portal.Business.ViewModels
{
    public class TrackServiceRequest : BaseRequest
    {
        public string MembershipNumber { get; set; }
        public string TrackingNumber { get; set; }
        public string RequestType { get; set; }
    }
}