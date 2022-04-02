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
    public class Hospital
    {
        #region Fields
        private int id;
        private string name;
        private string address;
        List<Doctor> listDoctor;
        #endregion

        #region Constructors
        public Hospital(int id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
            ListDoctor = new List<Doctor>();
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
        public string Address 
        {
            get => address; 
            set => address = value; 
        }

        public List<Doctor> ListDoctor
        {
            get => listDoctor;
            private set => listDoctor = value;
        }
        #endregion

        #region Methods

        public static void TambahData(Hospital h)
        {
            //string yang menampung sql query insert into
            string sql = "insert into hospitals (name, address) " +
                         "values ('" + h.Name + "', '" + h.Address + "')";

            //menjalankan perintah sql
            Koneksi.JalankanPerintahDML(sql);
        }

        public static void UbahData(Hospital h)
        {
            // Querry Insert
            string sql = "update hospitals set name = " + h.Name + ", address = " + h.Address + " where id = " + h.Id;
            Koneksi.JalankanPerintahDML(sql);
        }

        public static List<Hospital> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "select * from hospitals";
            //apabila kriteria tidak kosong
            if (kriteria != "") sql += " where " + kriteria + " like '%" + nilaiKriteria + "%'";

            DataTableReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Hospital> listHospital = new List<Hospital>();

            //kalau bisa/berhasil dibaca maka dimasukkin ke list pake constructors
            while (hasil.Read() == true)
            {
                Hospital hos = new Hospital(hasil.GetInt32(0), hasil.GetString(1), hasil.GetString(2));
                listHospital.Add(hos);
            }
            return listHospital;
        }

        public static Hospital AmbilDataPertama()
        {
            string sql = "select * from hospitals where id = 1";

            DataTableReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Hospital> listHospital = new List<Hospital>();

            //kalau bisa/berhasil dibaca maka dimasukkin ke list pake constructors
            while (hasil.Read() == true)
            {
                Hospital hos = new Hospital(hasil.GetInt32(0), hasil.GetString(1), hasil.GetString(2));
                listHospital.Add(hos);
            }
            return listHospital[0];
        }

        public static void HapusData(int id)
        {
            string sql = "delete from hospitals where id = " + id;

            Koneksi.JalankanPerintahDML(sql);
        }

        #endregion
    }
}
