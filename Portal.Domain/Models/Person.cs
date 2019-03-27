using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Portal.Domain.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(15)]
        public string Tel { get; set; }

        public string ProspectCode { get; set; }

        public string Address { get; set; }

        [MaxLength(15)]
        public string BioetricVerificationNumber { get; set; }

        [Required]
        [MaxLength(10)]
        public bool IsCustomer { get; set; }

        public string MemberShipNo { get; set; }

        public string PortalOnBoarding { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime OnCreated { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        public ICollection<PurchaseOrders> PurchaseOrderses { get; set; }
    }
}