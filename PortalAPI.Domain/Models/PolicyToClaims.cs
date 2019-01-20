using System.ComponentModel.DataAnnotations;

namespace PortalAPI.Domain.Models
{
    public class PolicyToClaims
    {
        [Key]
        public int Id { get; set; }

        public string PolicyName { get; set; }
        public string ClaimName { get; set; }
        public string ClaimValue { get; set; }
    }
}