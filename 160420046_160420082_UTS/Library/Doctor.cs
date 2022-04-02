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
    public class Doctor
    {
        #region Fields
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
        public Doctor(string username, string email, string phone_number, string password, byte[] profile_photo, string ktpNum, int balance, string availability, string bank_account, Hospital hospital)
        {
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
        public Doctor(string username, string email, string phone_number, string password, byte[] profile_photo, string ktpNum, Hospital hospital)
        {
            Username = username;
            Email = email;
            Phone_number = phone_number;
            Password = password;
            Profile_photo = profile_photo;
            KtpNum = ktpNum;
            Balance = 0;
            Availability = "true";
            Bank_account = null;
            Hospital = hospital;
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
        public static void TambahData(Doctor d)
        {
            string encPass = HashSalt.Encrypt(d.Password);

            byte[] hashedBytes = Convert.FromBase64String(encPass);
            byte[] salt = new byte[16];
            Array.Copy(hashedBytes, 0, salt, 0, 16);
            string saltString = Convert.ToBase64String(salt).Replace("=", "");

            string encMail = HashAes.Encrypt(saltString, d.Email);
            string encPhone = HashAes.Encrypt(saltString, d.Phone_number);
            string encKTPnum = HashAes.Encrypt(saltString, d.KtpNum);

            //string yang menampung sql query insert into
            string sql = "insert into doctors (username, email, phone_number, password, profile_photo," +
                         "KTPNum, balance, availability, bank_account, hospital_id) " +
                         "values ('" + d.username + "', '" + encMail + "', '" + encPhone + "', '" + encPass + "', @img, " +
                         "'" + encKTPnum + "', " + d.Balance + ", '" + d.Availability + "', " +
                         "'" + d.Bank_account + "', " + d.Hospital.Id + ")";

            //menjalankan perintah sql
            Koneksi.JalankanPerintahDMLFotoCreateUser(sql, d.Profile_photo);
        }

        public static void UbahData(Doctor d)
        {
            string encPass = HashSalt.Encrypt(d.Password);

            byte[] hashedBytes = Convert.FromBase64String(encPass);
            byte[] salt = new byte[16];
            Array.Copy(hashedBytes, 0, salt, 0, 16);
            string saltString = Convert.ToBase64String(salt).Replace("=", "");

            string encMail = HashAes.Encrypt(saltString, d.Email);
            string encPhone = HashAes.Encrypt(saltString, d.Phone_number);
            string encKTPnum = HashAes.Encrypt(saltString, d.KtpNum);

            // Querry Insert
            string sql = "update doctors set email = '" + encMail + "', " +
                         "phone_number = '" + encPhone + "', password = '" + encPass + "', " +
                         "profile_photo = @img, KTPnum = '" + encKTPnum + "', balance = " + d.Balance + ", " +
                         "availability = '" + d.Availability + "', bank_account = '" + d.Bank_account + "', " +
                         "hospital_id = " + d.Hospital.Id + " where username = '" + d.username + "'";

            Koneksi.JalankanPerintahDMLFoto(sql, d.Profile_photo);
        }

        public static List<Doctor> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "select * from doctors ";
            //apabila kriteria tidak kosong
            if (kriteria != "") sql += " where " + kriteria + " = '" + nilaiKriteria + "'";

            DataTableReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Doctor> listDoctor = new List<Doctor>();

            //kalau bisa/berhasil dibaca maka dimasukkin ke list pake constructors
            while (hasil.Read() == true)
            {
                byte[] hashedBytes = Convert.FromBase64String(hasil.GetValue(3).ToString());
                byte[] salt = new byte[16];
                Array.Copy(hashedBytes, 0, salt, 0, 16);
                string saltString = Convert.ToBase64String(salt).Replace("=", "");

                string plainMail = HashAes.Decrypt(saltString, hasil.GetValue(1).ToString());
                string plainPhone = HashAes.Decrypt(saltString, hasil.GetString(2).ToString());
                string plainKTPnum = HashAes.Decrypt(saltString, hasil.GetValue(5).ToString());


                byte[] img = ((byte[])hasil.GetValue(4));

                Hospital h = Hospital.AmbilData();

                Doctor doc = new Doctor(hasil.GetValue(0).ToString(), plainMail, plainPhone, hasil.GetValue(3).ToString(), img, plainKTPnum, hasil.GetInt32(6), hasil.GetString(7), hasil.GetString(8), h);

                listDoctor.Add(doc);
            }
            return listDoctor;
        }

        public static void HapusData(string username)
        {
            string sql = "delete from doctors where username = '" + username + "'";

            Koneksi.JalankanPerintahDML(sql);
        }

        public static void WithdrawBalance(int nominal, Doctor d)
        {
            string sql = "update doctors set balance = balance - " + nominal + " where username = '" + d.Username + "'";
            Koneksi.JalankanPerintahDML(sql);
        }
        #endregion
    }
}
