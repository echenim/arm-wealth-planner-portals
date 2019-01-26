using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Domain.Models
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(ProductCategory))]
        public int ProductCategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal StartFrom { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }

        public string IsExpressionOfInterest { get; set; }

        public ProductCategory ProductCategory { get; set; }
    }
}