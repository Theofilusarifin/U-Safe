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
    public partial class FormRegisterAdmin : Form
    {
        public FormRegisterAdmin()
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
        private void buttonLogin_MouseEnter(object sender, EventArgs e)
        {
            buttonRegister.BackgroundImage = Properties.Resources.Button_Hover;
        }
        private void buttonLogin_MouseLeave(object sender, EventArgs e)
        {
            buttonRegister.BackgroundImage = Properties.Resources.Button_Leave;
        }
        #endregion

        private void buttonRegister_Click(object sender, EventArgs e)
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
                            // Foto admin
                            PictureBox pb = pictureBoxFoto;

                            Admin a = new Admin(textBoxUsername.Text, textBoxEmail.Text, textBoxNomorTelepon.Text, textBoxPassword.Text, FormMain.ConvertImage(pb.Image), textBoxNomorKTP.Text);

                            Admin.TambahData(a);

                            MessageBox.Show("Admin data has been added!", "Update Info");

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

        private void pictureBoxFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.png)|*.png";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxFoto.Image = Image.FromFile(opf.FileName);
            }
        }
    }
}
