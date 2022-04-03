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
    public partial class FormDoctorEditProfile : Form
    {
        public FormDoctorEditProfile()
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
        private void buttonEditProfile_MouseEnter(object sender, EventArgs e)
        {
            buttonEditProfile.BackgroundImage = Properties.Resources.Button_Hover;
        }

        private void buttonEditProfile_MouseLeave(object sender, EventArgs e)
        {
            buttonEditProfile.BackgroundImage = Properties.Resources.Button_Leave;
        }
        #endregion


        private void FormDoctorEditProfile_Load(object sender, EventArgs e)
        {
            try
            {
                textBoxUsername.Text = FormMain.active_doctor.Username;
                textBoxNomorTelepon.Text = FormMain.active_doctor.Phone_number;
                textBoxEmail.Text = FormMain.active_doctor.Email;
                textBoxPassword.Text = FormMain.active_doctor.Password;
                textBoxPasswordKonfirmasi.Text = FormMain.active_doctor.Password;
                textBoxNomorKTP.Text = FormMain.active_doctor.KtpNum;
                comboBoxBank.Text = FormMain.active_doctor.Bank_account;

                // Convert Byte yang ada di database ke image
                pictureBoxFoto.Image = FormMain.ConvertByte(FormMain.active_doctor.Profile_photo); ;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\nMessage : '" + ex.Message + "'");
            }
        }
        private void buttonEditProfile_Click(object sender, EventArgs e)
        {
            try
            {
                // Tidak ada data yang kosong
                if (textBoxUsername.Text != "" && textBoxEmail.Text != "" && textBoxNomorTelepon.Text != "" && textBoxPassword.Text != "" && textBoxPasswordKonfirmasi.Text != "" && textBoxNomorKTP.Text != "")
                {
                    if (textBoxPassword.Text == textBoxPasswordKonfirmasi.Text) // Password dan Password konfimasi sudah sama
                    {
                        if (pictureBoxFoto.Image != null)
                        {
                            Doctor d = new Doctor(textBoxUsername.Text, textBoxEmail.Text, textBoxNomorTelepon.Text, textBoxPassword.Text, FormMain.ConvertImage(pictureBoxFoto.Image), textBoxNomorKTP.Text, FormMain.active_doctor.Balance, FormMain.active_doctor.Availability, comboBoxBank.Text, Hospital.AmbilDataPertama());

                            Doctor.UbahData(d);

                            MessageBox.Show("Doctor data has been updated!", "Update Info");

                            FormMain.active_doctor = d;

                            this.Close();
                        }
                        else
                        {
                            throw new Exception("Please select a photo!");
                        }
                    }
                    else
                    {
                        throw new Exception("Password does not match!");
                    }
                }
                else
                {
                    throw new Exception("Please fill out all input!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\nMessage : '" + ex.Message + "'");

            }
        }
        private void textBoxUsername_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Username can not be changed!", "Info");
        }
        private void pictureBoxFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxFoto.Image = Image.FromFile(opf.FileName);
            }
        }
    }
}
