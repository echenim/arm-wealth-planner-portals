using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Portal.Business.Contracts;
using Portal.Domain.ViewModels;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;

namespace Portal.Business.StoreManagers
{
    public class GeneratorsManager : IGeneratorsManager
    {
        private readonly ICartManager _cartManager;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public GeneratorsManager(ICartManager cartManager, IHttpContextAccessor httpContextAccessor)
        {
            _cartManager = cartManager;
            _httpContextAccessor = httpContextAccessor;
        }

        private const string SessionName = "_ArmTracker";

        /// <summary>
        /// method to generator uniques transaction number
        /// that be used as tracking no for session and Transaction Number in Transactional table
        /// this will ensure uniques transaction and cart id is alway genenrated
        /// trhe unique number generated is stored in the TransQIdenfier table for tracking record purpose only
        /// </summary>
        /// <returns>string of uniques id</returns>
        private string TrnxNo => _cartManager.TrnxGenerator().Id.ToString();

        public string UserSessionManagerForTrackingActivities()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext.Session.GetString(SessionName) == null)
            {
                var trnx = TrnxNo;
                httpContext.Session.SetString(SessionName, trnx.ToString());
            }

            ;

            return httpContext.Session.GetString(SessionName);
        }

        public CartDetailView ViewCart(string email)
        {
            var filter = email ?? _httpContextAccessor.HttpContext.Session.GetString(SessionName);
            var cartdata = _cartManager.Get(s => s.ItemOwner.ToLower().Equals(filter.ToLower())
                                                     && s.OrderAndPurchaseStatus.Equals("InCart"));
            var cart = new CartDetailView();
            cart.ItemsInCart = cartdata;
            return cart;
        }

        private static string getString(byte[] b)
        {
            return Encoding.UTF8.GetString(b);
        }

        private static byte[] Decrypt(byte[] data, byte[] key)
        {
            using (AesCryptoServiceProvider csp = new AesCryptoServiceProvider())
            {
                csp.KeySize = 256;
                csp.BlockSize = 128;
                csp.Key = key;
                csp.Padding = PaddingMode.PKCS7;
                csp.Mode = CipherMode.ECB;
                ICryptoTransform decrypter = csp.CreateDecryptor();
                return decrypter.TransformFinalBlock(data, 0, data.Length);
            }
        }

        public string DecryptCredentials(string credentials)
        {
            byte[] key = { 7, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5, 6, 7, 8,
                           1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5, 6, 7, 8 };
            var getEncryptedByte = Convert.FromBase64String(credentials);
            byte[] dec = Decrypt(getEncryptedByte, key);

            return getString(dec);
        }
    }
}