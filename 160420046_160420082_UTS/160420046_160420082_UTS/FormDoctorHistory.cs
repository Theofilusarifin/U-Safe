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
    public partial class FormDoctorHistory : Form
    {
        public FormDoctorHistory()
        {
            InitializeComponent();
        }

        List<Checkup> HistoryDoctor = new List<Checkup>();

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
            dataGridView.Columns.Add("customer", "Customer");
            dataGridView.Columns.Add("doctor", "Doctor");
            dataGridView.Columns.Add("price", "Price"); // buat total_price
            dataGridView.Columns.Add("start", "Start");
            dataGridView.Columns.Add("finish", "Finish");

            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 142, 123);
            dataGridView.EnableHeadersVisualStyles = false;

            //Agar lebar kolom dapat menyesuaikan panjang / isi data
            dataGridView.Columns["customer"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["doctor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["start"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["finish"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


            // Agar user tidak bisa menambah baris maupun mengetik langsung di datagridview
            dataGridView.AllowUserToAddRows = false;
            dataGridView.ReadOnly = true;
        }

        private void TampilDataGrid()
        {
            //Kosongi isi datagridview
            dataGridView.Rows.Clear();

            // kalau list tidak kosong
            if (HistoryDoctor.Count > 0)
            {
                // untuk setiap checkup di history
                foreach (Checkup c in HistoryDoctor)
                {
                    // kalau selesai
                    if(c.Finished == 1)
                    {
                        dataGridView.Rows.Add(c.Customer.Username, c.Doctor.Username, c.TotalPrice, c.Start_date, c.Finish_date);
                    }
                }
            }
            else
            {
                dataGridView.DataSource = null;
            }
        }
        #endregion Methods

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDoctorHistory_Load(object sender, EventArgs e)
        {
            try
            {
                HistoryDoctor = Checkup.BacaData("doctor_username", FormMain.active_doctor.Username); ;

                FormatDataGrid();
                TampilDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);

            }
        }
    }
}
