using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Domain.Models
{
    public class ProductFeatures
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(Products))]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        public virtual Products Products { get; set; }
    }
}