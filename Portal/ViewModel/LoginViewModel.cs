using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.ViewModel
{
    public class LoginViewModel
    {
        [EmailAddress]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class LoginResponseViewModel
    {
        public string Name { get; set; }

        //[EmailAddress]
        public string Email { get; set; }

        public string Token { get; set; }
        public bool IsLoginSuccessful { get; set; }
    }

    public class EditUserViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        public int UserType { get; set; }

        public int CompanyId { get; set; }
        public string Comment { get; set; }
        public bool IsBlackisted { get; set; }
    }

    public class UserPermissionViewModel
    {
        // [EmailAddress]
        public string UserName { get; set; }

        public string PermissionName { get; set; }
    }

    public class DeleteUserViewModel
    {
        // [EmailAddress]
        public string Email { get; set; }
    }

    public class UserListModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        // [EmailAddress]
        public string Email { get; set; }

        public string UserName { get; set; }

        public string UserType { get; set; }

        public string CompanyName { get; set; }
        public string Comment { get; set; }
        public bool IsBlackisted { get; set; }
    }

    public class UserViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        // [EmailAddress]
        public string Email { get; set; }

        public string UserName { get; set; }

        public int UserType { get; set; }
        public int CompanyId { get; set; }
        public string Comment { get; set; }
        public bool IsBlackisted { get; set; }
    }

    public class UserInformationViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        // [EmailAddress]
        public string Email { get; set; }

        public string UserName { get; set; }

        public int UserType { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Comment { get; set; }
        public bool IsBlackisted { get; set; }
    }

    public class UserEditViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public int UserType { get; set; }
        public int CompanyId { get; set; }
        public string Comment { get; set; }
        public bool IsBlackisted { get; set; }
    }

    public class ChangePasswordViewModel
    {
        // [EmailAddress]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
    }
}