﻿using System;
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
    public partial class FormChooseRegister : Form
    {
        public FormChooseRegister()
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

        private void pictureBoxPatient_Click(object sender, EventArgs e)
        {
            FormRegisterPatient frm = new FormRegisterPatient(); //Create Object
            frm.Owner = this.Owner;
            frm.Show();
            this.Close();
        }
        private void pictureBoxDoctor_Click(object sender, EventArgs e)
        {
            FormRegisterDoctor frm = new FormRegisterDoctor(); //Create Object
            frm.Owner = this.Owner;
            frm.Show();
            this.Close();
        }
        private void pictureBoxDoctorClick_Click(object sender, EventArgs e)
        {
            FormRegisterDoctor frm = new FormRegisterDoctor(); //Create Object
            frm.Owner = this.Owner;
            frm.Show();
            this.Close();
        }
    }
}
