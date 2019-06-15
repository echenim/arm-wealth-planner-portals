using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Portal.Business.Contracts;
using Portal.Business.Utilities;
using Portal.Business.ViewModels;
using Portal.Domain;
using Portal.Domain.Models;
using Portal.Domain.ViewModels;

namespace Portal.Business.StoreManagers
{
    public class CartManager : ICartManager
    {
        private readonly ApplicationDbContext _context;
        private readonly IArmOneServiceConfigManager _armOneServiceConfigManager;

        public CartManager(ApplicationDbContext context,IArmOneServiceConfigManager armOneServiceConfigManager)
        {
            _context = context;
            _armOneServiceConfigManager = armOneServiceConfigManager;
        } 

        public Transactional Save(Transactional model)
        {
            _context.Add(model);
            _context.SaveChanges();

            return model;
        }

        public ProcessPayments SavePayment(Transactional model)
        {
            var encryptedValue = new SecureCredentials();
            var payload = new List<Transactional>();
            payload.Add(model);

            var iRequest = new TransactionRequest { CustomerName = model.ItemOwner };

            var orderpayment = new orderPayment();
            orderpayment.Amount = model.Amount;
            orderpayment.PaymentMethod = "unknown";

            iRequest.OrderPayment = orderpayment;
            var InvReq = JsonConvert.SerializeObject(iRequest, Formatting.Indented);

            var transactions = new ProcessPayments();
            transactions.ArmTranxAmount = model.Amount.ToString();
            transactions.ArmTranxId = model.TransactionNo.ToString();
            transactions.Action = $"{_armOneServiceConfigManager.ArmAggregatorBaseUrl}/Aggregator2/Payment";
            transactions.ArmVendorUserName = encryptedValue.DecryptCredentials(_armOneServiceConfigManager.ArmServiceUsername);
            transactions.ArmTranxNotiUrl = _armOneServiceConfigManager.ReturnUrl;
            transactions.ArmXmlData = ArmXmlData(payload);
            transactions.ArmTranxCurr = "566";
            transactions.ArmCustomerId = model.ItemOwner;
            transactions.PaymentRequest = InvReq;

            _context.ProcessPayments.Add(transactions);
            _context.SaveChanges();

            return transactions;
        }

        public TransQIdenfier TrnxGenerator()
        {
            var trnsIdGenerator = new TransQIdenfier();
            trnsIdGenerator.Owner = "Mark";
            _context.Add(trnsIdGenerator);
            _context.SaveChanges();

            return trnsIdGenerator;
        }

        public string ArmXmlData(List<Transactional> datapayload)
        {
            var xml = new StringBuilder();
            xml.Append("<paymentitemxml><payment_items>");
            foreach (var item in datapayload)
            {
                var parts = $@"<payment_item>
                                    <item_code>{item.Product.Name}</item_code>
                                    <item_amt>{item.Amount.ToString().Replace(".", "")}</item_amt>
                              </payment_item>";

                xml.Append(parts);
            }

            xml.Append("</payment_items></paymentitemxml>");
            return xml.ToString();
        }

        public Transactional Edit(Transactional model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return model;
        }

        public void UpdateStatus(string trans, string status)
        {
            var commandText = $"UPDATE Transactional SET OrderAndPurchaseStatus=@OrderAndPurchaseStatus WHERE TransactionNo='{trans}'";
            var name = new SqlParameter("@OrderAndPurchaseStatus", status);
            _context.Database.ExecuteSqlCommand(commandText, name);
        }

        public Transactional Delete(Transactional model)
        {
            _context.Entry(model).State = EntityState.Deleted;
            _context.SaveChanges();
            return model;
        }

        //public Transactional GetCartItem(Transactional model)
        //{
        //    var item = _context.Transactional.Where(s => s.Id == model.Id && s.ItemOwner.Equals(model.ItemOwner)).FirstOrDefault();
        //    return item;
        //}

        public Transactional GetCartItem(long id, long tranxNo)
        {
            var item = _context.Transactional.Where(s => s.Id == id 
                        && s.TransactionNo == tranxNo 
                        && s.OrderAndPurchaseStatus.Equals("InCart")).FirstOrDefault();
            return item;
        }

        public Transactional DeleteCartItem(long id, long tranxNo)
        {
            var cartItem = GetCartItem(id, tranxNo);
            var deleteItem = Delete(cartItem); 

            return deleteItem;
        }

        public Transactional DeleteItemsFromCart(Transactional model)
        {
            var items = _context.Transactional.
                Where(x => x.TransactionNo == model.TransactionNo && x.ItemOwner.Equals(model.ItemOwner) && x.ProductId == model.ProductId).
                AsQueryable();

            foreach (var item in items)
            {
                Delete(item);
            }

            return null;
        }

        public string DecodeHex(string text)
        {
            byte[] bb = Enumerable.Range(0, text.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(text.Substring(x, 2), 16))
                             .ToArray();
            return System.Text.Encoding.ASCII.GetString(bb);
        }

        public IQueryable<Transactional> Get(Func<Transactional, bool> predicate = null)
            => (predicate != null ? _context.Transactional.Include(s => s.Product).Include(s => s.Product.ProductCategory).Where(predicate: predicate)
                : _context.Transactional.Include(s => s.Product).Include(s => s.Product.ProductCategory).AsNoTracking()).AsQueryable();

        public CartView GetCart(Func<Transactional, bool> predicate = null)
        {
            var data = (predicate != null ? _context.Transactional.Include(s => s.Product).Where(predicate: predicate)
                : _context.Transactional.Include(s => s.Product).AsNoTracking()).AsQueryable();

            var result = new CartView();
            result.CartCollection = data.AsEnumerable();
            result.SubTotal = result.CartCollection.Where(s => s.Product.ProductTypes.Equals("Enter Amount")).Sum(s => s.Amount);
            return result;
        }

        public void CartUpdateWithEmail(string email, string session)
        {
            var commandText = $"UPDATE Transactional SET ItemOwner=@ItemOwne WHERE TransactionNo='{session}'";
            var name = new SqlParameter("@ItemOwne", email);
            _context.Database.ExecuteSqlCommand(commandText, name);
        }

        public async void Edit(string cartId)
        {
            var sql = $"UPDATE Transactional SET OrderAndPurchaseStatus='Succeed' WHERE TransactionNo={cartId}";
            await _context.Database.ExecuteSqlCommandAsync(sql: sql);
        }
        
    }
}