using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Library;

namespace _160420046_160420082_UTS
{
    public partial class FormPatientPrescription : Form
    {
        public FormPatientPrescription()
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
        private void buttonClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackgroundImage = Properties.Resources.Button_Hover;
        }
        private void buttonClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackgroundImage = Properties.Resources.Button_Leave;
        }
        #endregion

        private void FormPatientPrescription_Load(object sender, EventArgs e)
        {
            try
            {
                //listBoxMedPrescription.Items.Clear();
                //Checkup checkup = FormPatientHistoryCheckUp.checkupSeePresctiption;
                //listBoxMedPrescription.Items.Add("Id: " + );
                //listBoxMedPrescription.Items.Add("Tanggal: " + o.Tanggal_waktu);
                //listBoxMedPrescription.Items.Add("Alamat: " + o.Alamat_tujuan);
                //listBoxMedPrescription.Items.Add("Ongkos Kirim: " + o.Ongkos_kirim);
                //listBoxMedPrescription.Items.Add("Total Bayar: " + o.Total_bayar);
                //listBoxMedPrescription.Items.Add("Status: " + o.Status);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pesan kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
