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
    public partial class Form_Urun_Islemleri : Form
    {
        List<Category> kategoriList = new List<Category>();

        public Form_Urun_Islemleri()
        {
            InitializeComponent();
        }

        private void Form_Urun_Islemleri_Load(object sender, EventArgs e)
        {

            comboboxAdapter();
            categorylistAdapter();
            dataGridViewsUpdater();
            //TabbedPage'in tabPage Görünümünü Saklama
            Rectangle r = new Rectangle(tabPage1.Left, tabPage1.Top, tabPage1.Width, tabPage1.Height);
            tabControl1.Region = new Region(r);
            groupBox_Silme.Visible = false;
            groupBoxGuncelleme.Visible = false;
        }
        public void categorylistAdapter()
        {
            DataTable table = BLL.Category.kategorileriGetir();
            List<string> categories = new List<string>();
            foreach (DataRow datarow in table.Rows)
            {
                object[] arr = datarow.ItemArray;
                for (int i = 0; i < arr.Length; i++)
                {
                    categories.Add(arr[i].ToString());
                }
            }
           
            for (int i = 0; i < categories.Count; i = i + 3)
            {
              
                kategoriList.Add(new Category { catID = Convert.ToInt32(categories[i]), catName = categories[i + 1] });
            }
        }
        public void comboboxAdapter()
        {
            DataTable table = BLL.Category.kategorileriGetir();
            List<string> categories = new List<string>();
            foreach (DataRow datarow in table.Rows)
            {
                object[] arr = datarow.ItemArray;
                for (int i = 0; i < arr.Length; i++) 
                {
                    categories.Add(arr[i].ToString());
                }
            }
            comboBox_yeni_kategori.Items.Add("Kategoriler");
            comboBox_Guncelle.Items.Add("Kategoriler");
            for (int i = 1; i < categories.Count; i = i + 3)
            {
                comboBox_yeni_kategori.Items.Add(categories[i]);
                comboBox_Guncelle.Items.Add(categories[i]);
            }
            comboBox_yeni_kategori.SelectedIndex = 0;
            comboBox_Guncelle.SelectedIndex = 0;
        }
        public void dataGridViewsUpdater()
        {
            DataTable dataTable = BLL.Product.urunleriGetir();
            dataGridView_Sil.DataSource = dataTable;
            dataGridView_Guncelle.DataSource = dataTable;
            dataGridView_Guncelle.Columns[0].Visible = false;
            dataGridView_Sil.Columns[0].Visible = false;
            dataGridView_Guncelle.Columns[1].Visible = false;
            dataGridView_Sil.Columns[1].Visible = false;
            dataGridView_Guncelle.Columns[1].HeaderText = "Kategori ID";
            dataGridView_Guncelle.Columns[2].HeaderText = "Ürün Adı";
            dataGridView_Guncelle.Columns[3].HeaderText = "Fiyat";
            dataGridView_Guncelle.Columns[4].HeaderText = "Stokta Var";
            dataGridView_Guncelle.Columns[5].HeaderText = "Açıklama";
            dataGridView_Sil.Columns[1].HeaderText = "Kategori ID";
            dataGridView_Sil.Columns[2].HeaderText = "Ürün Adı";
            dataGridView_Sil.Columns[3].HeaderText = "Fiyat";
            dataGridView_Sil.Columns[4].HeaderText = "Stokta Var";
            dataGridView_Sil.Columns[5].HeaderText = "Açıklama";
        }
        private void button_TabYeni_Click(object sender, EventArgs e)
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
        private void button_yeniUrunEkle_Click(object sender, EventArgs e)
        {
            if (comboBox_yeni_kategori.SelectedIndex == 0)
            {
                UyariPenceresi pencere = new UyariPenceresi("Kategori Seçmediniz");
                pencere.ShowDialog();
            }
            else
            {
                int catID=-1;
                string productName = txtbox_yeniUrun.Text;
                string name = comboBox_yeni_kategori.SelectedItem.ToString();
                foreach(Category cat in kategoriList)
                {
                    if (name.Equals(cat.catName))
                    {
                        catID = cat.catID;
                    }
                }
                string fiyat =Convert.ToString( numericUpDown_yeniFiyat.Value);
                string aciklama = richTextBox_yeniAciklama.Text;
                if (catID == -1 && numericUpDown_yeniFiyat.Value < 0 &&productName.Equals(""))
                {
                    UyariPenceresi pencere = new UyariPenceresi("Alanlar Boş Bırakılamaz");
                    pencere.ShowDialog();
                }
                else
                {
                   string response= BLL.Product.urunEkle(catID,productName, fiyat, aciklama);
                    if (response.Equals(true))
                    {
                        UyariPenceresi pencere = new UyariPenceresi("Ürün Başarıyla Eklendi");
                        pencere.ShowDialog();
                        dataGridViewsUpdater();
                    }
                    else
                    {
                        UyariPenceresi pencere = new UyariPenceresi("Ürün Ekleme Başarısız");
                        pencere.ShowDialog();
                    }
                }
            }
            
        }
        private void button_yeniUrunEkleIptal_Click(object sender, EventArgs e)
        {
            txtbox_yeniUrun.Text = "";
            comboBox_yeni_kategori.SelectedIndex = 0;
            numericUpDown_yeniFiyat.Value = 0;
            richTextBox_yeniAciklama.Text = "";
        }
        private void dataGridView_Guncelle_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            groupBoxGuncelleme.Visible = true;
            richTextBox_Guncelle.Text = dataGridView_Guncelle.CurrentRow.Cells["description"].Value.ToString();
            textBox_GuncelleProductName.Text = dataGridView_Guncelle.CurrentRow.Cells["productName"].Value.ToString();
            string price = dataGridView_Guncelle.CurrentRow.Cells["price"].Value.ToString().Replace(".", ",");
            numericUpDown2.Value = Convert.ToDecimal(price);
            int catID = Convert.ToInt32(dataGridView_Guncelle.CurrentRow.Cells["catID"].Value);
            foreach(Category cat in kategoriList)
            {
                if (catID.Equals(cat.catID))
                {
                comboBox_Guncelle.SelectedItem = cat.catName;
                }
            }
            
           
        }
        private void button_Guncelle_Click(object sender, EventArgs e)
        {
            string bildirim = "";
            int control = 0;
            string productName = dataGridView_Guncelle.CurrentRow.Cells["productName"].Value.ToString();
            if (productName.Equals(""))
            {
                bildirim += "Ürün İsmi Boş Bırakılamaz";
                control++;
            }
            string price = numericUpDown2.Value.ToString();
            if (price.Equals("0"))
            {
                bildirim += "Fiyat 0 olamaz";
                control++;
            }
            if(control==0)
            {
            string description = richTextBox_Guncelle.Text;
            int catID = Convert.ToInt32(dataGridView_Guncelle.CurrentRow.Cells["catID"].Value);
            int productID = Convert.ToInt32(dataGridView_Guncelle.CurrentRow.Cells["productID"].Value);
            string response=BLL.Product.urunGuncelle(productName,price,1,description,catID,productID);
                if (response.Equals("True"))
                {
                    UyariPenceresi pencere = new UyariPenceresi("Ürün Güncelleme Başarılı");
                    pencere.ShowDialog();
                    dataGridViewsUpdater();
                }
                else
                {
                    UyariPenceresi pencere = new UyariPenceresi("Ürün Güncelleme Başarısız");
                    pencere.ShowDialog();
                }
            }
            else
            {
                UyariPenceresi pencere = new UyariPenceresi(bildirim);
                pencere.ShowDialog();
            }
        
        }
        private void button_GuncelleIptal_Click(object sender, EventArgs e)
        {
            richTextBox_Guncelle.Text = "";
            textBox_GuncelleProductName.Text = "";
            numericUpDown2.Value = 0;
            comboBox_Guncelle.SelectedIndex = 0;
            groupBoxGuncelleme.Visible = false;
        }
        private void button_ProductSil_Click(object sender, EventArgs e)
        {
            if (label5.Text.Equals(""))
            {
                UyariPenceresi penc = new UyariPenceresi("Tabloda Ürün Seçiniz");
                penc.ShowDialog();
            }
            else
            {
                    int productID = Convert.ToInt32(dataGridView_Sil.CurrentRow.Cells["productID"].Value);
                    bool response= BLL.Product.urunSiparisleriyleSil(productID);
                if (response.Equals(true))
                {
                    UyariPenceresi penc = new UyariPenceresi("Ürün Başarıyla Silindi");
                    penc.ShowDialog();
                    dataGridViewsUpdater();
                }
                else
                {
                    UyariPenceresi penc = new UyariPenceresi("Ürüne Dair Sipariş Bulunmaktadır \n Silinemiyor");
                    penc.ShowDialog();
                }
            }
           
        }
        private void button_ProductSilHayir_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            groupBox_Silme.Visible = false;
        }
        private void dataGridView_Sil_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label5.Text = dataGridView_Sil.CurrentRow.Cells["productName"].Value.ToString();
            groupBox_Silme.Visible = true;
        }
    }

    public class Category
    {
      public  int catID { get; set; }
      public  string catName { get; set; }
    }
}
