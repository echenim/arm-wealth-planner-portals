using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Newtonsoft.Json;
using Portal.Areas.Client.Models;
using Portal.Areas.Client.ViewModels;
//using ARMClientPortal.ViewModels;

namespace Portal.Services
{
    public class ArmClientServices
    {
        private readonly AppSettings _appSettings;
        private readonly string _contentRootPath;
        private IConfiguration configuration;

        public ArmClientServices(AppSettings appSettings, string contentRootPath, IConfiguration _configuration)
        {
            _appSettings = appSettings;
            _contentRootPath = contentRootPath;
            configuration = _configuration;
        }

        public R CallRestAction<R, T>(T model, string url)
        {
            if (model == null) return default(R);
            var response = default(R);
            try
            {
                var restResponse = JsonHelper.PostRequest(_contentRootPath, url, model);

                if (restResponse.Content != null && restResponse.Content.Length > 0)
                {
                    response = JsonConvert.DeserializeObject<R>(restResponse.Content);
                }
            }
            catch (Exception ex)
            {
                Utilities.ProcessError(ex, _contentRootPath);

            }

            return response;
        }

        public R CallArmOneRestAction<R, T>(T model, string url, string token)
        {
            if (model == null) return default(R);
            var response = default(R);

            try
            {
                var restResponse = JsonHelper.ArmOnePostRequest(_contentRootPath, url, model, token);
                if (!string.IsNullOrEmpty(restResponse))
                {
                    response = JsonConvert.DeserializeObject<R>(restResponse);
                }
            }
            catch (Exception ex)
            {
                Utilities.ProcessError(ex, _contentRootPath);
            }

            return response;
        }

        public R CallArmOneRestTokenAction<R, T>(T model, string url)
        {
            if (model == null) return default(R);
            var response = default(R);

            try
            {
                var restResponse = JsonHelper.ArmOneTokenPostRequest(_contentRootPath, model, url);
                if (!string.IsNullOrEmpty(restResponse))
                {
                    response = JsonConvert.DeserializeObject<R>(restResponse);
                }
            }
            catch (Exception ex)
            {
                Utilities.ProcessError(ex, _contentRootPath);
            }

            return response;
        }

        public R ArmOneValidateCallAction<R, T>(T model, string url, string token, string sessionString)
        {
            if (model == null) return default(R);
            var response = default(R);

            try
            {
                var restResponse = JsonHelper.ArmOneTokenPostRequest(_contentRootPath, model, url, token, sessionString);
                if (!string.IsNullOrEmpty(restResponse))
                {
                    response = JsonConvert.DeserializeObject<R>(restResponse);
                }
            }
            catch (Exception ex)
            {
                Utilities.ProcessError(ex, _contentRootPath);
            }

            return response;
        }

        public R GetArmOneDetails<R>(string url)
        {
            if (url == null) return default(R);
            var response = default(R);

            try
            {
                var restResponse = JsonHelper.GetArmOneRequest(_contentRootPath, url);
                if (!string.IsNullOrEmpty(restResponse))
                {
                    response = JsonConvert.DeserializeObject<R>(restResponse);
                }
            }
            catch (Exception ex)
            {
                Utilities.ProcessError(ex, _contentRootPath);
            }

            return response;
        }

        public ChangePasswordResponse ChangePassword(ChangePasswordRequest payload)
        {
            string url = _appSettings.ArmBaseUrl + "/Client/ChangePassword";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_appSettings.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_appSettings.ArmServicePassword);
            return CallRestAction<ChangePasswordResponse, ChangePasswordRequest>(payload, url);
        }

        public ResetPasswordResponse ResetPassword(ResetPasswordRequest payload)
        {
            string url = _appSettings.ArmBaseUrl + "/Client/ResetPassword";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_appSettings.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_appSettings.ArmServicePassword);
            return CallRestAction<ResetPasswordResponse, ResetPasswordRequest>(payload, url);
        }

        public AddSecurityQuestionResponse AddSecurityQuestion(AddSecurityQuestionRequest payload)
        {
            string url = _appSettings.ArmBaseUrl + "/Client/AddSecurityQuestion";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_appSettings.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_appSettings.ArmServicePassword);
            return CallRestAction<AddSecurityQuestionResponse, AddSecurityQuestionRequest>(payload, url);
        }

        public ArmOneRegisterResponse ArmOneRegister(ArmOneRegisterRequest payload)
        {
            UtilityHelper UH = new UtilityHelper(configuration);
            var token = UH.ARMOneToken();
            string url = _appSettings.ArmOne + "/ARMONE/Register";
            return CallArmOneRestAction<ArmOneRegisterResponse, ArmOneRegisterRequest>(payload, url, token);
        }

        public ArmOneAuthResponse ArmOneAuthenticate(ArmOneAuthRequest payload)
        {
            UtilityHelper UH = new UtilityHelper(configuration);
            var token = UH.ARMOneToken();
            string url = _appSettings.ArmOne + "/ARMONE/Login";
            return CallArmOneRestAction<ArmOneAuthResponse, ArmOneAuthRequest>(payload, url, token);
        }

        public ArmOneCustomerDetailsResponse GetCustomerDetails(ArmOneCustomerDetailsRequest payload)
        {
            string url = _appSettings.ArmOne + $@"/ARMONE/GetCustomerDetails/?Id={payload.Id}&Channel={payload.Channel}";
            return GetArmOneDetails<ArmOneCustomerDetailsResponse>(url);
        }

        public ArmOneChangePasswordResponse ArmOneChangePassword(ArmOneChangePasswordRequest payload)
        {
            UtilityHelper UH = new UtilityHelper(configuration);
            var token = UH.ARMOneToken();
            string url = _appSettings.ArmOne + "/ARMONE/ChangePassword";
            return CallArmOneRestAction<ArmOneChangePasswordResponse, ArmOneChangePasswordRequest>(payload, url, token);
        }

        public ArmOnePasswordResetResponse ArmOnePasswordReset(ArmOnePasswordResetRequest payload)
        {
            UtilityHelper UH = new UtilityHelper(configuration);
            var token = UH.ARMOneToken();
            string url = _appSettings.ArmOne + "/ARMONE/ResetPassword";
            return CallArmOneRestAction<ArmOnePasswordResetResponse, ArmOnePasswordResetRequest>(payload, url, token);
        }

        public ArmOneSecurityQuestionResponse ArmOneSecurityQuestion(ArmOneSecurityQuestionRequest payload)
        {
            UtilityHelper UH = new UtilityHelper(configuration);
            var token = UH.ARMOneToken();
            string url = _appSettings.ArmOne + "/ARMONE/UpdateSecurityQuestions";
            return CallArmOneRestAction<ArmOneSecurityQuestionResponse, ArmOneSecurityQuestionRequest>(payload, url, token);
        }

        public ArmOneAuthTokenResponse ArmOneAuthToken(ArmOneAuthTokenRequest payload)
        {
            string url = _appSettings.ArmOne + "/OAuth/Token";
            return CallArmOneRestTokenAction<ArmOneAuthTokenResponse, ArmOneAuthTokenRequest>(payload, url);
        }

        public ArmOneValidateSessionResponse ArmOneValidateSession(ArmOneValidateSessionRequest payload, string token, string session)
        {
            string url = _appSettings.ArmOne + "/ARMONE/ValidateSession";
            return ArmOneValidateCallAction<ArmOneValidateSessionResponse, ArmOneValidateSessionRequest>(payload, url, token, session);
        }

        public ArmOneValidateCookieResponse ArmOneValidateCookie(ArmOneValidateCookieRequest payload, string token, string session)
        {
            string url = _appSettings.ArmOne + "/ARMONE/ValidateCookie";
            return ArmOneValidateCallAction<ArmOneValidateCookieResponse, ArmOneValidateCookieRequest>(payload, url, token, session);
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest payload)
        {
            string url = _appSettings.ArmBaseUrl + "/Client/Authenticate";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_appSettings.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_appSettings.ArmServicePassword);
            return CallRestAction<AuthenticateResponse, AuthenticateRequest>(payload, url);
        }

        public TrackServiceResponse TrackService(TrackServiceRequest payload)
        {
            string url = _appSettings.ArmBaseUrl + "/SelfService/TrackService";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_appSettings.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_appSettings.ArmServicePassword);
            return CallRestAction<TrackServiceResponse, TrackServiceRequest>(payload, url);
        }

        public EmbassyLetterResponse SendEmbassyLetter(EmbassyLetterRequest payload)
        {
            string url = _appSettings.ArmBaseUrl + "/SelfService/EmbassyLetter";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_appSettings.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_appSettings.ArmServicePassword);
            return CallRestAction<EmbassyLetterResponse, EmbassyLetterRequest>(payload, url);
        }
        public FeedbackResponse SendFeedback(FeedbackRequest payload)
        {
            string url = _appSettings.ArmBaseUrl + "/SelfService/Feedback";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_appSettings.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_appSettings.ArmServicePassword);
            return CallRestAction<FeedbackResponse, FeedbackRequest>(payload, url);
        }

        public RedemptionResponse Redemption(RedemptionRequest payload)
        {
            string url = _appSettings.ArmBaseUrl + "/SelfService/Redemption";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_appSettings.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_appSettings.ArmServicePassword);
            return CallRestAction<RedemptionResponse, RedemptionRequest>(payload, url);
        }

        public AdditionalInvResponse AddSales(InvestmentRequest payload)
        {
            string url = _appSettings.ArmBaseUrl + "/Sale/Additional";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_appSettings.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_appSettings.ArmServicePassword);
            return CallRestAction<AdditionalInvResponse, InvestmentRequest>(payload, url);
        }

        public SendOtpResponse SendOtp(SendOtpRequest payload)
        {
            string url = _appSettings.ArmBaseUrl + "/Otp/SendOtp";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_appSettings.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_appSettings.ArmServicePassword);
            return CallRestAction<SendOtpResponse, SendOtpRequest>(payload, url);
        }

        public AddTcResponse AddTc(AddTcRequest payload)
        {
            string url = _appSettings.ArmBaseUrl + "/Client/AddTcAgreed";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_appSettings.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_appSettings.ArmServicePassword);
            return CallRestAction<AddTcResponse, AddTcRequest>(payload, url);
        }

        public ClientValidateResponse ClientValidate(ClientValidateRequest payload)
        {
            string url = _appSettings.ArmBaseUrl + "/Client/Validate";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_appSettings.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_appSettings.ArmServicePassword);
            return CallRestAction<ClientValidateResponse, ClientValidateRequest>(payload, url);
        }
        public RedemptionResponse SendRedemption(RedemptionRequest payload)
        {
            string url = _appSettings.ArmBaseUrl + "/SelfService/Redemption";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_appSettings.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_appSettings.ArmServicePassword);
            return CallRestAction<RedemptionResponse, RedemptionRequest>(payload, url);
        }

        public SummaryResponse GetAccountSummary(SummaryRequest payload)
        {
            string url = _appSettings.ArmBaseUrl + "/Portfolio/Summary";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_appSettings.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_appSettings.ArmServicePassword);
            return CallRestAction<SummaryResponse, SummaryRequest>(payload, url);
        }

        public StatementResponse GetTransactions(StatementRequest payload)
        {
            string url = _appSettings.ArmBaseUrl + "/Portfolio/Transaction";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_appSettings.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_appSettings.ArmServicePassword);
            return CallRestAction<StatementResponse, StatementRequest>(payload, url);
        }

        public LastTransactionResponse GetLastTransactions(LastTransactionRequest payload)
        {
            string url = _appSettings.ArmBaseUrl + "/Portfolio/LastTransaction";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_appSettings.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_appSettings.ArmServicePassword);
            return CallRestAction<LastTransactionResponse, LastTransactionRequest>(payload, url);
        }

        public TotalBalanceResponse GetTotalBalance(TotalBalanceRequest payload)
        {
            string url = _appSettings.ArmBaseUrl + "/Portfolio/TotalBalance";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_appSettings.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_appSettings.ArmServicePassword);
            return CallRestAction<TotalBalanceResponse, TotalBalanceRequest>(payload, url);
        }

        public CancelDirectDebitResponse CancelDirectDebit(CancelDirectDebitRequest payload)
        {
            string url = _appSettings.ArmBaseUrl + "/Payment/CancelDirectDebit";
            return CallRestAction<CancelDirectDebitResponse, CancelDirectDebitRequest>(payload, url);
        }

        public TransactionResponse Payment(TransactionModel payload)
        {
            string url = _appSettings.ArmAggregatorBaseUrl + "/Aggregator/Payment";
            return CallRestAction<TransactionResponse, TransactionModel>(payload, url);
        }

        public DirectDebitTransactionResponse Debit(DirectDebitTransactionModel payload)
        {
            string url = _appSettings.ArmAggregatorBaseUrl + "/Aggregator/DirectDebit";
            return CallRestAction<DirectDebitTransactionResponse, DirectDebitTransactionModel>(payload, url);
        }
    }
}
