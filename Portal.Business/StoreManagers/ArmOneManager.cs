using System;
using System.Collections.Generic;
using System.Text;
using Portal.Business.Contracts;
using Portal.Domain.ViewModels;
using Portal.Business.ViewModels;
using Portal.Business.TestServices;
using Microsoft.AspNetCore.Hosting;

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

        public CustomerInformationView GetCustomerInformation(string emailaddress, string membershipnumber)
        {
            var result = new CustomerInformationView();       
            
            #region service calling for customer information

            var configSetting = _configSettingManager;

            #endregion service calling for customer information
            var customerInfoRequest = new ArmOneCustomerDetailsRequest { Id = emailaddress };
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

        public CustomerInformationView GetCustomerInformation(string membershipnumber)
        {
            var result = new CustomerInformationView();
            
            #region service calling for customer information

            var configSetting = _configSettingManager;

            #endregion service calling for customer information
            var customerInfoRequest = new ArmOneCustomerDetailsRequest { Id = membershipnumber };
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
    }
}