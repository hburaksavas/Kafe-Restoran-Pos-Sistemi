using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerAnaSayfa
{
    public partial class Form_Masa_Islemleri : Form
    {
        public Form_Masa_Islemleri()
        {
            InitializeComponent();
        
        }
        public void updateDataGridViews()
        {
            DataTable table = BLL.Tables.masalariGetir();
            dataGridView_Guncelle.DataSource = table;
            dataGridView_Sil.DataSource = table;
            dataGridView_Guncelle.Columns[0].Visible = false;
            dataGridView_Sil.Columns[0].Visible = false;
            dataGridView_Guncelle.Columns[1].HeaderText = "Masa No";
            dataGridView_Guncelle.Columns[2].HeaderText = "Garson No";
            dataGridView_Guncelle.Columns[3].HeaderText = "Masa Durumu";
            dataGridView_Guncelle.Columns[4].HeaderText = "Açılış Tarihi";
            dataGridView_Guncelle.Columns[5].HeaderText = "Kapasite";
            dataGridView_Guncelle.Columns[6].HeaderText = "Hesap";
            dataGridView_Sil.Columns[1].HeaderText = "Masa No";
            dataGridView_Sil.Columns[2].HeaderText = "Garson No";
            dataGridView_Sil.Columns[3].HeaderText = "Masa Durumu";
            dataGridView_Sil.Columns[4].HeaderText = "Açılış Tarihi";
            dataGridView_Sil.Columns[5].HeaderText = "Kapasite";
            dataGridView_Sil.Columns[6].HeaderText = "Hesap";
        }
        private void Form_Masa_Islemleri_Load(object sender, EventArgs e)
        {
            Rectangle r = new Rectangle(tabPage1.Left,tabPage1.Top,tabPage1.Width,tabPage1.Height);
            tabControl1.Region = new Region(r);

            button_newMasaEkle.Enabled = false;
            button_newMasaIptal.Enabled = false;
            updateDataGridViews();
        }
        private void button_newMasaEkle_Click(object sender, EventArgs e)
        {
            string tableName = textBox_newMasaName.Text;
            int tableCapacity = Convert.ToInt32(numericUpDown_newMasaKapasite.Value);
            if (tableName.Equals(""))
            {
                UyariPenceresi bildir = new UyariPenceresi("Masa No Giriniz");
                bildir.ShowDialog();
            }
            else if (tableCapacity < 2)
            {
                UyariPenceresi bildir = new UyariPenceresi("Kapasite 2 de küçük olamaz");
                bildir.ShowDialog();
            }
            else
            {
                string response = BLL.Tables.masaEkle(tableName, tableCapacity);
                if (response.Equals("True"))
                {
                    UyariPenceresi bildir = new UyariPenceresi("Masa Başarıyla Eklendi\n Masa Adı: " +tableName+"\n Kapasite: "+tableCapacity);
                    bildir.ShowDialog();
                    updateDataGridViews();
                    textBox_newMasaName.Text = "";
                    numericUpDown_newMasaKapasite.Value = 2;
                }
                else
                {
                    UyariPenceresi bildir = new UyariPenceresi("Masa Ekleme Başarısız");
                    bildir.ShowDialog();
                }
            }

        }

     
        private void button_newMasaIptal_Click(object sender, EventArgs e)
        {
            textBox_newMasaName.Text = "";
            button_newMasaEkle.Enabled = false;
            button_newMasaIptal.Enabled = false;
        }

        private void textBox_newMasaName_TextChanged(object sender, EventArgs e)
        {
            button_newMasaIptal.Enabled = true;
            button_newMasaEkle.Enabled = true;
        }

        private void button_guncelleMasa_Click(object sender, EventArgs e)
        {
            string bildirim="";
            int tableID = Convert.ToInt32(dataGridView_Guncelle.CurrentRow.Cells["tableID"].Value);
            string tableNo = textBox_guncelleName.Text;
            int capacity = Convert.ToInt32(numericUpDown_guncelleKapasite.Value);
            if (tableNo == "")
            {
                bildirim += "Masa Adı Boş Bırakılamaz \n";
            }else if(capacity<2){
                bildirim += "Kapasite 2'den Küçük Olamaz";
            }
            else
            {
               string response= BLL.Tables.masaGuncelle(tableNo,capacity,tableID);
                if (response.Equals("True"))
                {
                    bildirim = "Masa Güncelleme Başarılı";

                    updateDataGridViews();
                    
                }
                else
                {
                    bildirim = "Masa Güncelleme Başarısız";
                }
            }
            UyariPenceresi uyari = new UyariPenceresi(bildirim);
            uyari.ShowDialog();
        }

        private void button_guncelleMasaIptal_Click(object sender, EventArgs e)
        {
            textBox_guncelleName.Text = "";
            numericUpDown_guncelleKapasite.Value = 2;
            button_guncelleMasa.Enabled = false;
            button_guncelleMasaIptal.Enabled = false;
        }

        private void dataGridView_Guncelle_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            string tableName = dataGridView_Guncelle.CurrentRow.Cells["tableNo"].Value.ToString();
            textBox_guncelleName.Text = tableName;
            if (dataGridView_Guncelle.CurrentRow.Cells["capacity"].Value.ToString().Equals(""))
            {

            }
            else
            {
            int capacity = Convert.ToInt32(dataGridView_Guncelle.CurrentRow.Cells["capacity"].Value);
            numericUpDown_guncelleKapasite.Value = capacity;
            }

        }

        private void dataGridView_Sil_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string tableName = dataGridView_Sil.CurrentRow.Cells["tableNo"].Value.ToString();
            label_silMasaName.Text = tableName;
        }

        private void button_silMasaEvet_Click(object sender, EventArgs e)
        {
            string bildirim = "";
            string tableName = dataGridView_Sil.CurrentRow.Cells["tableID"].Value.ToString();
            int tableID = Convert.ToInt32(tableName);
            if (label_silMasaName.Text.Equals(""))
            {
                bildirim = "Masa Seçmediniz";
            }
            else
            {
            bool response= BLL.Tables.masaSil(tableID);
                 if (response.Equals(true))
                 {
                    bildirim = "Masa Silindi";
                    updateDataGridViews();
                }
                else
                {
                     bildirim = "Masa Silinemiyor";
                }
            }
            
            UyariPenceresi pencere = new UyariPenceresi(bildirim);
            pencere.ShowDialog();
        }

        private void button_silMasaHayir_Click(object sender, EventArgs e)
        {
            label_silMasaName.Text = "";
        }

        private void button_TabEkle_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void button_TabGuncelle_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void button_TabSil_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
        }
    }
}
