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
            // Check arguments.
            if (plainText == null || plainText.Length <= 0) throw new ArgumentNullException("plainText");

            byte[] encrypted;

            aesObj.Padding = PaddingMode.PKCS7;

            // Create an encryptor to perform the stream transform.
            ICryptoTransform encryptor = aesObj.CreateEncryptor(aesObj.Key, aesObj.IV);

            // Create the streams used for encryption.
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        //Write all data to the stream.
                        swEncrypt.Write(plainText);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        public string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0) throw new ArgumentNullException("cipherText");

            if (Key == null || Key.Length <= 0) throw new ArgumentNullException("Key");

            if (IV == null || IV.Length <= 0) throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            aesObj.Padding = PaddingMode.PKCS7;

            // Create a decryptor to perform the stream transform.
            ICryptoTransform decryptor = aesObj.CreateDecryptor(Key, IV);

            // Create the streams used for decryption.
            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {

                        // Read the decrypted bytes from the decrypting stream
                        // and place them in a string.
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }

            return plaintext;
        }
    }
}
