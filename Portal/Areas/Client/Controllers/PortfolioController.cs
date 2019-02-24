using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Portal.Business.Contracts;
using Portal.Business.TestServices;
using Portal.Business.ViewModels;
using Portal.Domain;
using Portal.Services;
using WkWrap.Core;

namespace Portal.Areas.Client.Controllers
{
    [Area("Client")]
    public class PortfolioController : Controller
    {
        public string _webRootPath;
        public string _contentRootPath;
        public readonly IHostingEnvironment _hostingEnvironment;
        public JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

        public readonly ILogger<PortfolioController> _logger;
        public readonly IConfiguration _configuration;

        private readonly IArmOneServiceConfigManager _configSettingManager;
        public TestArmClientServices _clientService;

        public ApplicationDbContext db;
        public ClientRepository _client;

        public PortfolioController(IHostingEnvironment hostingEnvironment, IArmOneServiceConfigManager configManager,
                                    ILogger<PortfolioController> logger, IConfiguration configuration,
                                    IDistributedCache cache, ApplicationDbContext _db)
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
        }

        public IActionResult FamilyAccounts()
        {
            var model = new FamilyAccountsViewModel();
            var _user = new AuthenticateResponse
            {
                MembershipKey = 1007435,
                EmailAddress = "gbadebo.ayan@gmail.com",
                FirstName = "Funmilayo",
                LastName = "Adeyemi",
                FullName = "Funmilayo Ruth Adeyemi",
            };

            try
            {
                var familyAccounts = _client.GetFamilyAccount(_user.MembershipKey.ToString());
                var accountBalance = _client.GetTotalAccountBalance(_user.MembershipKey);

                model.Status = familyAccounts.Status;
                model.StatusMessage = familyAccounts.StatusMessage;
                model.AccountDetails = familyAccounts.AccountDetails;

            }
            catch (Exception ex)
            {
                TempData["message"] = ViewBag.Message = ex.Message;
                Utilities.ProcessError(ex, _contentRootPath);
                _logger.LogError(null, ex, ex.Message);
            }
            return View(model);
        }

        public IActionResult MyInvestments()
        {
            return View();
        }

        public IActionResult AccountStatement(string code)
        {
            var model = new AccountStatementViewModel();
            var _user = new AuthenticateResponse
            {
                MembershipKey = 1007435,
                EmailAddress = "gbadebo.ayan@gmail.com",
                FirstName = "Funmilayo",
                LastName = "Adeyemi",
                FullName = "Funmilayo Ruth Adeyemi",
            };
            try
            {
                List<ProductItems> getItems = new List<ProductItems>();
                var productcode = "";

                var customer = new CustomerDetail();
                customer = _client.GetUserProfile(_user.MembershipKey);

                if (string.IsNullOrEmpty(code))
                {
                    productcode = customer.ProductItems.Select(x => x.ProductCode).FirstOrDefault();
                }
                else
                {
                    productcode = code;
                }

                var accountsResponse = _client.GetAccountSummary(_user.MembershipKey);
                var productDetail = _client.GetProductInAccount(productcode, accountsResponse);

                if (productDetail != null)
                {
                    model.ProductDetails.ProductCode = productDetail.ProductCode;
                    model.ProductDetails.ProductName = productDetail.ProductName;
                    model.ProductDetails.Currency = productDetail.Currency;
                    model.ProductDetails.AccruedInterest = productDetail.AccruedInterest;
                    model.ProductDetails.CurrentBalance = productDetail.CurrentBalance;
                }

                if (customer.ProductItems != null)
                {
                    foreach (var productitems in customer.ProductItems)
                    {
                        var product = new ProductItems();
                        product.ProductName = productitems.ProductName;
                        product.ProductCode = productitems.ProductCode;

                        getItems.Add(product);
                    }
                    model.SelectProductName = getItems;
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = ViewBag.Message = ex.Message;
                Utilities.ProcessError(ex, _contentRootPath);
                _logger.LogError(null, ex, ex.Message);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult AccountStatement(AccountStatementViewModel model)
        {
            var _user = new AuthenticateResponse
            {
                MembershipKey = 1007435,
                EmailAddress = "gbadebo.ayan@gmail.com",
                FirstName = "Funmilayo",
                LastName = "Adeyemi",
                FullName = "Funmilayo Ruth Adeyemi",
            };

            try
            {
                var customer = _client.GetUserProfile(_user.MembershipKey);
                var productcode = customer.ProductItems.Select(x => x.ProductCode).FirstOrDefault();
                var accountsResponse = _client.GetAccountSummary(_user.MembershipKey);
                var productDetail = _client.GetProductInAccount(productcode, accountsResponse);

                if (productDetail != null)
                {
                    model.ProductDetails.ProductCode = productDetail.ProductCode;
                    model.ProductDetails.ProductName = productDetail.ProductName;
                    model.ProductDetails.Currency = productDetail.Currency;
                    model.ProductDetails.AccruedInterest = productDetail.AccruedInterest;
                    model.ProductDetails.CurrentBalance = productDetail.CurrentBalance;
                }

                List<ProductItems> getProductItems = new List<ProductItems>();
                if (customer.ProductItems != null)
                {
                    foreach (var productitems in customer.ProductItems)
                    {
                        var productItems = new ProductItems();
                        productItems.ProductName = productitems.ProductName;
                        productItems.ProductCode = productitems.ProductCode;

                        getProductItems.Add(productItems);
                    }
                    model.SelectProductName = getProductItems;
                }

                //get statement request(s)
                var trResponse = _client.GetClientTransactions(_user, model);
                List<ProductTransactions> getItems = new List<ProductTransactions>();

                if (trResponse.Transactions != null)
                {
                    foreach (var response in trResponse.Transactions)
                    {
                        var product = new ProductTransactions();
                        product.MarketValue = response.MarketValue;
                        product.Description = response.Description;
                        product.TransactionDate = response.TransactionDate;
                        product.TransactionType = response.TransactionType;
                        product.Amount = response.Amount;
                        product.UnitPrice = response.UnitPrice;
                        product.Units = response.Units;
                        product.FundCode = response.FundCode;

                        getItems.Add(product);
                    }

                    model.Transactions = getItems;
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = ViewBag.Message = ex.Message;
                Utilities.ProcessError(ex, _contentRootPath);
                _logger.LogError(null, ex, ex.Message);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult PrintStatement(AccountStatementViewModel model)
        {
            var _user = new AuthenticateResponse
            {
                MembershipKey = 1007435,
                EmailAddress = "gbadebo.ayan@gmail.com",
                FirstName = "Funmilayo",
                LastName = "Adeyemi",
                FullName = "Funmilayo Ruth Adeyemi",
            };

            try
            {
                var accountsResponse = _client.GetAccountSummary(_user.MembershipKey);
                var customer = _client.GetUserProfile(_user.MembershipKey);
                var productDetail = _client.GetProductInAccount(model.ProductCode, accountsResponse);

                if (productDetail != null)
                {
                    model.ProductDetails.ProductCode = productDetail.ProductCode;
                    model.ProductDetails.ProductName = productDetail.ProductName;
                    model.ProductDetails.Currency = productDetail.Currency;
                    model.ProductDetails.AccruedInterest = productDetail.AccruedInterest;
                    model.ProductDetails.CurrentBalance = productDetail.CurrentBalance;
                }

                List<ProductDetails> getSummaries = new List<ProductDetails>();
                if (accountsResponse != null)
                {
                    foreach (var item in accountsResponse.Summaries)
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

                List<ProductTransactions> getTransactions = new List<ProductTransactions>();
                var trResponse = _client.GetClientTransactions(_user, model);
                var transactions = _client.LoadLastTransactions(_user, accountsResponse, 6);

                if (trResponse != null && trResponse.Transactions.Count > 0)
                {
                    foreach (var item in trResponse.Transactions)
                    {
                        var product = new ProductTransactions();
                        product.MarketValue = item.MarketValue;
                        product.Description = item.Description;
                        product.TransactionDate = item.TransactionDate;
                        product.TransactionType = item.TransactionType;
                        product.Amount = item.Amount;
                        product.UnitPrice = item.UnitPrice;
                        product.Units = item.Units;

                        getTransactions.Add(product);
                    }

                    model.Transactions = getTransactions;
                }

                model.CurrentTimeStamp = DateTime.Now.ToString("dd MMMM yyyy");

                if (customer.MembershipNumber > 0)
                {
                    model.CustomerDetails.FullName = customer.FullName;
                    model.CustomerDetails.FirstName = customer.FirstName;
                    model.CustomerDetails.LastName = customer.LastName;
                    model.CustomerDetails.MembershipNumber = customer.MembershipNumber;
                    model.CustomerDetails.PhoneNumber = customer.MobileNumber;
                    model.CustomerDetails.MobileNumber = customer.MobileNumber;
                    model.CustomerDetails.EmailAddress = customer.EmailAddress;
                    model.CustomerDetails.Address = customer.Address;
                    model.CustomerDetails.State = customer.State;
                    model.CustomerDetails.Country = customer.Country;
                    model.CustomerDetails.ProductItems = customer.ProductItems;
                }

                return DownloadPdf(model);
            }
            catch (Exception ex)
            {
                TempData["message"] = ViewBag.Message = ex.Message;
                Utilities.ProcessError(ex, _contentRootPath);
                _logger.LogError(null, ex, ex.Message);
            }
            return View();
        }

        public IActionResult DownloadPdf(AccountStatementViewModel model)
        {
            var sbuilder = new StringBuilder();

            var beginningOfPage = @"<html xmlns='http://www.w3.org/1999/xhtml'><head> <meta http-equiv='Content-Type' content='text/html; charset=utf-8'> <meta name='viewport' content='width=device-width, initial-scale=1.0'> <title>Account Statement</title> <style type='text/css'> /* Client-specific Styles */ #outlook a{padding: 0;}/* Force Outlook to provide a 'view in browser' menu link. */ body{width: 100% !important; -webkit-text-size-adjust: 100%; background: #F8F8F8; -ms-text-size-adjust: 100%; margin: 0; padding: 0; color: #333333; font-family: Helvetica, Arial, sans-serif;}/* Prevent Webkit and Windows Mobile platforms from changing default font sizes, while not breaking desktop design. */ .ExternalClass{width: 100%;}/* Force Hotmail to display emails at full width */ .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div{line-height: 100%;}/* Force Hotmail to display normal line spacing. */ #backgroundTable{margin: 0; padding: 0; width: 100% !important; line-height: 100% !important;}img{outline: none; text-decoration: none; border: none; -ms-interpolation-mode: bicubic;}a{color: #7a023f;}strong{font-weight: 700 !important;}b{font-weight: 700 !important;}tr{vertical-align: top !important;}a img{border: none;}.image_fix{display: block;}/*p{margin: 0px 0px !important;}*/ /* fixes */ .norm{font-size: 13px; line-height: 14px;}.sideHeadings{font-weight: bold; text-align: left; padding: 6px 8px 6px 0 !important; font-size: 13px; Color: #999999;}.roomDuration{color: #333333; font-weight: bold; text-align: left; padding: 6px 8px 6px 0 !important;}.sect td, .sumSect td, .lastSect td, .paySect td{padding: 6px; vertical-align: top !important; line-height: 19px;}.paySect{border-bottom: 1px solid #DDDDDD;}.last{border-color: #000000;}.infoSect{line-height: 19px;}.sectTitleBg{text-transform: uppercase !important; font-size: 12px !important; font-weight: bold !important; color: #FFFFFF !important; background: #000040; text-align: left !important; line-height: 20px !important; padding: 8px 14px !important; display: block !important;}.littleRight{font-size: 10px; color: #999999; text-align: right;}.price{text-align: right; padding: 5px}.vat{color: #999; font-size: 10px; line-height: 10px;}.infoArea{font-size: 13px; line-height: 18px; width: 520px;}.undoreset table{table-layout: fixed !important; margin: 0 auto !important;}.uberlink{color: #1FBAD6 !important; text-decoration: none;}table td{border-collapse: collapse;}table{border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; vertical-align: top; table-layout: fixed;}table table{table-layout: auto;}/*a{color: #e95353;text-decoration: none;text-decoration:none!important;}*/ /*STYLES*/ table[class=full]{width: 100%; clear: both;}</style></head><body>";

            var printhtml1 = @"<table width='100%' border='0' cellspacing='0' cellpadding='0' style='' bgcolor='#F8F8F8'> <tr> <td align='center'> <table width='100%' border='0' align='center' cellpadding='0' cellspacing='0' class='deviceWidth'> <tr> <td width='600' align='center'>";

            var printhtml2 = @"<div class='block'> <table width='100%' bgcolor='#F8F8F8' cellpadding='0' cellspacing='0' border='0' id='backgroundTable'> <tbody> <tr> <td> <table width='100%' bgcolor='#FFF' cellpadding='0' cellspacing='0' border='0' align='center' class='devicewidth'> <tbody> <tr> <td align='center'> <table cellpadding='0' cellspacing='0' border='0' align='center' class='devicewidth' width='96%'> <tbody> <tr> <td valign='middle' align='right' style='padding: 25px 0 15px 15px;' class='logo'> <div class='imgpop'> <a href='' title='ARM Investment Managers Account Statement' alt='ARM Investment Managers Account Statement'><img src='~/img/logo.png' alt='ARM' border='0' style='display:block; border:none; outline:none; text-decoration:none; max-width:150px;' class='logo'></a> </div></td></tr></tbody> </table> </td></tr></tbody> </table> </td></tr></tbody> </table> </div>";

            //customer details
            var acctCustomerBegin = @"<div class='block'> <table width='100%' bgcolor='#F8F8F8' cellpadding='0' cellspacing='0' border='0' id='backgroundTable'> <tbody> <tr> <td> <table bgcolor='#ffffff' width='100%' cellpadding='0' cellspacing='0' border='0' align='center' class='devicewidth'> <tbody> <tr> <td width='100%' height='10'></td></tr><tr> <td align='center'> <table width='96%' align='center' cellpadding='0' cellspacing='0' border='0' class='devicewidthinner'> <tbody> <tr> <td colspan='2' st-title='rightimage-title' background='#DDDDDD'><div style='text-transform:uppercase !important; font-size: 20px !important; font-weight:bold !important; color: #000000 !important; background:#DDDDDD; text-align:center !important;line-height: 20px !important; padding:8px 14px !important; display:block !important;'>CLIENT STATEMENT</div></td></tr><tr> <td height='5' colspan='2'></td></tr>";

            var acctCustomer = $@"<tr> <td><div style='padding:20px 0; font-size:18px; font-weight:bold;'>{model.CustomerDetails.LastName.ToUpper()} {model.CustomerDetails.FirstName}</div></td><td width='180'><div style='text-align:right; font-size:13px; padding:20px 0; display:block;'>Print Date: {model.CurrentTimeStamp}</div></td></tr><tr> <td colspan='2' style='font-size: 12px; background:#F4F4E8; text-align:left;line-height: 20px;' st-title='rightimage-title'> <table style='font-size:13px; background:#FFFFFF' width='40%'> <tr class='sect' valign='top'> <td style='font-weight:bold; text-align:left; padding:6px 8px 6px 0 !important; font-size: 13px; Color: #999999;'>Membership Number:</td><td style='padding:6px 0 6px 8px !important;'>{model.CustomerDetails.MembershipNumber}</td></tr><tr class='sect' valign='top'> <td style='font-weight:bold; text-align:left; padding:6px 8px 6px 0 !important; font-size: 13px; Color: #999999; '>Email Address:</td><td style='padding:6px 0 6px 8px !important;'>{model.CustomerDetails.EmailAddress}</td></tr><tr class='sect' valign='top'> <td style='font-weight:bold; text-align:left; padding:6px 8px 6px 0 !important; font-size: 13px; Color: #999999;'>Phone Number:</td><td style='padding:6px 0 6px 8px !important;'>{model.CustomerDetails.PhoneNumber}</td></tr></table> </td></tr>";

            var acctCustomerEnd = @"<tr> <td width='100%' colspan='2' height='10'></td></tr></tbody> </table> </td></tr></tbody> </table> </td></tr></tbody> </table> </div>";

            //summaries
            var summaryBegin = @"<div class='block'> <table width='100%' bgcolor='#FFFFFF' cellpadding='0' cellspacing='0' border='0' id='backgroundTable' st-sortable='rightimage'> <tbody> <tr> <td> <table bgcolor='#ffffff' width='100%' cellpadding='0' cellspacing='0' border='0' align='center' class='devicewidth' modulebg='edit'> <tbody> <tr> <td align='center'> <table width='96%' align='center' border='0' cellpadding='0' cellspacing='0' class='devicewidthinner'> <tbody> <tr> <td height='5'></td></tr>";

            var summary = @"<tr> <td style='font-size: 12px; background:#F4F4E8; text-align:left;line-height: 20px;' st-title='rightimage-title'>";

            var summary2 = String.Empty;
            var summary3 = String.Empty;
            var summary4 = String.Empty;
            if (model.Summaries != null && model.Summaries.Count > 0)
            {
                summary2 = @"<table style='font-size:13px; background:#FFFFFF' width='100%'> <tr class='paySect'> <td style='padding:6px; vertical-align:top !important; line-height:19px; border-bottom:1px solid #DDDDDD; font-weight: bold; font-size:15px;'>Fund</td><td style='padding:6px; vertical-align:top !important; line-height:19px; border-bottom:1px solid #DDDDDD; font-weight: bold; font-size:15px;'>Current Balance</td><td style='padding:6px; vertical-align:top !important; line-height:19px; border-bottom:1px solid #DDDDDD; font-weight: bold; font-size:15px;'>Accrued Interest</td></tr>";

                foreach (var summaryInfo in model.Summaries)
                {
                    summary3 = summary3 + $@"<tr class='paySect' valign='top'> <td style='padding:6px; vertical-align:top !important; line-height:19px; border-bottom:1px solid #DDDDDD;'>{summaryInfo.ProductName}</td><td style='padding:6px; vertical-align:top !important; line-height:19px; border-bottom:1px solid #DDDDDD;'>₦{summaryInfo.CurrentBalance.ToString("F2")}</td><td style='padding:6px; vertical-align:top !important; line-height:19px; border-bottom:1px solid #DDDDDD;'>₦{summaryInfo.AccruedInterest.ToString("F2")}</td></tr>";
                }

                summary4 = "</table>";
            }
            var summary5 = @"</td></tr>";
            var summaryEnd = @"<tr> <td width='100%' height='40'></td></tr></tbody> </table> </td></tr></tbody> </table> </td></tr></tbody> </table> </div>";

            //fund
            var fundListingStart = $@"<div class='block'> <table width='100%' bgcolor='#F8F8F8' cellpadding='0' cellspacing='0' border='0' id='backgroundTable' st-sortable='rightimage'> <tbody> <tr> <td> <table bgcolor='#ffffff' width='100%' cellpadding='0' cellspacing='0' border='0' align='center' class='devicewidth' modulebg='edit'> <tbody> <tr> <td align='center'> <table width='96%' align='center' border='0' cellpadding='0' cellspacing='0' class='devicewidthinner'> <tbody> <tr> <td st-title='rightimage-title'><div style='padding:15px 0px; border-top:1px dotted #bbb; font-size: 13px !important; text-align:left !important;'><span style='font-weight:bold; font-size:16px; line-height: 24px; color: #000000 !important;'>{model.ProductDetails.ProductName}</span></div></td></tr><tr> <td st-title='rightimage-title'><div style='padding:15px 0px; border-top:1px solid #bbb; font-size: 13px !important; text-align:left !important;'>Reporting Period: {model.Start.ToString("dd-MMM-yyyy")} to {model.End.ToString("dd-MMM-yyyy")}</div></td></tr><tr> <td height='5'></td></tr><tr> <td style='font-size: 12px; background:#F4F4E8; text-align:left;line-height: 20px;' st-title='rightimage-title'>";

            var transact = String.Empty;
            var transact2 = String.Empty;
            var transact3 = String.Empty;
            if (model.Transactions != null && model.Transactions.Count > 0)
            {
                var closingUnit = 0;
                var closingPrice = 0;
                var closingValue = 0;

                transact = @"<table style='font-size:13px; background:#FFFFFF' width='100%'> <tr class='paySect'> <td style='padding:6px; vertical-align:top !important; line-height:12px; border-bottom:1px solid #DDDDDD; font-weight: bold; font-size:13px;'>Date</td><td style='padding:6px; vertical-align:top !important; line-height:12px; border-bottom:1px solid #DDDDDD; font-weight: bold; font-size:13px;'>Type</td><td style='padding:6px; vertical-align:top !important; line-height:12px; border-bottom:1px solid #DDDDDD; font-weight: bold; font-size:13px;'>Amt Invested</td><td style='padding:6px; vertical-align:top !important; line-height:12px; border-bottom:1px solid #DDDDDD; font-weight: bold; font-size:13px;'>Unit Purchased</td><td style='padding:6px; vertical-align:top !important; line-height:12px; border-bottom:1px solid #DDDDDD; font-weight: bold; font-size:13px;'>Unit Price</td><td style='padding:6px; vertical-align:top !important; line-height:12px; border-bottom:1px solid #DDDDDD; font-weight: bold; font-size:13px;'>Value</td><td style='padding:6px; vertical-align:top !important; line-height:12px; border-bottom:1px solid #DDDDDD; font-weight: bold; font-size:13px;'>Desc</td></tr>";

                foreach (var transaction in model.Transactions)
                {
                    closingUnit = closingUnit + (int)transaction.Units;
                    closingPrice = closingPrice + (int)transaction.UnitPrice;
                    closingValue = closingValue + (int)transaction.MarketValue;

                    var last = model.Transactions.Last();

                    transact2 = transact2 + $@"<tr class='paySect' valign='top'> <td style='padding:6px; vertical-align:top !important; line-height:12px; border-bottom:1px solid #DDDDDD;'>{transaction.TransactionDate.ToString("d MMM y")}</td><td style='padding:6px; vertical-align:top !important; line-height:12px; border-bottom:1px solid #DDDDDD;'>{transaction.TransactionType}</td><td style='padding:6px; vertical-align:top !important; line-height:12px; border-bottom:1px solid #DDDDDD;'>{transaction.Amount.ToString("F2")}</td><td style='padding:6px; vertical-align:top !important; line-height:12px; border-bottom:1px solid #DDDDDD;'>{transaction.Units.ToString("F2")}</td><td style='padding:6px; vertical-align:top !important; line-height:12px; border-bottom:1px solid #DDDDDD;'>{transaction.UnitPrice.ToString("F2")}</td><td style='padding:6px; vertical-align:top !important; line-height:12px; border-bottom:1px solid #DDDDDD;'>{transaction.MarketValue.ToString("F2")}</td><td style='padding:6px; vertical-align:top !important; line-height:12px; border-bottom:1px solid #DDDDDD;'>{transaction.Description}</td></tr>";
                }

                transact3 = "</table>";
            }
            var endOfFundListing = @"</td></tr><tr> <td width='100%' height='60'></td></tr></tbody> </table> </td></tr></tbody> </table> </td></tr></tbody> </table> </div>";

            //footer
            var printFooter1 = @"<div class='block'> <table width='100%' bgcolor='#F8F8F8' cellpadding='0' cellspacing='0' border='0' id='backgroundTable' st-sortable='rightimage'> <tbody> <tr> <td> <table bgcolor='#ffffff' width='100%' cellpadding='0' cellspacing='0' border='0' align='center' class='devicewidth' modulebg='edit'> <tbody> <tr> <td align='center'> <table width='96%' align='center' border='0' cellpadding='0' cellspacing='0' class='devicewidthinner'> <tbody> <tr> <td height='10'></td></tr><tr> <td style='font-size: 12px; background:#F4F4E8; text-align:left;line-height: 20px;' st-title='rightimage-title'> <table style='font-size:13px; background:#FFFFFF' width='100%'> <tr> <td colspan='2' style='padding:6px; vertical-align:top !important; line-height:12px; font-weight: bold; font-size:13px;'>Lagos</td><td style='padding:6px; vertical-align:top !important; line-height:12px; font-weight: bold; font-size:13px;'>Port Harcourt</td><td style='padding:6px; vertical-align:top !important; line-height:12px; font-weight: bold; font-size:13px;'>Abuja</td><td style='padding:6px; vertical-align:top !important; line-height:12px;font-weight: bold; font-size:13px;'>Onitsha</td></tr><tr valign='top'> <td style='padding:6px; vertical-align:top !important; line-height:16px;'>1, Mekunwen Road,<br>Off Oyinkan Abayomi Drive,<br>Ikoyi, Lagos</td><td style='padding:6px; vertical-align:top !important; line-height:16px;'>68C, Coker Road, Along Town<br>Planning Way Ilupeju Lagos</td><td style='padding:6px; vertical-align:top !important; line-height:16px;'>12, Circular Road, Presidential<br>Estate By GRA Junction Port<br>Harcourt Rivers State</td><td style='padding:6px; vertical-align:top !important; line-height:16px;'>129, Adetokunbo Ademola<br>Crescent Wuse II, Abuja</td><td style='padding:6px; vertical-align:top !important; line-height:16px;'>60A Old Market Road,<br>Opposite Broad Way Cinema,<br>Onitsha, Anambra State.</td></tr></table> </td></tr><tr> <td width='100%' height='20'></td></tr></tbody> </table> </td></tr></tbody> </table> </td></tr></tbody> </table> </div>";
            var printFooter2 = @"<div class='block'> <table width='100%' bgcolor='#F8F8F8' cellpadding='0' cellspacing='0' border='0' id='backgroundTable' st-sortable='fulltext'> <tbody> <tr> <td> <table bgcolor='#ffffff' width='100%' cellpadding='0' cellspacing='0' border='0' align='center' class='devicewidth' modulebg='edit'> <tbody> <tr> <td align='center'> <table width='96%' align='center' cellpadding='0' cellspacing='0' border='0' class='devicewidthinner'> <tbody> <tr> <td class='norm' style=' font-size: 13px; color: #333333; padding-right:10px; text-align:left; line-height: 18px;'><p>For enquiries: Please contact the support unit at <a href='mailto:enquiries@arminvestmentcenter.com'>enquiries@arminvestmentcenter.com</a> or call us on <a href='tel:07002255276'>0700CALLARM</a> (07002255276)<br><br><br></p></td></tr></tbody> </table> </td></tr></tbody> </table> </td></tr></tbody> </table> </div>";

            //end of html
            var printendofHtml = @"</td></tr></table> </td></tr></table>";

            var endOfPage = @"</body></html>";

            sbuilder.Append(beginningOfPage);
            sbuilder.Append(printhtml1);
            sbuilder.Append(printhtml2);
            sbuilder.Append(acctCustomerBegin);
            sbuilder.Append(acctCustomer);
            sbuilder.Append(acctCustomerEnd);
            sbuilder.Append(summaryBegin);
            sbuilder.Append(summary);
            sbuilder.Append(summary2);
            sbuilder.Append(summary3);
            sbuilder.Append(summary4);
            sbuilder.Append(summary5);
            sbuilder.Append(summaryEnd);
            sbuilder.Append(fundListingStart);
            sbuilder.Append(transact);
            sbuilder.Append(transact2);
            sbuilder.Append(transact3);
            sbuilder.Append(endOfFundListing);
            sbuilder.Append(printFooter1);
            sbuilder.Append(printFooter2);
            sbuilder.Append(printendofHtml);
            sbuilder.Append(endOfPage);
            string html = sbuilder.ToString();

            var wkhtmltopdf = new FileInfo(@"C:\Program Files\wkhtmltopdf\bin\wkhtmltopdf.exe");
            var converter = new HtmlToPdfConverter(wkhtmltopdf);
            var settings = new ConversionSettings(
                pageSize: WkWrap.Core.PageSize.A4,
                orientation: PageOrientation.Portrait,
                margins: new PageMargins(10, 25, 10, 10),
                grayscale: true,
                lowQuality: true,
                quiet: true,
                enableJavaScript: true,
                javaScriptDelay: null,
                enableExternalLinks: true,
                enableImages: true,
                executionTimeout: null);
            var pdfBytes = converter.ConvertToPdf(html);

            MemoryStream workStream = new MemoryStream();
            workStream.Write(pdfBytes, 0, pdfBytes.Length);
            workStream.Position = 0;
            FileStreamResult fileResult = new FileStreamResult(workStream, "application/pdf");
            fileResult.FileDownloadName = "AccountStatement.pdf";

            return fileResult;
        }
    }
}