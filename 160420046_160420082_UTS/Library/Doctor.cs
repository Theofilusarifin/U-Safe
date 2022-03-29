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
    class Doctor
    {
        #region Fields
        private int id;
        private string username;
        private string email;
        private string phone_number;
        private string password;
        private byte[] profile_photo;
        private string ktpNum;
        private int balance;
        private string availability;
        private string bank_account;
        private Hospital hospital;
        #endregion

        #region Constructors
        public Doctor(int id, string username, string email, string phone_number, string password, byte[] profile_photo, string ktpNum, int balance, string availability, string bank_account, Hospital hospital)
        {
            Id = id;
            Username = username;
            Email = email;
            Phone_number = phone_number;
            Password = password;
            Profile_photo = profile_photo;
            KtpNum = ktpNum;
            Balance = balance;
            Availability = availability;
            Bank_account = bank_account;
            Hospital = hospital;
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
        public string KtpNum 
        {
            get => ktpNum; 
            set => ktpNum = value; 
        }
        public int Balance 
        {
            get => balance; 
            set => balance = value; 
        }
        public string Availability 
        {
            get => availability; 
            set => availability = value; 
        }
        public string Bank_account 
        {
            get => bank_account; 
            set => bank_account = value; 
        }
        internal Hospital Hospital 
        {
            get => hospital; 
            set => hospital = value; 
        }
        #endregion

        #region Methods
        public static Boolean TambahData(Doctor d)
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

            string encName = HashAes.Encrypt(saltString, d.Username.Replace("'", "\\'"));
            string encMail = HashAes.Encrypt(saltString, d.Email);

            string passAsli = HashSalt.Encrypt(d.Password);

            Bitmap originalImage = Steganography.CreateNonIndexedImage(ConvertByte(d.Profile_photo));
            var imageWithHiddenData = Steganography.MergeText(passAsli, originalImage);

            MemoryStream ms = new MemoryStream();
            imageWithHiddenData.Save(ms, ImageFormat.Bmp);
            byte[] bitmapData = ms.ToArray();

            //string yang menampung sql query insert into
            string sql = "insert into customers (username, email, phone_number, password, profile_photo," +
                         "KTPNum, balance, availability, bank_account, hospital_id) " +
                         "values ('" + encName + "', '" + encMail + "', '" + d.Phone_number + "', '" + encPass + "', @img, " +
                         "'" + d.KtpNum + "', " + d.Balance + ", '" + d.Availability + "', " +
                         "'" + d.Bank_account + "', " + d.Hospital.Id + ")";

            //menjalankan perintah sql
            int jumlahDitambah = Koneksi.JalankanPerintahDML(sql);
            if (jumlahDitambah == 0) return false;
            else return true;
        }

        public static Boolean UbahData(Doctor d)
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

            string encName = HashAes.Encrypt(saltString, d.Username.Replace("'", "\\'"));
            string encMail = HashAes.Encrypt(saltString, d.Email);

            string passAsli = HashSalt.Encrypt(d.Password);

            Bitmap originalImage = Steganography.CreateNonIndexedImage(ConvertByte(d.Profile_photo));
            var imageWithHiddenData = Steganography.MergeText(passAsli, originalImage);

            MemoryStream ms = new MemoryStream();
            imageWithHiddenData.Save(ms, ImageFormat.Bmp);
            byte[] bitmapData = ms.ToArray();

            // Querry Insert
            string sql = "update customers set username = '" + encName + "', email = '" + encMail + "', " +
                         "phone_number = '" + d.Phone_number + "', password = '" + encPass + "', " +
                         "profile_photo = @img, KTPnum = '" + d.KtpNum + "', balance = " + d.Balance + ", " +
                         "availability = '" + d.Availability + "', bank_account = '" + d.Bank_account + "', " +
                         "hospital_id = " + d.Hospital.Id + " where id = " + d.Id;

            int jumlahDitambah = Koneksi.JalankanPerintahDML(sql);
            if (jumlahDitambah == 0) return false;
            else return true;
        }

        public static List<Doctor> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "select * from customers c inner join hospitals h on c.hospital_id=d.id";
            //apabila kriteria tidak kosong
            if (kriteria != "") sql += " where " + kriteria + " like '%" + nilaiKriteria + "%'";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Doctor> listDoctor = new List<Doctor>();

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

                Hospital h = new Hospital(hasil.GetInt32(11), hasil.GetString(12), hasil.GetString(13));

                Doctor doc = new Doctor(hasil.GetInt32(0), plainName, plainMail, hasil.GetString(4), hasil.GetValue(5).ToString(), img, hasil.GetString(7), hasil.GetInt32(8), hasil.GetString(9), hasil.GetString(10), h);

                listDoctor.Add(doc);
            }
            //hasil.Dispose();
            //hasil.Close();

            return listDoctor;
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
