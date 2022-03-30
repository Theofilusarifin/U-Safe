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
    public partial class FormLogin : Form
    {
        public FormLogin()
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
        private void buttonLogin_MouseEnter(object sender, EventArgs e)
        {
            buttonLogin.BackgroundImage = Properties.Resources.Button_Hover;
        }
        private void buttonLogin_MouseLeave(object sender, EventArgs e)
        {
            buttonLogin.BackgroundImage = Properties.Resources.Button_Leave;
        }
        #endregion

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //create object baru
                Koneksi koneksi = new Koneksi();

                // Check apakah di awal username ada pagar (Kalau ada admin)
                if (textBoxUsername.Text[0] == '#')
                {
                    // Cari data apakah ada admin dengan username yang dimasukkan
                    Admin a = Admin.BacaData("username", textBoxUsername.Text.Remove(0, 1))[0];

                    // Jika ada
                    if (a != null)
                    {
                        // Ambil profile photo admin
                        Image img = FormMain.ConvertByte(a.Profile_photo);

                        // Extract password dari steganography
                        string hashPass = Steganography.ExtractText(new Bitmap((Image)img));
                        string pass = textBoxPassword.Text;
                        // Compare password
                        bool success = HashSalt.Compare(hashPass, pass);

                        if (success) // Apabila berhasil
                        {
                            // Set variabel di form main
                            FormMain.role = "admin";
                            FormMain.active_admin = a;
                            FormMain.frmMain.labelNama.Text = a.Username;

                            FormLoading form = new FormLoading(); //Create Object
                            form.Owner = this;
                            form.Show();
                            this.Hide();
                        }
                        else // Apabila gagal
                        {
                            var original = this.Location;
                            var rnd = new Random(1337);
                            const int shake_amplitude = 10;
                            for (int i = 0; i < 10; i++)
                            {
                                this.Location = new Point(original.X + rnd.Next(-shake_amplitude, shake_amplitude), original.Y + rnd.Next(-shake_amplitude, shake_amplitude));
                                System.Threading.Thread.Sleep(20);
                            }
                            this.Location = original;

                            throw (new Exception("Username or password is incorrect!"));
                        }
                    }
                    else // Data tidak ditemukan
                    {
                        throw (new Exception("Username is not registered!"));
                    }

                }
                else // Doctor/Patient
                {
                    if (!cb.Checked)
                    {
                        List<Customer> a = Customer.BacaData("username", this.Controls["textBoxUsernameLogin"].Text);
                        Customer c = a[0];
                        if (c != null)
                        {
                            bool success = HashSalt.Compare(c.Password, this.Controls["textBoxPasswordLogin"].Text);
                            if (success)
                            {
                                if (c.Status != "inactive")
                                {
                                    MessageBox.Show("USER LOGIN SUCCESS!\nWelcome back " + c.Name);

                                    c.Password = this.Controls["textBoxPasswordLogin"].Text;
                                    ChangeForm(4);
                                    activeCus = c;
                                    UpdateDisplayMainMenu();
                                }
                                else
                                {
                                    throw (new Exception("Your account has been banned by the admin."));
                                }
                            }
                            else
                            {
                                throw (new Exception("Username or Password is incorrect!"));
                            }
                        }
                        else
                        {
                            throw (new Exception("Username is not registered!"));
                        }
                    }
                    else //driver
                    {
                        Driver d = Driver.BacaDataSpesifik("id", this.Controls["textBoxUsernameLogin"].Text)[0];
                        if (d != null)
                        {
                            bool success = HashSalt.Compare(d.Password, this.Controls["textBoxPasswordLogin"].Text);
                            if (success)
                            {
                                if (d.Status != "inactive")
                                {
                                    MessageBox.Show("DRIVER LOGIN SUCCESS!\nWelcome back " + d.Name);

                                    d.Password = this.Controls["textBoxPasswordLogin"].Text;
                                    activeDri = d;
                                    ChangeForm(11);
                                    UpdateDisplayMainMenuDriver();
                                }
                                else
                                {
                                    throw (new Exception("Your account has been banned by the admin."));
                                }
                            }
                            else
                            {
                                throw (new Exception("Driver Username or Password is incorrect!"));
                            }
                        }
                        else
                        {
                            throw (new Exception("Driver Username is not registered!"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }

        private void labelRegistrasi_Click(object sender, EventArgs e)
        {
            FormChooseRegister frm = new FormChooseRegister(); //Create Object
            frm.Owner = this.Owner;
            frm.Show();
            this.Owner.Hide();
            this.Hide();
        }

        bool passwordSeen = false;
        private void pictureBoxMata_Click(object sender, EventArgs e)
        {
            if (!passwordSeen)
            {
                pictureBoxMata.Image = Properties.Resources.Open_Eye;
                textBoxPassword.PasswordChar = '\0';
                passwordSeen = true;
            }
            else if (passwordSeen)
            {
                pictureBoxMata.Image = Properties.Resources.Closed_Eye;
                textBoxPassword.PasswordChar = '⚉';
                passwordSeen = false;
            }
        }
    }
}
