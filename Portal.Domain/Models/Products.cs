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

        public string Description { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string ProductTypes { get; set; }

        public string Features { get; set; }
        public string Benefits { get; set; }
        public string MoreInformation { get; set; }
        public string InvestmentManagement { get; set; }
        public string HowToBegin { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public ProductCategory ProductCategory { get; set; }
    }
}