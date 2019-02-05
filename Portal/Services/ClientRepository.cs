using Portal.Areas.Client.Models;
using Portal.Areas.Client.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Services
{
    public class ClientRepository
    {
        public readonly AppSettings _appSettings;
        public ArmClientServices _clientService;
        public string _contentRootPath;
        public readonly IConfiguration _configuration;

        public ClientRepository(AppSettings appSettings, IConfiguration configuration)
        {
            _appSettings = appSettings;
            _clientService = new ArmClientServices(_appSettings, _contentRootPath, _configuration);
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

        public List<LastTransactions> LoadLastTransactions(AuthenticateResponse user, SummaryResponse accounts, int count = 2, string type = "")
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
