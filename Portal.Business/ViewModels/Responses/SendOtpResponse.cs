﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Business.ViewModels
{
    public class SendOtpResponse
    {
        public string CustomerReference { get; set; }
        public string Status { get; set; }
        public string StatusMessage { get; set; }
    }
}