using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARMClientPortal.ViewModels
{
    public class RedemptionRequest : BaseRequest
    {
        public string MembershipNumber { get; set; }
        public Decimal TotalAmount { get; set; }
        public List<RedemptionProduct> Products { get; set; }
        public string Source { get; set; }
        public string Reason { get; set; }
        public string ReasonOther { get; set; }
        public VerifyOtpRequest VerifyOtp { get; set; }

        public RedemptionRequest()
        {
            Products = new List<RedemptionProduct>();
            VerifyOtp = new VerifyOtpRequest();
        }
    }

    public class RedemptionProduct
    {
        public Decimal Amount { get; set; }
        public string ProductCode { get; set; }
    }

    public class VerifyOtpRequest
    {
        public string OtpCode { get; set; }
        public string SessionId { get; set; }
    }
}
