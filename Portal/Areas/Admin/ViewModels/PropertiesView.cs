using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NPOI.Util;
using Portal.Domain.Models;

namespace Portal.Areas.Admin.ViewModels
{
    public class PropertiesView
    {
        [Required]
        public string ProductName { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public string Sections { get; set; }

        [Required]
        public int Hierarchy { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public static implicit operator WhatYouNeedToKNowAboutThisProduct(PropertiesView model)
        {
            return new WhatYouNeedToKNowAboutThisProduct
            {
                ProductId = model.ProductId,
                Sections = model.Sections,
                Hierarchy = model.Hierarchy,
                Description = model.Description,
                Title = model.Title,
                OnCreated = DateTime.Now.ToUniversalTime()
            };
        }

        public static implicit operator PropertiesView(WhatYouNeedToKNowAboutThisProduct model)
        {
            return new PropertiesView
            {
                ProductId = model.ProductId,
                Sections = model.Sections,
                Hierarchy = model.Hierarchy,
                Description = model.Description,
                Title = model.Title
            };
        }
    }
}