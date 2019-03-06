using System;
using System.Collections.Generic;
using System.Text;
using Portal.Domain.Models;

namespace Portal.Domain.ViewModels
{
    public class ProductAndInvestmentView
    {
        public Products Product { get; set; }
        public IEnumerable<ProductInvestmentInfo> InvestmentInfos { get; set; }
    }
}