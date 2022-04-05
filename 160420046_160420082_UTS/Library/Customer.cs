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
    public class Customer
    {
        #region Fields
        private string username;
        private string email;
        private string phone_number;
        private string password;
        private int balance;
        private byte[] profile_photo;
        private string ktpNum;
        #endregion

        #region Construtors
        public Customer(string username, string email, string phone_number, string password, int balance, byte[] profile_photo, string ktpNum)
        {
            Username = username;
            Email = email;
            Phone_number = phone_number;
            Password = password;
            Balance = balance;
            Profile_photo = profile_photo;
            KtpNum = ktpNum;
        }
        public Customer(string username, string email, string phone_number, string password, byte[] profile_photo, string ktpNum)
        {
            Username = username;
            Email = email;
            Phone_number = phone_number;
            Password = password;
            Balance = 0;
            Profile_photo = profile_photo;
            KtpNum = ktpNum;
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
        public static void TambahData(Customer c)
        {
            string encPass = HashSalt.Encrypt(c.Password);

            byte[] hashedBytes = Convert.FromBase64String(encPass);
            byte[] salt = new byte[16];
            Array.Copy(hashedBytes, 0, salt, 0, 16);
            string saltString = Convert.ToBase64String(salt).Replace("=", "");

            string encMail = HashAes.Encrypt(saltString, c.Email);
            string encPhone = HashAes.Encrypt(saltString, c.Phone_number);
            string encKTPnum = HashAes.Encrypt(saltString, c.KtpNum);

            //string yang menampung sql query insert into
            string sql = "insert into customers (username, email, phone_number, password, balance, profile_photo, KTPNum) " +
                         "values ('" + c.username + "', '" + encMail + "', '" + encPhone + "', " +
                         "'" + encPass + "', " + c.Balance + ", @img, '" + encKTPnum + "')";

            //menjalankan perintah sql
            Koneksi.JalankanPerintahDMLFotoCreateUser(sql, c.Profile_photo);
        }

        public static void UbahData(Customer c)
        {
            string encPass = HashSalt.Encrypt(c.Password);

            byte[] hashedBytes = Convert.FromBase64String(encPass);
            byte[] salt = new byte[16];
            Array.Copy(hashedBytes, 0, salt, 0, 16);
            string saltString = Convert.ToBase64String(salt).Replace("=", "");

            string encMail = HashAes.Encrypt(saltString, c.Email);
            string encPhone = HashAes.Encrypt(saltString, c.Phone_number);
            string encKTPnum = HashAes.Encrypt(saltString, c.KtpNum);

            // Querry Update
            string sql = "update customers set email = '" + encMail + "', " +
                         "phone_number = '" + encPhone + "', password = '" + encPass + "', " +
                         "profile_photo = @img, KTPnum = '" + encKTPnum + "' where username = '" + c.Username +"'";

            Koneksi.JalankanPerintahDMLFoto(sql, c.Profile_photo);
        }

        public static List<Customer> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "select * from customers";
            //apabila kriteria tidak kosong
            if (kriteria != "") sql += " where " + kriteria + " = '" + nilaiKriteria + "'";

            DataTableReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Customer> listCustomer = new List<Customer>();

            //kalau bisa/berhasil dibaca maka dimasukkin ke list pake constructors
            while (hasil.Read() == true)
            {
                byte[] hashedBytes = Convert.FromBase64String(hasil.GetValue(3).ToString());
                byte[] salt = new byte[16];
                Array.Copy(hashedBytes, 0, salt, 0, 16);
                string saltString = Convert.ToBase64String(salt).Replace("=", "");

                string plainMail = HashAes.Decrypt(saltString, hasil.GetValue(1).ToString());
                string plainPhone = HashAes.Decrypt(saltString, hasil.GetString(2));
                string plainKTPnum = HashAes.Decrypt(saltString, hasil.GetString(6));

                byte[] img = ((byte[])hasil.GetValue(5));

                Customer cus = new Customer(hasil.GetValue(0).ToString(), plainMail, plainPhone, hasil.GetString(3), hasil.GetInt32(4), img, plainKTPnum);

                listCustomer.Add(cus);
            }

            return listCustomer;
        }

        public static void HapusData(string username)
        {
            string sql = "delete from customers where username = " + username;

            Koneksi.JalankanPerintahDML(sql);
        }

        public static Customer AmbilData(string username)
        {
            string sql = "select * from customers where username = '" + username + "'";

            DataTableReader hasil = Koneksi.JalankanPerintahQuery(sql);

            Customer cus = null;

            while (hasil.Read())
            {
                byte[] hashedBytes = Convert.FromBase64String(hasil.GetValue(3).ToString());
                byte[] salt = new byte[16];
                Array.Copy(hashedBytes, 0, salt, 0, 16);
                string saltString = Convert.ToBase64String(salt).Replace("=", "");

                string plainMail = HashAes.Decrypt(saltString, hasil.GetValue(1).ToString());
                string plainPhone = HashAes.Decrypt(saltString, hasil.GetString(2));
                string plainKTPnum = HashAes.Decrypt(saltString, hasil.GetString(6));

                byte[] img = ((byte[])hasil.GetValue(5));

                cus = new Customer(hasil.GetValue(0).ToString(), plainMail, plainPhone, hasil.GetString(3), hasil.GetInt32(4), img, plainKTPnum);

            }
            return cus;
        }

        public static List<string> AmbilNama()
        {
            string sql = "select distinct(username) from customers";

            DataTableReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<string> listUsername = new List<string>();

            while (hasil.Read())
            {
                string username = hasil.GetString(0);

                listUsername.Add(username);
            }
            return listUsername;
        }

        public static void TopUpBalance(int nominal, Customer c)
        {
            string sql = "update customers set balance = balance + " + nominal + " where username = '" + c.Username + "'";
            Koneksi.JalankanPerintahDML(sql);
        }

        public static void UpdateBalance(Checkup ch)
        {
            string sql = "update customers set balance = balance - " + ch.Price + " where username = '" + ch.Customer.Username + "'";
            Koneksi.JalankanPerintahDML(sql);
        }

        public static List<Checkup> SearchClashingSchedule(DateTime upperLimit, DateTime lowerLimit, string customerUsername)
        {
            string sql = "select * from checkups ch " +
                         "inner join customers cu on ch.customer_username = cu.username " +
                         "inner join doctors d on ch.doctor_username = d.username " +
                         "where ch.start_date < '" + upperLimit.ToString("yyyy-MM-dd HH:mm:ss") + "' " +
                         "and ch.start_date > '" + lowerLimit.ToString("yyyy-MM-dd HH:mm:ss") + "' " +
                         "and ch.customer_username = '" + customerUsername + "' " +
                         "and ch.finished = 0";

            DataTableReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Checkup> listCheckup = new List<Checkup>();

            //kalau bisa/berhasil dibaca maka dimasukkin ke list pake constructors
            while (hasil.Read() == true)
            {
                #region Decrypt
                // Decrypt customer
                byte[] cusHashedBytes = Convert.FromBase64String(hasil.GetValue(10).ToString());
                byte[] cusSalt = new byte[16];
                Array.Copy(cusHashedBytes, 0, cusSalt, 0, 16);
                string cusSaltString = Convert.ToBase64String(cusSalt).Replace("=", "");

                string cusPlainMail = HashAes.Decrypt(cusSaltString, hasil.GetValue(8).ToString());
                string cusPlainPhone = HashAes.Decrypt(cusSaltString, hasil.GetString(9));
                string cusPlainKTPnum = HashAes.Decrypt(cusSaltString, hasil.GetString(13));

                byte[] cusImg = ((byte[])hasil.GetValue(12));

                // Decrypt doctor
                byte[] docHashedBytes = Convert.FromBase64String(hasil.GetValue(17).ToString());
                byte[] docSalt = new byte[16];
                Array.Copy(docHashedBytes, 0, docSalt, 0, 16);
                string docSaltString = Convert.ToBase64String(docSalt).Replace("=", "");

                string docPlainMail = HashAes.Decrypt(docSaltString, hasil.GetValue(15).ToString());
                string docPlainPhone = HashAes.Decrypt(docSaltString, hasil.GetString(16).ToString());
                string docPlainKTPnum = HashAes.Decrypt(docSaltString, hasil.GetValue(19).ToString());

                byte[] docImg = ((byte[])hasil.GetValue(18));
                #endregion Decrypt

                Hospital h = Hospital.AmbilDataPertama();

                Doctor d = new Doctor(hasil.GetString(14), docPlainMail, docPlainPhone, hasil.GetString(17), docImg, docPlainKTPnum, hasil.GetInt32(20), hasil.GetString(21), hasil.GetString(22), h);

                Customer c = new Customer(hasil.GetString(7), cusPlainMail, cusPlainPhone, hasil.GetString(10), hasil.GetInt32(11), cusImg, cusPlainKTPnum);

                Checkup chk = new Checkup(hasil.GetInt32(0), hasil.GetInt32(1), int.Parse(hasil.GetValue(2).ToString()), hasil.GetDateTime(3), hasil.GetDateTime(4), c, d);

                listCheckup.Add(chk);
            }
            return listCheckup;
        }
        #endregion
    }
}
