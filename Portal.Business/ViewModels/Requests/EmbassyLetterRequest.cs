namespace Portal.Business.ViewModels
{
    public class EmbassyLetterRequest : BaseRequest
    {
        public int MembershipKey { get; set; }
        public string PassPortNumber { get; set; }
        public string AttentionName { get; set; }
        public string RecipientAddress { get; set; }
        public string AdditionalInstruction { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
