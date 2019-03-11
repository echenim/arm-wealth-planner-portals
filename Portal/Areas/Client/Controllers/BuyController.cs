using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Portal.Areas.Client.Extensions;
using Portal.Domain;
using Portal.Services;
using Portal.Business.Contracts;
using Portal.Business.TestServices;
using Portal.Business.ViewModels;
using Portal.Domain.Models;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

namespace Portal.Areas.Client.Controllers
{
    [Area("Client")]
    public class BuyController : Controller
    {
        public string _webRootPath;
        public string _contentRootPath;
        public readonly IHostingEnvironment _hostingEnvironment;
        public JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

        public readonly ILogger<DashboardController> _logger;
        public readonly IConfiguration _configuration;

        private readonly IArmOneServiceConfigManager _configSettingManager;
        public TestArmClientServices _clientService;

        public ApplicationDbContext db;
        public ClientRepository _client;

        private readonly IMemoryCache _cache;

        public BuyController(IHostingEnvironment hostingEnvironment, IArmOneServiceConfigManager configManager,
                                    ILogger<DashboardController> logger, IConfiguration configuration,
                                    IMemoryCache cache, ApplicationDbContext _db)
        {
            _hostingEnvironment = hostingEnvironment;
            _webRootPath = _hostingEnvironment.WebRootPath;
            _contentRootPath = _hostingEnvironment.ContentRootPath;

            _logger = logger;
            _configuration = configuration;

            _configSettingManager = configManager;

            _clientService = new TestArmClientServices(_configSettingManager, _contentRootPath);
            _client = new ClientRepository(_configSettingManager, _contentRootPath);

            db = _db;
            _cache = cache;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddInvestment()
        {
            var model = new AccountStatementViewModel();
            var _user = _cache.Get<AuthenticateResponse>("ArmUser");
            if (_user == null)
            {
                TempData["SessionTimeOut"] = $@"You have been logged out due to inactivity. 
                                                Please login to gain access.";
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            try
            {
                List<ProductDetails> getSummaries = new List<ProductDetails>();

                var getClientSummary = _client.GetAccountSummary(_user.MembershipKey);
                var getClientBalance = _client.GetTotalAccountBalance(_user.MembershipKey);

                if (getClientSummary != null)
                {
                    foreach (var item in getClientSummary.Summaries)
                    {
                        var summaries = new ProductDetails();
                        summaries.ProductName = item.ProductName;
                        summaries.ProductCode = item.ProductCode;
                        summaries.Currency = item.Currency;
                        summaries.AccruedInterest = item.AccruedInterest;
                        summaries.CurrentBalance = item.CurrentBalance;

                        getSummaries.Add(summaries);
                    }

                    model.Summaries = getSummaries;
                }              

                if (getClientBalance != null)
                    model.TotalBalance = getClientBalance.TotalBalance;
            }
            catch (Exception ex)
            {
                TempData["message"] = ViewBag.Message = ex.Message;
                Utilities.ProcessError(ex, _contentRootPath);
                _logger.LogError(null, ex, ex.Message);
            }

            return View(model);
        }

        public IActionResult NewInvestment()
        {
            var model = new AccountStatementViewModel();
            var _user = _cache.Get<AuthenticateResponse>("ArmUser");
            if (_user == null)
            {
                TempData["SessionTimeOut"] = $@"You have been logged out due to inactivity. 
                                                Please login to gain access.";
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            try
            {
                List<ProductDetails> getSummaries = new List<ProductDetails>();

                var getClientSummary = _client.GetAccountSummary(_user.MembershipKey);

                if (getClientSummary != null)
                {
                    foreach (var item in getClientSummary.Summaries)
                    {
                        var summaries = new ProductDetails();
                        summaries.ProductName = item.ProductName;
                        summaries.ProductCode = item.ProductCode;
                        summaries.Currency = item.Currency;
                        summaries.AccruedInterest = item.AccruedInterest;
                        summaries.CurrentBalance = item.CurrentBalance;

                        getSummaries.Add(summaries);
                    }

                    model.Summaries = getSummaries;
                    model.TotalBalance = getClientSummary.TotalBalance;

                    var funds = new Dictionary<string, string>()
                    {
                        { "AGF", "ARM Aggressive Growth Fund" },
                        { "ARMDF", "ARM Discovery Fund" },
                        { "ARMEF", "ARM Ethical Fund" },
                        { "ARMMMF", "ARM Money Market Fund" }
                    };

                    var myfunds = new Dictionary<string, string>();

                    foreach (var prod in getClientSummary.Summaries)
                    {
                        myfunds.Add(prod.ProductCode, prod.ProductName);
                    }

                    var diff = funds.Except(myfunds).Concat(myfunds.Except(funds));
                    Dictionary<string, string> result = diff.ToDictionary(x => x.Key, x => x.Value);
                    model.Products = result;
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = ViewBag.Message = ex.Message;
                Utilities.ProcessError(ex, _contentRootPath);
                _logger.LogError(null, ex, ex.Message);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProcessPayment([FromBody]Investment modelview)
        {
            Buy model = new Buy();
            model.TotalAmount = modelview.TotalAmount;
            model.Orders = modelview.Orders;

            var _user = _cache.Get<AuthenticateResponse>("ArmUser");
            if (_user == null)
            {
                TempData["SessionTimeOut"] = $@"You have been logged out due to inactivity. 
                                                Please login to gain access.";
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            try
            {
                AccountStatementViewModel postdata = new AccountStatementViewModel();
                var decrypt = new SecureCredentials();

                string MacKey = _configSettingManager.ArmMacKey;

                if (ModelState.IsValid)
                {
                    var customer = new CustomerDetail();
                    customer = _client.GetUserProfile(_user.MembershipKey);

                    TransactionRequest iRequest = new TransactionRequest
                    {
                        CustomerReference = _user.MembershipKey,
                        CustomerName = _user.FullName,
                        EmailAddress = _user.EmailAddress,
                        MobileNumber = customer.MobileNumber
                    };

                    var ItemData = String.Empty;
                    var XmlData = String.Empty;
                    decimal TransactionAmount = 0;

                    List<paymentItems> Items = new List<paymentItems>();
                    if (model.Orders != null && model.Orders.Count > 0)
                    {
                        foreach (var item in model.Orders)
                        {
                            if (model.Orders.ContainsKey(item.Key) && model.Orders[item.Key].Equals(item.Value))
                            {
                                if (item.Value > 999)
                                {
                                    var damount = item.Value * 100;
                                    ItemData += $@"<payment_item>
                                                        <item_code>{item.Key}</item_code>
                                                        <item_amt>{damount}</item_amt>
                                                    </payment_item>";

                                    TransactionAmount += damount;

                                    paymentItems paymentitem = new paymentItems();
                                    paymentitem.ItemCode = item.Key;
                                    paymentitem.ItemName = item.Key;
                                    paymentitem.ItemAmount = TransactionAmount / 100;

                                    Items.Add(paymentitem);
                                }
                            }
                        }

                        iRequest.PaymentItems = Items;
                    }

                    if (TransactionAmount <= 0)
                    {
                        return StatusCode((int)HttpStatusCode.ExpectationFailed, "Invalid Transaction.");
                    }
                    else
                    {
                        XmlData = $@"<paymentitemxml> <payment_items>{ItemData}</payment_items> </paymentitemxml>";
                    }

                    var TransactionReference = _client.GenerateUniqueID(_user.MembershipKey);

                    orderPayment orderpayment = new orderPayment();
                    orderpayment.Amount = TransactionAmount / 100;
                    orderpayment.PaymentMethod = "unknown";
                    orderpayment.PaymentLogId = TransactionReference;

                    iRequest.OrderPayment = orderpayment;

                    var InvReq = JsonConvert.SerializeObject(iRequest, Formatting.Indented);

                    var userdetails = JsonConvert.SerializeObject(_user, Formatting.Indented);
                    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(userdetails);
                    var user = System.Convert.ToBase64String(plainTextBytes);

                    var transaction = new TransactionModel
                    {
                        ArmVendorUserName = decrypt.DecryptCredentials(_configSettingManager.ArmServiceUsername),
                        ArmTranxID = TransactionReference,
                        ArmTranxAmount = TransactionAmount,
                        ArmCustomerID = _user.MembershipKey,
                        ArmCustomerName = _user.FullName,
                        ArmTranxCurr = "566",
                        ArmTranxNotiUrl = string.Format("{0}://{1}{2}", Request.Scheme, Request.Host.ToUriComponent(), Request.PathBase.ToUriComponent()) + "/PaymentStatus?au=" + user,
                        ArmXmlData = XmlData,
                        ArmPaymentParams = TransactionReference,
                        PaymentRequest = InvReq
                    };

                    //var HashData = _client.PaymentsHashString(MacKey, transaction);
                    var hashString = String.Concat(transaction.ArmTranxID, transaction.ArmVendorUserName,
                                                    transaction.ArmTranxAmount, transaction.ArmTranxNotiUrl, MacKey);
                    string ArmHash = _client.GetHashString(hashString);
                    transaction.ArmHash = ArmHash;

                    ProcessPayments getTransactions = new ProcessPayments();
                    getTransactions.Action = _configSettingManager.ArmAggregatorBaseUrl + "/Aggregator2/Payment";
                    getTransactions.ArmVendorUserName = transaction.ArmVendorUserName;
                    getTransactions.ArmTranxId = transaction.ArmTranxID;
                    getTransactions.ArmTranxAmount = transaction.ArmTranxAmount.ToString();
                    getTransactions.ArmCustomerId = transaction.ArmCustomerID.ToString();
                    getTransactions.ArmCustomerName = transaction.ArmCustomerName;
                    getTransactions.ArmTranxCurr = transaction.ArmTranxCurr;
                    getTransactions.ArmTranxNotiUrl = transaction.ArmTranxNotiUrl;
                    getTransactions.ArmXmlData = transaction.ArmXmlData;
                    getTransactions.ArmPaymentParams = transaction.ArmPaymentParams;
                    getTransactions.PaymentRequest = transaction.PaymentRequest;
                    getTransactions.ArmHash = transaction.ArmHash;

                    postdata.ProcessPayments = getTransactions;
                    db.ProcessPayments.Add(postdata.ProcessPayments);
                    db.SaveChanges();

                    return Json(getTransactions);
                }
            }
            catch (Exception ex)
            {
                HttpContext.Session.Set("error", ex.Message);
                TempData["message"] = ViewBag.Message = ex.Message;
                Utilities.ProcessError(ex, _contentRootPath);
                _logger.LogError(null, ex, ex.Message);
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [IgnoreAntiforgeryToken(Order = 1001)]
        public IActionResult PaymentStatus(IFormCollection response, string au)
        {
            var userprofile = new AuthenticateResponse();
            if (!String.IsNullOrEmpty(au))
            {
                var base64EncodedBytes = System.Convert.FromBase64String(au);
                var decodedJson = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

                userprofile = JsonConvert.DeserializeObject<AuthenticateResponse>(decodedJson);
            }

            var _user = _cache.Get<AuthenticateResponse>("ArmUser");
            if (_user == null)
            {
                _cache.Set<AuthenticateResponse>("ArmUser", userprofile, 
                                                    new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(20))
                                                                                 .SetAbsoluteExpiration(TimeSpan.FromHours(1)));
            }
            
            //var getClientBalance = _client.GetTotalAccountBalance(_user.MembershipKey);

            //if (getClientBalance != null)
            //{
            //    HttpContext.Session.Set("ArmClientBalance", getClientBalance);
            //}

            var trResponse = response;
            var transactionRef = trResponse["arm_txnref"];
            var trStatusCode = trResponse["arm_tranx_status_code"];
            var trPayRef = trResponse["arm_payref"];
            var trAmount = trResponse["arm_tranx_amt"];
            var trStatusMsg = trResponse["arm_tranx_status_msg"];
            var trCurrency = trResponse["arm_tranx_curr"];
            var trCustId = trResponse["arm_cust_id"];
            var trPaymentParams = trResponse["arm_payment_params"];

            if (trResponse != null)
            {
                var logInfo = $@"Response from the payment gateway :  Status Code:{trStatusCode} --- Status Message: {trStatusMsg}";
                _logger.LogInformation(logInfo);
            }

            var transactionStatus = new PaymentTransactionStatus();

            if (!String.IsNullOrEmpty(transactionRef))
            {
                var transactionquery = db.ProcessPayments.Where(s => s.ArmTranxId.Equals(transactionRef)).FirstOrDefault<ProcessPayments>();

                var inResponse = new AdditionalInvResponse();
                if (trStatusCode == "00")
                {
                    var paymentRequest = transactionquery.PaymentRequest;
                    var investmentRequest = new InvestmentRequest();
                    investmentRequest = JsonConvert.DeserializeObject<InvestmentRequest>(paymentRequest);

                    var orderpayment = investmentRequest.OrderPayment;
                    orderpayment.PaymentReference = transactionRef;
                    orderpayment.PaymentMethod = trPayRef;

                    investmentRequest.OrderPayment = orderpayment;

                    var payload = JsonConvert.SerializeObject(investmentRequest, Formatting.Indented);
                    transactionquery.PaymentRequest = payload;

                    //make API call to AddSales endpoint 
                    inResponse = _clientService.AddSales(investmentRequest);

                    //update ProcessPayment table to reflect changes.
                    db.ProcessPayments.Update(transactionquery);
                    db.SaveChanges();
                }

                if (trResponse != null || inResponse != null)
                {
                    //persist PaymentTransactions record to the DB
                    transactionStatus = new PaymentTransactionStatus()
                    {
                        TransactionReference = transactionRef,
                        PaymentReference = trPayRef,
                        TransactionStatusCode = trStatusCode,
                        TransactionAmount = Convert.ToDecimal(trAmount),
                        TransactionStatusMessage = trStatusMsg,
                        TransactionCurrency = trCurrency,
                        CustomerId = trCustId,
                        PaymentParameters = trPaymentParams,
                        DateSubmitted = DateTime.Now
                    };

                    db.PaymentTransactionStatus.Add(transactionStatus);
                    db.SaveChanges();
                }
            }

            return View("TransactionStatus", transactionStatus);
        }

        public IActionResult TransactionStatus(PaymentTransactionStatus transactionStatus)
        {
            var model = new PaymentTransactionStatus();
            model = transactionStatus;
            return View(model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult ProcessDirectDebit([FromBody]SetUp model)
        {
            var _user = _cache.Get<AuthenticateResponse>("ArmUser");
            if (_user == null)
            {
                TempData["SessionTimeOut"] = $@"You have been logged out due to inactivity. 
                                                Please login to gain access.";
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            try
            {
                var decrypt = new SecureCredentials();

                string MacKey = _configSettingManager.ArmMacKey;
                var XmlData = string.Empty;
                
                if (ModelState.IsValid)
                {
                    var product = model.ProductCode;
                    var amount = Decimal.Parse(model.Amount) * 100;
                    var startdate = model.StartDate;
                    var frequency = model.Frequency;

                    if (amount <= 0)
                    {
                        return StatusCode((int)HttpStatusCode.ExpectationFailed, "Invalid Transaction.");
                    }
                    else
                    {
                        XmlData = $@"<paymentitemxml>
                                       <payment_items> 
                                            <payment_item>
                                               <item_code>{product}</item_code>
                                               <item_amt>{amount}</item_amt>
                                            </payment_item>
                                       </payment_items>
                                   </paymentitemxml>";
                    }

                    var userdetails = JsonConvert.SerializeObject(_user, Formatting.Indented);
                    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(userdetails);
                    var userprofile = System.Convert.ToBase64String(plainTextBytes);

                    var TransactionReference = _client.GenerateUniqueID(_user.MembershipKey);
                    var transactionDebit = new DirectDebitTransactionModel
                    {
                        ArmVendorUserName = decrypt.DecryptCredentials(_configSettingManager.ArmServiceUsername),
                        ArmCustomerID = _user.MembershipKey,
                        ArmCustomerName = _user.FullName,
                        ArmDdAmt = amount,
                        ArmStartDate = startdate,
                        ArmFrequency = frequency,
                        ArmDdNotiUrl = string.Format("{0}://{1}{2}", Request.Scheme, Request.Host.ToUriComponent(), Request.PathBase.ToUriComponent()) + "/Client/Buy/DebitStatus?au=" + userprofile,
                        ArmPaymentParams = TransactionReference,
                        ArmXmlData = XmlData
                    };

                    var HashData = _client.DebitHashString(MacKey, transactionDebit);

                    var hashString = String.Concat(transactionDebit.ArmCustomerID, transactionDebit.ArmVendorUserName, 
                                                        transactionDebit.ArmDdAmt, transactionDebit.ArmDdNotiUrl, MacKey);

                    var ArmHash = _client.GetHashString(hashString);
                    transactionDebit.ArmHash = ArmHash;

                    DirectDebitTransactions debit = new DirectDebitTransactions();
                    debit.Action = _configSettingManager.ArmAggregatorBaseUrl + "/Aggregator/DirectDebit/";
                    debit.ArmVendorUsername = transactionDebit.ArmVendorUserName;
                    debit.ArmCustomerId = transactionDebit.ArmCustomerID.ToString();
                    debit.ArmCustomerName = transactionDebit.ArmCustomerName;
                    debit.ArmDdAmt = transactionDebit.ArmDdAmt;
                    debit.ArmStartDate = transactionDebit.ArmStartDate;
                    debit.ArmFrequency = transactionDebit.ArmFrequency;
                    debit.ArmDdNotiUrl = transactionDebit.ArmDdNotiUrl;
                    debit.ArmPaymentParams = transactionDebit.ArmPaymentParams;
                    debit.ArmXmlData = transactionDebit.ArmXmlData;
                    debit.ArmHash = transactionDebit.ArmHash;

                    db.DirectDebitTransactions.Add(debit);
                    db.SaveChanges();

                    return Json(debit);
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = ViewBag.Message = ex.Message;
                Utilities.ProcessError(ex, _contentRootPath);
                _logger.LogError(null, ex, ex.Message);
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [IgnoreAntiforgeryToken(Order = 1001)]
        public IActionResult DebitStatus(IFormCollection response, string au)
        {
            var userprofile = new AuthenticateResponse();
            if (!String.IsNullOrEmpty(au))
            {
                var base64EncodedBytes = System.Convert.FromBase64String(au);
                var decodedJson = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

                userprofile = JsonConvert.DeserializeObject<AuthenticateResponse>(decodedJson);
            }

            var _user = _cache.Get<AuthenticateResponse>("ArmUser");
            if (_user == null)
            {
                _cache.Set<AuthenticateResponse>("ArmUser", userprofile,
                                                            new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(20))
                                                                                 .SetAbsoluteExpiration(TimeSpan.FromHours(1)));
            }

            //var getClientBalance = _client.GetTotalAccountBalance(_user.MembershipKey);

            //if (getClientBalance != null)
            //{
            //HttpContext.Session.Set("ArmClientBalance", getClientBalance);
            //set session at this point.
            //}

            var ddResponse = response;
            var ddRef = ddResponse["arm_ddref"];
            var ddStatusCode = ddResponse["arm_dd_status_code"];
            var ddStatusMsg = ddResponse["arm_dd_status_msg"];
            var ddAmount = ddResponse["arm_dd_amt"];
            var ddCustomerId = ddResponse["arm_cust_id"];
            var ddCardType = ddResponse["arm_cc_type"];
            var ddCardMask = ddResponse["arm_cc_mask"];
            var ddAmtAppr = ddResponse["arm_dd_amt_appr"];

            var directDebit = new DDebit();

            if (!String.IsNullOrEmpty(ddRef))
            {
                if (!String.IsNullOrEmpty(ddStatusCode) || ddStatusCode.Equals("0") || ddStatusCode.Equals("00"))
                {
                    directDebit.CustomerId = ddCustomerId;
                    directDebit.DirectDebitReference = ddRef;
                    directDebit.DebitAmount = Convert.ToDecimal(ddAmount);
                    directDebit.AmountApproved = Convert.ToDecimal(ddAmtAppr);
                    directDebit.CardMask = ddCardMask;
                    directDebit.CardType = ddCardType;
                    directDebit.StatusMessage = ddStatusMsg;
                    directDebit.StatusCode = ddStatusCode;
                    directDebit.CreatedOn = DateTime.Now;

                    db.DDebit.Add(directDebit);
                    db.SaveChanges();
                }
            }

            var model = new DirectDebitTransactionResponse
            {
                ArmDdRef = ddRef,
                ArmDdStatusCode = ddStatusCode,
                ArmDdStatusMsg = ddStatusMsg,
                ArmDdAmt = Convert.ToDecimal(ddAmount),
                ArmCustId = ddCustomerId,
                ArmCcType = ddCardType,
                ArmCcMask = ddCardMask,
                ArmDdAmtAppr = Convert.ToDecimal(ddAmtAppr)
            };

            return View("DirectDebitStatus", model);
        }

        public IActionResult DirectDebitStatus(DirectDebitTransactionResponse model)
        {
            return View(model);
        }

        public IActionResult CancelDirectDebit(int id)
        {
            var decrypt = new SecureCredentials();

            var _user = _cache.Get<AuthenticateResponse>("ArmUser");
            if (_user == null)
            {
                TempData["SessionTimeOut"] = $@"You have been logged out due to inactivity. 
                                                Please login to gain access.";
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            var vendorUserName = decrypt.DecryptCredentials(_configSettingManager.ArmServiceUsername);
            var mackey = _configSettingManager.ArmMacKey;
            try
            {
                var directDebit = db.DDebit
                                          .Where(s => s.CustomerId == _user.MembershipKey.ToString() && s.Id == id)
                                          .FirstOrDefault<DDebit>();

                var notifyUrl = Url.Action("TransactionStatus", "Buy", new { type = 1 }, Request.Scheme);
                if (directDebit != null)
                {
                    var HashData = $@"{_user.MembershipKey}{vendorUserName}{directDebit.CardMask}{mackey}";
                    var ArmHash = _client.GetHashString(HashData);

                    var cRequest = new CancelDirectDebitRequest
                    {
                        ArmDdRef = directDebit.DirectDebitReference,
                        ArmVendorUsername = vendorUserName,
                        ArmHash = ArmHash,
                        ArmCcMask = directDebit.CardMask,
                        ArmCcType = directDebit.CardType,
                        ArmCustId = directDebit.CustomerId
                    };
                    var cResponse = _clientService.CancelDirectDebit(cRequest);

                    if (cResponse.ArmDdStatusCode == "0" || cResponse.ArmDdStatusCode == "00")
                    {
                        //delete record from the DB
                        db.DDebit.Remove(directDebit);
                        db.SaveChanges();

                        return Json(cResponse);
                    }
                    else if (cResponse.ArmDdStatusCode == "Z2")
                    {
                        return Json(cResponse);
                    }
                    else
                    {
                        return StatusCode((int)HttpStatusCode.ExpectationFailed, cResponse.ArmDdStatusCode + " There was a problem processing your request.");
                    }

                }
                else
                {
                    return NotFound("No direct debit mandate found for the provided information.");
                }
            }
            catch (Exception ex)
            {
                HttpContext.Session.Set("error", ex.Message);
                TempData["message"] = ViewBag.Message = ex.Message;
                Utilities.ProcessError(ex, _contentRootPath);
                _logger.LogError(null, ex, ex.Message);
            }
            return View();
        }
    }
}