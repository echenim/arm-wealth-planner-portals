using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Portal.Domain.Models;
using Portal.Domain.ModelView;

namespace Portal.Domain.ViewModels
{
    public class CartView
    {
        public IEnumerable<Transactional> CartCollection { get; set; }
        public Person Person { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public string TransactionNo { get; set; }
        public string TransactionParameter { get; set; }
        public string MemberUniqueIdentifier { get; set; }
        public string FullName { get; set; }
        public string PaymentGateway { get; set; }
        public string XmlPayload { get; set; }
        public string HashedData { get; set; }
        public string VendorUserName { get; set; }
        public string ReturnUr { get; set; }
        public decimal Total => SubTotal - Discount;
        public string PTotal => Total.ToString().Replace(".", "");

        #region signin

        [Required(ErrorMessage = "user name is required")]
        [MinLength(4, ErrorMessage = "user name lenght must not be less than 4")]
        public string Username { get; set; }

        [Required(ErrorMessage = "password is required")]
        [MinLength(4, ErrorMessage = "password lengh must not be less than 4")]
        public string Password { get; set; }

        #endregion signin

        #region registration

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(15)]
        public string Tel { get; set; }

        public string Address { get; set; }

        [MaxLength(15)]
        public string BioetricVerificationNumber { get; set; }

        #endregion registration
    }
}