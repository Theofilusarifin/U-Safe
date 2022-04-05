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
    public class Checkup_Medicine
    {
        #region Fields
        private Checkup checkup;
        private Medicine medicine;
        private int amount;
        private int price;
        #endregion

        #region Constructors
        public Checkup_Medicine(Checkup checkup, Medicine medicine, int amount, int price)
        {
            Checkup = checkup;
            Medicine = medicine;
            Amount = amount;
            Price = price;
        }
        #endregion

        #region Properties
        public Checkup Checkup 
        { 
            get => checkup; 
            set => checkup = value; 
        }
        public Medicine Medicine 
        { 
            get => medicine;
            set => medicine = value; 
        }
        public int Amount
        {
            get => amount;
            set => amount = value;
        }
        public int Price
        {
            get => price;
            set => price = value;
        }
        #endregion

        #region Methods
        public static void TambahData(Checkup_Medicine cm)
        {
            //string yang menampung sql query insert into
            string sql = "insert into checkup_medicine (checkup_id, medicine_id, amount, price) " +
                         "values (" + cm.Checkup.Id + ", " + cm.Medicine.Id + ", " + cm.Amount + ", " + cm.Price + ")";

            //menjalankan perintah sql
            Koneksi.JalankanPerintahDML(sql);
        }

        public static List<Checkup_Medicine> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "select * from checkup_medicine cm " +
                         "inner join checkups ch on cm.checkup_id = ch.id " +
                         "inner join customers cu on ch.customer_username = cu.username " +
                         "inner join doctors d on ch.doctor_username = d.username " +
                         "inner join medicines m on cm.medicine_id = m.id";
            //apabila kriteria tidak kosong
            if (kriteria != "") sql += " where " + kriteria + " like '%" + nilaiKriteria + "%'";

            DataTableReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Checkup_Medicine> listCheckupMed = new List<Checkup_Medicine>();

            //kalau bisa/berhasil dibaca maka dimasukkin ke list pake constructors
            while (hasil.Read() == true)
            {
                #region Decrypt
                // Decrypt customer
                byte[] cusHashedBytes = Convert.FromBase64String(hasil.GetValue(14).ToString());
                byte[] cusSalt = new byte[16];
                Array.Copy(cusHashedBytes, 0, cusSalt, 0, 16);
                string cusSaltString = Convert.ToBase64String(cusSalt).Replace("=", "");

                string cusPlainMail = HashAes.Decrypt(cusSaltString, hasil.GetValue(12).ToString());
                string cusPlainPhone = HashAes.Decrypt(cusSaltString, hasil.GetString(13));
                string cusPlainKTPnum = HashAes.Decrypt(cusSaltString, hasil.GetString(17));

                byte[] cusImg = ((byte[])hasil.GetValue(16));

                // Decrypt doctor
                byte[] docHashedBytes = Convert.FromBase64String(hasil.GetValue(21).ToString());
                byte[] docSalt = new byte[16];
                Array.Copy(docHashedBytes, 0, docSalt, 0, 16);
                string docSaltString = Convert.ToBase64String(docSalt).Replace("=", "");

                string docPlainMail = HashAes.Decrypt(docSaltString, hasil.GetValue(19).ToString());
                string docPlainPhone = HashAes.Decrypt(docSaltString, hasil.GetString(20).ToString());
                string docPlainKTPnum = HashAes.Decrypt(docSaltString, hasil.GetValue(23).ToString());

                byte[] docImg = ((byte[])hasil.GetValue(22));
                #endregion Decrypt

                Medicine m = new Medicine(hasil.GetInt32(28), hasil.GetString(29), hasil.GetInt32(30), hasil.GetInt32(31));

                Hospital h = Hospital.AmbilDataPertama();

                Doctor d = new Doctor(hasil.GetString(18), docPlainMail, docPlainPhone, hasil.GetString(21), docImg, docPlainKTPnum, hasil.GetInt32(24), hasil.GetString(25), hasil.GetString(26), h);

                Customer cu = new Customer(hasil.GetString(11), cusPlainMail, cusPlainPhone, hasil.GetString(14), hasil.GetInt32(15), cusImg, cusPlainKTPnum);
                
                Checkup ch = new Checkup(hasil.GetInt32(4), hasil.GetInt32(5), int.Parse(hasil.GetValue(6).ToString()), hasil.GetDateTime(7), hasil.GetDateTime(8), cu, d);

                Checkup_Medicine cm = new Checkup_Medicine(ch, m, hasil.GetInt32(2), hasil.GetInt32(3));

                listCheckupMed.Add(cm);
            }
            return listCheckupMed;
        }
        #endregion
    }
}
