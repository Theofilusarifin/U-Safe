
namespace _160420046_160420082_UTS
{
    partial class FormLogin
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
            this.pictureBoxMata = new System.Windows.Forms.PictureBox();
            this.labelRegistrasi = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMata)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxMata
            // 
            this.pictureBoxMata.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxMata.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxMata.Image = global::_160420046_160420082_UTS.Properties.Resources.Closed_Eye;
            this.pictureBoxMata.Location = new System.Drawing.Point(366, 390);
            this.pictureBoxMata.Name = "pictureBoxMata";
            this.pictureBoxMata.Size = new System.Drawing.Size(35, 27);
            this.pictureBoxMata.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMata.TabIndex = 13;
            this.pictureBoxMata.TabStop = false;
            // 
            // labelRegistrasi
            // 
            this.labelRegistrasi.AutoSize = true;
            this.labelRegistrasi.BackColor = System.Drawing.Color.White;
            this.labelRegistrasi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelRegistrasi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelRegistrasi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRegistrasi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(65)))), ((int)(((byte)(36)))));
            this.labelRegistrasi.Location = new System.Drawing.Point(243, 524);
            this.labelRegistrasi.Name = "labelRegistrasi";
            this.labelRegistrasi.Size = new System.Drawing.Size(152, 18);
            this.labelRegistrasi.TabIndex = 12;
            this.labelRegistrasi.Text = "&Lakukan Registrasi";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPassword.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Bold);
            this.textBoxPassword.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxPassword.Location = new System.Drawing.Point(48, 392);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '⚉';
            this.textBoxPassword.Size = new System.Drawing.Size(290, 17);
            this.textBoxPassword.TabIndex = 10;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUsername.Font = new System.Drawing.Font("Montserrat", 12F);
            this.textBoxUsername.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxUsername.Location = new System.Drawing.Point(48, 307);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(339, 20);
            this.textBoxUsername.TabIndex = 9;
            // 
            // buttonLogin
            // 
            this.buttonLogin.AutoSize = true;
            this.buttonLogin.BackColor = System.Drawing.Color.Transparent;
            this.buttonLogin.BackgroundImage = global::_160420046_160420082_UTS.Properties.Resources.Button_Leave;
            this.buttonLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLogin.FlatAppearance.BorderSize = 0;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.Location = new System.Drawing.Point(37, 459);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(379, 44);
            this.buttonLogin.TabIndex = 11;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.MouseEnter += new System.EventHandler(this.buttonLogin_MouseEnter);
            this.buttonLogin.MouseLeave += new System.EventHandler(this.buttonLogin_MouseLeave);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::_160420046_160420082_UTS.Properties.Resources.Login_Form;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(452, 599);
            this.Controls.Add(this.pictureBoxMata);
            this.Controls.Add(this.labelRegistrasi);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.buttonLogin);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login User";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxMata;
        private System.Windows.Forms.Label labelRegistrasi;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Button buttonLogin;
    }
}

