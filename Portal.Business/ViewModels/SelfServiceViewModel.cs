using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Portal.Business.ViewModels
{
    public class SelfServiceViewModel
    {}

    public class FeedbackViewModel
    {
        [Required(ErrorMessage = "Message Category is required")]
        [Display(Name = "Message Category")]
        public string MessageCategory { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Message is required")]
        [Display(Name = "Message")]
        public string Message { get; set; }

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        //trackservice
        public TrackServiceViewModel SelfService { get; set; }
    }

    public class EmbassyLetterViewModel
    {
        [Required(ErrorMessage = "Passport Number is required")]
        [Display(Name = "Passport Number")]
        public string PassportNumber { get; set; }

        [Required(ErrorMessage = "Attention Name is required")]
        [Display(Name = "Attention Name")]
        public string AttentionName { get; set; }

        [Required(ErrorMessage = "Recipient Address is required")]
        [Display(Name = "Recipient Address")]
        public string RecipientAddress { get; set; }

        [Display(Name = "Additional Instruction")]
        public string AdditionalInstruction { get; set; }

        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        //trackservice
        public TrackServiceViewModel SelfService { get; set; }
    }

    public class TrackServiceViewModel
    {
        //[Required(ErrorMessage = "Request Type is required")]
        //[Display(Name = "Request Type")]
        public string RequestType { get; set; }

        //[Required(ErrorMessage = "Tracking Number is required")]
        //[Display(Name = "Tracking Number")]
        public string TrackingNumber { get; set; }

        public List<RequestStatuses> RequestStatuses { get; set; }

        public TrackServiceViewModel()
        {
            RequestStatuses = new List<RequestStatuses>();
        }
    }

    public class ClientUpdateViewModel
    {
        public string TaxNumber { get; set; }
        public string Jurisdiction { get; set; }

        //success and error messages
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class RequestStatuses
    {
        public string TrackingNumber { get; set; }
        public int MembershipNumber { get; set; }
        public string RequestDescription { get; set; }
        public DateTime RequestDate { get; set; }
        public string CurrentStatus { get; set; }
        public string Remark { get; set; }
    }
}
