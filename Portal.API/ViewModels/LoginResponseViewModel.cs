namespace Portal.API.ViewModels
{
    public class LoginResponseViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public string Token { get; set; }
        public bool IsLoginSuccessful { get; set; }
    }
}