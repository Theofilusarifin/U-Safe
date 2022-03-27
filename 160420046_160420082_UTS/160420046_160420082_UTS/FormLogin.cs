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
    public partial class FormLogin : Form
    {
        public FormLogin()
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
            buttonLogin.BackgroundImage = Properties.Resources.Button_Hover;
        }
        private void buttonLogin_MouseLeave(object sender, EventArgs e)
        {
            buttonLogin.BackgroundImage = Properties.Resources.Button_Leave;
        }
        #endregion

        private void buttonLogin_Click(object sender, EventArgs e)
        {

        }

        private void labelRegistrasi_Click(object sender, EventArgs e)
        {
            FormChooseRegister frm = new FormChooseRegister(); //Create Object
            frm.Owner = this.Owner;
            frm.Show();
            this.Owner.Hide();
            this.Hide();
        }

        bool passwordSeen = false;
        private void pictureBoxMata_Click(object sender, EventArgs e)
        {
            if (!passwordSeen)
            {
                pictureBoxMata.Image = Properties.Resources.Open_Eye;
                textBoxPassword.PasswordChar = '\0';
                passwordSeen = true;
            }
            else if (passwordSeen)
            {
                pictureBoxMata.Image = Properties.Resources.Closed_Eye;
                textBoxPassword.PasswordChar = '⚉';
                passwordSeen = false;
            }
        }
    }
}
