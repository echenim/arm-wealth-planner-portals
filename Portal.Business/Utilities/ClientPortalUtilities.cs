using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using Portal.Business.Contracts;

namespace Portal.Business.Utilities
{
    public class ClientPortalUtilities
    {
        private readonly IArmOneServiceConfigManager _configSettingManager;

        public ClientPortalUtilities(IArmOneServiceConfigManager configManager)
        {
            _configSettingManager = configManager;
        }

        public string ARMOneToken()
        {
            HttpClient webclient = new HttpClient();

            SecureCredentials decrypt = new SecureCredentials();

            var uname = _configSettingManager.ArmOneUsername;
            var pass = _configSettingManager.ArmOnePassword;
            var Url = _configSettingManager.ArmOneToken;

            var Username = decrypt.DecryptCredentials(uname);
            var Password = decrypt.DecryptCredentials(pass);
            var EmailAddress = _configSettingManager.ArmOneEmail;

            Uri mUrl = new Uri(Url);
            string Token = "";

            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("Username", Username);
            data.Add("Password", Password);
            data.Add("EmailAddress", EmailAddress);

            var MySerializedObject = JsonConvert.SerializeObject(data);

            var content = new StringContent(MySerializedObject, Encoding.UTF8, "application/json");

            var task = Task.Run(async () =>
            {
                return await webclient.PostAsync(mUrl, content);
            });

            var response = task.Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                response.EnsureSuccessStatusCode();
                var task1 = Task.Run(async () =>
                {
                    return await response.Content.ReadAsStringAsync();
                });

                var rep = task1.Result;

                Dictionary<string, object> aoresult = JsonConvert.DeserializeObject<Dictionary<string, object>>(rep);

                aoresult.TryGetValue("CustomerReference", out object MK);
                Token = MK.ToString();
            }
            return Token;
        }
    }

    public class SecureCredentials
    {
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

    public static class ManageExceptions
    {
        public static void ProcessError(Exception ex, string contentRootPath)
        {
            var errorFile = Path.Combine(contentRootPath, "logs", "applog-" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
            using (StreamWriter sw = (File.Exists(errorFile)) ? File.AppendText(errorFile) : File.CreateText(errorFile))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd h:mm:tt ") + ex.ToString());
            }
        }
    }
}
