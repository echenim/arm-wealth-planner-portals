using Portal.Domain.ViewModels;

namespace Portal.Business.Contracts
{
    public interface IArmOneManager
    {
        CustomerInformationView GetCustomerInformation(string username, string password);

        CustomerInformationView GetCustomerInformation(string username);

        bool UnLockAccount(string securityanswer);
    }
}