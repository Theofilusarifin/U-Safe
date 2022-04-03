
namespace _160420046_160420082_UTS
{
    partial class FormAdminEditProfile
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
            this.pictureBoxFoto = new System.Windows.Forms.PictureBox();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.textBoxNomorTelepon = new System.Windows.Forms.TextBox();
            this.textBoxNomorKTP = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxPasswordKonfirmasi = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxFoto
            // 
            this.pictureBoxFoto.BackgroundImage = global::_160420046_160420082_UTS.Properties.Resources.Image_Placeholder;
            this.pictureBoxFoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxFoto.Location = new System.Drawing.Point(34, 557);
            this.pictureBoxFoto.Name = "pictureBoxFoto";
            this.pictureBoxFoto.Size = new System.Drawing.Size(107, 107);
            this.pictureBoxFoto.TabIndex = 36;
            this.pictureBoxFoto.TabStop = false;
            this.pictureBoxFoto.Click += new System.EventHandler(this.pictureBoxFoto_Click);
            // 
            // buttonRegister
            // 
            this.buttonRegister.AutoSize = true;
            this.buttonRegister.BackColor = System.Drawing.Color.Transparent;
            this.buttonRegister.BackgroundImage = global::_160420046_160420082_UTS.Properties.Resources.Button_Register1;
            this.buttonRegister.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRegister.FlatAppearance.BorderSize = 0;
            this.buttonRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.buttonRegister.ForeColor = System.Drawing.Color.White;
            this.buttonRegister.Location = new System.Drawing.Point(29, 692);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(632, 44);
            this.buttonRegister.TabIndex = 34;
            this.buttonRegister.Text = "Edit Profile";
            this.buttonRegister.UseVisualStyleBackColor = false;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            this.buttonRegister.MouseEnter += new System.EventHandler(this.buttonRegister_MouseEnter);
            this.buttonRegister.MouseLeave += new System.EventHandler(this.buttonRegister_MouseLeave);
            // 
            // textBoxNomorTelepon
            // 
            this.textBoxNomorTelepon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNomorTelepon.Font = new System.Drawing.Font("Montserrat", 12F);
            this.textBoxNomorTelepon.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxNomorTelepon.Location = new System.Drawing.Point(372, 316);
            this.textBoxNomorTelepon.Name = "textBoxNomorTelepon";
            this.textBoxNomorTelepon.Size = new System.Drawing.Size(275, 20);
            this.textBoxNomorTelepon.TabIndex = 29;
            // 
            // textBoxNomorKTP
            // 
            this.textBoxNomorKTP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNomorKTP.Font = new System.Drawing.Font("Montserrat", 12F);
            this.textBoxNomorKTP.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxNomorKTP.Location = new System.Drawing.Point(372, 398);
            this.textBoxNomorKTP.Name = "textBoxNomorKTP";
            this.textBoxNomorKTP.Size = new System.Drawing.Size(275, 20);
            this.textBoxNomorKTP.TabIndex = 31;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxEmail.Font = new System.Drawing.Font("Montserrat", 12F);
            this.textBoxEmail.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxEmail.Location = new System.Drawing.Point(42, 398);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(275, 20);
            this.textBoxEmail.TabIndex = 30;
            // 
            // textBoxPasswordKonfirmasi
            // 
            this.textBoxPasswordKonfirmasi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPasswordKonfirmasi.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Bold);
            this.textBoxPasswordKonfirmasi.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxPasswordKonfirmasi.Location = new System.Drawing.Point(372, 482);
            this.textBoxPasswordKonfirmasi.Name = "textBoxPasswordKonfirmasi";
            this.textBoxPasswordKonfirmasi.PasswordChar = '⚉';
            this.textBoxPasswordKonfirmasi.Size = new System.Drawing.Size(275, 17);
            this.textBoxPasswordKonfirmasi.TabIndex = 33;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPassword.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Bold);
            this.textBoxPassword.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxPassword.Location = new System.Drawing.Point(42, 482);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '⚉';
            this.textBoxPassword.Size = new System.Drawing.Size(275, 17);
            this.textBoxPassword.TabIndex = 32;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUsername.Font = new System.Drawing.Font("Montserrat", 12F);
            this.textBoxUsername.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxUsername.Location = new System.Drawing.Point(40, 316);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(275, 20);
            this.textBoxUsername.TabIndex = 28;
            // 
            // FormAdminEditProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::_160420046_160420082_UTS.Properties.Resources.Form_Edit_Profile;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(688, 782);
            this.Controls.Add(this.pictureBoxFoto);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.textBoxNomorTelepon);
            this.Controls.Add(this.textBoxNomorKTP);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxPasswordKonfirmasi);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsername);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormAdminEditProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormProfileAdmin";
            this.Load += new System.EventHandler(this.FormAdminEditProfile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxFoto;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.TextBox textBoxNomorTelepon;
        private System.Windows.Forms.TextBox textBoxNomorKTP;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxPasswordKonfirmasi;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
    }
}