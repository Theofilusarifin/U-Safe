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
    public partial class FormPatientBookCheckUp : Form
    {
        public FormPatientBookCheckUp()
        {
            InitializeComponent();
        }

        List<Checkup> ListCheckup = new List<Checkup>();

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
        private void buttonTambah_MouseEnter(object sender, EventArgs e)
        {
            buttonTambah.BackgroundImage = Properties.Resources.Button_Hover;
        }
        private void buttonTambah_MouseLeave(object sender, EventArgs e)
        {
            buttonTambah.BackgroundImage = Properties.Resources.Button_Leave;
        }
        #endregion

        #region Methods
        private void FormatDataGrid()
        {
            //Kosongi semua kolom di datagridview
            dataGridView.Columns.Clear();

            //Menambah kolom di datagridview
            dataGridView.Columns.Add("patient", "Patient");
            dataGridView.Columns.Add("doctor", "Doctor");
            dataGridView.Columns.Add("start", "Start");
            dataGridView.Columns.Add("finish", "Finish");

            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 142, 123);
            dataGridView.EnableHeadersVisualStyles = false;

            //Agar lebar kolom dapat menyesuaikan panjang / isi data
            dataGridView.Columns["patient"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["doctor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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
            if (ListCheckup.Count > 0)
            {
                // untuk setiap checkup di history
                foreach (Checkup c in ListCheckup)
                {
                    // kalau belum selesai
                    if (c.Finished == 0)
                    {
                        dataGridView.Rows.Add(c.Customer.Username, c.Doctor.Username, c.Start_date, c.Finish_date);
                    }
                }
            }
            else
            {
                dataGridView.DataSource = null;
            }
        }
        #endregion Methods

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormPatientAddCheckUp formPatientAddCheckUp = new FormPatientAddCheckUp();
            formPatientAddCheckUp.Owner = this;
            formPatientAddCheckUp.ShowDialog();
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormPatientBookCheckUp_Load(object sender, EventArgs e)
        {
            try
            {
                ListCheckup = Checkup.BacaData("customer_username", FormMain.active_patient.Username);

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
