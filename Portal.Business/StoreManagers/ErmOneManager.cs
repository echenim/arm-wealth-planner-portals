using System;
using System.Collections.Generic;
using System.Text;
using Portal.Business.Contracts;
using Portal.Domain.ViewModels;

namespace Portal.Business.StoreManagers
{
    public class ErmOneManager : IErmOneManager
    {
        public CustomerInformationView GetCustomerInformation(string username, string membershipnumber)
        {
            var result = new CustomerInformationView();

            #region service calling for customer information

            var customer = "";

            #endregion service calling for customer information

            return result;
        }

        public CustomerInformationView GetCustomerInformation(string membershipnumber)
        {
            var result = new CustomerInformationView();

            #region service calling for customer information

            var customer = "";

            #endregion service calling for customer information

            return result;
        }

        public bool UnLockAccount(string securityanswer)
        {
            var state = false;

            #region service callingfor security question

            var result = "";

            #endregion service callingfor security question

            return state;
        }
    }
}