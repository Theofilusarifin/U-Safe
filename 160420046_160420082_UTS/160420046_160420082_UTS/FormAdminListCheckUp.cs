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
    public partial class FormAdminListCheckUp : Form
    {
        public List<Checkup> listCheckUp = new List<Checkup>();
        public FormAdminListCheckUp()
        {
            InitializeComponent();
        }

        string person = "";
        string username = "";

        bool setting = true;

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
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.Button_Hover;
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.Button_Leave;
        }
        private void btnPrintAll_MouseEnter(object sender, EventArgs e)
        {
            btnPrintAll.BackgroundImage = Properties.Resources.Button_Hover;
        }
        private void btnPrintAll_MouseLeave(object sender, EventArgs e)
        {
            btnPrintAll.BackgroundImage = Properties.Resources.Button_Leave;
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
                        dataGridView.Rows.Add(c.Id, c.Price, status, c.Start_date, c.Finish_date, c.Customer.Username, c.Doctor.Username);
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
                 listCheckUp = Checkup.BacaData(person, username);

                //Tampilkan semua isi list di datagridview (Panggil method TampilDataGridView)
                TampilDataGrid();

                if (setting)
                {
                    cmbDoctorOrPatient.Text = "Customer";
                    setting = false;
                }

                #region ComboBox
                cmbDoctorOrPatient.DropDownStyle = ComboBoxStyle.DropDownList;

                if (cmbNama.DataSource == null)
                {
                    //List<string> listAll = new List<string>();
                    //List<string> listCusUsername = Customer.AmbilNama();
                    //List<string> listDocUsername = Doctor.AmbilNama();

                    //listAll.AddRange(listCusUsername);
                    //listAll.AddRange(listDocUsername);

                    cmbNama.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbNama.DataSource = null;
                    cmbNama.SelectedItem = "";
                }
                #endregion
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
                DateTime start = (DateTime)dataGridView.CurrentRow.Cells["start_date"].Value;

                //Kalau button Add diklik
                if (e.ColumnIndex == dataGridView.Columns["btnPrint"].Index && e.RowIndex >= 0)
                {
                    Checkup ch = Checkup.AmbilSatuData(patientName, doctorName, start);
                    ch.CetakCheckup("Admin_Checkup ID " + ch.Id + "_" + DateTime.Now.ToString("dd-MM-yyyy")+ ".txt");
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
                string kriteria = "";
                switch (cmbDoctorOrPatient.Text)
                {
                    case "Customer":
                        kriteria = "customer_username";
                        break;
                    case "Doctor":
                        kriteria = "doctor_username";
                        break;
                }
                Checkup.CetakDaftarOrder(kriteria, cmbNama.Text, "Admin_AllCheckup_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt");
                MessageBox.Show("Seluruh Order berhasil dicetak!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }

        private void cmbDoctorOrPatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cmbDoctorOrPatient.SelectedItem.ToString())
            {
                case "Customer":
                    List<Customer> listCustomer = Customer.BacaData("", "");

                    cmbNama.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbNama.DataSource = listCustomer;
                    cmbNama.DisplayMember = "username";

                    person = "customer_username";
                    break;

                case "Doctor":
                    List<Doctor> listDoctor = Doctor.BacaData("", "");

                    cmbNama.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbNama.DataSource = listDoctor;
                    cmbNama.DisplayMember = "username";

                    person = "doctor_username";
                    break;
            }
        }

        private void cmbNama_SelectedIndexChanged(object sender, EventArgs e)
        {
            username = cmbNama.Text;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FormAdminListCheckUp_Load(sender, e);
        }
    }
}
