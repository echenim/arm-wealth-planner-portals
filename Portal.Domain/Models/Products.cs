﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Domain.Models
{
    public class Products
    {
        //public Products()
        //{
        //    // ProductInvestmentInfos = new HashSet<ProductInvestmentInfo>();
        //    WhatYouNeedToKNowAboutThisProducts = new List<WhatYouNeedToKNowAboutThisProduct>();
        //}

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

        [Required]
        public bool IsActive { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        public ICollection<WhatYouNeedToKNowAboutThisProduct> WhatYouNeedToKNowAboutThisProducts { get; set; }
        public ICollection<ProductInvestmentInfo> ProductInvestmentInfos { get; set; }
    }
}