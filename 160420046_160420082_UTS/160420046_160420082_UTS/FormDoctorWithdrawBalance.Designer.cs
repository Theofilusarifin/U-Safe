
namespace _160420046_160420082_UTS
{
    partial class FormDoctorWithdrawBalance
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
            this.buttonWithdraw = new System.Windows.Forms.Button();
            this.textBoxSaldo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonWithdraw
            // 
            this.buttonWithdraw.AutoSize = true;
            this.buttonWithdraw.BackColor = System.Drawing.Color.Transparent;
            this.buttonWithdraw.BackgroundImage = global::_160420046_160420082_UTS.Properties.Resources.Button_Leave;
            this.buttonWithdraw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonWithdraw.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonWithdraw.FlatAppearance.BorderSize = 0;
            this.buttonWithdraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWithdraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.buttonWithdraw.ForeColor = System.Drawing.Color.White;
            this.buttonWithdraw.Location = new System.Drawing.Point(36, 351);
            this.buttonWithdraw.Name = "buttonWithdraw";
            this.buttonWithdraw.Size = new System.Drawing.Size(379, 44);
            this.buttonWithdraw.TabIndex = 16;
            this.buttonWithdraw.Text = "Withdraw";
            this.buttonWithdraw.UseVisualStyleBackColor = false;
            this.buttonWithdraw.Click += new System.EventHandler(this.buttonWithdraw_Click);
            this.buttonWithdraw.MouseEnter += new System.EventHandler(this.buttonWithdraw_MouseEnter);
            this.buttonWithdraw.MouseLeave += new System.EventHandler(this.buttonWithdraw_MouseLeave);
            // 
            // textBoxSaldo
            // 
            this.textBoxSaldo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSaldo.Font = new System.Drawing.Font("Montserrat", 12F);
            this.textBoxSaldo.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxSaldo.Location = new System.Drawing.Point(57, 265);
            this.textBoxSaldo.Name = "textBoxSaldo";
            this.textBoxSaldo.Size = new System.Drawing.Size(339, 20);
            this.textBoxSaldo.TabIndex = 17;
            // 
            // FormDoctorWithdrawBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::_160420046_160420082_UTS.Properties.Resources.Form_Withdraw_Balance;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(452, 446);
            this.Controls.Add(this.textBoxSaldo);
            this.Controls.Add(this.buttonWithdraw);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormDoctorWithdrawBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormWithdrawBalance";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonWithdraw;
        private System.Windows.Forms.TextBox textBoxSaldo;
    }
}