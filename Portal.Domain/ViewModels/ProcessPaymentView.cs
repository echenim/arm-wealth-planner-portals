using System;
using System.Collections.Generic;
using System.Text;
using Portal.Domain.Models;

namespace Portal.Domain.ViewModels
{
    public class ProcessPaymentView
    {
        public string TransactionNo { get; set; }
        public string Amount { get; set; }
    }
}