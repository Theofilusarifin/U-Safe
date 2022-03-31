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
    public partial class FormDoctorWithdrawBalance : Form
    {
        public FormDoctorWithdrawBalance()
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
        private void buttonWithdraw_MouseEnter(object sender, EventArgs e)
        {
            buttonWithdraw.BackgroundImage = Properties.Resources.Button_Hover;
        }
        private void buttonWithdraw_MouseLeave(object sender, EventArgs e)
        {
            buttonWithdraw.BackgroundImage = Properties.Resources.Button_Leave;
        }
        #endregion

        private void buttonWithdraw_Click(object sender, EventArgs e)
        {
            try
            {
                // kurangi saldo di database dengan nominal di textbox
                Doctor.WithdrawBalance(int.Parse(textBoxSaldo.Text), FormMain.active_doctor);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Terjadi Error. Pesan kesalahan : " + ex.Message, "Error");
            }
        }
    }
}
