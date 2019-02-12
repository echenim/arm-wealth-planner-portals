using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Business.ViewModels
{
    public class AppSettings
    {
        public string DbConfigString { get; set; }
        public string ArmBaseUrl { get; set; }
        public string ArmAggregatorBaseUrl { get; set; }
        public string ArmServiceUsername { get; set; }
        public string ArmServicePassword { get; set; }
        public string SessionMaxIdleTime { get; set; }
        public string ArmMacKey { get; set; }
        public string ArmOne { get; set; }
        public string ArmOneToken { get; set; }
        public string ArmOneTokenUsername { get; set; }
        public string ArmOneTokenPassword { get; set; }
        public string ArmOneTokenEmail { get; set; }
        public string ChangePassword { get; set; }
    }
}
