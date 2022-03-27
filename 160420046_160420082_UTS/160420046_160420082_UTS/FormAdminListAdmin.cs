using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _160420046_160420082_UTS
{
    public partial class FormAdminListAdmin : Form
    {
        public FormAdminListAdmin()
        {
            InitializeComponent();
        }

        #region Desain Button
        private void buttonClose_MouseEnter(object sender, EventArgs e)
        {
            buttonClose.BackgroundImage = Properties.Resources.Button_Hover;
        }
        private void buttonClose_MouseLeave(object sender, EventArgs e)
        {
            buttonClose.BackgroundImage = Properties.Resources.Button_Leave;
        }
        private void buttonRegister_MouseEnter(object sender, EventArgs e)
        {
            buttonRegister.BackgroundImage = Properties.Resources.Button_Hover;
        }
        private void buttonRegister_MouseLeave(object sender, EventArgs e)
        {
            buttonRegister.BackgroundImage = Properties.Resources.Button_Leave;
        }
        #endregion
    }
}
