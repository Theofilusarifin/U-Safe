
namespace _160420046_160420082_UTS
{
    partial class FormAdminAddMedicine
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
            this.textBoxNama = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxHarga = new System.Windows.Forms.TextBox();
            this.textBoxStock = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxNama
            // 
            this.textBoxNama.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNama.Font = new System.Drawing.Font("Montserrat", 12F);
            this.textBoxNama.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxNama.Location = new System.Drawing.Point(56, 262);
            this.textBoxNama.Name = "textBoxNama";
            this.textBoxNama.Size = new System.Drawing.Size(339, 20);
            this.textBoxNama.TabIndex = 0;
            // 
            // buttonAdd
            // 
            this.buttonAdd.AutoSize = true;
            this.buttonAdd.BackColor = System.Drawing.Color.Transparent;
            this.buttonAdd.BackgroundImage = global::_160420046_160420082_UTS.Properties.Resources.Button_Leave;
            this.buttonAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Location = new System.Drawing.Point(37, 504);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(379, 44);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            this.buttonAdd.MouseEnter += new System.EventHandler(this.buttonAdd_MouseEnter);
            this.buttonAdd.MouseLeave += new System.EventHandler(this.buttonAdd_MouseLeave);
            // 
            // textBoxHarga
            // 
            this.textBoxHarga.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxHarga.Font = new System.Drawing.Font("Montserrat", 12F);
            this.textBoxHarga.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxHarga.Location = new System.Drawing.Point(56, 341);
            this.textBoxHarga.Name = "textBoxHarga";
            this.textBoxHarga.Size = new System.Drawing.Size(339, 20);
            this.textBoxHarga.TabIndex = 1;
            // 
            // textBoxStock
            // 
            this.textBoxStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxStock.Font = new System.Drawing.Font("Montserrat", 12F);
            this.textBoxStock.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxStock.Location = new System.Drawing.Point(56, 421);
            this.textBoxStock.Name = "textBoxStock";
            this.textBoxStock.Size = new System.Drawing.Size(339, 20);
            this.textBoxStock.TabIndex = 2;
            // 
            // FormAdminAddMedicine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::_160420046_160420082_UTS.Properties.Resources.Form_Add_Medicine;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(452, 599);
            this.Controls.Add(this.textBoxStock);
            this.Controls.Add(this.textBoxHarga);
            this.Controls.Add(this.textBoxNama);
            this.Controls.Add(this.buttonAdd);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "FormAdminAddMedicine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAdminAddMedicine";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNama;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxHarga;
        private System.Windows.Forms.TextBox textBoxStock;
    }
}