using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Portal.Services
{
    public static class Utilities
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
}
