using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Domain.Models;

namespace Portal.ViewModel
{
    public class PersonAndPersonBuyHistoryView
    {
        public Person PersonObj { get; set; }
        public List<Transactional> BuyHistory { get; set; }
    }
}