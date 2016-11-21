using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientAnaSayfa
{
    public partial class SiparisSayfasi : Form
    {
        int tableID;
        string tableNo;
        public bool degisiklik = false;
        int lastProductID=0; //Son işlem yapılan ürünün productID'si GERİ AL fonksiyonu için
        Stack productStack = new Stack(); //İşlem yapılan ürünlerin productID leri tutulur
        DataTable dt; //Ürünler tutulacak
        DataTable dtKategori; //Kategoriler tutulacak
        DataTable tableOrders = new DataTable();
        ServiceReference1.Service1Client client = Client.wcfRequest();
        public SiparisSayfasi(int butonID, string tableNo)
        {
            InitializeComponent();
            this.tableID = butonID;
            this.tableNo = tableNo;
            Text = tableNo + " Sipariş Sayfası"; //Form title
            tableOrders.Clear();
            tableOrders.Columns.Add("Ürün");
            tableOrders.Columns.Add("Birim Fiyatı");
            tableOrders.Columns.Add("Adet");
            tableOrders.Columns.Add("catID");
            tableOrders.Columns.Add("productID");
            dt = client.Product_akfitUrunleriGetir();
            dtKategori = client.Category_kategorileriGetir();
            kategorileriListele();
            urunleriListele(0); //Kategoride Hepsi Seçili Gibi Başlayacak Tüm Ürünler Gelecek
        }
        void kategorileriListele()
        {
            //Butonlara kategori isimleri ilk buton heps. Butonlara click event click eventte dt doldurulup create çalışacak
            flowLayoutKategori.Controls.Clear();
            Button button = new Button();
            button.Height = 40;
            button.Width = 110;
            button.AutoSize = true;
            button.FlatStyle = FlatStyle.Popup; //Buton kenarları
            button.ForeColor = SystemColors.ControlText; //Buton yazı rengi
            button.Margin = new Padding(2); //Butonlar arası boşluk
            button.BackColor = SystemColors.ControlLight;
            button.Font = new Font("Arial", 10, FontStyle.Regular); //Buton yazı stili
            button.Click += new EventHandler(buttonKategoriClick); //Buton event
            button.Text = "Hepsi";
            button.Tag = "0";
            flowLayoutKategori.Controls.Add(button);
            if (dtKategori.Rows.Count > 0)
            {
                foreach (DataRow row in dtKategori.Rows)
                {
                    button = new Button();
                    button.Height = 40;
                    button.Width = 110;
                    button.AutoSize = true;
                    button.FlatStyle = FlatStyle.Popup; //Buton kenarları
                    button.ForeColor = SystemColors.ControlText; //Buton yazı rengi
                    button.Margin = new Padding(2); //Butonlar arası boşluk
                    button.BackColor = SystemColors.ControlLight;
                    button.Font = new Font("Arial", 10, FontStyle.Regular); //Buton yazı stili
                    button.Click += new EventHandler(buttonKategoriClick); //Buton event
                    button.Text = row["catName"].ToString();
                    button.Tag = row["catID"].ToString();
                    flowLayoutKategori.Controls.Add(button);
                }
            }
        }
        void urunleriListele(int catID) //0 ise tüm ürünler getirilir
        {
            flowLayoutUrun.Controls.Clear();
            if (catID == 0)
                dt = client.Product_akfitUrunleriGetir();
            else
            {
                dt = client.Product_kategoriyeGoreUrunleriGetir(catID);
            }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Button button = new Button();
                    button.Height = 70;
                    button.Width = 150;
                    button.FlatStyle = FlatStyle.Popup; //Buton kenarları
                    button.ForeColor = Color.WhiteSmoke; //Buton yazı rengi
                    button.Margin = new Padding(5); //Butonlar arası boşluk
                    button.BackColor = Color.Teal;
                    button.Font = new Font("Arial", 12, FontStyle.Bold); //Buton yazı stili
                    button.Click += new EventHandler(buttonUrunClick); //Buton event
                    Product product = new Product();
                    product.productID = Convert.ToInt16(row["productID"]);
                    product.catID = Convert.ToInt16(row["catID"]);
                    product.productName = row["productName"].ToString();
                    product.price = row["price"].ToString();
                    product.description = row["description"].ToString();
                    button.Tag = product;
                    button.Text = row["productName"].ToString();
                    flowLayoutUrun.Controls.Add(button);
                }
            }
        }
        void buttonKategoriClick(object sender, EventArgs e)
        {
            Button buton = (Button)sender;
            int catID = Convert.ToInt32(buton.Tag);
            urunleriListele(catID);
        }
        void buttonUrunClick(object sender, EventArgs e)
        {
            Button buton = (Button)sender;
            Product product = (Product)buton.Tag;
            int productID = product.productID;
            productStack.Push(productID);
            int catID = product.catID;
            string productName = product.productName;
            string price = product.price;
            string description = product.description;
            DataRow[] filteredRows = tableOrders.Select("productID = '"+productID+"'");
            if(filteredRows.Length != 0)
            {
                filteredRows[0]["Adet"] = Convert.ToInt16(filteredRows[0]["Adet"])+1;
            }
            else
            {
                DataRow row;
                row = tableOrders.NewRow();
                row["Ürün"] = productName;
                row["Birim Fiyatı"] = price;
                row["Adet"] = 1;
                row["catID"] = catID;
                row["productID"] = productID;
                tableOrders.Rows.Add(row);
            }
            dataGridSiparis.DataSource = tableOrders;
            dataGridSiparis.Columns["catID"].Visible = false;
            dataGridSiparis.Columns["productID"].Visible = false;
        }

        private void buttonSiparisEkle_Click(object sender, EventArgs e)
        {
            if (tableOrders.Rows.Count > 0)
            {
                foreach (DataRow row in tableOrders.Rows)
                {
                    bool control = client.Orders_siparisEkle(tableID, Convert.ToInt16(row["productID"]), Convert.ToInt16(row["catID"]), Convert.ToInt16(row["Adet"]));
                    if (control)
                        degisiklik = true;
                }
                if (degisiklik)
                    MessageBox.Show("Siparişler Başarıyla Eklendi");
                else
                    MessageBox.Show("Siparişler Eklenirken Bir Hata Oluştu", "Hata");
                Close();
            }
            else
                MessageBox.Show("Hata", "İşlem yapmak için siparişe eklenecek ürünleri seçiniz.");
        }
        private void buttonIptal_Click(object sender, EventArgs e)
        {
            string secim1 = "SAYFAYI KAPAT"; //return true
            string secim2 = "İPTAL"; //return false
            UyariPenceresi uyari = new UyariPenceresi("SEÇİM", "Sipariş sayfasını kapatın yada\nsiparişleri iptal edin", secim1, secim2);
            uyari.ShowDialog();
            if (uyari.secim)
                Close();
            tableOrders.Clear();
            dataGridSiparis.DataSource = tableOrders;
        }
        private void buttonGeriAl_Click(object sender, EventArgs e)
        {
            lastProductID = (int)productStack.Pop();
            //Son yapılan işlem geri alnacak
            if (lastProductID != 0)
            {
                DataRow[] filteredRows = tableOrders.Select("productID = '" + lastProductID + "'");
                if (filteredRows.Length != 0) //Tabloda ürün varsa
                {
                    int yeniAdet = Convert.ToInt16(filteredRows[0]["Adet"]) - 1;
                    if (yeniAdet == 0) //Adet sıfırsa tablodan çıkar
                    {
                        for (int i = tableOrders.Rows.Count - 1; i >= 0; i--)
                        {
                            DataRow row = tableOrders.Rows[i];
                            if (row["productID"].ToString() == lastProductID.ToString())
                                row.Delete();
                        }
                    }
                    else
                        filteredRows[0]["Adet"] = yeniAdet;
                    dataGridSiparis.DataSource = tableOrders;
                    dataGridSiparis.Columns["catID"].Visible = false;
                    dataGridSiparis.Columns["productID"].Visible = false;
                }
            }
            else
                MessageBox.Show("Geri Alınabilecek İşlem Bulunmamaktadır");
        }
    }
    class Product
    {
        public int productID { get; set; }
        public int catID { get; set; }
        public string productName { get; set; }
        public string price { get; set; }
        public string description { get; set; }
    }
}
