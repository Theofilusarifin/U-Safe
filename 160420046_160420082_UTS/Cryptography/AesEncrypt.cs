using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// System tambahan
using System.IO;
using System.Security.Cryptography;

namespace Cryptography
{
    public class AesEncrypt
    {
        public Aes aesObj;

        #region Constructors
        public AesEncrypt(string password)
        {
            aesObj = Aes.Create();
            aesObj.IV = Convert.FromBase64String("T5rVOW6Lp/rTSMBkFZ6VEg==");
            aesObj.BlockSize = 128;
            aesObj.KeySize = 128;
        }

        public void Modify(int keySize, bool generateIV)
        {
            aesObj.BlockSize = 128;
            aesObj.KeySize = keySize;
            if (generateIV)
                aesObj.GenerateIV();
            else
                aesObj.IV = aesObj.IV;
        }

        #endregion

        public byte[] EncryptStringToBytes_Aes(string plainText)
        {
            // cek arguments
            if (plainText == null || plainText.Length <= 0) throw new ArgumentNullException("plainText");

            byte[] encrypted;

            aesObj.Padding = PaddingMode.PKCS7;

            // buat encryptor untuk melakukan stream transform
            ICryptoTransform encryptor = aesObj.CreateEncryptor(aesObj.Key, aesObj.IV);

            // buat stream yang akan dipakai untuk encryption
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        //Write semua data ke stream
                        swEncrypt.Write(plainText);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }

            // return encrypted bytes dari memory stream
            return encrypted;
        }

        public string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // cek arguments
            if (cipherText == null || cipherText.Length <= 0) throw new ArgumentNullException("cipherText");

            if (Key == null || Key.Length <= 0) throw new ArgumentNullException("Key");

            if (IV == null || IV.Length <= 0) throw new ArgumentNullException("IV");

            // buat string untuk menampung decrypted text
            string plaintext = null;

            aesObj.Padding = PaddingMode.PKCS7;

            // buat decryptor untuk melakukan stream transform
            ICryptoTransform decryptor = aesObj.CreateDecryptor(Key, IV);

            // buat streams yang dipakai untuk decryption
            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {

                        // Read decrypted bytes dari decrypting stream dan taruh mereka ke string
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }

            return plaintext;
        }
    }
}
