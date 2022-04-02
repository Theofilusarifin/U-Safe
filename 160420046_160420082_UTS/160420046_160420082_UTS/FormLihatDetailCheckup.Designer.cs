
namespace _160420046_160420082_UTS
{
    partial class FormLihatDetailCheckup
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
            this.btnClose = new System.Windows.Forms.Button();
            this.listBoxCheckup = new System.Windows.Forms.ListBox();
            this.btnCetak = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(445, 466);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // listBoxCheckup
            // 
            this.listBoxCheckup.FormattingEnabled = true;
            this.listBoxCheckup.Location = new System.Drawing.Point(37, 38);
            this.listBoxCheckup.Name = "listBoxCheckup";
            this.listBoxCheckup.Size = new System.Drawing.Size(483, 407);
            this.listBoxCheckup.TabIndex = 2;
            // 
            // btnCetak
            // 
            this.btnCetak.Location = new System.Drawing.Point(37, 466);
            this.btnCetak.Name = "btnCetak";
            this.btnCetak.Size = new System.Drawing.Size(75, 23);
            this.btnCetak.TabIndex = 3;
            this.btnCetak.Text = "Cetak";
            this.btnCetak.UseVisualStyleBackColor = true;
            this.btnCetak.Click += new System.EventHandler(this.btnCetak_Click);
            // 
            // FormLihatDetailCheckup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 510);
            this.Controls.Add(this.btnCetak);
            this.Controls.Add(this.listBoxCheckup);
            this.Controls.Add(this.btnClose);
            this.Name = "FormLihatDetailCheckup";
            this.Text = "FormLihatDetailCheckup";
            this.Load += new System.EventHandler(this.FormLihatDetailCheckup_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListBox listBoxCheckup;
        private System.Windows.Forms.Button btnCetak;
    }
}