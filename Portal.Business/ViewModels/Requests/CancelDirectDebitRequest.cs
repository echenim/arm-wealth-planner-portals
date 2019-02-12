using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Business.ViewModels
{
    public class CancelDirectDebitRequest : BaseRequest
    {
        [JsonProperty("arm_ddref")]
        public string ArmDdRef { get; set; }

        [JsonProperty("arm_vendor_username")]
        public string ArmVendorUsername { get; set; }

        [JsonProperty("arm_hash")]
        public string ArmHash { get; set; }

        [JsonProperty("arm_cc_mask")]
        public string ArmCcMask { get; set; }

        [JsonProperty("arm_cc_type")]
        public string ArmCcType { get; set; }

        [JsonProperty("arm_cust_id")]
        public string ArmCustId { get; set; }
    }
}
