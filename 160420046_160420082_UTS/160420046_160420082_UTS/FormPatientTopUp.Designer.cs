
namespace _160420046_160420082_UTS
{
    partial class FormPatientTopUp
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
            this.textBoxSaldo = new System.Windows.Forms.TextBox();
            this.buttonTopUp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxSaldo
            // 
            this.textBoxSaldo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSaldo.Font = new System.Drawing.Font("Montserrat", 12F);
            this.textBoxSaldo.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxSaldo.Location = new System.Drawing.Point(59, 264);
            this.textBoxSaldo.Name = "textBoxSaldo";
            this.textBoxSaldo.Size = new System.Drawing.Size(339, 20);
            this.textBoxSaldo.TabIndex = 19;
            // 
            // buttonTopUp
            // 
            this.buttonTopUp.AutoSize = true;
            this.buttonTopUp.BackColor = System.Drawing.Color.Transparent;
            this.buttonTopUp.BackgroundImage = global::_160420046_160420082_UTS.Properties.Resources.Button_Leave;
            this.buttonTopUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonTopUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTopUp.FlatAppearance.BorderSize = 0;
            this.buttonTopUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTopUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.buttonTopUp.ForeColor = System.Drawing.Color.White;
            this.buttonTopUp.Location = new System.Drawing.Point(38, 349);
            this.buttonTopUp.Name = "buttonTopUp";
            this.buttonTopUp.Size = new System.Drawing.Size(379, 44);
            this.buttonTopUp.TabIndex = 18;
            this.buttonTopUp.Text = "Top Up";
            this.buttonTopUp.UseVisualStyleBackColor = false;
            this.buttonTopUp.Click += new System.EventHandler(this.buttonTopUp_Click);
            this.buttonTopUp.MouseEnter += new System.EventHandler(this.buttonTopUp_MouseEnter);
            this.buttonTopUp.MouseLeave += new System.EventHandler(this.buttonTopUp_MouseLeave);
            // 
            // FormPatientTopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::_160420046_160420082_UTS.Properties.Resources.Form_Top_Up;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(452, 446);
            this.Controls.Add(this.textBoxSaldo);
            this.Controls.Add(this.buttonTopUp);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormPatientTopUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPatientTopUp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSaldo;
        private System.Windows.Forms.Button buttonTopUp;
    }
}