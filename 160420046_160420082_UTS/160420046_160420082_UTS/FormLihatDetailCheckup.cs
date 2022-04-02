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
    public partial class FormLihatDetailCheckup : Form
    {
        public FormLihatDetailCheckup()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormLihatDetailCheckup_Load(object sender, EventArgs e)
        {
            try
            {
                listBoxCheckup.Items.Clear();
                Checkup ch = FormPatientHistoryCheckUp.detailCheckup;
                listBoxCheckup.Items.Add("Id: " + ch.Id);
                listBoxCheckup.Items.Add("Tanggal: " + ch.Customer);
                listBoxCheckup.Items.Add("Alamat: " + ch.Doctor);
                listBoxCheckup.Items.Add("Start Date: " + ch.Start_date);
                listBoxCheckup.Items.Add("Finish Date: " + ch.Finish_date);
                listBoxCheckup.Items.Add("Total Price: " + ch.TotalPrice.ToString("#,###"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }

        private void btnCetak_Click(object sender, EventArgs e)
        {
            try
            {
                Checkup ch = FormPatientHistoryCheckUp.detailCheckup;
                ch.CetakCheckup("Checkup " + ch.Id + ".txt"); //Mulai cetak file
                MessageBox.Show("Order berhasil dicetak!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }
    }
}
