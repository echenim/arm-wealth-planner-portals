using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Domain.Models
{
    public class Redemption
    {
        public int Id { get; set; }
        public string CustomerReference { get; set; }
        public string RedeemedProducts { get; set; }
        public Decimal Amount { get; set; }
        public string Reason { get; set; }
        public string ReasonOther { get; set; }
    }
}
