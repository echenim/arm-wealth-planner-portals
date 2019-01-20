using System.ComponentModel.DataAnnotations;

namespace PortalAPI.Domain.Models
{
    public class PolicyModel
    {
        [Key]
        public int Id { get; set; }

        public string PolicyName { get; set; }
    }
}