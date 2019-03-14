using Portal.Business.Contracts;
using Portal.Domain.ViewModels;
using Portal.Business.ViewModels;
using Portal.Business.TestServices;
using Microsoft.AspNetCore.Hosting;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System;
using Portal.Domain.Models;

namespace Portal.Business.StoreManagers
{
    public class ArmOneManager : IArmOneManager
    {
        private readonly IArmOneServiceConfigManager _configSettingManager;
        public TestArmClientServices _clientService;
        public readonly IHostingEnvironment _hostingEnvironment;
        public string _contentRootPath;

        public ArmOneManager(IArmOneServiceConfigManager configManager, IHostingEnvironment hostingEnvironment)
        {
            _configSettingManager = configManager;
            _hostingEnvironment = hostingEnvironment;
            _contentRootPath = _hostingEnvironment.ContentRootPath;
            _clientService = new TestArmClientServices(_configSettingManager, _contentRootPath);
        }

        public CustomerInformationView GetCustomerInformation(string username, string password)
        {
            var result = new CustomerInformationView();          
            var configSetting = _configSettingManager;

            var absoluteUrl = new UriBuilder()
            {
                Path = "Dashboard/Index",
                Host = "localhost",
                Port = 5000
            };
            
            //authenticate user
            var customerLoginRequest = new ArmOneAuthRequest
            {
                Membershipkey = username,
                Password = password,
                Channel = "Client_Portal",
                RedirectURL = absoluteUrl.Uri.AbsoluteUri
            };
            var customerLoginResponse = _clientService.ArmOneAuthenticate(customerLoginRequest);

            //if the client is on armone, get customer detail from armone
            //else authenticate on datahub and onboard on armone
            if (customerLoginResponse.ResponseCode == null)
            {
                if (IsValidEmailAddress(username) == false)
                {
                    var dHubResponse = DataHubClientInfo(username, password);
                    if (dHubResponse != null)
                    {
                        //make datahub call for bvn and gender
                        var customerRequest = new ClientValidateRequest
                        { CustomerReference = dHubResponse.MembershipKey.ToString() };
                        var customerResponse = _clientService.ClientValidate(customerRequest);

                        var customerDetail = customerResponse.CustomerDetails.FirstOrDefault();

                        result.FirstName = dHubResponse.FirstName;
                        result.LastName = dHubResponse.LastName;
                        result.ResponseDescription = dHubResponse.ResponseMessage;
                        result.ResponseCode = "00";
                        result.Email = dHubResponse.EmailAddress;
                        result.IsAccountActivated = dHubResponse.IsActive;
                        result.MembershipNumber = dHubResponse.MembershipKey.ToString();
                        result.BvnNumber = customerDetail.BvnNumber;
                        result.Gender = customerDetail.Gender;

                        return result;
                    }
                }

                var registerOnArmOne = OnboardOldUsers(username, password);
                if (registerOnArmOne.ResponseCode == "00")
                    customerLoginResponse = _clientService.ArmOneAuthenticate(customerLoginRequest);               

            }

            //get customer detail from arm one
            var customerInfoRequest = new ArmOneCustomerDetailsRequest { Id = customerLoginResponse.EmailAddress };
            var customerInfoResponse = _clientService.GetArmOneCustomerDetails(customerInfoRequest);

            if (customerInfoResponse != null)
            {
                //make datahub call for bvn and gender
                var customerRequest = new ClientValidateRequest
                { CustomerReference = customerInfoResponse.MembershipKey.ToString() };
                var customerResponse = _clientService.ClientValidate(customerRequest);

                if (customerResponse != null)
                {
                    var customerDetail = customerResponse.CustomerDetails.FirstOrDefault();

                    result.FirstName = customerInfoResponse.FirstName;
                    result.LastName = customerInfoResponse.LastName;
                    result.ResponseCode = customerInfoResponse.ResponseCode;
                    result.ResponseDescription = customerInfoResponse.ResponseDescription;
                    result.Email = customerInfoResponse.EmailAddress;
                    result.IsAccountActivated = customerInfoResponse.IsAccountActivated;
                    result.MembershipNumber = customerInfoResponse.MembershipKey.ToString();
                    result.BvnNumber = customerDetail.BvnNumber;
                    result.Gender = customerDetail.Gender;
                }
            }

            return result;
        }

        public AuthenticateResponse DataHubClientInfo(string membershipnumber, string password)
        {
            var request = new AuthenticateRequest { Password = password, UserName = membershipnumber };
            var response = _clientService.Authenticate(request); 

            return response;
        }

        bool IArmOneManager.IsValidEmailAddress(string s)
        {
            return IsValidEmailAddress(s);
        }

        public ArmOneRegisterResponse OnboardNewUsers(Person model, string password)
        {
            var response = new ArmOneRegisterResponse();
            var snResponse = new SalesNewCustomerResponse();

            //onboard on datahub API
            //first, on sales/prospect
            var spRequest = new SalesProspectRequest
            {
                Surname = model.LastName,
                FirstName = model.FirstName,
                EmailAddress = model.Email,
                MobileNumber = model.Tel,
                Sex = model.Gender,
                Address = model.Address,
                BvnNumber = model.BioetricVerificationNumber
            };
            var spResponse = _clientService.AddNewCustomerStageOne(spRequest);

            //then, on sales/newcustomer
            if (spResponse != null && spResponse.ProspectCode > 0)
            {
                var snRequest = new SalesNewCustomerRequest { ProspectCode = spResponse.ProspectCode };
                snResponse = _clientService.AddNewCustomerStageTwo(snRequest);
            }

            //onboard on ArmOne
            if (snResponse != null)
            {
                var armRequest = new ArmOneRegisterRequest
                {
                    Membershipkey = snResponse.MembershipNumber,
                    Password = password,
                    EmailAddress = model.Email,
                    MobileNumber = model.Tel,
                    SecurityQuestion = "",
                    SecurityAnswer = "",
                    SecurtiyQuestion2 = String.Empty,
                    SecurityAnswer2 = String.Empty,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Channel = "CLient_Portal"
                };
                response = _clientService.ArmOneRegister(armRequest);
            }

            return response;
        }

        //this method is intended for clients
        //who have accounts on datahub but not on armone
        //it is intended to take response from authentication
        //on datahub and use it to register them on armone
        public ArmOneRegisterResponse OnboardOldUsers(string username, string password)
        {
            var customer = new CustomerDetail();
            var response = new ArmOneRegisterResponse();

            //make call to datahub API and authenticate user
            var dataHubAuthRequest = new AuthenticateRequest { Password = password, UserName = username };
            var dataHubAuthResponse = _clientService.Authenticate(dataHubAuthRequest);

            if (dataHubAuthResponse != null && dataHubAuthResponse.IsActive == true)
            {
                //get customer details
                customer = GetUserProfile(dataHubAuthResponse.MembershipKey);

                //register user on ArmOne
                var request = new ArmOneRegisterRequest
                {
                    Membershipkey = customer.MembershipNumber,
                    Password = password,
                    EmailAddress = customer.EmailAddress,
                    MobileNumber = customer.MobileNumber,
                    SecurityQuestion = dataHubAuthResponse.SecurityQuestion,
                    SecurityAnswer = dataHubAuthResponse.SecurityAnswer,
                    SecurtiyQuestion2 = String.Empty,
                    SecurityAnswer2 = String.Empty,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Channel = "Client_Portal"
                };
                response = _clientService.ArmOneRegister(request);
            }

            return response;
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

        public AllPriceResponse GetAllFundPrices(DateTime? date)
        {
            var request = new AllPriceRequest { PriceDate = date.Value };
            var response = _clientService.GetFundPrices(request);

            return response;
        }

        public AllPriceResponse GetAllFundPrices()
        {
            var request = new AllPriceRequest();
            var response = _clientService.GetFundPrices(request);

            return response;
        }

        public CustomerInformationView GetCustomerInformation(string username)
        {
            var result = new CustomerInformationView();

            #region service calling for customer information

            var configSetting = _configSettingManager;

            #endregion service calling for customer information

            var customerInfoRequest = new ArmOneCustomerDetailsRequest { Id = username };
            var customerInfoResponse = _clientService.GetArmOneCustomerDetails(customerInfoRequest);

            if (customerInfoResponse != null)
            {
                result.FirstName = customerInfoResponse.FirstName;
                result.LastName = customerInfoResponse.LastName;
                result.ResponseCode = customerInfoResponse.ResponseCode;
                result.ResponseDescription = customerInfoResponse.ResponseDescription;
                result.Email = customerInfoResponse.EmailAddress;
                result.IsAccountActivated = customerInfoResponse.IsAccountActivated;
            }

            return result;
        }

        public AdditionalInvResponse AddSales(InvestmentRequest request)
        {
            var response = _clientService.AddSales(request);
            return response;
        }

        /// <summary>
        /// send a single email of a customer that their kyc statsu need to be verify
        /// </summary>
        /// <param name="customerEmail">email of customer</param>
        /// <returns>single customer kyc status</returns>
        public KycStatus GetKycStatus(string customerEmail)
        {
            var kyc = new KycStatus();

            return kyc;
        }

        /// <summary>
        /// get the kyc status of customer whose email is included in  list of customers
        /// </summary>
        /// <param name="customerEmail">list of email</param>
        /// <returns>the kyc status of each memeber in the list</returns>
        public List<KycStatus> GetKycStatus(List<string> customerEmail)
        {
            var kyc = new List<KycStatus>();

            return kyc;
        }

        public bool UnLockAccount(string securityanswer)
        {
            var state = false;

            #region service callingfor security question

            var configSetting = _configSettingManager;

            #endregion service callingfor security question

            return state;
        }

        public bool IsValidEmailAddress(string s)
        {
            var regex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*
                                    @(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            return regex.IsMatch(s);
        }
    }
}