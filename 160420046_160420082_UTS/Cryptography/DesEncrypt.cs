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
    public class DesEncrypt
    {
        public DES desObj;

        #region Constructors
        public DesEncrypt()
        {
            desObj = DES.Create();
            desObj.KeySize = 64;
        }

        public void Modify()
        {
            desObj.GenerateIV();
        }

        #endregion

        public byte[] EncryptTextToMemory(string Data)
        {
            try
            {
                // buat MemoryStream
                MemoryStream mStream = new MemoryStream();

                desObj.Padding = PaddingMode.PKCS7;

                // buat DES object baru
                DES DESalg = DES.Create();

                // buat CryptoStream memakai MemoryStream, passed key, dan initialization vector (IV)
                CryptoStream cStream = new CryptoStream(mStream, DESalg.CreateEncryptor(desObj.Key, desObj.IV), CryptoStreamMode.Write);

                // ubah passed string ke byte array.
                byte[] toEncrypt = new ASCIIEncoding().GetBytes(Data);

                // Write byte array ke crypto stream dan flush datanya
                cStream.Write(toEncrypt, 0, toEncrypt.Length);
                cStream.FlushFinalBlock();

                // ambil bytes array encrypted data dari MemoryStream
                byte[] encrypted = mStream.ToArray();

                // tutup stream
                cStream.Close();
                mStream.Close();

                // return encrypted buffer.
                return encrypted;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }

        public string DecryptTextFromMemory(byte[] Data, byte[] Key, byte[] IV)
        {
            try
            {
                // buat MemoryStream baru memakai passed array encrypted data
                MemoryStream msDecrypt = new MemoryStream(Data);

                desObj.Padding = PaddingMode.PKCS7;

                // buat DES object baru
                DES DESalg = DES.Create();

                // buat CryptoStream memakai MemoryStream, passed key dan initialization vector (IV)
                CryptoStream csDecrypt = new CryptoStream(msDecrypt, DESalg.CreateDecryptor(Key, IV), CryptoStreamMode.Read);

                // buat buffer untuk menampung decrypted data
                byte[] fromEncrypt = new byte[Data.Length];

                // Read decrypted data keluar dari crypto streamdan taruh ke temporary buffer
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                //ubah buffer jadi string dan return
                return new ASCIIEncoding().GetString(fromEncrypt);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }
    }
}
