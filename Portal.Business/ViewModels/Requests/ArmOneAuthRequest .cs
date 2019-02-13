namespace Portal.Business.ViewModels
{
    public class ArmOneAuthRequest
    {
        public string Membershipkey { get; set; }
        public string Password { get; set; }
        public string Channel { get; set; }
        public string RedirectURL { get; set; }
    }
}
