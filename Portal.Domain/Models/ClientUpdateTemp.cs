using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Domain.Models
{
    public class ClientUpdateTemp
    {
        public int Id { get; set; }
        public int MembershipNumber { get; set; }
        public string ProgressStatus { get; set; }
        public string EvaluationStatus { get; set; }
        public byte[] Passport { get; set; }
        public byte[] Signature { get; set; }
        public byte[] Thumbprint { get; set; }
        public byte[] ValidID { get; set; }
        public string TaxNumber { get; set; }
        public string Jurisdiction { get; set; }
        public Boolean? IsKYCApproved { get; set; }
        public Boolean? IsPassportApproved { get; set; }
        public Boolean? IsSignatureApproved { get; set; }
        public Boolean? IsThumbprintApproved { get; set; }
        public Boolean? IsValidIdApproved { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
