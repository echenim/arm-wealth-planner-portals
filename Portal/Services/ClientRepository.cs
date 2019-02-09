using Portal.Areas.Client.Models;
//using Portal.Areas.Client.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Business.Contracts;
using Portal.Business.TestServices;
using Portal.Business.ViewModels;

namespace Portal.Services
{
    public class ClientRepository
    {
        //public readonly AppSettings _appSettings;
        //public ArmClientServices _clientService;
        //public readonly IConfiguration _configuration;
        public string _contentRootPath;

        //test
        private readonly IArmOneServiceConfigManager _configSettingManager;
        public TestArmClientServices _clientService;

        public ClientRepository(IArmOneServiceConfigManager configManager, string contentRootPath)
        {
            //_appSettings = appSettings;
            //_configuration = configuration;
            _configSettingManager = configManager;
            _contentRootPath = contentRootPath;
            _clientService = new TestArmClientServices(_configSettingManager, _contentRootPath);
        }

        public CustomerDetail GetUserProfile(int membershipKey)
        {
            var customerRequest = new ClientValidateRequest
            {
                CustomerReference = membershipKey.ToString()
            };
            var customerResponse = _clientService.ClientValidate(customerRequest);
            if (customerResponse != null)
            {
                return customerResponse.CustomerDetails.FirstOrDefault();
            }
            return null;
        }

        public List<LastTransactions> LoadLastTransactions(AuthenticateResponse user, SummaryResponse accounts, 
                                                            int count = 2, string type = "")
        {
            var transactions = new List<LastTransactions>();
            if (accounts != null && accounts.Summaries.Count > 0)
            {
                foreach (var summary in accounts.Summaries)
                {
                    var request = new LastTransactionRequest
                    {
                        MembershipNumber = user.MembershipKey,
                        ProductCode = summary.ProductCode,
                        Count = count
                    };

                    var code = summary.ProductCode;
                    var response = _clientService.GetLastTransactions(request);
                    if (response.LastTransactions != null && response.LastTransactions.Count > 0)
                    {
                        transactions = response.LastTransactions;
                    }
                }
            }
            return transactions;
        }


    }
}
