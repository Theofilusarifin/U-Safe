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

        List<Checkup> clashingSchedule = new List<Checkup>();
        List<string> availableDoctorName = new List<string>();

        Doctor availableDoctor;

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
            DateTime Now = dateTimePickerTanggalMulai.Value.Date + dateTimePickerWaktuMulai.Value.TimeOfDay;

            DateTime upperLimit = Now.Add(new TimeSpan(0, 30, 0));
            DateTime lowerLimit = Now.Add(new TimeSpan(0, -30, 0));

            try
            {
                List<Checkup> listCheckup = Checkup.BacaData("customer_username", FormMain.active_patient.Username);
                if(listCheckup.Count != 0)
                {
                    clashingSchedule = Customer.SearchClashingSchedule(upperLimit, lowerLimit, FormMain.active_patient.Username);
                }

                availableDoctorName = Doctor.SearchAvailableDoctor(upperLimit, lowerLimit);

                Random random = new Random();
                int randNum = random.Next(availableDoctorName.Count());

                availableDoctor = Doctor.AmbilData(availableDoctorName[randNum]);

                Checkup c = new Checkup(Now, FormMain.active_patient, availableDoctor);

                if (clashingSchedule.Count == 0)
                {
                    Checkup.TambahData(c);

                    Customer.UpdateBalance(c);

                    MessageBox.Show("You have successfully added a checkup on " + c.Start_date);
                }
                else
                {
                    MessageBox.Show("You have another checkup schedule on " + c.Start_date);
                }
            }
            catch (Exception ex)
            {
                availableDoctorName = Doctor.SearchAvailableDoctor(upperLimit, lowerLimit);

                Random random = new Random();
                int randNum = random.Next(availableDoctorName.Count());

                availableDoctor = Doctor.AmbilData(availableDoctorName[randNum]);

                Checkup c = new Checkup(Now, FormMain.active_patient, availableDoctor);

                MessageBox.Show("Sorry, there is no doctor available on " + c.Start_date);
                //MessageBox.Show("Error Occured!\n" + ex.Message);
            }

        }

        private void FormPatientAddCheckUp_Load(object sender, EventArgs e)
        {
            dateTimePickerTanggalMulai.Value = DateTime.Now;
            dateTimePickerWaktuMulai.Value = Convert.ToDateTime(DateTime.Now.TimeOfDay.ToString());
        }
    }
}
