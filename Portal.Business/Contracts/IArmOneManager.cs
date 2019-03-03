using System;
using System.Collections.Generic;
using Portal.Business.ViewModels;
using Portal.Domain.ViewModels;

namespace Portal.Business.Contracts
{
    public interface IArmOneManager
    {
        CustomerInformationView GetCustomerInformation(string username, string password);

        CustomerInformationView GetCustomerInformation(string username);

        AllPriceResponse GetAllFundPrices(DateTime? date);

        AllPriceResponse GetAllFundPrices();

        KycStatus GetKycStatus(string customerEmail);

        List<KycStatus> GetKycStatus(List<string> customerEmail);

        bool UnLockAccount(string securityanswer);
    }
}