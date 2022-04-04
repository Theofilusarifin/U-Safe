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
    public partial class FormLoading : Form
    {
        public FormLoading()
        {
            InitializeComponent();
        }

        string role_user = "";


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

        private void timerLoading_Tick(object sender, EventArgs e)
        {
            panelLoading.Width += 3;
            if (panelLoading.Width >= 533)
            {
                timerLoading.Stop();
                this.Close();
            }
        }
        private void FormLoading_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Owner.Show();
                // Tampilkan element pada form main
                FormMain.frmMain.panelLeftNavbar.Show();
                FormMain.frmMain.panelLeft.Show();
                FormMain.frmMain.panelHeader.Show();
                FormMain.frmMain.panelActiveForm.Show();
                FormMain.frmMain.panelLeftNavbar.BringToFront();

                if (FormMain.role == "admin") // Admin
                {
                    FormMain.frmMain.panelAdmin.Show(); // Tampilkan panel admin
                    FormMain.frmMain.labelUsername.Text = FormMain.active_admin.Username;
                }
                else if(FormMain.role == "doctor" || FormMain.role == "patient")
                {
                    // Tampilkan element balance
                    FormMain.frmMain.pictureBoxSaldo.Show();
                    FormMain.frmMain.labelSaldoHeader.Show();
                    FormMain.frmMain.labelSaldo.Show();
                    FormMain.frmMain.labelSaldoHeader.BringToFront();
                    FormMain.frmMain.labelSaldo.BringToFront();

                    if (FormMain.role == "doctor")
                    {
                        FormMain.frmMain.panelDoctor.Show(); // Tampilkan panel doctor
                        FormMain.frmMain.labelSaldo.Text = FormMain.active_doctor.Balance.ToString(); // Tampilkan nilai balance doctor
                        FormMain.frmMain.labelUsername.Text = FormMain.active_doctor.Username;
                    }
                    else if (FormMain.role == "patient")
                    {

                        FormMain.frmMain.labelSaldo.Text = FormMain.active_patient.Balance.ToString(); // Tampilkan nilai balance doctor
                        FormMain.frmMain.labelUsername.Text = FormMain.active_patient.Username;
                    }

                }
                else MessageBox.Show("Error Occured!\n role not found");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }
    }
}
