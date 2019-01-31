using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Areas.Client.ViewModels
{
    public class ClientValidateResponse
    {
        public List<CustomerDetail> CustomerDetails { get; set; }
    }

    public class ProductItem
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
    }

    public class CustomerDetail
    {
        public int MembershipNumber { get; set; }
        public string CustomerReference { get; set; }
        public string CustomerReferenceAlternate { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Status { get; set; }
        public string StatusMessage { get; set; }
        public List<ProductItem> ProductItems { get; set; }
    }
}
