namespace Portal.Business.ViewModels
{
    public class ArmOneCustomerDetailsRequest
    {
        //either the membership key or the email address
        public string Id { get; set; }

        public string Channel { get; set; } = "Client_Portal";
    }
}
