using System.ComponentModel.DataAnnotations;

namespace Portal.Domain.Models
{
    public class PolicyModel
    {
        [Key]
        public int Id { get; set; }

        public string PolicyName { get; set; }
    }
}