using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Portal.Domain.Models;

namespace Portal.Areas.Admin.ViewModels
{
    public class ProductInvestmentInformationView
    {
        [Required]
        public string ProductName { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public string Sections { get; set; }

        [Required]
        public string Abs { get; set; }

        public string RangOrCost { get; set; }

        public static implicit operator ProductInvestmentInfo(ProductInvestmentInformationView model)
        {
            return new ProductInvestmentInfo
            {
                ProductId = model.ProductId,
                Sections = model.Sections,
                Abs = model.Abs,
                RangOrCost = model.RangOrCost,
                OnCreated = DateTime.Now.ToUniversalTime()
            };
        }

        public static implicit operator ProductInvestmentInformationView(ProductInvestmentInfo model)
        {
            return new ProductInvestmentInformationView
            {
                ProductId = model.ProductId,
                Sections = model.Sections,
                Abs = model.Abs,
                RangOrCost = model.RangOrCost
            };
        }
    }
}