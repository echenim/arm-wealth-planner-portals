﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Areas.Client.ViewModels
{
    public class ArmOneAuthTokenResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public string CustomerReference { get; set; }
    }
}
