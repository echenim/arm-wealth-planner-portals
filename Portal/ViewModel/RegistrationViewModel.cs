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

        [MaxLength(15)]
        public string Tel { get; set; }

        [MaxLength(15)]
        public string BioetricVerificationNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [MaxLength(20)]
        public string EmailOfReferrer { get; set; }

        public static implicit operator Person(RegistrationViewModel model)
        {
            return new Person
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                BioetricVerificationNumber = model.BioetricVerificationNumber,
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
                BioetricVerificationNumber = model.BioetricVerificationNumber,
                Gender = model.Gender
            };
        }
    }
}