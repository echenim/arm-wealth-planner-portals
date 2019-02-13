namespace Portal.Business.ViewModels
{
    public class FeedbackRequest : BaseRequest
    {
        public int MembershipNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string MessageCategory { get; set; }
        public string Message { get; set; }
    }
}
