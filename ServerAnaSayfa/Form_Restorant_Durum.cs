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
    public partial class Form_Restorant_Durum : Form
    {
        string versiyon = "0";
        Timer versionTimer = new Timer();
        List<Masalar> masaListesi = new List<Masalar>();
        List<Siparisler> siparisListesi = new List<Siparisler>();

        Bitmap acikMasa = Properties.Resources.openMasa;
        Bitmap kapaliMasa = Properties.Resources.closeMasa;
        int acikMasaSayisi, kapaliMasaSayisi;
        public Form_Restorant_Durum()
        {
            InitializeComponent();

        }
        private void Form_Restorant_Durum_Load(object sender, EventArgs e)
        {
            ListAdapter();
            versionTimer.Tick += new EventHandler(checkDB);
            versionTimer.Start();
        }
        void checkDB(object sender, EventArgs e)
        {
            versionTimer.Interval = 10000; //10 Saniyede bir kontrol
            string dbVersion = BLL.Program.getDBVersion();
            string[] degerler = dbVersion.Split('#');
            string check = degerler[1]; //Update
            if (check.Equals(versiyon))
            {
                return;
            }
            startEvent();
        }
        void startEvent()
        {
            ListAdapter();
            panel_Tables.Controls.Clear();
            butunMasalar();
            string id = "";
            DataTable dt = BLL.Tables.acikMasalariGetir();
            if (dt.Rows.Count > 0)
                id = Convert.ToString(dt.Rows[0]["tableID"]);
            foreach (Masalar masa in masaListesi)
            {
                if (id.Equals(masa.masaId))
                {
                    label_masano.Text = masa.masaAd;
                    label_masagarson.Text = masa.garsonId;
                    label_masakapasite.Text = masa.kapasite;
                    label_hesap.Text = masa.hesap;
                    label_masatarih.Text = masa.tarih;
                    if (masa.masaDurum.Equals("True"))
                    {
                        label_masadurumu.Text = "Açık";
                        label_masadurumu.ForeColor = Color.Green;
                    }
                    else
                    {
                        label_masadurumu.Text = "Kapalı";
                        label_masadurumu.ForeColor = Color.Red;
                    }
                    ListViewSiparisAdapter(Convert.ToInt32(masa.masaId));
                }
            }
        }
        public void ListViewSiparisAdapter(int tableID)
        {
            try
            {
            siparisListesi.Clear();
                listView1.Clear();
                listView1.Columns.Add("Sipariş", 100, HorizontalAlignment.Left);
                listView1.Columns.Add("Adet", 100, HorizontalAlignment.Left);
                listView1.Columns.Add("Sipariş Tarihi", 121, HorizontalAlignment.Left);
                colorListViewHeader(ref listView1, ColorTranslator.FromHtml("#95AFBD"), Color.AntiqueWhite);
                string productName="";
            DataTable table = BLL.Orders.masayaAitSiparisleriGetir(tableID);

            if (!table.Equals(null))
                foreach (DataRow datarow in table.Rows)
                {
                    object[] arr = datarow.ItemArray;
                    for (int i = 0; i < arr.Length; i = i+6)
                    {
                        DataTable tableUrunBil = BLL.Product.urunBilgileriniGetir(Convert.ToInt32(arr[i + 2]));
                        foreach (DataRow dataUrun in tableUrunBil.Rows)
                        {
                            object[] obj = dataUrun.ItemArray;
                            productName = obj[2].ToString();
                        }
                        siparisListesi.Add(new Siparisler {
                            urunAd = productName,
                            adet = arr[i + 4].ToString(),
                            date=arr[i+5].ToString(),
                            tableNo=tableID.ToString()                 
                        }); 
                    }
                }
            int k = 0;
            foreach(Siparisler siparis in siparisListesi)
            {
                listView1.Items.Add(siparis.urunAd);
                listView1.Items[k].SubItems.Add(siparis.adet);
                listView1.Items[k].SubItems.Add(siparis.date);
                k++;
            }
            }catch(Exception e)
            {

            }
          

        }
        public void ListAdapter()
        {
            masaListesi.Clear();
            DataTable tableAcikMasalar = BLL.Tables.acikMasalariGetir();
            DataTable tableKapaliMasalar = BLL.Tables.bosMasalariGetir();
            
            if (!tableAcikMasalar.Equals(null))
                foreach (DataRow datarow in tableAcikMasalar.Rows)
                {
                    object[] arr = datarow.ItemArray;
                    for (int i = 0; i < arr.Length; i = i + 7)
                    {
                        masaListesi.Add(
                            new Masalar
                            {
                                masaId = arr[i].ToString(),
                                masaAd = arr[i + 1].ToString(),
                                garsonId = arr[i + 2].ToString(),
                                masaDurum = arr[i + 3].ToString(),
                                tarih = arr[i + 4].ToString(),
                                kapasite = arr[i + 5].ToString(),
                                hesap = arr[i + 6].ToString()
                            });
                    }
                }
            acikMasaSayisi = masaListesi.Count;
            textBox_acikMasaSayisi.Text = acikMasaSayisi.ToString();

            if (!tableKapaliMasalar.Equals(null))
                foreach (DataRow datarow in tableKapaliMasalar.Rows)
                {
                    object[] arr = datarow.ItemArray;
                    for (int i = 0; i < arr.Length; i = i + 7)
                    {
                        masaListesi.Add(
                            new Masalar
                            {
                                masaId = arr[i].ToString(),
                                masaAd = arr[i + 1].ToString(),
                                garsonId = arr[i + 2].ToString(),
                                masaDurum = arr[i + 3].ToString(),
                                tarih = arr[i + 4].ToString(),
                                kapasite = arr[i + 5].ToString(),
                                hesap = arr[i + 6].ToString()
                            });
                    }
                }
            kapaliMasaSayisi = masaListesi.Count-acikMasaSayisi;
            textBox_kapaliMasaSayisi.Text = kapaliMasaSayisi.ToString();
        }
        /// <summary>
        /// Açık Masalar CheckBox'ı işaretlenince panele açık masaları çizer
        /// </summary>
        public void acikMasalar()
        {
            for (int i = 0; i < acikMasaSayisi; i++)
            {
                Label label = new Label();
                label.Text = masaListesi[i].masaAd;
                label.Name = masaListesi[i].masaId;
                label.Image = acikMasa;
                label.ImageAlign = ContentAlignment.MiddleCenter;
                label.TextAlign = ContentAlignment.TopCenter;
                label.Size = new Size(150, 120); label.Margin = new Padding(10, 75, 0, 0);
                label.Font = new Font("Times New Roman", 12, FontStyle.Bold);
                label.ForeColor = Color.Green;
                panel_Tables.Controls.Add(label);
                label.Click += Label_Click;
            }
        }
        /// <summary>
        /// Kapalı Masalar CheckBox'ı işaretlenince panele kapalı masaları çizer
        /// </summary>
        public void kapaliMasalar()
        {
            for (int i = 0; i <kapaliMasaSayisi; i++)
            {
                Label label = new Label();
                label.Text = masaListesi[acikMasaSayisi+i].masaAd;
                label.Name = masaListesi[acikMasaSayisi + i].masaAd;
                label.Image = kapaliMasa;
                label.ImageAlign = ContentAlignment.MiddleCenter;
                label.TextAlign = ContentAlignment.TopCenter;
                label.Size = new Size(150, 130); label.Margin = new Padding(10, 75, 0, 0);
                label.Font = new Font("Times New Roman", 12, FontStyle.Bold);
                label.ForeColor = Color.Red;
                panel_Tables.Controls.Add(label);
                label.Click += Label_Click;
            }
        }
        /// <summary>
        /// Bütün Masaları Çizer
        /// </summary>
        public void butunMasalar()
        {
            panel_Tables.Controls.Clear();
            for (int i = 0; i < masaListesi.Count; i++)
            {
                Label label = new Label();
                label.Text = masaListesi[i].masaAd;
                label.Name = masaListesi[i].masaId;
                if (masaListesi[i].masaDurum.Equals("True"))
                {
                    label.Image = acikMasa;
                    label.ForeColor = Color.Green;
                }
                else
                {
                    label.Image = kapaliMasa;
                    label.ForeColor = Color.Red;
                }
                
                label.ImageAlign = ContentAlignment.MiddleCenter;
                label.TextAlign = ContentAlignment.TopCenter;
                label.Size = new Size(150, 130); label.Margin = new Padding(10, 75, 0, 0);
                label.Font = new Font("Times New Roman", 12, FontStyle.Bold);
               
                panel_Tables.Controls.Add(label);
                label.Click += Label_Click;
            }
        }
        public void masaAramaveGoruntuleme(string masaAd)
        {
            int control = 0;
            foreach(Masalar masa in masaListesi)
            {
                if (masa.masaAd.Equals(masaAd) || masa.masaId.Equals(masaAd))
                {
                    control++;
                    panel_Tables.Controls.Clear();
                    Label label = new Label();
                    label.Text = masa.masaAd;
                    label.Name = masa.masaId;
                    ListViewSiparisAdapter(Convert.ToInt32(masa.masaId));
                    if (masa.masaDurum.Equals("True"))
                    {
                        label.Image = acikMasa;
                        label.ForeColor = Color.Green;
                    }
                    else
                    {
                        label.Image = kapaliMasa;
                        label.ForeColor = Color.Red;
                    }
                    
                    label.ImageAlign = ContentAlignment.MiddleCenter;
                    label.TextAlign = ContentAlignment.TopCenter;
                    label.Size = new Size(150, 120); label.Margin = new Padding(10, 75, 0, 0);
                    label.Font = new Font("Times New Roman", 12, FontStyle.Bold);
                 
                    panel_Tables.Controls.Add(label);
                    label.Click += Label_Click;
                }
              
            }  if (control < 1)
                {
                    UyariPenceresi pencere = new UyariPenceresi("Böyle Bir Masa Bulunmamaktadır");
                    pencere.ShowDialog();
                butunMasalar();
                }
        }
        private void Label_Click(object sender, EventArgs e)
        {
            Label lab = (Label)sender;
            string id = lab.Name;
            foreach(Masalar masa in masaListesi)
            {
                if (id.Equals(masa.masaId))
                {
                    label_masano.Text = masa.masaAd;
                    label_masagarson.Text = masa.garsonId;
                    label_masakapasite.Text = masa.kapasite;
                    label_hesap.Text = masa.hesap;
                    label_masatarih.Text = masa.tarih;
                    if (masa.masaDurum.Equals("True"))
                    {
                        label_masadurumu.Text = "Açık";
                        label_masadurumu.ForeColor = Color.Green;
                    }
                    else
                    {
                        label_masadurumu.Text = "Kapalı";
                        label_masadurumu.ForeColor = Color.Red;
                    }
                    ListViewSiparisAdapter(Convert.ToInt32(masa.masaId));
                }
            }
        }

   

        /// <summary>
        /// ListView başlık renk değiştirme
        /// </summary>
        /// <param name="list"></param>
        /// <param name="backColor"></param>
        /// <param name="foreColor"></param>
        public static void colorListViewHeader(ref ListView list, Color backColor, Color foreColor)
        {
            list.OwnerDraw = true;
            list.DrawColumnHeader +=
                new DrawListViewColumnHeaderEventHandler
                (
                    (sender, e) => headerDraw(sender, e, backColor, foreColor)
                );
            list.DrawItem += new DrawListViewItemEventHandler(bodyDraw);
        }
        private static void headerDraw(object sender, DrawListViewColumnHeaderEventArgs e, Color backColor, Color foreColor)
        {
            e.Graphics.FillRectangle(new SolidBrush(backColor), e.Bounds);
            e.Graphics.DrawString(e.Header.Text,new Font("Arial",9,FontStyle.Bold), new SolidBrush(foreColor), e.Bounds);
        }
        private static void bodyDraw(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void checkBox_acikMasalar_CheckedChanged(object sender, EventArgs e)
        {
            bool acikMasalarListele= checkBox_acikMasalar.Checked;
            bool kapaliMasalarListele = checkBox_kapaliMasalar.Checked;
            if (acikMasalarListele&&kapaliMasalarListele)
            {
                panel_Tables.Controls.Clear();
                butunMasalar();
            }
            else if (acikMasalarListele)
            {
                panel_Tables.Controls.Clear();
                acikMasalar();
            }
            else if (kapaliMasalarListele)
            {
                panel_Tables.Controls.Clear();
                kapaliMasalar();
            }
            else
            {
                panel_Tables.Controls.Clear();
            }
        }
        private void checkBox_kapaliMasalar_CheckedChanged(object sender, EventArgs e)
        {
            bool acikMasalarListele = checkBox_acikMasalar.Checked;
            bool kapaliMasalarListele = checkBox_kapaliMasalar.Checked;
            if (acikMasalarListele && kapaliMasalarListele)
            {
                panel_Tables.Controls.Clear();
                butunMasalar();
            }
            else if (acikMasalarListele)
            {
                panel_Tables.Controls.Clear();
                acikMasalar();
            }
            else if (kapaliMasalarListele)
            {
                panel_Tables.Controls.Clear();
                kapaliMasalar();
            }
            else
            {
                panel_Tables.Controls.Clear();
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            masaAramaveGoruntuleme(textBox_masaAra.Text);
        }
     

        private void textBox_masaAra_MouseClick(object sender, MouseEventArgs e)
        {
            textBox_masaAra.Text = "";
        }

        private void textBox_masaAra_Leave(object sender, EventArgs e)
        {
            textBox_masaAra.Text = "Masa No Veya Id Giriniz";
        }

        private void textBox_masaAra_Enter(object sender, EventArgs e)
        {
            masaAramaveGoruntuleme(textBox_masaAra.Text);
        }

        private void textBox_masaAra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(Keys.Enter)))
            {
                masaAramaveGoruntuleme(textBox_masaAra.Text);
            }
        }








        public class Masalar
        {
            public string masaAd { get; set; }
            public string masaId { get; set; }
            public string kapasite { get; set; }
            public string tarih { get; set; }
            public string garsonId { get; set; }
            public string masaDurum { get; set; }
            public string hesap { get; set; }

        }


        public class Siparisler
        {
            public string urunAd { get; set; }
            public string adet { get; set; }
            public string tableNo { get; set; }
            public string date { get; set; }
        }
    }

}
