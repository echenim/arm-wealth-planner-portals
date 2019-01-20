using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Test.Models
{
    public class ProductViewModel
    {
        //public ProductViewModel()
        //{
        //    AvailableCategories = new List<SelectListItem>();
        //}

        public int Id { get; set; }
        public string Name { get; set; }

        //public int ProductCategory { get; set; }
        public decimal StartFrom { get; set; }

        ////////public string Description { get; set; }

        //[Required]
        //public IFormFile UploadProductImage { get; set; }

        //public List<SelectListItem> AvailableCategories { get; set; }
    }
}