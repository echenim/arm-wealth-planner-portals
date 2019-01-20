using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortalAPI.Domain.Models;

namespace PortalAPI.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal StartFrom { get; set; }
        public string Description { get; set; }

        public static implicit operator ProductViewModel(Products model)
        {
            return new ProductViewModel
            {
                Id = model.Id,
                ProductCategoryId = model.ProductCategoryId,
                ProductName = model.Name,
                StartFrom = model.StartFrom,
                Description = model.Description
            };
        }

        public static implicit operator Products(ProductViewModel model)
        {
            return new Products
            {
                Id = model.Id,
                ProductCategoryId = model.ProductCategoryId,
                Name = model.ProductName,
                StartFrom = model.StartFrom,
                Description = model.Description
            };
        }
    }
}