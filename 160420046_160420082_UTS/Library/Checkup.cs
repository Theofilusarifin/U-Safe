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
        private int finished;
        private DateTime start_date;
        private DateTime finish_date;
        private Customer customer;
        private Doctor doctor;
        List<Checkup_Medicine> listCheckupMedicine;
        #endregion

        #region Constructors
        public Checkup(int id, int price, int finished, DateTime start_date, DateTime finish_date, Customer customer, Doctor doctor)
        {
            Id = id;
            Price = price;
            Finished = finished;
            Start_date = start_date;
            Finish_date = finish_date;
            Customer = customer;
            Doctor = doctor;
            ListCheckupMedicine = new List<Checkup_Medicine>();
        }

        public Checkup(int price, int finished, DateTime start_date, DateTime finish_date, Customer customer, Doctor doctor)
        {
            Price = price;
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
            Finished = 0;
            Start_date = start_date;
            Finish_date = DateTime.MaxValue;
            Customer = customer;
            Doctor = doctor;
            ListCheckupMedicine = new List<Checkup_Medicine>();
        }

        public Checkup()
        {
            Price = 20000;
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
            string sql = "insert into checkups (price, finished, start_date, finish_date, customer_username, doctor_username) " +
                         "values (" + c.Price  + ", " + c.Finished + ", '" + c.Start_date.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                         "'" + c.Finish_date.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + c.Customer.Username + "', '" + c.Doctor.Username + "')";

            //menjalankan perintah sql
            Koneksi.JalankanPerintahDML(sql);
        }

        public static void UbahData(Checkup c)
        {
            // Querry Insert
            string sql = "update checkups set price = " + c.Price + ", finished = " + c.Finished + ", " +
                         "start_date = '" + c.Start_date.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                         "finish_date = '" + c.Finish_date.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                         "customer_username = '" + c.Customer.Username + "', " + "doctor_username = '" + c.Doctor.Username + "' " +
                         "where id = " + c.Id;
            Koneksi.JalankanPerintahDML(sql);
        }

        public static List<Checkup> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "select * from checkups ch " +
                         "inner join customers cu on ch.customer_username=cu.username " +
                         "inner join doctors d on ch.doctor_username=d.username";
            //apabila kriteria tidak kosong
            if (kriteria != "") sql += " where " + kriteria + " like '%" + nilaiKriteria + "%'";

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

        public static void HapusData(int id)
        {
            string sql = "delete from checkups where id = " + id;

            Koneksi.JalankanPerintahDML(sql);
        }

        public static Checkup AmbilData(string username)
        {
            string sql = "select * from checkups ch " +
                         "inner join customers cu on ch.customer_username=cu.username " +
                         "inner join doctors d on ch.doctor_username=d.username " +
                         "inner join hospitals h on d.hospital_id=h.id " +
                         "where cu.username = '" + username + "'";

            DataTableReader hasil = Koneksi.JalankanPerintahQuery(sql);

            Checkup ch = null;

            while (hasil.Read())
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

                Hospital h = new Hospital(hasil.GetInt32(24), hasil.GetString(25), hasil.GetString(26));

                Doctor d = new Doctor(hasil.GetString(14), docPlainMail, docPlainPhone, hasil.GetString(17), docImg, docPlainKTPnum, hasil.GetInt32(20), hasil.GetString(21), hasil.GetString(22), h);

                Customer c = new Customer(hasil.GetString(7), cusPlainMail, cusPlainPhone, hasil.GetString(10), hasil.GetInt32(11), cusImg, cusPlainKTPnum);

                ch = new Checkup(hasil.GetInt32(0), hasil.GetInt32(1), int.Parse(hasil.GetValue(2).ToString()), hasil.GetDateTime(3), hasil.GetDateTime(4), c, d);
            }
            return ch;
        }

        public static Checkup AmbilSatuData(string patientName, string doctorName, DateTime startDate)
        {
            string sql = "select * from checkups ch " +
                         "inner join customers cu on ch.customer_username=cu.username " +
                         "inner join doctors d on ch.doctor_username=d.username " +
                         "where cu.username = '" + patientName + "' " +
                         "and d.username = '" + doctorName + "' " +
                         "and ch.start_date = '" + startDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";

            DataTableReader hasil = Koneksi.JalankanPerintahQuery(sql);

            Checkup ch = null;

            while (hasil.Read())
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

                ch = new Checkup(hasil.GetInt32(0), hasil.GetInt32(1), int.Parse(hasil.GetValue(2).ToString()), hasil.GetDateTime(3), hasil.GetDateTime(4), c, d);
            }
            return ch;
        }

        public static void FinishCheckup(Checkup c)
        {
            // Querry Insert
            string sql = "update checkups set finished = " + 1 + ", finish_date = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where id = " + c.Id;
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
                file.WriteLine("Total Price = " + ch.Price.ToString("#,###"));

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
