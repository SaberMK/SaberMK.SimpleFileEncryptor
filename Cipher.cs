using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SaberMK.SimpleFileEncryptor
{
    public static class Cipher
    {
        public static string Encrypt(string input, string key)
        {
            key = IncreaseKey(key);
            byte[] inputArray = Encoding.Default.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = Encoding.Default.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Encoding.Default.GetString(resultArray, 0, resultArray.Length);
        }
        public static string Decrypt(string input, string key)
        {
            key = IncreaseKey(key);
            byte[] inputArray = Encoding.Default.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = Encoding.Default.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Encoding.Default.GetString(resultArray);
        }

        private static string IncreaseKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(key);

            while (true)
            {
                key += key;
                if (key.Length > 16)
                    return key.Substring(0, 16);
            }
        }
    }
}
