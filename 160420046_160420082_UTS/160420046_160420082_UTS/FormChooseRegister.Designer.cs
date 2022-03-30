
namespace _160420046_160420082_UTS
{
    partial class FormChooseRegister
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxPatient = new System.Windows.Forms.PictureBox();
            this.pictureBoxDoctor = new System.Windows.Forms.PictureBox();
            this.pictureBoxDoctorClick = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDoctor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDoctorClick)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxPatient
            // 
            this.pictureBoxPatient.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxPatient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxPatient.Image = global::_160420046_160420082_UTS.Properties.Resources.Patient;
            this.pictureBoxPatient.Location = new System.Drawing.Point(100, 207);
            this.pictureBoxPatient.Name = "pictureBoxPatient";
            this.pictureBoxPatient.Size = new System.Drawing.Size(280, 299);
            this.pictureBoxPatient.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPatient.TabIndex = 0;
            this.pictureBoxPatient.TabStop = false;
            this.pictureBoxPatient.Click += new System.EventHandler(this.pictureBoxPatient_Click);
            // 
            // pictureBoxDoctor
            // 
            this.pictureBoxDoctor.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxDoctor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxDoctor.Image = global::_160420046_160420082_UTS.Properties.Resources.Doctor;
            this.pictureBoxDoctor.Location = new System.Drawing.Point(554, 207);
            this.pictureBoxDoctor.Name = "pictureBoxDoctor";
            this.pictureBoxDoctor.Size = new System.Drawing.Size(202, 277);
            this.pictureBoxDoctor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxDoctor.TabIndex = 1;
            this.pictureBoxDoctor.TabStop = false;
            this.pictureBoxDoctor.Click += new System.EventHandler(this.pictureBoxDoctor_Click);
            // 
            // pictureBoxDoctorClick
            // 
            this.pictureBoxDoctorClick.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxDoctorClick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxDoctorClick.Location = new System.Drawing.Point(514, 207);
            this.pictureBoxDoctorClick.Name = "pictureBoxDoctorClick";
            this.pictureBoxDoctorClick.Size = new System.Drawing.Size(280, 299);
            this.pictureBoxDoctorClick.TabIndex = 2;
            this.pictureBoxDoctorClick.TabStop = false;
            this.pictureBoxDoctorClick.Click += new System.EventHandler(this.pictureBoxDoctorClick_Click);
            // 
            // FormChooseRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::_160420046_160420082_UTS.Properties.Resources.Form_Choose_Register;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(904, 643);
            this.Controls.Add(this.pictureBoxDoctor);
            this.Controls.Add(this.pictureBoxPatient);
            this.Controls.Add(this.pictureBoxDoctorClick);
            this.DoubleBuffered = true;
            this.Name = "FormChooseRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormRegister";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDoctor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDoctorClick)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPatient;
        private System.Windows.Forms.PictureBox pictureBoxDoctor;
        private System.Windows.Forms.PictureBox pictureBoxDoctorClick;
    }
}