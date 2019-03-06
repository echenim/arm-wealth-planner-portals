using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Domain.Models
{
    public class WhatYouNeedToKNowAboutThisProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Products))]
        public int ProductId { get; set; }

        [Required]
        public string Sections { get; set; }

        [Required]
        public int Hierarchy { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime OnCreated { get; set; }

        public Products Products { get; set; }
    }
}