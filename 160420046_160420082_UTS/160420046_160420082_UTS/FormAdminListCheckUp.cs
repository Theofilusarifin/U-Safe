using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Tambahkan using reference
using Library;
using Cryptography;

namespace _160420046_160420082_UTS
{
    public partial class FormAdminListCheckUp : Form
    {
        public List<Checkup> listCheckUp = new List<Checkup>();
        public FormAdminListCheckUp()
        {
            InitializeComponent();
        }

        #region No Tick Constrols
        //Optimized Controls(No Tick)
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        #endregion

        #region Desain Button
        private void buttonClose_MouseEnter(object sender, EventArgs e)
        {
            buttonClose.BackgroundImage = Properties.Resources.Button_Hover;
        }
        private void buttonClose_MouseLeave(object sender, EventArgs e)
        {
            buttonClose.BackgroundImage = Properties.Resources.Button_Leave;
        }
        #endregion

        #region Methods
        private void FormatDataGrid()
        {
            //Kosongi semua kolom di datagridview
            dataGridView.Columns.Clear();

            //Menambah kolom di datagridview
            dataGridView.Columns.Add("id", "Id");
            dataGridView.Columns.Add("total_price", "Total Price");
            dataGridView.Columns.Add("finished", "Status");
            dataGridView.Columns.Add("start_date", "Start Date");
            dataGridView.Columns.Add("finish_date", "Finish Date");
            dataGridView.Columns.Add("customer_username", "Customer");
            dataGridView.Columns.Add("doctor_username", "Doctor");


            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 142, 123);
            dataGridView.EnableHeadersVisualStyles = false;

            //Agar lebar kolom dapat menyesuaikan panjang / isi data
            dataGridView.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["total_price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["finished"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["start_date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["finish_date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["customer_username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["doctor_username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;



            // Agar user tidak bisa menambah baris maupun mengetik langsung di datagridview
            dataGridView.AllowUserToAddRows = false;
            dataGridView.ReadOnly = true;
        }

        private void TampilDataGrid()
        {
            try
            {
                //Kosongi isi datagridview
                dataGridView.Rows.Clear();

                if (listCheckUp.Count > 0)
                {
                    foreach (Checkup c in listCheckUp)
                    {
                        string status = "";
                        if (c.Finished == 1) status = "Finished"; // Kalau finished = 1, status sudah selesai
                        else if (c.Finished == 0) status = "Not Finished"; // Kalau finished = 0, status belum selesai
                        dataGridView.Rows.Add(c.Id, c.TotalPrice, status, c.Start_date, c.Finish_date, c.Customer.Username, c.Doctor.Username);
                    }
                }
                else
                {
                    dataGridView.DataSource = null;
                }

                if (!dataGridView.Columns.Contains("btnPrint"))
                {
                    //Button tambah ke keranjang
                    DataGridViewButtonColumn bcolPrint = new DataGridViewButtonColumn();

                    bcolPrint.Text = "Print";
                    bcolPrint.Name = "btnPrint";
                    bcolPrint.UseColumnTextForButtonValue = true;
                    bcolPrint.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dataGridView.Columns.Add(bcolPrint);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }
        #endregion

        private void FormAdminListCheckUp_Load(object sender, EventArgs e)
        {
            try
            {
                // Panggil Method untuk menambah kolom pada datagridview
                FormatDataGrid();

                // Tampilkan semua data
                listCheckUp = Checkup.BacaData("", "");

                //Tampilkan semua isi list di datagridview (Panggil method TampilDataGridView)
                TampilDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string patientName = dataGridView.CurrentRow.Cells["customer_username"].Value.ToString();
                string doctorName = dataGridView.CurrentRow.Cells["doctor_username"].Value.ToString();
                string start = dataGridView.CurrentRow.Cells["start_date"].Value.ToString();

                //Kalau button Add diklik
                if (e.ColumnIndex == dataGridView.Columns["btnPrint"].Index && e.RowIndex >= 0)
                {
                    Checkup ch = Checkup.AmbilSatuData(patientName, doctorName, start);
                    ch.CetakCheckup("Checkup " + ch.Id +".txt");
                    MessageBox.Show("Checkup printed successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            try
            {
                Checkup.CetakDaftarOrder("", "", "daftarCheckup.txt");
                MessageBox.Show("Seluruh Order berhasil dicetak!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }
    }
}
