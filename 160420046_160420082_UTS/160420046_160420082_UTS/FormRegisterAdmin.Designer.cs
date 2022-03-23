
namespace _160420046_160420082_UTS
{
    partial class FormRegisterAdmin
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
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textBoxNomorTelepon = new System.Windows.Forms.TextBox();
            this.textBoxNomorKTP = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxPasswordKonfirmasi = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.AutoSize = true;
            this.buttonLogin.BackColor = System.Drawing.Color.Transparent;
            this.buttonLogin.BackgroundImage = global::_160420046_160420082_UTS.Properties.Resources.Button_Register1;
            this.buttonLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLogin.FlatAppearance.BorderSize = 0;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.Location = new System.Drawing.Point(35, 732);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(632, 44);
            this.buttonLogin.TabIndex = 25;
            this.buttonLogin.Text = "Register";
            this.buttonLogin.UseVisualStyleBackColor = false;
            // 
            // textBoxNomorTelepon
            // 
            this.textBoxNomorTelepon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNomorTelepon.Font = new System.Drawing.Font("Montserrat", 12F);
            this.textBoxNomorTelepon.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxNomorTelepon.Location = new System.Drawing.Point(381, 335);
            this.textBoxNomorTelepon.Name = "textBoxNomorTelepon";
            this.textBoxNomorTelepon.Size = new System.Drawing.Size(275, 20);
            this.textBoxNomorTelepon.TabIndex = 24;
            // 
            // textBoxNomorKTP
            // 
            this.textBoxNomorKTP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNomorKTP.Font = new System.Drawing.Font("Montserrat", 12F);
            this.textBoxNomorKTP.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxNomorKTP.Location = new System.Drawing.Point(381, 419);
            this.textBoxNomorKTP.Name = "textBoxNomorKTP";
            this.textBoxNomorKTP.Size = new System.Drawing.Size(275, 20);
            this.textBoxNomorKTP.TabIndex = 23;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxEmail.Font = new System.Drawing.Font("Montserrat", 12F);
            this.textBoxEmail.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxEmail.Location = new System.Drawing.Point(48, 419);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(275, 20);
            this.textBoxEmail.TabIndex = 22;
            // 
            // textBoxPasswordKonfirmasi
            // 
            this.textBoxPasswordKonfirmasi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPasswordKonfirmasi.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Bold);
            this.textBoxPasswordKonfirmasi.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxPasswordKonfirmasi.Location = new System.Drawing.Point(381, 509);
            this.textBoxPasswordKonfirmasi.Name = "textBoxPasswordKonfirmasi";
            this.textBoxPasswordKonfirmasi.PasswordChar = '⚉';
            this.textBoxPasswordKonfirmasi.Size = new System.Drawing.Size(275, 17);
            this.textBoxPasswordKonfirmasi.TabIndex = 21;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPassword.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Bold);
            this.textBoxPassword.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxPassword.Location = new System.Drawing.Point(49, 508);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '⚉';
            this.textBoxPassword.Size = new System.Drawing.Size(275, 17);
            this.textBoxPassword.TabIndex = 20;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUsername.Font = new System.Drawing.Font("Montserrat", 12F);
            this.textBoxUsername.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxUsername.Location = new System.Drawing.Point(47, 334);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(275, 20);
            this.textBoxUsername.TabIndex = 19;
            // 
            // FormRegisterAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::_160420046_160420082_UTS.Properties.Resources.Form_Reegistration_Admin;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(704, 821);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.textBoxNomorTelepon);
            this.Controls.Add(this.textBoxNomorKTP);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxPasswordKonfirmasi);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsername);
            this.DoubleBuffered = true;
            this.Name = "FormRegisterAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormRegisterAdmin";
            this.Load += new System.EventHandler(this.FormRegisterAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox textBoxNomorTelepon;
        private System.Windows.Forms.TextBox textBoxNomorKTP;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxPasswordKonfirmasi;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
    }
}