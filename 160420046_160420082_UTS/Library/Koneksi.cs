using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

// Tambahkan ini untuk dapat memanggil private data member
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Library
{
    public class Koneksi
    {
        private MySqlConnection koneksiDB;

        #region Constructors
        public Koneksi(string pServer, string pDatabase, string pUsername, string pPassword)
        {
            string strConnectionString = "";
            if (pPassword != "")
            {
                strConnectionString = "Server=" + pServer + ";Database=" +
                pDatabase + ";Uid=" + pUsername + ";Pwd=" + pPassword + ";";
            }
            else
            {
                strConnectionString = "Server=" + pServer + ";Database=" +
                pDatabase + ";Uid=" + pUsername + ";";
            }
            this.KoneksiDB = koneksiDB;
            strConnectionString += "Minimumpoolsize=10;Maximumpoolsize=1000;charset=utf8";

            this.KoneksiDB = new MySqlConnection();
            this.KoneksiDB.ConnectionString = strConnectionString;

            this.Connect();

            UpdateAppConfig(strConnectionString);

        }

        public Koneksi()
        {
            KoneksiDB = new MySqlConnection();

            //set connection string sesuai yang ada di App.Config
            KoneksiDB.ConnectionString = ConfigurationManager.ConnectionStrings["namakoneksi"].ConnectionString;

            //panggil method Connect
            Connect();
        }
        #endregion

        #region Properties
        public MySqlConnection KoneksiDB
        {
            get => koneksiDB;
            private set => koneksiDB = value; //Dibuat private untuk alasan keaamanan 
        }
        #endregion

        #region Methods

        public void UpdateAppConfig(string con)
        {
            //Buka konfigurasi App.Config
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //Set App.Config pada section nama koneksi yang telah dibuat sebelumnya sesuai paramaeter
            config.ConnectionStrings.ConnectionStrings["namakoneksi"].ConnectionString = con;

            //simpan App.Config yang telah di update
            config.Save(ConfigurationSaveMode.Modified, true);

            //Reload App.Config dengan pengaturan yang baru
            ConfigurationManager.RefreshSection("connectionStrings");
        }
        public void Connect()
        {
            //Jika connection sedang terbuka maka tutup dahulu
            if (KoneksiDB.State == System.Data.ConnectionState.Open)
            {
                KoneksiDB.Close();
            }
            KoneksiDB.Open();
        }

        public static DataTableReader JalankanPerintahQuery(string pSql)
        {
            Koneksi k = new Koneksi();

            MySqlCommand c = new MySqlCommand(pSql, k.KoneksiDB);

            var dataReader = c.ExecuteReader();
            var dataTable = new DataTable();
            dataTable.Load(dataReader);

            k.KoneksiDB.Close();
            return dataTable.CreateDataReader();
        }

        public static void JalankanPerintahDML(string sql)
        {
            Koneksi koneksi = new Koneksi();
            MySqlCommand sqlCommand = new MySqlCommand(sql, koneksi.KoneksiDB);

            //Gunakan ExecuteNonQuerry untuk menjalankan perintah DML (Insert/Update/Delete)
            sqlCommand.ExecuteNonQuery();

            koneksi.KoneksiDB.Close();
        }

        public static void JalankanPerintahDMLFoto(string pSql, byte[] img)
        {
            Koneksi koneksi = new Koneksi();
            koneksi.Connect(); //bisa di skip karena di cons sudah connect

            //buat mysqlcommand
            MySqlCommand c = new MySqlCommand(pSql, koneksi.KoneksiDB);
            c.Parameters.Add("@img", MySqlDbType.LongBlob);

            c.Parameters["@img"].Value = img;
            //gunakan ExecuteNonQuery untuk menjalankan perintah INSERT/UPDATE/DELETE
            c.ExecuteNonQuery();

            koneksi.KoneksiDB.Close();
        }

        public static void JalankanPerintahDMLFotoCreateUser(string pSql, byte[] img)
        {
            Koneksi koneksi = new Koneksi("localhost", "u-safe", "root", "");
            koneksi.Connect(); //bisa di skip karena di cons sudah connect

            //buat mysqlcommand
            MySqlCommand c = new MySqlCommand(pSql, koneksi.KoneksiDB);
            c.Parameters.Add("@img", MySqlDbType.LongBlob);

            c.Parameters["@img"].Value = img;
            //gunakan ExecuteNonQuery untuk menjalankan perintah INSERT/UPDATE/DELETE
            c.ExecuteNonQuery();

            koneksi.KoneksiDB.Close();
        }

        #endregion Methods
    }
}
