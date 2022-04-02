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
    public partial class FormAdminAddMedicine : Form
    {
        public FormAdminAddMedicine()
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
        private void buttonAdd_MouseEnter(object sender, EventArgs e)
        {
            buttonAdd.BackgroundImage = Properties.Resources.Button_Hover;
        }
        private void buttonAdd_MouseLeave(object sender, EventArgs e)
        {
            buttonAdd.BackgroundImage = Properties.Resources.Button_Leave;
        }
        #endregion

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Medicine m = new Medicine(textBoxNama.Text, int.Parse(textBoxHarga.Text), int.Parse(textBoxStock.Text));

                Medicine.TambahData(m);

                MessageBox.Show("Data Gift berhasil ditambahkan", "Informasi");

                // Update Data Di Form Daftar
                FormAdminListMedicine frm = (FormAdminListMedicine)this.Owner;
                frm.FormAdminListMedicine_Load(sender, e);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }
    }
}
