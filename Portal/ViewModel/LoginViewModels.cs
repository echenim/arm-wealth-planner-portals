using System.ComponentModel.DataAnnotations;

namespace Portal.ViewModel
{
    public class LoginViewModels
    {
        [Required(ErrorMessage = "user name is required")]
        [MinLength(4, ErrorMessage = "user name lenght must not be less than 4")]
        public string Username { get; set; }

        [Required(ErrorMessage = "password is required")]
        [MinLength(4, ErrorMessage = "password lengh must not be less than 4")]
        public string Password { get; set; }
    }
}