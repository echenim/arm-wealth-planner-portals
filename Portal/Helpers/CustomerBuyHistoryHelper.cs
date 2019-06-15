using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Business.Contracts;
using Portal.ViewModel;

namespace Portal.Helpers
{
    public class CustomerBuyHistoryHelper
    {
        private IPersonManager _person;
        private ICartManager _andSalesManager;

        public CustomerBuyHistoryHelper(IPersonManager person, ICartManager andSalesManager)
        {
            _person = person;
            _andSalesManager = andSalesManager;
        }

        public PersonAndPersonBuyHistoryView FetchPersonBuyHistory(string id)
        {
            var data = new PersonAndPersonBuyHistoryView();
            data.BuyHistory = _andSalesManager.Get(s => s.ItemOwner.Equals(id)).ToList();
            data.PersonObj = _person.Get(s => s.Email.Equals(id)).SingleOrDefault();
            return data;
        }
    }
}