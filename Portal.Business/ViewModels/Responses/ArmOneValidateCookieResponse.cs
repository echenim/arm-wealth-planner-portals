﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Portal.Business.ViewModels
{
    public class ArmOneValidateCookieResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public int MembershipKey { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SessionKey { get; set; }
        public Boolean IsAccountActivated { get; set; }
        [JsonProperty("Subscription")]
        public List<Subscriptions> Subscription { get; set; }

        public ArmOneValidateCookieResponse()
        {
            Subscription = new List<Subscriptions>();
        }
    }

    public class Subscriptions
    {
        public string Name { get; set; }
        public string SubscriptionSpecifics { get; set; }
    }
}
