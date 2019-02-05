using System;
using System.Collections.Generic;
using System.Text;
using Portal.Domain.ViewModels;

namespace Portal.Business.Contracts
{
    public interface IErmOneManager
    {
        CustomerInformationView GetCustomerInformation(string username, string membershipnumber);

        CustomerInformationView GetCustomerInformation(string membershipnumber);

        bool UnLockAccount(string securityanswer);
    }
}