using System;
using System.ComponentModel.DataAnnotations;

namespace Portal.Business.ViewModels
{
    public class AccountViewModel
    {
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [Display(Name = "Old Password")]
        public string OldPassword { get; set; }

        [Required]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }
        [Required]
        [Display(Name = "Confirm New Password")]
        public string ConfirmNewPassword { get; set; }
    }

    public class AddQuestionViewModel
    {
        [Required]
        [Display(Name = "New Question")]
        public string NewQuestion { get; set; }

        [Required]
        [Display(Name = "New Answer")]
        public string NewAnswer { get; set; }
        [Required]
        [Display(Name = "Confirm New Answer")]
        public string ConfirmNewAnswer { get; set; }
    }

    public class AccountDetailViewModel
    {
        public string FullName { get; set; }
        public int MembershipNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public DateTime LastLoggedIn { get; set; }

        //reset password
        public ChangePasswordViewModel ResetPassword { get; set; }
    }
}
