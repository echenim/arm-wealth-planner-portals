using Portal.Areas.Client.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Business.Contracts;
using Portal.Business.TestServices;
using Portal.Business.ViewModels;
using System.Security.Cryptography;
using System.Text;

namespace Portal.Services
{
    public class ClientRepository
    {
        public string _contentRootPath;

        //test
        private readonly IArmOneServiceConfigManager _configSettingManager;
        public TestArmClientServices _clientService;

        public ClientRepository(IArmOneServiceConfigManager configManager, string contentRootPath)
        {
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

        public SummaryResponse GetAccountSummary(int membershipkey)
        {
            var accountsResponse = new SummaryResponse();
            var accountsRequest = new SummaryRequest
            {
                MembershipNumber = membershipkey
            };

            accountsResponse = _clientService.GetAccountSummary(accountsRequest);

            return accountsResponse;
        }

        public TotalBalanceResponse GetTotalAccountBalance(int membershipkey)
        {
            var totalBalanceResponse = new TotalBalanceResponse();
            var totalBalanceRequest = new TotalBalanceRequest
            {
                MembershipNumber = membershipkey
            };
            totalBalanceResponse = _clientService.GetTotalBalance(totalBalanceRequest);

            return totalBalanceResponse;
        }

        public List<LastTransactions> LoadLastTransactions(AuthenticateResponse user, 
                                                            SummaryResponse accounts, 
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

        public string GenerateUniqueID(int key)
        {
            return string.Format("{0}{1:N}", key, Guid.NewGuid());
        }

        public string PaymentsHashString(string mackey, TransactionModel transact)
        {
            string hashstring = $@"{transact.ArmTranxID}{transact.ArmVendorUserName}
                                    {transact.ArmTranxAmount}{transact.ArmTranxNotiUrl}" + mackey;
            return hashstring;
        }

        public string DebitHashString(string mackey, DirectDebitTransactionModel transact)
        {
            string hashstring = $@"{transact.ArmCustomerID}{transact.ArmVendorUserName}
                                    {transact.ArmDdAmt}{transact.ArmDdNotiUrl}" + mackey;
            return hashstring;
        }

        public byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA512.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("x2"));

            return sb.ToString();
        }

    }
}
