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

        public static Boolean TambahData(Hospital h)
        {
            //string yang menampung sql query insert into
            string sql = "insert into hospitals (name, address) " +
                         "values ('" + h.Name + "', '" + h.Address + "')";

            //menjalankan perintah sql
            int jumlahDitambah = Koneksi.JalankanPerintahDML(sql);
            if (jumlahDitambah == 0) return false;
            else return true;
        }

        public static Boolean UbahData(Hospital h)
        {
            // Querry Insert
            string sql = "update hospitals set name = " + h.Name + ", address = " + h.Address + " where id = " + h.Id;
            int jumlahDitambah = Koneksi.JalankanPerintahDML(sql);
            if (jumlahDitambah == 0) return false;
            else return true;
        }

        public static List<Hospital> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "select * from hospitals";
            //apabila kriteria tidak kosong
            if (kriteria != "") sql += " where " + kriteria + " like '%" + nilaiKriteria + "%'";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Hospital> listHospital = new List<Hospital>();

            //kalau bisa/berhasil dibaca maka dimasukkin ke list pake constructors
            while (hasil.Read() == true)
            {
                Hospital hos = new Hospital(hasil.GetInt32(0), hasil.GetString(1), hasil.GetString(3));
                listHospital.Add(hos);
            }
            //hasil.Dispose();
            //hasil.Close();

            return listHospital;
        }

        public static Boolean HapusData(int id)
        {
            string sql = "delete from hospitals where id = " + id;

            int jumlahDihapus = Koneksi.JalankanPerintahDML(sql);
            //Dicek apakah ada data yang berubah atau tidak
            if (jumlahDihapus == 0) return false;
            else return true;
        }

        #endregion
    }
}
