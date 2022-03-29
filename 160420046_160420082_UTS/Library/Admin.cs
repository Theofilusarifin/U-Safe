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


namespace Library
{
    class Admin
    {
        #region Fields
        private int id;
        private string username;
        private string email;
        private string phone_number;
        private string password;
        private byte[] profile_photo;
        private string ktpNum;
        #endregion

        #region Constructors
        public Admin(int id, string username, string email, string phone_number, string password, byte[] profile_photo, string ktpNum)
        {
            Id = id;
            Username = username;
            Email = email;
            Phone_number = phone_number;
            Password = password;
            Profile_photo = profile_photo;
            KTPNum = ktpNum;
        }
        #endregion

        #region Properties
        public int Id 
        { 
            get => id; 
            set => id = value; 
        }
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
        public static Boolean TambahData(Admin a)
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

            string encName = HashAes.Encrypt(saltString, a.Username.Replace("'", "\\'"));
            string encMail = HashAes.Encrypt(saltString, a.Email);

            string passAsli = HashSalt.Encrypt(a.Password);

            Bitmap originalImage = Steganography.CreateNonIndexedImage(ConvertByte(a.Profile_photo));
            var imageWithHiddenData = Steganography.MergeText(passAsli, originalImage);

            MemoryStream ms = new MemoryStream();
            imageWithHiddenData.Save(ms, ImageFormat.Bmp);
            byte[] bitmapData = ms.ToArray();

            //string yang menampung sql query insert into
            string sql = "insert into admins (username, email, phone_number, password, profile_photo, KTPNum) " +
                         "values ('" + encName + "', '" + encMail + "', '" + a.Phone_number + "', " +
                         "'" + encPass + "', @img, '" + a.KTPNum + "')";

            //menjalankan perintah sql
            int jumlahDitambah = Koneksi.JalankanPerintahDML(sql);
            if (jumlahDitambah == 0) return false;
            else return true;
        }

        public static Boolean UbahData(Admin a)
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

            string encName = HashAes.Encrypt(saltString, a.Username.Replace("'", "\\'"));
            string encMail = HashAes.Encrypt(saltString, a.Email);

            string passAsli = HashSalt.Encrypt(a.Password);

            Bitmap originalImage = Steganography.CreateNonIndexedImage(ConvertByte(a.Profile_photo));
            var imageWithHiddenData = Steganography.MergeText(passAsli, originalImage);

            MemoryStream ms = new MemoryStream();
            imageWithHiddenData.Save(ms, ImageFormat.Bmp);
            byte[] bitmapData = ms.ToArray();

            // Querry Insert
            string sql = "update admins set username = '" + encName + "', email = '" + encMail + "', " +
                         "phone_number = '" + a.Phone_number + "', password = '" + encPass + "', " +
                         "profile_photo = @img, KTPnum = '" + a.KTPNum + "' where id = " + a.Id;

            int jumlahDitambah = Koneksi.JalankanPerintahDML(sql);
            if (jumlahDitambah == 0) return false;
            else return true;
        }

        public static List<Admin> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "select * from admins";
            //apabila kriteria tidak kosong
            if (kriteria != "") sql += " where " + kriteria + " like '%" + nilaiKriteria + "%'";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Admin> listAdmin = new List<Admin>();

            //kalau bisa/berhasil dibaca maka dimasukkin ke list pake constructors
            while (hasil.Read() == true)
            {
                byte[] hashedBytes = Convert.FromBase64String(hasil.GetValue(3).ToString());
                byte[] salt = new byte[16];
                Array.Copy(hashedBytes, 0, salt, 0, 16);
                string saltString = Convert.ToBase64String(salt).Replace("=", "");

                string plainName = HashAes.Decrypt(saltString, hasil.GetValue(1).ToString());
                string plainMail = HashAes.Decrypt(saltString, hasil.GetValue(2).ToString());

                byte[] img = ((byte[])hasil.GetValue(4));

                Admin adm = new Admin(hasil.GetInt32(0), plainName, plainMail, hasil.GetString(3), hasil.GetString(4), img, hasil.GetString(6));

                listAdmin.Add(adm);
            }
            //hasil.Dispose();
            //hasil.Close();

            return listAdmin;
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
