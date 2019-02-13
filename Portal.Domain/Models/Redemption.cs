using System;

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
