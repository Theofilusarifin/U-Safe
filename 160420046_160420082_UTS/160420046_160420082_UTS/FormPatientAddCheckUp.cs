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
    public partial class FormPatientAddCheckUp : Form
    {
        public FormPatientAddCheckUp()
        {
            InitializeComponent();
            dateTimePickerWaktuMulai.Format = DateTimePickerFormat.Time;
            dateTimePickerWaktuMulai.ShowUpDown = true;

            // To get the DateTime from both these controls use the following code
            // DateTime myDate = datePortionDateTimePicker.Value.Date + timePortionDateTimePicker.Value.TimeOfDay;
            //dateTimePickerTanggalMulai.Value = myDate.Date;
            //dateTimePickerWaktuMulai.Value = myDate.TimeOfDay;
        }

        List<Doctor> availableDoctor = new List<Doctor>();

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
        private void buttonBook_MouseEnter(object sender, EventArgs e)
        {
            buttonBook.BackgroundImage = Properties.Resources.Button_Hover;
        }
        private void buttonBook_MouseLeave(object sender, EventArgs e)
        {
            buttonBook.BackgroundImage = Properties.Resources.Button_Leave;
        }
        #endregion

        private void buttonBook_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime Now = dateTimePickerTanggalMulai.Value.Date + dateTimePickerWaktuMulai.Value.TimeOfDay;

                DateTime upperLimit = Now.Add(new TimeSpan(0, 30, 0));
                DateTime lowerLimit = Now.Add(new TimeSpan(0, -30, 0));

                //availableDoctor = Doctor.SearchAvailableDoctor();

                //Checkup c = new Checkup(Now, FormMain.active_patient, );
                //Checkup.TambahData(c);

                //MessageBox.Show("Anda berhasil menambahkan checkup pada " + c.Start_date);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Maaf, penambahan checkup Anda pada " + c.Start_date + " gagal");
            }

        }

        private void FormPatientAddCheckUp_Load(object sender, EventArgs e)
        {
            dateTimePickerTanggalMulai.Value = DateTime.Now;
            dateTimePickerWaktuMulai.Value = Convert.ToDateTime(DateTime.Now.TimeOfDay.ToString());
        }
    }
}
