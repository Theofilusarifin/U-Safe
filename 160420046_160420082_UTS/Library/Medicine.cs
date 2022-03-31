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
    public class Medicine
    {
        #region Fields
        private int id;
        private string name;
        private int price;
        private int stock;
        List<Checkup_Medicine> checkup_medicine;
        #endregion

        #region Constructors
        public Medicine(int id, string name, int price, int stock)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
            Checkup_medicine = new List<Checkup_Medicine>();
        }
        #endregion

        #region Properties
        public int Id
        {
            get => id;
            set => id = value;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public int Price
        {
            get => price;
            set => price = value;
        }
        public int Stock
        {
            get => stock;
            set => stock = value;
        }
        public List<Checkup_Medicine> Checkup_medicine
        {
            get => checkup_medicine;
            private set => checkup_medicine = value;
        }
        #endregion

        #region Methods

        public static void TambahData(Medicine m)
        {
            //string yang menampung sql query insert into
            string sql = "insert into medicines (name, price, stock) " +
                         "values ('" + m.Name + "', " + m.Price + ", " + m.Stock + ")";

            //menjalankan perintah sql
            Koneksi.JalankanPerintahDML(sql);
        }

        public static void UbahData(Medicine m)
        {
            // Querry Insert
            string sql = "update medicines set name = " + m.Name + ", price = " + m.Price + ", stock = " + m.Stock + " where id = " + m.Id;
            Koneksi.JalankanPerintahDML(sql);
        }

        public static List<Medicine> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "select * from medicines";
            //apabila kriteria tidak kosong
            if (kriteria != "") sql += " where " + kriteria + " like '%" + nilaiKriteria + "%'";

            DataTableReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Medicine> listMedicine = new List<Medicine>();

            //kalau bisa/berhasil dibaca maka dimasukkin ke list pake constructors
            while (hasil.Read() == true)
            {
                Medicine med = new Medicine(hasil.GetInt32(0), hasil.GetString(1), hasil.GetInt32(2), hasil.GetInt32(3));

                listMedicine.Add(med);
            }
            //hasil.Dispose();
            //hasil.Close();

            return listMedicine;
        }

        public static void HapusData(int id)
        {
            string sql = "delete from medicines where id = " + id;

            Koneksi.JalankanPerintahDML(sql);
        }

        #endregion
    }
}
