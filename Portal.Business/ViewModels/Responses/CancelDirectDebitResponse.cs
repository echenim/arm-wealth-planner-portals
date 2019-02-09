using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Business.ViewModels
{
    public class CancelDirectDebitResponse
    {
        [JsonProperty("arm_dd_status_code")]
        public string ArmDdStatusCode { get; set; }

        [JsonProperty("arm_dd_status_msg")]
        public string ArmDdStatusMsg { get; set; }

        [JsonProperty("arm_cc_mask")]
        public string ArmCcMask { get; set; }

        [JsonProperty("arm_cc_type")]
        public string ArmCcType { get; set; }

        [JsonProperty("arm_ddref")]
        public string ArmDdRef { get; set; }

        [JsonProperty("arm_cust_id")]
        public string ArmCustId { get; set; }
    }
}
