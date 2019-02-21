using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.ViewModel
{
    public class ItemView
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public decimal StartFrom { get; set; }
        public string Description { get; set; }
        public string ProductTypes { get; set; }
        public string Benefit { get; set; }
        public string Feature { get; set; }
        public string MoreInformation { get; set; }
        public string InvestmentManagement { get; set; }
        public string HowToBegin { get; set; }
        public bool IsActive { get; set; }
        public string Url { get; set; }
    }
}