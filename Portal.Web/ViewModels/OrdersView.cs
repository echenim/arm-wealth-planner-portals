using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Web.ViewModels
{
    public class OrdersView
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public string CustNo { get; set; }
        public string Product { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
    }
}