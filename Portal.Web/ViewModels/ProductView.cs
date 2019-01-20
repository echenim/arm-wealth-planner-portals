using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortalAPI.Domain.Models;

namespace Portal.Web.ViewModels
{
    public class ProductView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductCategory { get; set; }
        public decimal StartFrom { get; set; }
        public string Description { get; set; }
    }
}