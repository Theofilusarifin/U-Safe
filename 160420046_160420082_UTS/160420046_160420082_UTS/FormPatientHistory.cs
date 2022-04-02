﻿using System;
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
    public partial class FormPatientHistoryCheckUp : Form
    {
        public FormPatientHistoryCheckUp()
        {
            InitializeComponent();
        }

        List<Checkup> HistoryPatient = new List<Checkup>();
        public static Checkup detailCheckup;

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
            dataGridView.Columns.Add("price", "Price"); // dipakai untuk total_price
            dataGridView.Columns.Add("start", "Start");
            dataGridView.Columns.Add("finish", "Finish");

            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 142, 123);
            dataGridView.EnableHeadersVisualStyles = false;

            //Agar lebar kolom dapat menyesuaikan panjang / isi data
            dataGridView.Columns["patient"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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
            if (HistoryPatient.Count > 0)
            {
                // untuk setiap checkup di history
                foreach (Checkup c in HistoryPatient)
                {
                    // kalau selesai
                    if (c.Finished == 1)
                    {
                        dataGridView.Rows.Add(c.Customer.Username, c.Doctor.Username, c.TotalPrice, c.Start_date, c.Finish_date);
                    }
                }
            }
            else
            {
                dataGridView.DataSource = null;
            }

            if (!dataGridView.Columns.Contains("btnCheckupDetail"))
            {
                //Button tambah ke keranjang
                DataGridViewButtonColumn bcolCheckupDetail = new DataGridViewButtonColumn();

                bcolCheckupDetail.Text = "Lihat Detail";
                bcolCheckupDetail.Name = "btnCheckupDetail";
                bcolCheckupDetail.UseColumnTextForButtonValue = true;
                bcolCheckupDetail.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView.Columns.Add(bcolCheckupDetail);
            }
        }
        #endregion Methods

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormPatientHistoryCheckUp_Load(object sender, EventArgs e)
        {
            try
            {
                HistoryPatient = Checkup.BacaData("customer_username", FormMain.active_patient.Username);

                FormatDataGrid();
                TampilDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Error. Pesan kesalahan : " + ex.Message, "Error");
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string patientName = dataGridView.CurrentRow.Cells["patient"].Value.ToString();

                //Kalau button Add diklik
                if (e.ColumnIndex == dataGridView.Columns["btnCheckupDetail"].Index && e.RowIndex >= 0)
                {
                    detailCheckup = Checkup.AmbilData(patientName);
                    // masuk ke detail checkup
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Error. Pesan kesalahan : " + ex.Message, "Kesalahan");
            }
        }
    }
}
