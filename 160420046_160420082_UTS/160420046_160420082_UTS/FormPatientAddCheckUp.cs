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
                // ambil nama doctor yang available pada jam NOW
                availableDoctorName = Doctor.SearchAvailableDoctor(upperLimit, lowerLimit);

                // baca semua data checkup dengan username pasien yang aktif sekarang
                List<Checkup> listCheckup = Checkup.BacaCheckupBelumSelesai("customer_username", FormMain.active_patient.Username);
                // kalau pasien punya checkup
                if (listCheckup.Count != 0)
                {
                    // cari schedule checkup yang bentrokan jamnya dengan NOW
                    clashingSchedule = Customer.SearchClashingSchedule(upperLimit, lowerLimit, FormMain.active_patient.Username);
                }

                // kalau ada dokter yang available
                if (availableDoctorName.Count() > 0)
                {
                    // buat random
                    Random random = new Random();
                    // ambil angka random min = 0, max = sebanyak item di list dokter available
                    int randNum = random.Next(availableDoctorName.Count());

                    // ambil data dokter yang available
                    availableDoctor = Doctor.AmbilData(availableDoctorName[randNum]);

                    // buat checkup baru
                    Checkup ch = new Checkup(Now, FormMain.active_patient, availableDoctor);

                    // kalau tidak ada schedule checkup yang bentrokan
                    if (clashingSchedule.Count == 0)
                    {
                        Checkup.TambahData(ch);

                        Customer.UpdateBalance(ch);

                        Customer cu = Customer.AmbilData(FormMain.active_patient.Username);

                        FormMain.active_patient = cu;

                        FormMain.frmMain.labelSaldo.Text = cu.Balance.ToString();

                        MessageBox.Show("You have successfully added a checkup on " + Now);
                    }
                    // kalau ada schedule checkup yang bentrokan
                    else
                    {
                        MessageBox.Show("You have another checkup schedule on " + Now);
                    }
                }
                // kalau tidak ada dokter yang available
                else
                {
                    MessageBox.Show("Sorry, there is no doctor available on " + Now);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }

        }

        private void FormPatientAddCheckUp_Load(object sender, EventArgs e)
        {
            dateTimePickerTanggalMulai.Value = DateTime.Now;
            dateTimePickerWaktuMulai.Value = Convert.ToDateTime(DateTime.Now.TimeOfDay.ToString());
        }
    }
}
