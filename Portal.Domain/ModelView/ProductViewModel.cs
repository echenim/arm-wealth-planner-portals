using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Portal.Domain.ModelView
{
    public class ProductViewModel
    {
        public ProductViewModel() => AvailableCategories = new List<SelectListItem>();

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int ProductCategory { get; set; }

        public decimal StartFrom { get; set; }

        public string Description { get; set; }

        [Required]
        public IFormFile UploadProductImage { get; set; }

        [Required]
        public string ProductTypes { get; set; }

        public string Benefit { get; set; }
        public string Feature { get; set; }

        public List<SelectListItem> AvailableCategories { get; set; }
    }
}