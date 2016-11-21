using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ClientAnaSayfa
{
    public partial class formClientAnaSayfa : Form
    {
        Button butonMasa; //Seçili masa butonu
        Button sonSeciliButonMasa; //Bir önceki seçili masa
        int butonID=0;
        int sonSeciliButonID=0;
        double masaHesap = 0; //Seçili masanın hesabı
        int userID = 1;
        Timer saatTimer = new Timer();
        ServiceReference1.Service1Client client = Client.wcfRequest();

        public formClientAnaSayfa()
        {
            InitializeComponent();
            labelSistemAcilisSaati.Text += DateTime.Now.ToLongTimeString().ToString();
            labelSaat.Text = DateTime.Now.ToLongTimeString().ToString();
            labelTarih.Text = DateTime.Now.ToString("dd MMMM yyyy");
            saatTimer.Tick += new EventHandler(saat);
            saatTimer.Start();
            bool serverStatus = false;
            try
            {
                client.Test();
                client.TestDataTable();
                serverStatus = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Bağlantı Hatası : \n" +ex,"WCF Bağlantı Hatası");
            }
            if (serverStatus)
                masalariOlustur(0);
        }
        /// <summary>
        /// Masa Filterisi 0: Tüm Masalar 1: Açık Masalar 2: Boş Masalar(Kapalı Masalar)
        /// </summary>
        /// <param name="filtre"></param>
        public void masalariOlustur(int filtre) 
        {
            flowMasa.Controls.Clear();
            //Masalar DataTable Olarak Alınır
            DataTable dt = new DataTable();
            switch (filtre)
            {
                case 0: dt = client.Tables_masalariGetir(); break;
                case 1: dt = client.Tables_acikMasalariGetir(); break;
                case 2: dt = client.Tables_bosMasalariGetir(); break;
            }
            //DataTable dt =client.Tables_masalariGetir();
            foreach (DataRow row in dt.Rows)
            {
                Button button = new Button();
                button.Height = 70;
                button.Width = 150;
                button.FlatStyle = FlatStyle.Popup; //Buton kenarları
                button.ForeColor = Color.WhiteSmoke; //Buton yazı rengi
                button.Margin = new Padding(10); //Butonlar arası boşluk
                button.Font = new Font("Arial", 12, FontStyle.Bold); //Buton yazı stili
                button.Click += new EventHandler(buttonMasaClick); //Buton event
                button.Tag = row["tableID"];
                button.Text = row["tableNo"].ToString();
                if (Convert.ToInt32(row["status"]) == 0)
                    button.BackColor = Color.Red;
                else
                    button.BackColor = Color.Green;
                flowMasa.Controls.Add(button);
            }
        }
        void solPanelMasaBilgileriniTemizle()
        {
            label_masaAdi.Text = "---";
            label_acilisSaati.Text = "---";
            label_kisiSayisi.Text = "---";
            label_sonSiparisSaati.Text = "---";
            label_masaninAcikOlduguSure.Text = "---";
            text_hesap.Text = "0.00";
            dataGridAdisyon.DataSource = null;
            dataGridAdisyon.Rows.Clear();
            dataGridAdisyon.Refresh();
        }
        void solPanelMasaBilgileriniListele()
        {
            if (butonID != 0) //İlk açılışta açık bir masa seçilmediyse listeleme yapılmaması için
            {
                //tables = tableID[0],tableNo[1],userID[2],status[3],date[4],capacity[5],bill[6]
                DataTable tableMasaBilgileri = client.Tables_masaBilgileriniGetir(butonID);
                if (Convert.ToInt32(tableMasaBilgileri.Rows[0]["status"]) == 1)
                {
                    solPanelAcKapa(1);
                    label_masaAdi.Text = tableMasaBilgileri.Rows[0]["tableNo"].ToString();
                    label_acilisSaati.Text = tableMasaBilgileri.Rows[0]["date"].ToString();
                    label_kisiSayisi.Text = tableMasaBilgileri.Rows[0]["capacity"].ToString();
                    //orderID[0],catID[1],productID[2],tableID[3],total[4],[date[5]
                    DataTable dt = client.Orders_masayaAitSiparisleriGetir(Convert.ToInt32(tableMasaBilgileri.Rows[0]["tableID"]));
                    dataGridAdisyon.DataSource = dt;
                    if (dt.Rows.Count > 0) //Sipariş varsa
                    {
                        DataTable dtAdisyon = new DataTable();
                        DataRow rowTemp;
                        dtAdisyon.Clear();
                        dtAdisyon.Columns.Add("Ürün");
                        dtAdisyon.Columns.Add("Adet");
                        dtAdisyon.Columns.Add("Fiyat");
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
                            dtAdisyon.Rows.Add(rowTemp);
                        }
                        dataGridAdisyon.DataSource = dtAdisyon;
                        string sonSiparisSaati = dt.Rows[dt.Rows.Count - 1]["date"].ToString();
                        sonSiparisSaati = DateTime.Parse(sonSiparisSaati).ToShortTimeString().ToString();
                        label_sonSiparisSaati.Text = sonSiparisSaati;
                        TimeSpan sureFarki = DateTime.Now.Subtract(DateTime.Parse(sonSiparisSaati));
                        string gecenSure = "";
                        if (sureFarki.Hours > 0)
                            gecenSure += sureFarki.Hours + " Saat ";
                        gecenSure += sureFarki.Minutes + " Dakika";
                        label_masaninAcikOlduguSure.Text = gecenSure;
                        double value = Convert.ToDouble(tableMasaBilgileri.Rows[0]["bill"].ToString());
                        masaHesap = value;
                        text_hesap.Text = value.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)+" ₺";
                    }
                    else
                    {
                        DataTable dtAdisyon = new DataTable();
                        dtAdisyon.Clear();
                        dtAdisyon.Columns.Add("Ürün");
                        dtAdisyon.Columns.Add("Adet");
                        dtAdisyon.Columns.Add("Fiyat");
                        dataGridAdisyon.DataSource = dtAdisyon;
                        TimeSpan sureFarki = DateTime.Now.Subtract(DateTime.Parse(tableMasaBilgileri.Rows[0]["date"].ToString()));
                        string gecenSure = "";
                        if (sureFarki.Hours > 0)
                            gecenSure += sureFarki.Hours + " Saat ";
                        gecenSure += sureFarki.Minutes + " Dakika";
                        label_masaninAcikOlduguSure.Text = gecenSure;
                    }
                }
                else
                {
                    solPanelAcKapa(0);
                }
            }
        }
        void solPanelAcKapa(int secim) //0 Masa kapalı demektir paneli kapatır 1 açar
        {
            if (secim == 0)
            {
                foreach (Control ctrl in panelSol.Controls)
                {
                    
                    ctrl.Enabled = false;
                }           
                groupBox_adisyon.Enabled = true;
                groupBox_adisyon.ForeColor = SystemColors.ControlDark;
                dataGridAdisyon.Visible = false;
                buton_masaAcİptal.Enabled = true;
                buton_masaAc.Enabled = true;
                buton_masaAc.Visible = true;
                buton_masaAcİptal.Visible = true;
            }
            else
            {
                foreach (Control ctrl in panelSol.Controls)
                {
                    ctrl.Enabled = true;
                }
                groupBox_adisyon.ForeColor = SystemColors.ControlText;
                dataGridAdisyon.Visible = true;
                buton_masaAc.Visible = false;
                buton_masaAcİptal.Visible = false;
            }
        }
        void buttonMasaClick(object sender, EventArgs e)
        {
            solPanelMasaBilgileriniTemizle();
            sonSeciliButonMasa = butonMasa;
            sonSeciliButonID = butonID;
            butonMasa = (Button)sender;
            butonID = Convert.ToInt32(butonMasa.Tag);
            solPanelMasaBilgileriniListele();
        }
        void saat(object sender, EventArgs e)
        {
            saatTimer.Interval = 1000; //1000 = 1sec
            labelSaat.Text = DateTime.Now.ToLongTimeString().ToString();
            labelTarih.Text = DateTime.Now.ToString("dd MMMM yyyy");
        }
        private void buton_masaAc_Click(object sender, EventArgs e)
        {
            client.Tables_masaAc(userID, butonID);
            masalariOlustur(0);
            solPanelMasaBilgileriniListele();
        } 
        private void buton_masaAcİptal_Click(object sender, EventArgs e)
        {
            solPanelAcKapa(1);
            butonMasa = sonSeciliButonMasa; //Masa açma işlemi iptal edilirse son seçili masa bilgileri geri gelir
            butonID = sonSeciliButonID; //Son seçili masaid geri gelir
            solPanelMasaBilgileriniTemizle();
            solPanelMasaBilgileriniListele();
        }
        private void buton_hesap_Click(object sender, EventArgs e)
        {
            if (client.Tables_masaDurumGetir(butonID))
            {
                if (masaHesap != 0)
                {
                    HesapPenceresi hesap = new HesapPenceresi(butonID, butonMasa.Text);
                    hesap.ShowDialog();
                    if (hesap.degisiklik)
                    {
                        masalariOlustur(0);
                        solPanelMasaBilgileriniListele();
                    }
                }
                else
                    MessageBox.Show("Masada hesap bulunmamaktadır.","Uyarı");
            }
            else
                MessageBox.Show("Bir hata oluştu. Masa açık durumda değil.", "Hata");
        }
        private void buton_masaKapat_Click(object sender, EventArgs e)
        {
            if (client.Tables_masaDurumGetir(butonID))
            {
                string uyariMesaji = "Masanın ";
                uyariMesaji += text_hesap.Text;
                uyariMesaji += " Hesabı Bulunmaktadır";
                UyariPenceresi uyari = new UyariPenceresi("Uyarı", uyariMesaji, "MASAYI KAPAT", "İPTAL");
                uyari.ShowDialog();
                if (uyari.secim)
                {
                    client.Tables_masaKapat(butonID);
                    masalariOlustur(0);
                    solPanelMasaBilgileriniListele();
                }

            }
            else
                MessageBox.Show("Bir hata oluştu. Masa açık durumda değil.", "Hata");
        }
        private void buton_siparis_Click(object sender, EventArgs e)
        {
            if (client.Tables_masaDurumGetir(butonID))
            {
                SiparisSayfasi siparis = new SiparisSayfasi(butonID, butonMasa.Text);
                siparis.ShowDialog();
                if (siparis.degisiklik)
                {
                    masalariOlustur(0);
                    solPanelMasaBilgileriniListele();
                }
            }
            else
                MessageBox.Show("Bir hata oluştu. Masa açık durumda değil.", "Hata");
        }
        private void buttonMasaHepsi_Click(object sender, EventArgs e)
        {
            masalariOlustur(0);
        }
        private void buttonMasaAcik_Click(object sender, EventArgs e)
        {
            masalariOlustur(1);
        }
        private void buttonMasaBos_Click(object sender, EventArgs e)
        {
            masalariOlustur(2);
        }
    }
}
