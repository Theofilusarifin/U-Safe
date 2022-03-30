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
    public class Customer
    {
        #region Fields
        private int id;
        private string username;
        private string email;
        private string phone_number;
        private string password;
        private int balance;
        private byte[] profile_photo;
        private string ktpNum;
        #endregion

        #region Construtors
        public Customer(int id, string username, string email, string phone_number, string password, int balance, byte[] profile_photo, string ktpNum)
        {
            Id = id;
            Username = username;
            Email = email;
            Phone_number = phone_number;
            Password = password;
            Balance = balance;
            Profile_photo = profile_photo;
            KtpNum = ktpNum;
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
        public int Balance 
        { 
            get => balance; 
            set => balance = value; 
        }
        public byte[] Profile_photo 
        { 
            get => profile_photo; 
            set => profile_photo = value; 
        }
        public string KtpNum 
        { 
            get => ktpNum; 
            set => ktpNum = value; 
        }
        #endregion

        #region Methods
        public static Boolean TambahData(Customer c)
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

            string encName = HashAes.Encrypt(saltString, c.Username.Replace("'", "\\'"));
            string encMail = HashAes.Encrypt(saltString, c.Email);

            string passAsli = HashSalt.Encrypt(c.Password);

            Bitmap originalImage = Steganography.CreateNonIndexedImage(ConvertByte(c.Profile_photo));
            var imageWithHiddenData = Steganography.MergeText(passAsli, originalImage);

            MemoryStream ms = new MemoryStream();
            imageWithHiddenData.Save(ms, ImageFormat.Bmp);
            byte[] bitmapData = ms.ToArray();

            //string yang menampung sql query insert into
            string sql = "insert into customers (username, email, phone_number, password, balance, profile_photo, KTPNum) " +
                         "values ('" + encName + "', '" + encMail + "', '" + c.Phone_number + "', " +
                         "'" + encPass + "', " + c.Balance + ", @img, '" + c.KtpNum + "')";

            //menjalankan perintah sql
            int jumlahDitambah = Koneksi.JalankanPerintahDML(sql);
            if (jumlahDitambah == 0) return false;
            else return true;
        }

        public static Boolean UbahData(Customer c)
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

            string encName = HashAes.Encrypt(saltString, c.Username.Replace("'", "\\'"));
            string encMail = HashAes.Encrypt(saltString, c.Email);

            string passAsli = HashSalt.Encrypt(c.Password);

            Bitmap originalImage = Steganography.CreateNonIndexedImage(ConvertByte(c.Profile_photo));
            var imageWithHiddenData = Steganography.MergeText(passAsli, originalImage);

            MemoryStream ms = new MemoryStream();
            imageWithHiddenData.Save(ms, ImageFormat.Bmp);
            byte[] bitmapData = ms.ToArray();

            // Querry Insert
            string sql = "update customers set username = '" + encName + "', email = '" + encMail + "', " +
                         "phone_number = '" + c.Phone_number + "', password = '" + encPass + "', " +
                         "balance = " + c.Balance + "profile_photo = @img, KTPnum = '" + c.KtpNum + "' where id = " + c.Id;

            int jumlahDitambah = Koneksi.JalankanPerintahDML(sql);
            if (jumlahDitambah == 0) return false;
            else return true;
        }

        public static List<Customer> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "select * from customers";
            //apabila kriteria tidak kosong
            if (kriteria != "") sql += " where " + kriteria + " like '%" + nilaiKriteria + "%'";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Customer> listCustomer = new List<Customer>();

            //kalau bisa/berhasil dibaca maka dimasukkin ke list pake constructors
            while (hasil.Read() == true)
            {
                byte[] hashedBytes = Convert.FromBase64String(hasil.GetValue(4).ToString());
                byte[] salt = new byte[16];
                Array.Copy(hashedBytes, 0, salt, 0, 16);
                string saltString = Convert.ToBase64String(salt).Replace("=", "");

                string plainName = HashAes.Decrypt(saltString, hasil.GetValue(1).ToString());
                string plainMail = HashAes.Decrypt(saltString, hasil.GetValue(2).ToString());

                byte[] img = ((byte[])hasil.GetValue(6));

                Customer cus = new Customer(hasil.GetInt32(0), plainName, plainMail, hasil.GetString(3), hasil.GetString(4), hasil.GetInt32(5), img, hasil.GetString(7));

                listCustomer.Add(cus);
            }
            //hasil.Dispose();
            //hasil.Close();

            return listCustomer;
        }

        public static Boolean HapusData(int id)
        {
            string sql = "delete from customers where id = " + id;

            int jumlahDihapus = Koneksi.JalankanPerintahDML(sql);
            //Dicek apakah ada data yang berubah atau tidak
            if (jumlahDihapus == 0) return false;
            else return true;
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
