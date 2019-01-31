using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Areas.Client.ViewModels
{
    public class StatementRequest : BaseRequest
    {
        public int MembershipNumber { get; set; }
        public string ProductCode { get; set; }
        public string TransactionType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Amount { get; set; }
    }
}
