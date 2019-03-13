using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.ViewModel
{
    public class PaymentDetailView
    {
        public string Trns { get; set; }
        public Dictionary<string, string> Items { get; set; }
    }
}