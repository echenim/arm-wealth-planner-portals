using System;
using System.Collections.Generic;
using System.Linq;
using Portal.Business.Contracts;
using Portal.Business.TestServices;
using Portal.Business.ViewModels;
using System.Security.Cryptography;
using System.Text;
using Portal.Business.Utilities;
using System.Data.SqlClient;
using Dapper;

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

        public Summaries GetProductInAccount(string productcode, SummaryResponse accounts)
        {
            if (accounts.Summaries != null)
            {
                foreach (var item in accounts.Summaries)
                {
                    if (item.ProductCode == productcode)
                    {
                        return item;
                    }
                }
            }
            return null;
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

        public StatementResponse GetClientTransactions(AuthenticateResponse user,
                                                        AccountStatementViewModel model)
        {
            var response = new StatementResponse();
            var request = new StatementRequest
            {
                MembershipNumber = user.MembershipKey,
                EndDate = model.EndDate.Value.AddDays(1),
                StartDate = model.StartDate.Value.AddDays(1),
                TransactionType = model.TransactionType,
                ProductCode = model.ProductCode
            };

            response = _clientService.GetTransactions(request);

            return response;
        }

        public SubAccountsResponse GetFamilyAccount(string membershipkey)
        {
            var response = new SubAccountsResponse();
            var request = new SubAccountsRequest { CustomerReference = membershipkey };

            response = _clientService.SubAccounts(request);

            return response;
        }

        //currently api can't pull from test db as endpoint has not been written.
        //pulling directly from the testdb.
        public PriceHistoryResponse GetFundPriceHistory(string fundcode)
        {
            var request = new PriceHistoryRequest
            {
                FundCode = fundcode,
                StartDate = DateTime.Now.AddYears(-1),
                EndDate = DateTime.Now
            };
            var response = _clientService.GetFundPriceHistory(request);
            return response;
        }

        //until the endpoint for the above method has been created,
        //this is what would be used to spool data for fund prices
        public FundPrices GetFundPrices(string fundcode)
        {
            var response = new FundPrices();
            var settings = _configSettingManager.FundPriceConnection;

            var sql = $@"SELECT * FROM dw.FactFundPrice
                         WHERE ProductCode = '{fundcode}'";

            using (var connection = new SqlConnection(settings))
            {
                response.FundPrice = connection.Query<FactFundPrice>(sql).ToList();
            }

            return response;
        }

        public YieldHistoryResponse GetYieldHistory(string fundcode)
        {
            var request = new YieldHistoryRequest
            {
                FundCode = fundcode,
                StartDate = DateTime.Now.AddYears(-1),
                EndDate = DateTime.Now
            };
            var response = _clientService.GetFundYieldHistory(request);

            return response;
        }

        public EmbassyLetterResponse SendEmbassyLetter(EmbassyLetterViewModel model,
                                                        AuthenticateResponse user)
        {
            var embassyLetter = new EmbassyLetterRequest
            {
                MembershipKey = user.MembershipKey,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PassPortNumber = model.PassportNumber,
                AttentionName = model.AttentionName,
                RecipientAddress = model.RecipientAddress,
                AdditionalInstruction = model.AdditionalInstruction
            };

            var elResponse = _clientService.SendEmbassyLetter(embassyLetter);
            return elResponse;
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