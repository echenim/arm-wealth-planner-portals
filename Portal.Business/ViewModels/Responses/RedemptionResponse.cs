﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Business.ViewModels
{
    public class RedemptionResponse
    {
        public int MembershipNumber { get; set; }
        public string TrackingId { get; set; }
        public string Status { get; set; }
        public string StatusMessage { get; set; }
    }
}
