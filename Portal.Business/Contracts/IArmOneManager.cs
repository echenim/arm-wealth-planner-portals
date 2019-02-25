using System.Collections.Generic;
using Portal.Domain.ViewModels;

namespace Portal.Business.Contracts
{
    public interface IArmOneManager
    {
        CustomerInformationView GetCustomerInformation(string username, string password);

        CustomerInformationView GetCustomerInformation(string username);

        KycStatus GetKycStatus(string customerEmail);

        List<KycStatus> GetKycStatus(List<string> customerEmail);

        bool UnLockAccount(string securityanswer);
    }
}