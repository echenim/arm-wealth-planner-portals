using Portal.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Business.StoreManagers
{
    public class ArmOneServiceConfigManager : IArmOneServiceConfigManager
    {
        public string ArmBaseUrl { get; set; }
        public string ArmOne { get; set; }
        public string ArmOneToken { get; set; }
        public string ArmAggregatorBaseUrl { get; set; }
        public string ArmOneEmail { get; set; }
        public string ArmOneUsername { get; set; }
        public string ArmOnePassword { get; set; }
        public string ArmServiceUsername { get; set; }
        public string ArmServicePassword { get; set; }
        public string SessionMaxIdleTime { get; set; }
        public string ArmMacKey { get; set; }
        public string ArmOneTokenUsername { get; set; }
        public string ArmOneTokenPassword { get; set; }
        public string ArmOneTokenEmail { get; set; }
    }
}