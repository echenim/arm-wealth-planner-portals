using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Portal.Business.ViewModels
{
    public class ArmOneAuthResponse
    {
        [JsonProperty("ResponseCode")]
        public string ResponseCode { get; set; }
        [JsonProperty("ResponseDescription")]
        public string ResponseDescription { get; set; }
        [JsonProperty("SessionKey")]
        public string SessionKey { get; set; }
        [JsonProperty("RedirectURL")]
        public string RedirectURL { get; set; }
        [JsonProperty("MembershipKey")]
        public int MembershipKey { get; set; }
        [JsonProperty("EmailAddress")]
        public string EmailAddress { get; set; }
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }
        [JsonProperty("LastName")]
        public string LastName { get; set; }
        [JsonProperty("SecurityQuestion")]
        public string SecurityQuestion { get; set; }
        [JsonProperty("SecurityQuestion2")]
        public string SecurityQuestion2 { get; set; }
        [JsonProperty("IsAccountActivated")]
        public Boolean IsAccountActivated { get; set; }
        [JsonProperty("Subscription")]
        public List<Subscription> Subscription { get; set; }

        public ArmOneAuthResponse()
        {
            Subscription = new List<Subscription>();
        }
    }

    public class Subscription
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("SubscriptionSpecifics")]
        public string SubscriptionSpecifics { get; set; }
    }
}
