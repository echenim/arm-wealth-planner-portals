namespace Portal.Business.ViewModels
{
    public class ArmOneRegisterRequest
    {
        public int Membershipkey { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurtiyQuestion2 { get; set; }
        public string SecurityAnswer { get; set; }
        public string SecurityAnswer2 { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Channel { get; set; }
    }
}
