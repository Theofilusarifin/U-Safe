using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cryptography;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data;

namespace Library
{
    public class Admin
    {
        #region Fields
        private string username;
        private string email;
        private string phone_number;
        private string password;
        private byte[] profile_photo;
        private string ktpNum;
        #endregion

        #region Constructors
        public Admin(string username, string email, string phone_number, string password, byte[] profile_photo, string ktpNum)
        {
            Username = username;
            Email = email;
            Phone_number = phone_number;
            Password = password;
            Profile_photo = profile_photo;
            KTPNum = ktpNum;
        }
        #endregion

        #region Properties
        public string Username 
        { 
            get => username; 
            set => username = value; 
        }
        public string Email 
        { 
            get => email; 
            set => email = value; 
        }
        public string Phone_number 
        { 
            get => phone_number; 
            set => phone_number = value; 
        }
        public string Password 
        { 
            get => password; 
            set => password = value; 
        }
        public byte[] Profile_photo 
        { 
            get => profile_photo; 
            set => profile_photo = value; 
        }
        public string KTPNum 
        { 
            get => ktpNum; 
            set => ktpNum = value; 
        }
        #endregion

        #region Methods
        public static void TambahData(Admin a)
        {
            Random random = new Random();
            var rString = "";
            for (var i = 0; i < 8; i++)
                rString += ((char)(random.Next(1, 26) + 64)).ToString().ToLower();

            string encPass = HashSalt.Encrypt(rString);

            byte[] hashedBytes = Convert.FromBase64String(encPass);
            byte[] salt = new byte[16];
            Array.Copy(hashedBytes, 0, salt, 0, 16);
            string saltString = Convert.ToBase64String(salt).Replace("=", "");

            string encMail = HashAes.Encrypt(saltString, a.Email);
            string encPhone = HashAes.Encrypt(saltString, a.Phone_number);
            string encKTPnum = HashAes.Encrypt(saltString, a.KTPNum);

            string passAsli = HashSalt.Encrypt(a.Password);

            Bitmap originalImage = Steganography.CreateNonIndexedImage(ConvertByte(a.Profile_photo));
            var imageWithHiddenData = Steganography.MergeText(passAsli, originalImage);

            MemoryStream ms = new MemoryStream();
            imageWithHiddenData.Save(ms, ImageFormat.Bmp);
            byte[] bitmapData = ms.ToArray();

            //string yang menampung sql query insert into
            string sql = "insert into admins (username, email, phone_number, password, profile_photo, KTPNum) " +
                         "values ('" + a.username + "', '" + encMail + "', '" + encPhone + "', " +
                         "'" + encPass + "', @img, '" + encKTPnum + "')";

            //menjalankan perintah sql
            Koneksi.JalankanPerintahDMLFotoCreateUser(sql, bitmapData);
        }

        public static void UbahData(Admin a)
        {
            Random random = new Random();
            var rString = "";
            for (var i = 0; i < 8; i++)
                rString += ((char)(random.Next(1, 26) + 64)).ToString().ToLower();

            string encPass = HashSalt.Encrypt(rString);

            byte[] hashedBytes = Convert.FromBase64String(encPass);
            byte[] salt = new byte[16];
            Array.Copy(hashedBytes, 0, salt, 0, 16);
            string saltString = Convert.ToBase64String(salt).Replace("=", "");

            string encMail = HashAes.Encrypt(saltString, a.Email);
            string encPhone = HashAes.Encrypt(saltString, a.Phone_number);
            string encKTPnum = HashAes.Encrypt(saltString, a.KTPNum);

            string passAsli = HashSalt.Encrypt(a.Password);

            Bitmap originalImage = Steganography.CreateNonIndexedImage(ConvertByte(a.Profile_photo));
            var imageWithHiddenData = Steganography.MergeText(passAsli, originalImage);

            MemoryStream ms = new MemoryStream();
            imageWithHiddenData.Save(ms, ImageFormat.Bmp);
            byte[] bitmapData = ms.ToArray();

            // Querry Insert
            string sql = "update admins set email = '" + encMail + "', " +
                         "phone_number = '" + encPhone + "', password = '" + encPass + "', " +
                         "profile_photo = @img, KTPnum = '" + encKTPnum + "' where username = '" + a.username + "'";

            Koneksi.JalankanPerintahDMLFoto(sql, bitmapData);
        }

        public static List<Admin> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "select * from admins";
            //apabila kriteria tidak kosong
            if (kriteria != "") sql += " where " + kriteria + " = '" + nilaiKriteria + "'";

            DataTableReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Admin> listAdmin = new List<Admin>();

            //kalau bisa/berhasil dibaca maka dimasukkin ke list pake constructors
            while (hasil.Read() == true)
            {
                byte[] hashedBytes = Convert.FromBase64String(hasil.GetValue(3).ToString());
                byte[] salt = new byte[16];
                Array.Copy(hashedBytes, 0, salt, 0, 16);
                string saltString = Convert.ToBase64String(salt).Replace("=", "");

                string plainMail = HashAes.Decrypt(saltString, hasil.GetValue(1).ToString());
                string plainPhone = HashAes.Decrypt(saltString, hasil.GetValue(1).ToString());
                string plainKTPnum = HashAes.Decrypt(saltString, hasil.GetValue(1).ToString());


                byte[] img = ((byte[])hasil.GetValue(4));

                Admin adm = new Admin(hasil.GetValue(0).ToString(), plainMail, plainPhone, hasil.GetString(3), img, plainKTPnum);

                listAdmin.Add(adm);
            }
            return listAdmin;
        }

        public static void HapusData(string username)
        {
            string sql = "delete from admins where username = '" + username +"'";

            Koneksi.JalankanPerintahDML(sql);
        }

        public static Image ConvertByte(byte[] img)
        {
            MemoryStream stream = new MemoryStream(img);
            Image result = Image.FromStream(stream);

            return result;
        }
        #endregion
    }
}
