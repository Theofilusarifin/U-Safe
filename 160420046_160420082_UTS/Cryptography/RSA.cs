using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// System tambahan
using System.Security.Cryptography;

namespace Cryptography
{
    public class RSA
    {
        // method untuk encrypt data dengan RSA
        public byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                //buat instansi RSACryptoServiceProvider baru
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {

                    //Import RSA Key information (hanya perlu public key information)
                    RSA.ImportParameters(RSAKeyInfo);

                    //Encrypt byte array dan spesifikasi OAEP padding 
                    //OAEP padding is only available on Microsoft Windows XP or later
                    encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        }

        // method untuk decrypt data dengan RSA
        public byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                //buat instansi RSACryptoServiceProvider baru
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    //Import RSA Key information (perlu private key information)
                    RSA.ImportParameters(RSAKeyInfo);

                    //Decrypt byte array dan spesifikasi OAEP padding
                    //OAEP padding is only available on Microsoft Windows XP or later
                    decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());

                return null;
            }
        }
    }
}
