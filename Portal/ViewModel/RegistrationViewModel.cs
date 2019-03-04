using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Portal.Domain.Models;

namespace Portal.ViewModel
{
    public class RegistrationViewModel
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }

        [MaxLength(20)]
        public string MembershipNo { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(15)]
        public string Tel { get; set; }

        [MaxLength(11, ErrorMessage = "BVN must be 11 digit")]
        [MinLength(11, ErrorMessage = "BVN must be 11 digit")]
        public string BioetricVerificationNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Address { get; set; }

        [EmailAddress]
        public string EmailOfReferrer { get; set; }

        public static implicit operator Person(RegistrationViewModel model)
        {
            return new Person
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                BioetricVerificationNumber = model.BioetricVerificationNumber,
                Address = model.Address,
                Tel = model.Tel,
                Gender = model.Gender,
                IsCustomer = true,
                OnCreated = DateTime.Now.ToUniversalTime(),
                PortalOnBoarding = $"NPB"
            };
        }

        public static implicit operator RegistrationViewModel(Person model)
        {
            return new RegistrationViewModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Address = model.Address,
                Tel = model.Tel,
                BioetricVerificationNumber = model.BioetricVerificationNumber,
                Gender = model.Gender
            };
        }
    }
}