﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Areas.Client.ViewModels
{
    public class SendOtpRequest : BaseRequest
    {
        public string CustomerReference { get; set; }
        public string SessionId { get; set; }
        public string CustomerAction { get; set; }
    }
}
