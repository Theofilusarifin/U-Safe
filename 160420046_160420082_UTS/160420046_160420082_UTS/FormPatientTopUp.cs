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
    public partial class FormPatientTopUp : Form
    {
        public FormPatientTopUp()
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
        private void buttonTopUp_MouseEnter(object sender, EventArgs e)
        {
            buttonTopUp.BackgroundImage = Properties.Resources.Button_Hover;
        }
        private void buttonTopUp_MouseLeave(object sender, EventArgs e)
        {
            buttonTopUp.BackgroundImage = Properties.Resources.Button_Leave;
        }
        #endregion

        private void buttonTopUp_Click(object sender, EventArgs e)
        {
            try
            {
                // tambah saldo di database dengan nominal di textbox
                Customer.TopUpBalance(int.Parse(textBoxSaldo.Text), FormMain.active_patient);
                MessageBox.Show("Top up balance succeded", "Info");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }
    }
}
