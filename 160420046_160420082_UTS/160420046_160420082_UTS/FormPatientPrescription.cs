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
                listBoxMedPrescription.Items.Clear();
                
                Checkup checkup = FormPatientHistoryCheckUp.checkupSeePresctiption;
                List<Checkup_Medicine> listMed = Checkup_Medicine.BacaData("checkup_id", checkup.Id.ToString());
                
                listBoxMedPrescription.Items.Add("Medicines:");
                foreach (Checkup_Medicine cm in listMed)
                {
                    listBoxMedPrescription.Items.Add("Name: " + cm.Medicine.Name + " Amount: " + cm.Amount + " Total Price: " + cm.Price);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
