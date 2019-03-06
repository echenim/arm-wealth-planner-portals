using Portal.Business.Contracts;
using Portal.Business.ViewModels;
using Portal.Business.Utilities;

namespace Portal.Business.TestServices
{
    public class TestArmClientServices
    {
        private readonly string _contentRootPath;
        private readonly IArmOneServiceConfigManager _configSettingManager;

        public TestArmClientServices(IArmOneServiceConfigManager configManager, string contentRootPath)
        {
            _configSettingManager = configManager;
            _contentRootPath = contentRootPath;
        }


        public ChangePasswordResponse ChangePassword(ChangePasswordRequest payload)
        {
            string url = _configSettingManager.ArmOne + "/Client/ChangePassword";
            var encryptedValue = new SecureCredentials();
            var _client = new RestActions(_contentRootPath);

            payload.ServiceUsername = encryptedValue.DecryptCredentials(_configSettingManager.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_configSettingManager.ArmServicePassword);
            return _client.CallRestAction<ChangePasswordResponse, ChangePasswordRequest>(payload, url);
        }

        public ResetPasswordResponse ResetPassword(ResetPasswordRequest payload)
        {
            string url = _configSettingManager.ArmBaseUrl + "/Client/ResetPassword";
            var encryptedValue = new SecureCredentials();
            var _client = new RestActions(_contentRootPath);

            payload.ServiceUsername = encryptedValue.DecryptCredentials(_configSettingManager.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_configSettingManager.ArmServicePassword);
            return _client.CallRestAction<ResetPasswordResponse, ResetPasswordRequest>(payload, url);
        }

        public AddSecurityQuestionResponse AddSecurityQuestion(AddSecurityQuestionRequest payload)
        {
            string url = _configSettingManager.ArmBaseUrl + "/Client/AddSecurityQuestion";
            var encryptedValue = new SecureCredentials();
            var _client = new RestActions(_contentRootPath);

            payload.ServiceUsername = encryptedValue.DecryptCredentials(_configSettingManager.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_configSettingManager.ArmServicePassword);
            return _client.CallRestAction<AddSecurityQuestionResponse, AddSecurityQuestionRequest>(payload, url);
        }

        public ArmOneRegisterResponse ArmOneRegister(ArmOneRegisterRequest payload)
        {
            ClientPortalUtilities generate = new ClientPortalUtilities(_configSettingManager);
            var token = generate.ARMOneToken();
            var _client = new RestActions(_contentRootPath);

            string url = _configSettingManager.ArmOne + "/ARMONE/Register";
            return _client.CallArmOneRestAction<ArmOneRegisterResponse, ArmOneRegisterRequest>(payload, url, token);
        }

        public ArmOneAuthResponse ArmOneAuthenticate(ArmOneAuthRequest payload)
        {
            ClientPortalUtilities generate = new ClientPortalUtilities(_configSettingManager);
            var token = generate.ARMOneToken();
            var _client = new RestActions(_contentRootPath);

            string url = _configSettingManager.ArmOne + "/ARMONE/Login";
            return _client.CallArmOneRestAction<ArmOneAuthResponse, ArmOneAuthRequest>(payload, url, token);
        }

        public ArmOneCustomerDetailsResponse GetArmOneCustomerDetails(ArmOneCustomerDetailsRequest payload)
        {
            string url = _configSettingManager.ArmOne + $@"/ARMONE/GetCustomerDetails/?Id={payload.Id}&Channel={payload.Channel}";
            var _client = new RestActions(_contentRootPath);            
            return _client.GetArmOneDetails<ArmOneCustomerDetailsResponse>(url); 
        }

        public ArmOneChangePasswordResponse ArmOneChangePassword(ArmOneChangePasswordRequest payload)
        {
            ClientPortalUtilities generate = new ClientPortalUtilities(_configSettingManager);
            var token = generate.ARMOneToken();
            var _client = new RestActions(_contentRootPath);

            string url = _configSettingManager.ArmOne + "/ARMONE/ChangePassword";
            return _client.CallArmOneRestAction<ArmOneChangePasswordResponse, ArmOneChangePasswordRequest>(payload, url, token);
        }

        public ArmOnePasswordResetResponse ArmOnePasswordReset(ArmOnePasswordResetRequest payload)
        {
            ClientPortalUtilities generate = new ClientPortalUtilities(_configSettingManager);
            var token = generate.ARMOneToken();
            var _client = new RestActions(_contentRootPath);

            string url = _configSettingManager.ArmOne + "/ARMONE/ResetPassword";
            return _client.CallArmOneRestAction<ArmOnePasswordResetResponse, ArmOnePasswordResetRequest>(payload, url, token);
        }

        public ArmOneSecurityQuestionResponse ArmOneSecurityQuestion(ArmOneSecurityQuestionRequest payload)
        {
            ClientPortalUtilities generate = new ClientPortalUtilities(_configSettingManager);
            var token = generate.ARMOneToken();
            var _client = new RestActions(_contentRootPath);

            string url = _configSettingManager.ArmOne + "/ARMONE/UpdateSecurityQuestions";
            return _client.CallArmOneRestAction<ArmOneSecurityQuestionResponse, ArmOneSecurityQuestionRequest>(payload, url, token);
        }

        public ArmOneAuthTokenResponse ArmOneAuthToken(ArmOneAuthTokenRequest payload)
        {
            var _client = new RestActions(_contentRootPath);
            string url = _configSettingManager.ArmOne + "/OAuth/Token";
            return _client.CallArmOneRestTokenAction<ArmOneAuthTokenResponse, ArmOneAuthTokenRequest>(payload, url);
        }

        public ArmOneValidateSessionResponse ArmOneValidateSession(ArmOneValidateSessionRequest payload, string token, string session)
        {
            var _client = new RestActions(_contentRootPath);
            string url = _configSettingManager.ArmOne + "/ARMONE/ValidateSession";
            return _client.ArmOneValidateCallAction<ArmOneValidateSessionResponse, ArmOneValidateSessionRequest>(payload, url, token, session);
        }

        public ArmOneValidateCookieResponse ArmOneValidateCookie(ArmOneValidateCookieRequest payload, string token, string session)
        {
            var _client = new RestActions(_contentRootPath);
            string url = _configSettingManager.ArmOne + "/ARMONE/ValidateCookie";
            return _client.ArmOneValidateCallAction<ArmOneValidateCookieResponse, ArmOneValidateCookieRequest>(payload, url, token, session);
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest payload)
        {
            var _client = new RestActions(_contentRootPath);
            string url = _configSettingManager.ArmBaseUrl + "/Client/Authenticate";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_configSettingManager.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_configSettingManager.ArmServicePassword);
            return _client.CallRestAction<AuthenticateResponse, AuthenticateRequest>(payload, url);
        }

        public TrackServiceResponse TrackService(TrackServiceRequest payload)
        {
            var _client = new RestActions(_contentRootPath);
            string url = _configSettingManager.ArmBaseUrl + "/SelfService/TrackService";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_configSettingManager.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_configSettingManager.ArmServicePassword);
            return _client.CallRestAction<TrackServiceResponse, TrackServiceRequest>(payload, url);
        }

        public EmbassyLetterResponse SendEmbassyLetter(EmbassyLetterRequest payload)
        {
            var _client = new RestActions(_contentRootPath);
            string url = _configSettingManager.ArmBaseUrl + "/SelfService/EmbassyLetter";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_configSettingManager.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_configSettingManager.ArmServicePassword);
            return _client.CallRestAction<EmbassyLetterResponse, EmbassyLetterRequest>(payload, url);
        }

        public FeedbackResponse SendFeedback(FeedbackRequest payload)
        {
            var _client = new RestActions(_contentRootPath);
            string url = _configSettingManager.ArmBaseUrl + "/SelfService/Feedback";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_configSettingManager.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_configSettingManager.ArmServicePassword);
            return _client.CallRestAction<FeedbackResponse, FeedbackRequest>(payload, url);
        }

        public RedemptionResponse Redemption(RedemptionRequest payload)
        {
            var _client = new RestActions(_contentRootPath);
            string url = _configSettingManager.ArmBaseUrl + "/SelfService/Redemption";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_configSettingManager.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_configSettingManager.ArmServicePassword);
            return _client.CallRestAction<RedemptionResponse, RedemptionRequest>(payload, url);
        }

        public AdditionalInvResponse AddSales(InvestmentRequest payload)
        {
            var _client = new RestActions(_contentRootPath);
            string url = _configSettingManager.ArmBaseUrl + "/Sale/Additional";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_configSettingManager.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_configSettingManager.ArmServicePassword);
            return _client.CallRestAction<AdditionalInvResponse, InvestmentRequest>(payload, url);
        }

        public SendOtpResponse SendOtp(SendOtpRequest payload)
        {
            var _client = new RestActions(_contentRootPath);
            string url = _configSettingManager.ArmBaseUrl + "/Otp/SendOtp";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_configSettingManager.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_configSettingManager.ArmServicePassword);
            return _client.CallRestAction<SendOtpResponse, SendOtpRequest>(payload, url);
        }

        public AddTcResponse AddTc(AddTcRequest payload)
        {
            var _client = new RestActions(_contentRootPath);
            string url = _configSettingManager.ArmBaseUrl + "/Client/AddTcAgreed";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_configSettingManager.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_configSettingManager.ArmServicePassword);
            return _client.CallRestAction<AddTcResponse, AddTcRequest>(payload, url);
        }

        public ClientValidateResponse ClientValidate(ClientValidateRequest payload)
        {
            var _client = new RestActions(_contentRootPath);
            string url = _configSettingManager.ArmBaseUrl + "/Client/Validate";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_configSettingManager.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_configSettingManager.ArmServicePassword);
            return _client.CallRestAction<ClientValidateResponse, ClientValidateRequest>(payload, url);
        }

        public RedemptionResponse SendRedemption(RedemptionRequest payload)
        {
            var _client = new RestActions(_contentRootPath);
            string url = _configSettingManager.ArmBaseUrl + "/SelfService/Redemption";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_configSettingManager.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_configSettingManager.ArmServicePassword);
            return _client.CallRestAction<RedemptionResponse, RedemptionRequest>(payload, url);
        }

        public SummaryResponse GetAccountSummary(SummaryRequest payload)
        {
            var _client = new RestActions(_contentRootPath);
            string url = _configSettingManager.ArmBaseUrl + "/Portfolio/Summary";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_configSettingManager.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_configSettingManager.ArmServicePassword);
            return _client.CallRestAction<SummaryResponse, SummaryRequest>(payload, url);
        }

        public StatementResponse GetTransactions(StatementRequest payload)
        {
            var _client = new RestActions(_contentRootPath);
            string url = _configSettingManager.ArmBaseUrl + "/Portfolio/Transaction";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_configSettingManager.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_configSettingManager.ArmServicePassword);
            return _client.CallRestAction<StatementResponse, StatementRequest>(payload, url);
        }

        public LastTransactionResponse GetLastTransactions(LastTransactionRequest payload)
        {
            var _client = new RestActions(_contentRootPath);
            string url = _configSettingManager.ArmBaseUrl + "/Portfolio/LastTransaction";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_configSettingManager.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_configSettingManager.ArmServicePassword);
            return _client.CallRestAction<LastTransactionResponse, LastTransactionRequest>(payload, url);
        }

        public TotalBalanceResponse GetTotalBalance(TotalBalanceRequest payload)
        {
            var _client = new RestActions(_contentRootPath);
            string url = _configSettingManager.ArmBaseUrl + "/Portfolio/TotalBalance";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_configSettingManager.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_configSettingManager.ArmServicePassword);
            return _client.CallRestAction<TotalBalanceResponse, TotalBalanceRequest>(payload, url);
        }

        public CancelDirectDebitResponse CancelDirectDebit(CancelDirectDebitRequest payload)
        {
            var _client = new RestActions(_contentRootPath);
            string url = _configSettingManager.ArmBaseUrl + "/Payment/CancelDirectDebit";
            return _client.CallRestAction<CancelDirectDebitResponse, CancelDirectDebitRequest>(payload, url);
        }

        public SubAccountsResponse SubAccounts(SubAccountsRequest payload)
        {
            var _client = new RestActions(_contentRootPath);
            string url = _configSettingManager.ArmBaseUrl + "/Client/SubAccounts";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_configSettingManager.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_configSettingManager.ArmServicePassword);
            return _client.CallRestAction<SubAccountsResponse, SubAccountsRequest>(payload, url);
        }

        public AllPriceResponse GetFundPrices(AllPriceRequest payload)
        {
            var _client = new RestActions(_contentRootPath);
            string url = _configSettingManager.ArmFundBaseUrl + "/Fund/AllPrice";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_configSettingManager.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_configSettingManager.ArmServicePassword);
            return _client.CallRestAction<AllPriceResponse, AllPriceRequest>(payload, url);
        }

        public PriceHistoryResponse GetFundPriceHistory(PriceHistoryRequest payload)
        {
            var _client = new RestActions(_contentRootPath);
            string url = _configSettingManager.ArmFundBaseUrl + "/Fund/PriceHistory";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_configSettingManager.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_configSettingManager.ArmServicePassword);
            return _client.CallRestAction<PriceHistoryResponse, PriceHistoryRequest>(payload, url);
        }

        public YieldHistoryResponse GetFundYieldHistory(YieldHistoryRequest payload)
        {
            var _client = new RestActions(_contentRootPath);
            string url = _configSettingManager.ArmFundBaseUrl + "/Fund/YieldHistory";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_configSettingManager.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_configSettingManager.ArmServicePassword);
            return _client.CallRestAction<YieldHistoryResponse, YieldHistoryRequest>(payload, url);
        }

        public SalesProspectResponse AddNewCustomerStageOne(SalesProspectRequest payload)
        {
            var _client = new RestActions(_contentRootPath);
            string url = _configSettingManager.ArmBaseUrl + "/Sale/Prospect";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_configSettingManager.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_configSettingManager.ArmServicePassword);
            return _client.CallRestAction<SalesProspectResponse, SalesProspectRequest>(payload, url);
        }

        public SalesNewCustomerResponse AddNewCustomerStageTwo(SalesNewCustomerRequest payload)
        {
            var _client = new RestActions(_contentRootPath);
            string url = _configSettingManager.ArmBaseUrl + "/Sale/NewCustomer";
            var encryptedValue = new SecureCredentials();
            payload.ServiceUsername = encryptedValue.DecryptCredentials(_configSettingManager.ArmServiceUsername);
            payload.ServicePassword = encryptedValue.DecryptCredentials(_configSettingManager.ArmServicePassword);
            return _client.CallRestAction<SalesNewCustomerResponse, SalesNewCustomerRequest>(payload, url);
        }
    }
}
