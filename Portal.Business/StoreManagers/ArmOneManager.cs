using Portal.Business.Contracts;
using Portal.Domain.ViewModels;
using Portal.Business.ViewModels;
using Portal.Business.TestServices;
using Microsoft.AspNetCore.Hosting;
using System.Text.RegularExpressions;
using System;

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

            #region service calling for customer information

            var configSetting = _configSettingManager;
            
            var absoluteUrl = new UriBuilder()
            {
                Path = "Dashboard/Index",
                Host = "localhost",
                Port = 5000
            };
            #endregion service calling for customer information

            //authenticate user
            var customerLoginRequest = new ArmOneAuthRequest
            {
                Membershipkey = username,
                Password = password,
                Channel = "Client_Portal",
                RedirectURL = absoluteUrl.Uri.AbsoluteUri
            };
            var customerLoginResponse = _clientService.ArmOneAuthenticate(customerLoginRequest);

            ////make call to datahub API
            //var dataHubAuthRequest = new AuthenticateRequest
            //{
            //    Password = password,
            //    UserName = customerLoginResponse.MembershipKey.ToString()
            //};
            //  var dataHubAuthResponse = _clientService.Authenticate(dataHubAuthRequest);

            //get customer detail from arm one
            var customerInfoRequest = new ArmOneCustomerDetailsRequest { Id = customerLoginResponse.EmailAddress };
            var customerInfoResponse = _clientService.GetArmOneCustomerDetails(customerInfoRequest);

            if (customerInfoResponse != null)
            {
                result.FirstName = customerInfoResponse.FirstName;
                result.LastName = customerInfoResponse.LastName;
                result.ResponseCode = customerInfoResponse.ResponseCode;
                result.ResponseDescription = customerInfoResponse.ResponseDescription;
                result.Email = customerInfoResponse.EmailAddress;
                result.IsAccountActivated = customerInfoResponse.IsAccountActivated;
                result.AltUsername = "";  //dataHubAuthResponse.AltUsername;
                result.MembershipNumber = customerInfoResponse.MembershipKey.ToString();
            }

            return result;
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

        public bool UnLockAccount(string securityanswer)
        {
            var state = false;

            #region service callingfor security question

            var configSetting = _configSettingManager;

            #endregion service callingfor security question

            return state;
        }

        public static bool IsValidEmailAddress(string s)
        {
            var regex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*
                                    @(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            return regex.IsMatch(s);
        }
    }
}