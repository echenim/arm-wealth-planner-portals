namespace Portal.API.ViewModels
{
    public class EditUserViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public virtual UserViewModel v { get; set; }
    }
}