
namespace _160420046_160420082_UTS
{
    partial class FormPatientAddCheckUp
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
            this.buttonBook = new System.Windows.Forms.Button();
            this.dateTimePickerTanggalMulai = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerWaktuMulai = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // buttonBook
            // 
            this.buttonBook.AutoSize = true;
            this.buttonBook.BackColor = System.Drawing.Color.Transparent;
            this.buttonBook.BackgroundImage = global::_160420046_160420082_UTS.Properties.Resources.Button_Leave;
            this.buttonBook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonBook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBook.FlatAppearance.BorderSize = 0;
            this.buttonBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.buttonBook.ForeColor = System.Drawing.Color.White;
            this.buttonBook.Location = new System.Drawing.Point(37, 352);
            this.buttonBook.Name = "buttonBook";
            this.buttonBook.Size = new System.Drawing.Size(379, 44);
            this.buttonBook.TabIndex = 18;
            this.buttonBook.Text = "Book";
            this.buttonBook.UseVisualStyleBackColor = false;
            this.buttonBook.Click += new System.EventHandler(this.buttonBook_Click);
            this.buttonBook.MouseEnter += new System.EventHandler(this.buttonBook_MouseEnter);
            this.buttonBook.MouseLeave += new System.EventHandler(this.buttonBook_MouseLeave);
            // 
            // dateTimePickerTanggalMulai
            // 
            this.dateTimePickerTanggalMulai.CalendarFont = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTanggalMulai.CustomFormat = "";
            this.dateTimePickerTanggalMulai.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTanggalMulai.Location = new System.Drawing.Point(37, 268);
            this.dateTimePickerTanggalMulai.Name = "dateTimePickerTanggalMulai";
            this.dateTimePickerTanggalMulai.Size = new System.Drawing.Size(263, 26);
            this.dateTimePickerTanggalMulai.TabIndex = 19;
            // 
            // dateTimePickerWaktuMulai
            // 
            this.dateTimePickerWaktuMulai.CalendarFont = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerWaktuMulai.CustomFormat = "";
            this.dateTimePickerWaktuMulai.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerWaktuMulai.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerWaktuMulai.Location = new System.Drawing.Point(306, 268);
            this.dateTimePickerWaktuMulai.Name = "dateTimePickerWaktuMulai";
            this.dateTimePickerWaktuMulai.ShowUpDown = true;
            this.dateTimePickerWaktuMulai.Size = new System.Drawing.Size(110, 26);
            this.dateTimePickerWaktuMulai.TabIndex = 20;
            // 
            // FormPatientAddCheckUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::_160420046_160420082_UTS.Properties.Resources.Form_Add_Check_Up;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(452, 446);
            this.Controls.Add(this.dateTimePickerWaktuMulai);
            this.Controls.Add(this.dateTimePickerTanggalMulai);
            this.Controls.Add(this.buttonBook);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormPatientAddCheckUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPatientAddCheckUp";
            this.Load += new System.EventHandler(this.FormPatientAddCheckUp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBook;
        private System.Windows.Forms.DateTimePicker dateTimePickerTanggalMulai;
        private System.Windows.Forms.DateTimePicker dateTimePickerWaktuMulai;
    }
}