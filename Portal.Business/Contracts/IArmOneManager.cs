using System;
using System.Collections.Generic;
using System.Text;
using Portal.Domain.ViewModels;

namespace Portal.Business.Contracts
{
    public interface IArmOneManager
    {
        CustomerInformationView GetCustomerInformation(string username, string membershipnumber);

        CustomerInformationView GetCustomerInformation(string membershipnumber);

        bool UnLockAccount(string securityanswer);
    }
}