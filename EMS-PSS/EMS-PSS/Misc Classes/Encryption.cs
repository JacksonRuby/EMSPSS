
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace EMS_PSS
{
    public static class Encryption
    {
        public static bool encryptText;                 //bool for encrypting or not
        private static string key = "a1b2c3d4e5g6";     //key for encrypting

        /*
        *   FUNCTION    : enc()
        *   DESCRIPTION : Encrypts the text.
        *   PARAMETERS  :
        *       string text
        */
        public static string enc(string text)
        {
            string encText = "";
            byte[] textBytes = Encoding.Unicode.GetBytes(text);

            using (Aes encrypt = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encrypt.Key = pdb.GetBytes(32);
                encrypt.IV = pdb.GetBytes(16);

                using (MemoryStream memStream = new MemoryStream())
                {
                    using (CryptoStream cryptStream = new CryptoStream(memStream, encrypt.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptStream.Write(textBytes, 0, textBytes.Length);
                        cryptStream.Close();
                    }
                    encText = Convert.ToBase64String(memStream.ToArray());
                }
            }

            return encText;
        }

        /*
        *   FUNCTION    : dec()
        *   DESCRIPTION : Decrypts the text.
        *   PARAMETERS  :
        *       string text
        */
        public static string dec(string text)
        {
            string decText = "";
            text = text.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(text);
            using (Aes encrypt = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encrypt.Key = pdb.GetBytes(32);
                encrypt.IV = pdb.GetBytes(16);
                using (MemoryStream memStream = new MemoryStream())
                {
                    using (CryptoStream cryptStream = new CryptoStream(memStream, encrypt.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cryptStream.Write(cipherBytes, 0, cipherBytes.Length);
                        cryptStream.Close();
                    }
                    decText = Encoding.Unicode.GetString(memStream.ToArray());
                }
            }

            return decText;
        }
    }
}
