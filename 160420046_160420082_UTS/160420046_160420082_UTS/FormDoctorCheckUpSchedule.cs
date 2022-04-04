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
    public partial class FormDoctorCheckUpSchedule : Form
    {
        public FormDoctorCheckUpSchedule()
        {
            InitializeComponent();
        }

        public static Checkup thisCheckup = new Checkup();

        List<Checkup> ListCheckupSchedule = new List<Checkup>();

        public static string patientName;

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
            if (ListCheckupSchedule.Count > 0)
            {
                // untuk setiap checkup di history
                foreach (Checkup c in ListCheckupSchedule)
                {
                    // kalau belum selesai
                    if (c.Finished == 0)
                    {
                        dataGridView.Rows.Add(c.Customer.Username, c.Doctor.Username, c.Start_date, "-");
                    }
                }
            }
            else
            {
                dataGridView.DataSource = null;
            }

            if (!dataGridView.Columns.Contains("btnPrescribeMed"))
            {
                //Button tambah ke keranjang
                DataGridViewButtonColumn bcolPrint = new DataGridViewButtonColumn();

                bcolPrint.Text = "Prescribe Medicine";
                bcolPrint.Name = "btnPrescribeMed";
                bcolPrint.UseColumnTextForButtonValue = true;
                bcolPrint.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView.Columns.Add(bcolPrint);
            }
        }
        #endregion Methods

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDoctorCheckUpSchedule_Load(object sender, EventArgs e)
        {
            try
            {
                ListCheckupSchedule = Checkup.BacaData("doctor_username", FormMain.active_doctor.Username);

                FormatDataGrid();
                TampilDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string patientName = dataGridView.CurrentRow.Cells["patient"].Value.ToString();
            string doctorName = dataGridView.CurrentRow.Cells["doctor"].Value.ToString();
            DateTime startDate = (DateTime)dataGridView.CurrentRow.Cells["start"].Value;

            if (e.ColumnIndex == dataGridView.Columns["btnPrescribeMed"].Index && e.RowIndex >= 0)
            {
                thisCheckup = Checkup.AmbilSatuData(patientName, doctorName, startDate);

                FormDoctorPrescribeMedicine formDoctorPrescribeMedicine = new FormDoctorPrescribeMedicine();
                formDoctorPrescribeMedicine.Owner = this;
                formDoctorPrescribeMedicine.ShowDialog();
            }
        }
    }
}
