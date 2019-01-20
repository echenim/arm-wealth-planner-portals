using System.ComponentModel.DataAnnotations;

namespace PortalAPI.Domain.Models
{
    public class ProductOwner
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}