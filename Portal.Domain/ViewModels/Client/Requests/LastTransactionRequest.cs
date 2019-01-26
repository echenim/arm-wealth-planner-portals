﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARMClientPortal.ViewModels
{
    public class LastTransactionRequest : BaseRequest
    {
        public int MembershipNumber { get; set; }
        public string ProductCode { get; set; }
        public int Count { get; set; }
    }
}
