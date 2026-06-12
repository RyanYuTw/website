using System.Security.Cryptography;
using System.Text;

namespace MyWeb.Helpers
{
    public class CryptoHelper
    {
        private static readonly string Key = System.Web.Configuration.WebConfigurationManager.AppSettings["EncryptKey"];

        public static string Encrypt(string plainText)
        {
            using (MD5 hasher = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(Key + plainText);
                byte[] hashBytes = hasher.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        public static bool Verify(string plainText, string hash)
        {
            return Encrypt(plainText) == hash;
        }
    }
}
