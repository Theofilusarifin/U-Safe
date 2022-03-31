﻿using System;
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
        internal Customer Customer 
        {
            get => customer; 
            set => customer = value; 
        }
        internal Doctor Doctor 
        {
            get => doctor; 
            set => doctor = value; 
        }
        internal List<Checkup_Medicine> ListCheckupMedicine
        {
            get => listCheckupMedicine; 
            private set => listCheckupMedicine = value; 
        }
        #endregion

        #region Methods
        public static Boolean TambahData(Checkup c)
        {
            //string yang menampung sql query insert into
            string sql = "insert into checkups (price, total_price, finished, start_date, finish_date, customer_username, doctor_username) " +
                         "values (" + c.Price + ", " + c.TotalPrice + ", " + c.Finished + ", " + c.Start_date + ", " +
                         "" + c.Finish_date + ", " + c.Customer.Username + ", " + c.Doctor.Username + ")";

            //menjalankan perintah sql
            int jumlahDitambah = Koneksi.JalankanPerintahDML(sql);
            if (jumlahDitambah == 0) return false;
            else return true;
        }

        public static Boolean UbahData(Checkup c)
        {
            // Querry Insert
            string sql = "update checkups set price = " + c.Price + ", total_price = " + c.TotalPrice + ", " +
                         "finished = " + c.Finished + ", start_date = '" + c.Start_date + "', " +
                         "finish_date = " + c.Finish_date + ", customer_username = " + c.Customer.Username + ", " +
                         "doctor_username = " + c.Doctor.Username + " where id = " + c.Id;
            int jumlahDitambah = Koneksi.JalankanPerintahDML(sql);
            if (jumlahDitambah == 0) return false;
            else return true;
        }

        public static List<Checkup> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "select * from checkups ch " +
                         "inner join customers cu on ch.customer_username=cu.username " +
                         "inner join doctors d on ch.doctor_username=d.username " +
                         "inner join hospitals h on d.hospital_id=h.id";
            //apabila kriteria tidak kosong
            if (kriteria != "") sql += " where " + kriteria + " like '%" + nilaiKriteria + "%'";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Checkup> listCheckup = new List<Checkup>();

            //kalau bisa/berhasil dibaca maka dimasukkin ke list pake constructors
            while (hasil.Read() == true)
            {
                #region Decrypt
                // Decrypt customer
                byte[] cusHashedBytes = Convert.FromBase64String(hasil.GetString(12));
                byte[] cusSalt = new byte[16];
                Array.Copy(cusHashedBytes, 0, cusSalt, 0, 16);
                string cusSaltString = Convert.ToBase64String(cusSalt).Replace("=", "");

                string cusPlainName = HashAes.Decrypt(cusSaltString, hasil.GetString(9));
                string cusPlainMail = HashAes.Decrypt(cusSaltString, hasil.GetString(10));

                byte[] cusImg = ((byte[])hasil.GetValue(14));

                // Decrypt doctor
                byte[] docHashedBytes = Convert.FromBase64String(hasil.GetString(20));
                byte[] docSalt = new byte[16];
                Array.Copy(docHashedBytes, 0, docSalt, 0, 16);
                string docSaltString = Convert.ToBase64String(docSalt).Replace("=", "");

                string docPlainName = HashAes.Decrypt(docSaltString, hasil.GetString(17));
                string docPlainMail = HashAes.Decrypt(docSaltString, hasil.GetString(18));

                byte[] docImg = ((byte[])hasil.GetValue(21));
                #endregion Decrypt

                Hospital h = new Hospital(hasil.GetInt32(27), hasil.GetString(28), hasil.GetString(29));

                Doctor d = new Doctor(hasil.GetInt32(16), docPlainName, docPlainMail, hasil.GetString(19), hasil.GetString(20), docImg, hasil.GetString(22), hasil.GetInt32(23), hasil.GetString(24), hasil.GetString(25), h);

                Customer c = new Customer(hasil.GetInt32(8), cusPlainName, cusPlainMail, hasil.GetString(11), hasil.GetString(12), hasil.GetInt32(13), cusImg, hasil.GetString(15));

                Checkup chk = new Checkup(hasil.GetInt32(0), hasil.GetInt32(1), hasil.GetInt32(2), hasil.GetInt32(3), hasil.GetDateTime(4), hasil.GetDateTime(5), c, d);

                listCheckup.Add(chk);
            }
            //hasil.Dispose();
            //hasil.Close();

            return listCheckup;
        }

        public static Boolean HapusData(int id)
        {
            string sql = "delete from checkups where id = " + id;

            int jumlahDihapus = Koneksi.JalankanPerintahDML(sql);
            //Dicek apakah ada data yang berubah atau tidak
            if (jumlahDihapus == 0) return false;
            else return true;
        }

        #endregion
    }
}