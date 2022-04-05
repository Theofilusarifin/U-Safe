using System;
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
    public partial class FormDoctorPrescribeMedicine : Form
    {
        public FormDoctorPrescribeMedicine()
        {
            InitializeComponent();
        }

        List<Medicine> ListMed = new List<Medicine>();
        List<Medicine> MedPrescribe = new List<Medicine>();
        List<Checkup_Medicine> MedPrescript = new List<Checkup_Medicine>();

        Checkup_Medicine checkup_Medicine;
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

        #region Desain Button
        private void buttonFinish_MouseEnter(object sender, EventArgs e)
        {
            buttonFinish.BackgroundImage = Properties.Resources.Button_Hover;
        }
        private void buttonFinish_MouseLeave(object sender, EventArgs e)
        {
            buttonFinish.BackgroundImage = Properties.Resources.Button_Leave;
        }
        private void buttonSearch_MouseEnter(object sender, EventArgs e)
        {
            buttonSearch.BackgroundImage = Properties.Resources.Button_Hover;
        }
        private void buttonSearch_MouseLeave(object sender, EventArgs e)
        {
            buttonSearch.BackgroundImage = Properties.Resources.Button_Leave;
        }
        #endregion

        #region Methods
        private void FormatDataGridMed()
        {
            //Kosongi semua kolom di datagridview
            dataGridViewMed.Columns.Clear();

            //Menambah kolom di datagridview
            dataGridViewMed.Columns.Add("name", "Name");

            dataGridViewMed.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 142, 123);
            dataGridViewMed.EnableHeadersVisualStyles = false;

            //Agar lebar kolom dapat menyesuaikan panjang / isi data
            dataGridViewMed.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewMed.Columns["name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Agar user tidak bisa menambah baris maupun mengetik langsung di datagridview
            dataGridViewMed.AllowUserToAddRows = false;
            dataGridViewMed.ReadOnly = true;
        }

        private void TampilDataGridMed()
        {
            try
            {
                //Kosongi isi datagridview
                dataGridViewMed.Rows.Clear();

                // kalau list tidak kosong
                if (ListMed.Count > 0)
                {
                    // untuk setiap checkup di history
                    foreach (Medicine m in ListMed)
                    {
                        dataGridViewMed.Rows.Add(m.Name);
                    }
                }
                else
                {
                    dataGridViewMed.DataSource = null;
                }

                if (!dataGridViewMed.Columns.Contains("btnAddMed"))
                {
                    //Button tambah ke keranjang
                    DataGridViewButtonColumn bcolAddMed = new DataGridViewButtonColumn();

                    bcolAddMed.HeaderText = "";
                    bcolAddMed.Text = "Add to Med Prescript";
                    bcolAddMed.Name = "btnAddMed";
                    bcolAddMed.UseColumnTextForButtonValue = true;
                    bcolAddMed.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dataGridViewMed.Columns.Add(bcolAddMed);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormatDataGridPrescript()
        {
            //Kosongi semua kolom di datagridview
            dataGridViewPrescript.Columns.Clear();

            //Menambah kolom di datagridview
            dataGridViewPrescript.Columns.Add("name", "Name");
            dataGridViewPrescript.Columns.Add("price", "Price");
            dataGridViewPrescript.Columns.Add("amount", "Amount");

            dataGridViewPrescript.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 142, 123);
            dataGridViewPrescript.EnableHeadersVisualStyles = false;

            //Agar lebar kolom dapat menyesuaikan panjang / isi data
            dataGridViewPrescript.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPrescript.Columns["price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPrescript.Columns["amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewPrescript.Columns["name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Agar user tidak bisa menambah baris maupun mengetik langsung di datagridview
            dataGridViewPrescript.AllowUserToAddRows = false;
            dataGridViewPrescript.ReadOnly = true;
        }

        private void TampilDataGridPrescript()
        {
            try
            {
                //Kosongi isi datagridview
                dataGridViewPrescript.Rows.Clear();
                MedPrescript.Clear();

                #region MedPrescribe to MedPrescript
                bool helper;

                // kalau keranjang ada isinya
                if (MedPrescribe.Count > 0)
                {
                    // untuk setiap barang di keranjang
                    foreach (Medicine m in MedPrescribe)
                    {
                        // anggap barang dengan id yang sama tidak akan ketemu dahulu
                        helper = false;

                        // kalau list barang order ada isinya
                        if (MedPrescript.Count > 0)
                        {
                            // untuk setiap barang order di list barang order
                            foreach (Checkup_Medicine cm in MedPrescript)
                            {
                                // kalau id barang di keranjang sama dengan id barang order di list barang order
                                if (m.Id == cm.Medicine.Id)
                                {
                                    // ketemu barang dengan id yang sama 
                                    helper = true;

                                    // jumlah dan harga ditambah
                                    cm.Amount += 1;
                                    cm.Price += m.Price;

                                    // kalau ketemu langsung lanjut ke barang selanjutnya
                                    break;
                                }
                            }
                            // kalau tidak ada id yang sama
                            if (helper == false)
                            {
                                checkup_Medicine = new Checkup_Medicine(FormDoctorCheckUpSchedule.thisCheckup, m, 1, m.Price);
                                MedPrescript.Add(checkup_Medicine);
                            }
                        }
                        // kalau list barang order kosong
                        else
                        {
                            checkup_Medicine = new Checkup_Medicine(FormDoctorCheckUpSchedule.thisCheckup, m, 1, m.Price);
                            MedPrescript.Add(checkup_Medicine);
                        }
                    }
                }
                #endregion MedPrescribe to MedPrescript

                // kalau list tidak kosong
                if (MedPrescript.Count > 0)
                {
                    // untuk setiap med di med prescribe
                    foreach (Checkup_Medicine cm in MedPrescript)
                    {
                        dataGridViewPrescript.Rows.Add(cm.Medicine.Name, cm.Price, cm.Amount); ;
                    }
                }
                else
                {
                    dataGridViewPrescript.DataSource = null;
                }

                if (!dataGridViewPrescript.Columns.Contains("btnRemoveOneMed"))
                {
                    //Button tambah ke keranjang
                    DataGridViewButtonColumn bcolRemoveOneMed = new DataGridViewButtonColumn();

                    bcolRemoveOneMed.HeaderText = "";
                    bcolRemoveOneMed.Text = "-";
                    bcolRemoveOneMed.Name = "btnRemoveOneMed";
                    bcolRemoveOneMed.UseColumnTextForButtonValue = true;
                    bcolRemoveOneMed.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dataGridViewPrescript.Columns.Add(bcolRemoveOneMed);
                }

                if (!dataGridViewPrescript.Columns.Contains("btnRemove"))
                {
                    //Button tambah ke keranjang
                    DataGridViewButtonColumn bcolRemove = new DataGridViewButtonColumn();

                    bcolRemove.HeaderText = "";
                    bcolRemove.Text = "Remove";
                    bcolRemove.Name = "btnRemove";
                    bcolRemove.UseColumnTextForButtonValue = true;
                    bcolRemove.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dataGridViewPrescript.Columns.Add(bcolRemove);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion Methods

        #region Load
        private void FormDoctorPrescribeMedicine_Load(object sender, EventArgs e)
        {
            ListMed = Medicine.BacaData("name", txtMedName.Text);

            FormatDataGridMed();
            TampilDataGridMed();

            FormatDataGridPrescript();
            TampilDataGridPrescript();
        }
        #endregion Load

        #region btnClose
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion btnClose

        #region DataGridView
        private void dataGridViewMed_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string medName = dataGridViewMed.CurrentRow.Cells["name"].Value.ToString();

                if (e.ColumnIndex == dataGridViewMed.Columns["btnAddMed"].Index && e.RowIndex >= 0)
                {
                    Medicine m = Medicine.AmbilData(medName);
                    MedPrescribe.Add(m);
                    FormDoctorPrescribeMedicine_Load(sender, e);
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }

        private void dataGridViewPrescript_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string medName = dataGridViewPrescript.CurrentRow.Cells["name"].Value.ToString();
                Medicine m = Medicine.AmbilData(medName);

                // minus 1 obat
                if (e.ColumnIndex == dataGridViewPrescript.Columns["btnRemoveOneMed"].Index && e.RowIndex >= 0)
                {
                    
                    for (int i = 0; i < MedPrescribe.Count; i++)
                    {
                        if (MedPrescribe[i].Id == m.Id && MedPrescribe[i].Name == m.Name)
                        {
                            MedPrescribe.RemoveAt(i);
                            break;
                        }
                    }
                    FormDoctorPrescribeMedicine_Load(sender, e);
                }

                // minus semua obat yang dipilih
                if (e.ColumnIndex == dataGridViewPrescript.Columns["btnRemove"].Index && e.RowIndex >= 0)
                {
                    //User ditanya sesuai dibawah
                    DialogResult hasil = MessageBox.Show(this, "Are You sure to remove all " + m.Name + " from Prescription?",
                                                         "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //Kalau User klik yes barang akan dihapus
                    if (hasil == DialogResult.Yes)
                    {
                        MedPrescribe.RemoveAll(medicine => medicine.Id == m.Id);
                        
                        // refresh halaman
                        FormDoctorPrescribeMedicine_Load(sender, e);

                        MessageBox.Show("All " + m.Name + " has been removed from Prescription");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!\n" + ex.Message);
            }
        }
        #endregion DataGridView

        private void buttonFinish_Click(object sender, EventArgs e)
        {
            foreach (Checkup_Medicine cm in MedPrescript)
            {
                Checkup_Medicine.TambahData(cm);
                Medicine.UpdateStockMed(cm);
            }

            Checkup.FinishCheckup(FormDoctorCheckUpSchedule.thisCheckup);

            this.Close();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            FormDoctorPrescribeMedicine_Load(sender, e);
        }
    }
}
