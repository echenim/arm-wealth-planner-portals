﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Areas.Client.ViewModels
{
    public class ClientValidateRequest : BaseRequest
    {
        public string CustomerReference { get; set; }
    }
}
