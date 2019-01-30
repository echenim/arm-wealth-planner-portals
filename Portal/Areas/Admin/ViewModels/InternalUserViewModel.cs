using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Portal.Areas.Admin.ViewModels
{
    public class InternalUserViewModel
    {
        public InternalUserViewModel()
            => AvailableRoles = new List<SelectListItem>();

        public long Id { get; set; }

        [Required(ErrorMessage = "FirstName is required, please provide ")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required, please provide ")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required, please provide ")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [MaxLength(15, ErrorMessage = "password length should not be more than 15 characters")]
        //[MinLength(5, ErrorMessage = "password shouldn ot be less than 5 characters")]
        [Required(ErrorMessage = "Password is required, please provided password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password comfirmation failed, please enter a matching password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Role is required, please select one ")]
        public string Roles { get; set; }

        public List<SelectListItem> AvailableRoles { get; set; }
    }

    public class EditInternalUserViewModel
    {
        public EditInternalUserViewModel()
            => AvailableRoles = new List<SelectListItem>();

        public long Id { get; set; }

        [Required(ErrorMessage = "FirstName is required, please provide ")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required, please provide ")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required, please provide ")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Role is required, please select one ")]
        public string Roles { get; set; }

        public List<SelectListItem> AvailableRoles { get; set; }
    }
}