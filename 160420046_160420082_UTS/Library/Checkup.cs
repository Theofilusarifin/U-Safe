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
    public class Checkup
    {
        #region Fields
        private int id;
        private int price;
        private int totalPrice;
        private int finished;
        private DateTime start_date;
        private DateTime finish_date;
        private Customer customer;
        private Doctor doctor;
        List<Checkup_Medicine> listCheckupMedicine;
        #endregion

        #region Constructors
        public Checkup(int id, int price, int totalPrice, int finished, DateTime start_date, DateTime finish_date, Customer customer, Doctor doctor)
        {
            Id = id;
            Price = price;
            TotalPrice = totalPrice;
            Finished = finished;
            Start_date = start_date;
            Finish_date = finish_date;
            Customer = customer;
            Doctor = doctor;
            ListCheckupMedicine = new List<Checkup_Medicine>();
        }

        public Checkup(int price, int totalPrice, int finished, DateTime start_date, DateTime finish_date, Customer customer, Doctor doctor)
        {
            Price = price;
            TotalPrice = totalPrice;
            Finished = finished;
            Start_date = start_date;
            Finish_date = finish_date;
            Customer = customer;
            Doctor = doctor;
            ListCheckupMedicine = new List<Checkup_Medicine>();
        }

        public Checkup(DateTime start_date, Customer customer, Doctor doctor)
        {
            Price = 20000;
            TotalPrice = 0;
            Finished = 0;
            Start_date = start_date;
            Customer = customer;
            Doctor = doctor;
            ListCheckupMedicine = new List<Checkup_Medicine>();
        }

        public Checkup()
        {
            Price = 20000;
            TotalPrice = 0;
            Finished = 0;
            ListCheckupMedicine = new List<Checkup_Medicine>();
        }
        #endregion

        #region Properties
        public int Id 
        {
            get => id; 
            set => id = value; 
        }
        public int Price 
        {
            get => price; 
            set => price = value; 
        }
        public int TotalPrice 
        {
            get => totalPrice;
            set => totalPrice = value; 
        }
        public int Finished 
        {
            get => finished; 
            set => finished = value;
        }
        public DateTime Start_date 
        {
            get => start_date; 
            set => start_date = value; 
        }
        public DateTime Finish_date 
        {
            get => finish_date; 
            set => finish_date = value; 
        }
        public Customer Customer 
        {
            get => customer; 
            set => customer = value; 
        }
        public Doctor Doctor 
        {
            get => doctor; 
            set => doctor = value; 
        }
        public List<Checkup_Medicine> ListCheckupMedicine
        {
            get => listCheckupMedicine; 
            private set => listCheckupMedicine = value; 
        }
        #endregion

        #region Methods
        public static void TambahData(Checkup c)
        {
            //string yang menampung sql query insert into
            string sql = "insert into checkups (price, total_price, finished, start_date, finish_date, customer_username, doctor_username) " +
                         "values (" + c.Price + ", " + c.TotalPrice + ", " + c.Finished + ", " + c.Start_date + ", " +
                         "" + c.Finish_date + ", " + c.Customer.Username + ", " + c.Doctor.Username + ")";

            //menjalankan perintah sql
            Koneksi.JalankanPerintahDML(sql);
        }

        public static void UbahData(Checkup c)
        {
            // Querry Insert
            string sql = "update checkups set price = " + c.Price + ", total_price = " + c.TotalPrice + ", " +
                         "finished = " + c.Finished + ", start_date = '" + c.Start_date + "', " +
                         "finish_date = " + c.Finish_date + ", customer_username = " + c.Customer.Username + ", " +
                         "doctor_username = " + c.Doctor.Username + " where id = " + c.Id;
            Koneksi.JalankanPerintahDML(sql);
        }

        public static List<Checkup> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "select * from checkups ch " +
                         "inner join customers cu on ch.customer_username=cu.username " +
                         "inner join doctors d on ch.doctor_username=d.username " +
                         "inner join hospitals h on d.hospital_id=h.id";
            //apabila kriteria tidak kosong
            if (kriteria != "") sql += " where " + kriteria + " like '%" + nilaiKriteria + "%'";

            DataTableReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Checkup> listCheckup = new List<Checkup>();

            //kalau bisa/berhasil dibaca maka dimasukkin ke list pake constructors
            while (hasil.Read() == true)
            {
                #region Decrypt
                // Decrypt customer
                byte[] cusHashedBytes = Convert.FromBase64String(hasil.GetString(11));
                byte[] cusSalt = new byte[16];
                Array.Copy(cusHashedBytes, 0, cusSalt, 0, 16);
                string cusSaltString = Convert.ToBase64String(cusSalt).Replace("=", "");

                string cusPlainName = HashAes.Decrypt(cusSaltString, hasil.GetString(8));
                string cusPlainMail = HashAes.Decrypt(cusSaltString, hasil.GetString(9));

                byte[] cusImg = ((byte[])hasil.GetValue(13));

                // Decrypt doctor
                byte[] docHashedBytes = Convert.FromBase64String(hasil.GetString(18));
                byte[] docSalt = new byte[16];
                Array.Copy(docHashedBytes, 0, docSalt, 0, 16);
                string docSaltString = Convert.ToBase64String(docSalt).Replace("=", "");

                string docPlainName = HashAes.Decrypt(docSaltString, hasil.GetString(15));
                string docPlainMail = HashAes.Decrypt(docSaltString, hasil.GetString(16));

                byte[] docImg = ((byte[])hasil.GetValue(19));
                #endregion Decrypt

                Hospital h = new Hospital(hasil.GetInt32(25), hasil.GetString(26), hasil.GetString(27));

                Doctor d = new Doctor(docPlainName, docPlainMail, hasil.GetString(17), hasil.GetString(18), docImg, hasil.GetString(20), hasil.GetInt32(21), hasil.GetString(22), hasil.GetString(23), h);

                Customer c = new Customer(cusPlainName, cusPlainMail, hasil.GetString(10), hasil.GetString(11), hasil.GetInt32(12), cusImg, hasil.GetString(14));

                Checkup chk = new Checkup(hasil.GetInt32(0), hasil.GetInt32(1), hasil.GetInt32(2), hasil.GetInt32(3), hasil.GetDateTime(4), hasil.GetDateTime(5), c, d);

                listCheckup.Add(chk);
            }
            return listCheckup;
        }

        public static void HapusData(int id)
        {
            string sql = "delete from checkups where id = " + id;

            Koneksi.JalankanPerintahDML(sql);
        }

        public static Checkup AmbilData(string name)
        {
            string sql = "select * from checkups ch " +
                         "inner join customers cu on ch.customer_username=cu.username " +
                         "inner join doctors d on ch.doctor_username=d.username " +
                         "inner join hospitals h on d.hospital_id=h.id " +
                         "where cu.username = " + name;

            DataTableReader hasil = Koneksi.JalankanPerintahQuery(sql);

            Checkup ch = null;

            while (hasil.Read())
            {
                #region Decrypt
                // Decrypt customer
                byte[] cusHashedBytes = Convert.FromBase64String(hasil.GetString(11));
                byte[] cusSalt = new byte[16];
                Array.Copy(cusHashedBytes, 0, cusSalt, 0, 16);
                string cusSaltString = Convert.ToBase64String(cusSalt).Replace("=", "");

                string cusPlainName = HashAes.Decrypt(cusSaltString, hasil.GetString(8));
                string cusPlainMail = HashAes.Decrypt(cusSaltString, hasil.GetString(9));

                byte[] cusImg = ((byte[])hasil.GetValue(13));

                // Decrypt doctor
                byte[] docHashedBytes = Convert.FromBase64String(hasil.GetString(18));
                byte[] docSalt = new byte[16];
                Array.Copy(docHashedBytes, 0, docSalt, 0, 16);
                string docSaltString = Convert.ToBase64String(docSalt).Replace("=", "");

                string docPlainName = HashAes.Decrypt(docSaltString, hasil.GetString(15));
                string docPlainMail = HashAes.Decrypt(docSaltString, hasil.GetString(16));

                byte[] docImg = ((byte[])hasil.GetValue(19));
                #endregion Decrypt

                Hospital h = new Hospital(hasil.GetInt32(25), hasil.GetString(26), hasil.GetString(27));

                Doctor d = new Doctor(docPlainName, docPlainMail, hasil.GetString(17), hasil.GetString(18), docImg, hasil.GetString(20), hasil.GetInt32(21), hasil.GetString(22), hasil.GetString(23), h);

                Customer c = new Customer(cusPlainName, cusPlainMail, hasil.GetString(10), hasil.GetString(11), hasil.GetInt32(12), cusImg, hasil.GetString(14));

                ch = new Checkup(hasil.GetInt32(0), hasil.GetInt32(1), hasil.GetInt32(2), hasil.GetInt32(3), hasil.GetDateTime(4), hasil.GetDateTime(5), c, d);
            }
            return ch;
        }

        public static Checkup AmbilSatuData(string patientName, string doctorName, string startDate)
        {
            string sql = "select * from checkups ch " +
                         "inner join customers cu on ch.customer_username=cu.username " +
                         "inner join doctors d on ch.doctor_username=d.username " +
                         "inner join hospitals h on d.hospital_id=h.id " +
                         "where cu.username = " + patientName + " " +
                         "and d.username = " + doctorName + " " +
                         "and ch.start_date = " + startDate;

            DataTableReader hasil = Koneksi.JalankanPerintahQuery(sql);

            Checkup ch = null;

            while (hasil.Read())
            {
                #region Decrypt
                // Decrypt customer
                byte[] cusHashedBytes = Convert.FromBase64String(hasil.GetString(11));
                byte[] cusSalt = new byte[16];
                Array.Copy(cusHashedBytes, 0, cusSalt, 0, 16);
                string cusSaltString = Convert.ToBase64String(cusSalt).Replace("=", "");

                string cusPlainName = HashAes.Decrypt(cusSaltString, hasil.GetString(8));
                string cusPlainMail = HashAes.Decrypt(cusSaltString, hasil.GetString(9));

                byte[] cusImg = ((byte[])hasil.GetValue(13));

                // Decrypt doctor
                byte[] docHashedBytes = Convert.FromBase64String(hasil.GetString(18));
                byte[] docSalt = new byte[16];
                Array.Copy(docHashedBytes, 0, docSalt, 0, 16);
                string docSaltString = Convert.ToBase64String(docSalt).Replace("=", "");

                string docPlainName = HashAes.Decrypt(docSaltString, hasil.GetString(15));
                string docPlainMail = HashAes.Decrypt(docSaltString, hasil.GetString(16));

                byte[] docImg = ((byte[])hasil.GetValue(19));
                #endregion Decrypt

                Hospital h = new Hospital(hasil.GetInt32(25), hasil.GetString(26), hasil.GetString(27));

                Doctor d = new Doctor(docPlainName, docPlainMail, hasil.GetString(17), hasil.GetString(18), docImg, hasil.GetString(20), hasil.GetInt32(21), hasil.GetString(22), hasil.GetString(23), h);

                Customer c = new Customer(cusPlainName, cusPlainMail, hasil.GetString(10), hasil.GetString(11), hasil.GetInt32(12), cusImg, hasil.GetString(14));

                ch = new Checkup(hasil.GetInt32(0), hasil.GetInt32(1), hasil.GetInt32(2), hasil.GetInt32(3), hasil.GetDateTime(4), hasil.GetDateTime(5), c, d);
            }
            return ch;
        }

        public static void FinishCheckup(Checkup c)
        {
            // Querry Insert
            string sql = "update checkups set finished = " + 1 + "finish_date = " + DateTime.Now + " where id = " + c.Id;
            Koneksi.JalankanPerintahDML(sql);
        }

        public void CetakCheckup(string namaFile)
        {
            StreamWriter file = new StreamWriter(namaFile);
            char pemisah = '-';
            file.WriteLine(""); //Cetak 1 baris kosong
            file.WriteLine("U-Safe");
            file.WriteLine("No. Checkup = " + Id);
            file.WriteLine("Patient = " + Customer.Username);
            file.WriteLine("Doctor = " + Doctor.Username);
            file.WriteLine("Start Date = " + Start_date);
            file.WriteLine("Finish Date = " + Finish_date);
            file.WriteLine("Price = " + Price.ToString("#,###"));

            file.WriteLine("-".PadRight(50, pemisah));
            file.WriteLine("Terima kasih!");
            file.WriteLine("=".PadRight(50, '='));
            file.Close();

            Cetak c = new Cetak(namaFile, 10, 9, 9, 9);
            c.CetakKePrinter();
        }

        public static void CetakDaftarOrder(string kriteria, string nilai, string namaFile)
        {
            List<Checkup> listData = Checkup.BacaData(kriteria, nilai);
            StreamWriter file = new StreamWriter(namaFile);
            char pemisah = '-';
            file.WriteLine(""); //Cetak 1 baris kosong
            file.WriteLine("Online Mart - Trivial");
            foreach (Checkup ch in listData)
            {
                file.WriteLine("No Checkup = " + ch.Id);
                file.WriteLine("Patient = " + ch.Customer.Username);
                file.WriteLine("Doctor = " + ch.Doctor.Username);
                file.WriteLine("Start Date = " + ch.Start_date);
                file.WriteLine("Finish Date = " + ch.Finish_date);
                file.WriteLine("Total Price = " + ch.TotalPrice.ToString("#,###"));

                file.WriteLine("-".PadRight(50, pemisah));
                file.WriteLine("Terima kasih!");
                file.WriteLine("=".PadRight(50, '='));
            }
            file.Close();

            Cetak c = new Cetak(namaFile, 10, 9, 9, 9);
            c.CetakKePrinter();
        }
        #endregion
    }
}
