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
        private IOrdersAndSalesManager _andSalesManager;

        public CustomerBuyHistoryHelper(IPersonManager person, IOrdersAndSalesManager andSalesManager)
        {
            _person = person;
            _andSalesManager = andSalesManager;
        }

        public PersonAndPersonBuyHistoryView FetchPersonBuyHistory(long id)
        {
            var data = new PersonAndPersonBuyHistoryView();
            data.BuyHistory = _andSalesManager.PersonBuyHistory(id).ToList();
            data.PersonObj = _person.Get(s => s.Id.Equals(id)).SingleOrDefault();
            return data;
        }
    }
}