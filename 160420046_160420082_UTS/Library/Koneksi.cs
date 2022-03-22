using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string strCon = "server=" + pServer + ";database=" + pDatabase + ";uid=" + pUsername + ";password=" + pPassword + ";SSL Mode=None" + // Tambahkan SSL Mode supaya tidak error SSL
                            ";MultipleActiveResultSets=true";

            KoneksiDB = new MySqlConnection();
            KoneksiDB.ConnectionString = strCon;

            // KoneksiDB yang dipakai adalah KoneksiDB yang sudah di set di construstor (atas)
            Connect();

        }

        public Koneksi()
        {
            //Buka konfigurasi App.Config
            Configuration myConf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Ambil section userSettings yang otomatis dibuat berdasarkan file .settings
            ConfigurationSectionGroup userSettings = myConf.SectionGroups["userSettings"];

            //Ambil bagian setting SIJualBeli.db
            var settingSection = userSettings.Sections["OnlineMart_Trivial.db"] as ClientSettingsSection;

            //Ambil tiap variabel setting
            string DbServer = settingSection.Settings.Get("DbServer").Value.ValueXml.InnerText;
            string DbName = settingSection.Settings.Get("DbName").Value.ValueXml.InnerText;
            string DbUsername = settingSection.Settings.Get("DbUsername").Value.ValueXml.InnerText;
            string DbPassword = settingSection.Settings.Get("DbPassword").Value.ValueXml.InnerText;

            string strCon = "server=" + DbServer + ";database=" + DbName + ";uid=" + DbUsername + ";password=" + DbPassword + ";SSL Mode=None"; // Tambahkan SSL Mode supaya tidak error SSL
            KoneksiDB = new MySqlConnection();

            KoneksiDB.ConnectionString = strCon;

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
        public void Connect()
        {
            //Jika connection sedang terbuka maka tutup dahulu
            if (KoneksiDB.State == System.Data.ConnectionState.Open)
            {
                KoneksiDB.Close();
            }
            KoneksiDB.Open();
        }

        public static MySqlDataReader JalankanPerintahQuery(string sql)
        {
            Koneksi koneksi = new Koneksi();
            MySqlCommand sqlCommand = new MySqlCommand(sql, koneksi.KoneksiDB);

            MySqlDataReader hasil = sqlCommand.ExecuteReader();

            return hasil;
        }

        public static int JalankanPerintahDML(string sql)
        {
            Koneksi koneksi = new Koneksi();
            MySqlCommand sqlCommand = new MySqlCommand(sql, koneksi.KoneksiDB);

            //Gunakan ExecuteNonQuerry untuk menjalankan perintah DML (Insert/Update/Delete)
            int hasil = 0;
            hasil = sqlCommand.ExecuteNonQuery();

            return hasil;
        }

        #endregion Methods
    }
}
