﻿using System;
using System.Collections.Generic;

namespace Portal.Business.ViewModels
{
    public class TrackServiceResponse
    {
        public List<StatusList> RequestStatuses { get; set; }

        public TrackServiceResponse()
        {
            RequestStatuses = new List<StatusList>();
        }
    }

    public class StatusList
    {
        public string TrackingNumber { get; set; }
        public int MembershipNumber { get; set; }
        public string RequestDescription { get; set; }
        public DateTime RequestDate { get; set; }
        public string CurrentStatus { get; set; }
        public string Remark { get; set; }
    }
}
