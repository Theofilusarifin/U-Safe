using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

// Tambahkan using reference
using Library;
using Cryptography;

namespace _160420046_160420082_UTS
{
    public partial class FormMain : Form
    {
        public static FormMain frmMain = null;

        public static Koneksi koneksi = null;
        public static string role;

        public static Admin active_admin;
        public static Doctor active_doctor;
        public static Customer active_patient;

        public FormMain()
        {
            InitializeComponent();
            HideSubMenuFirst();
            frmMain = this;
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

        #region Method Public
        public static void EditPhoto(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pb.Image = Image.FromFile(dialog.FileName);
            }
        }

        public static Image ConvertByte(byte[] img)
        {
            MemoryStream stream = new MemoryStream(img);
            Image result = Image.FromStream(stream);

            return result;
        }

        public static byte[] ConvertImage(Image image)
        {
            MemoryStream stream = new MemoryStream();
            image.Save(stream, image.RawFormat);
            byte[] img = stream.ToArray();

            return img;
        }

        public static void NumberCheck(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        public static void NumConverter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text != "")
            {
                tb.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("id-ID"), "{0:#,###}", double.Parse(tb.Text));
                tb.SelectionStart = tb.TextLength;
            }
        }
        #endregion

        #region OpenChildForm
        public Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelActiveForm.Controls.Add(childForm);
            panelActiveForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }
        #endregion

        #region SubMenuPanel
        public void HideSubMenuFirst()
        {
            panelShowData.Hide();
        }
        public void HideSubMenu()
        {
            if (panelShowData.Visible) panelShowData.Hide();
        }

        public void ShowSubMenu(Panel subMenu)
        {
            if (!subMenu.Visible)
            {
                HideSubMenu();
                subMenu.Show();
            }
            else subMenu.Hide();
        }
        #endregion

        #region FormDoctor
        private void buttonDoctorCheckUp_Click(object sender, EventArgs e)
        {
            try
            {
                HideSubMenu();
                openChildForm(new FormDoctorCheckUpSchedule());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }
        private void buttonDoctorMedicines_Click(object sender, EventArgs e)
        {
            try
            {
                HideSubMenu();
                openChildForm(new FormDoctorListMedicine());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }
        private void buttonDoctorHistory_Click(object sender, EventArgs e)
        {
            try
            {
                HideSubMenu();
                openChildForm(new FormDoctorHistory());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }
        private void buttonDoctorWithdraw_Click(object sender, EventArgs e)
        {
            try
            {
                //Buka Form
                Form form = Application.OpenForms["FormDoctorWithdrawBalance"];

                if (form == null) //Jika Form ini belum di-create sebelumnya
                {
                    FormDoctorWithdrawBalance frm = new FormDoctorWithdrawBalance(); //Create Object
                    frm.Owner = this;
                    frm.Show();
                    frm.BringToFront(); //Agar form tampil di depan
                }
                else
                {
                    form.Show();
                    form.BringToFront(); //Agar form tampil di depan
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }
        private void buttonDoctorEditProfile_Click(object sender, EventArgs e)
        {
            try
            {
                HideSubMenu();
                openChildForm(new FormDoctorEditProfile());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }

        }
        #endregion

        #region FormPatient
        private void ButtonPatientBook_Click(object sender, EventArgs e)
        {
            try
            {
                HideSubMenu();
                openChildForm(new FormPatientBookCheckUp());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }

        private void ButtonPatientHistory_Click(object sender, EventArgs e)
        {
            try
            {
                HideSubMenu();
                openChildForm(new FormPatientHistoryCheckUp());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }

        private void ButtonPatientTopUp_Click(object sender, EventArgs e)
        {
            try
            {
                //Buka Form
                Form form = Application.OpenForms["FormPatientTopUp"];

                if (form == null) //Jika Form ini belum di-create sebelumnya
                {
                    FormPatientTopUp frm = new FormPatientTopUp(); //Create Object
                    frm.Owner = this;
                    frm.Show();
                    frm.BringToFront(); //Agar form tampil di depan
                }
                else
                {
                    form.Show();
                    form.BringToFront(); //Agar form tampil di depan
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }
        private void ButtonPatientEditProfile_Click(object sender, EventArgs e)
        {
            try
            {
                //Buka Form
                Form form = Application.OpenForms["FormPatientEditProfile"];

                if (form == null) //Jika Form ini belum di-create sebelumnya
                {
                    FormPatientEditProfile frm = new FormPatientEditProfile(); //Create Object
                    frm.Owner = this;
                    frm.Show();
                    frm.BringToFront(); //Agar form tampil di depan
                }
                else
                {
                    form.Show();
                    form.BringToFront(); //Agar form tampil di depan
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }
        #endregion

        #region FormAdmin
        private void buttonAdminShowData_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelShowData);
        }
        private void buttonAdminDataAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                HideSubMenu();
                openChildForm(new FormAdminListAdmin());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }
        private void buttonAdminDataMedicine_Click(object sender, EventArgs e)
        {
            try
            {
                HideSubMenu();
                openChildForm(new FormAdminListMedicine());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }
        private void buttonAdminDataDoctor_Click(object sender, EventArgs e)
        {
            try
            {
                HideSubMenu();
                openChildForm(new FormAdminListDoctor());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }
        private void buttonAdminDataPatient_Click(object sender, EventArgs e)
        {
            try
            {
                HideSubMenu();
                openChildForm(new FormAdminListPatient());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }
        private void buttonAdminDataMedicine_Click_1(object sender, EventArgs e)
        {
            try
            {
                HideSubMenu();
                openChildForm(new FormAdminListMedicine());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }
        private void buttonAdminCheckUp_Click(object sender, EventArgs e)
        {
            try
            {
                HideSubMenu();
                openChildForm(new FormAdminListCheckUp());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }
        private void buttonAdminEditProfile_Click(object sender, EventArgs e)
        {
            try
            {
                HideSubMenu();
                //Buka Form
                Form form = Application.OpenForms["FormAdminEditProfile"];

                if (form == null) //Jika Form ini belum di-create sebelumnya
                {
                    FormAdminEditProfile frm = new FormAdminEditProfile(); //Create Object
                    frm.Owner = this;
                    frm.Show();
                    frm.BringToFront(); //Agar form tampil di depan
                }
                else
                {
                    form.Show();
                    form.BringToFront(); //Agar form tampil di depan
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }
        #endregion

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                //Ambil nilai di db setting
                koneksi = new Koneksi("localhost", "u-safe", "root", "");
                //MessageBox.Show("Koneksi Berhasil");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi Gagal. Pesan Kesalahan : " + ex.Message);
            }
        }

        #region FormLogin
        int opening = 0;
        private void timerLoading_Tick(object sender, EventArgs e)
        {
            opening++;
            if (opening == 1)
            {
                FormLogin form = new FormLogin(); //Create Object
                form.Owner = this;
                form.Show();
                this.Hide();
                timerLoading.Stop();
                opening = 0;
            }
        }
        #endregion

        #region Logout
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            // Set semua ke null
            role = null;
            active_admin = null;
            active_doctor = null;
            active_patient = null;

            panelLeftNavbar.Hide();
            panelLeft.Hide();
            panelHeader.Hide();
            panelActiveForm.Hide();

            panelAdmin.Hide(); // Hide panel admin
            panelDoctor.Hide(); // Hide panel doctor
            panelPasien.Hide(); // Hide panel patient

            labelUsername.Text = "";
            labelSaldo.Text = "";

            // Hide element balance
            pictureBoxSaldo.Hide();
            labelSaldoHeader.Hide();
            labelSaldo.Hide();

            // Hide form ini
            HideSubMenu();

            // Tampilkan form login
            FormLogin form = new FormLogin(); //Create Object
            form.Owner = this;
            form.Show();
            this.Hide();
        }
        #endregion
    }
}
