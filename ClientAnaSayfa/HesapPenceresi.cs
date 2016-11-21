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
    public partial class HesapPenceresi : Form
    {
        ServiceReference1.Service1Client client = Client.wcfRequest();
        int tableID;
        string tableNo;
        double toplamHesap = 0; //Ödenen parça hesap
        public bool degisiklik = false; //1 İse Masa İçeriğinde Değişiklik Yapıldı Demektir

        public HesapPenceresi(int butonID,string tableNo)
        {
            InitializeComponent();
            this.tableID = butonID;
            this.tableNo = tableNo;
            Text = tableNo + " Hesap Sayfası"; //Form Başlığı
            listBoxAdisyon.Enabled = false;
            create();
        }
        public void create()
        {
            // tables = tableID[0],tableNo[1],userID[2],status[3],date[4],capacity[5],bill[6]
            DataTable tableMasaBilgileri = client.Tables_masaBilgileriniGetir(tableID);
            if (Convert.ToInt32(tableMasaBilgileri.Rows[0]["status"]) == 1)
            {
                //ADİSYON productID ye göre ürün ismi ,total ve total*fiyat listelenecek
                //orderID[0],catID[1],productID[2],tableID[3],total[4],[date[5]
                DataTable dt = client.Orders_masayaAitSiparisleriGetir(Convert.ToInt32(tableMasaBilgileri.Rows[0]["tableID"]));
                if (dt.Rows.Count > 0) //Sipariş varsa
                {
                    DataTable dtAdisyon = new DataTable();
                    DataRow rowTemp;
                    dtAdisyon.Clear();
                    dtAdisyon.Columns.Add("Ürün");
                    dtAdisyon.Columns.Add("Adet");
                    dtAdisyon.Columns.Add("Fiyat");
                    dtAdisyon.Columns.Add("orderID");
                    dtAdisyon.Columns.Add("productID");
                    DataGridViewCheckBoxColumn checkboxCol = new DataGridViewCheckBoxColumn();
                    dataGridHesap.Columns.Add(checkboxCol);
                    DataGridViewColumn column = dataGridHesap.Columns[0];
                    column.Width = 30; //Checkbox column genişliği
                    foreach (DataRow row in dt.Rows)
                    {
                        //productBilgileri = productID[0],catID[1],productName[2],price[3],status[4],description[5]
                        DataTable tableProduct = client.Product_urunBilgileriniGetir(Convert.ToInt32(row["productID"]));
                        rowTemp = dtAdisyon.NewRow();
                        rowTemp["Ürün"] = tableProduct.Rows[0]["productName"].ToString();
                        rowTemp["Adet"] = row["total"].ToString();
                        double price;
                        double.TryParse(tableProduct.Rows[0]["price"].ToString().Replace(".", ","), out price);
                        rowTemp["Fiyat"] = price * Convert.ToInt32(row["total"]);
                        rowTemp["orderID"] = row["orderID"].ToString();
                        rowTemp["productID"] = row["productID"].ToString();
                        dtAdisyon.Rows.Add(rowTemp);
                    }
                    dataGridHesap.DataSource = dtAdisyon;
                    dataGridHesap.Columns["orderID"].Visible = false; //orderID listelenmeyecek
                    dataGridHesap.Columns["productID"].Visible = false; //productID listelenmeyecek
                }
            }
        }

        private void buttonMasaKapat_Click(object sender, EventArgs e)
        {
            if (client.Tables_masaDurumGetir(tableID))
            {
                string uyariMesaji = "Masanın ";
                uyariMesaji += client.Tables_masaHesapGetir(tableID);
                uyariMesaji += " Hesabı Bulunmaktadır";
                UyariPenceresi uyari = new UyariPenceresi("Uyarı", uyariMesaji, "MASAYI KAPAT", "İPTAL");
                uyari.ShowDialog();
                if (uyari.secim)
                {
                    degisiklik = true;
                    client.Tables_masaKapat(tableID);
                    MessageBox.Show(tableNo+" Kapatıldı");
                    Close();
                }
            }
            else
                MessageBox.Show("Bir hata oluştu. Masa açık durumda değil.", "Hata");
        }

        private void buttonAdisyonAyir_Click(object sender, EventArgs e)
        {
            listBoxAdisyon.Enabled = true;
            double odenenHesap = 0;
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dataGridHesap.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    int productID = Convert.ToInt32(row.Cells[5].Value.ToString());
                    int total = Convert.ToInt32(row.Cells[2].Value.ToString());
                    int tabID = tableID;
                    if (Convert.ToBoolean(client.Orders_siparisSil(tableID, productID, total)))
                    {
                        double fiyat;
                        double.TryParse(row.Cells[3].Value.ToString().Replace(".", ","), out fiyat);
                        odenenHesap += fiyat;
                        toplamHesap += fiyat;
                        string urunAdi = row.Cells[1].Value.ToString();
                        listBoxAdisyon.Items.Add(total+" Adet "+urunAdi);
                        labelToplam.Text = toplamHesap.ToString();
                        rows.Add(row);
                        degisiklik = true;
                    }
                }
            }
            foreach (DataGridViewRow row in rows)
            {
                dataGridHesap.Rows.Remove(row);
            }
            MessageBox.Show("Ödenen Tutar: " + odenenHesap);
            if (dataGridHesap.Rows.Count <= 0)
            {
                MessageBox.Show(tableNo + " Kapatıldı");
                client.Tables_masaKapat(tableID);
                Close();
            }
        }

        private void buttonIptal_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
