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
    public partial class YoneticiAnasayfa : Form
    {
        string versiyon = "0";
        Timer versionTimer = new Timer();

        public YoneticiAnasayfa()
        {
            InitializeComponent();
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
            create();
        }
        void create()
        {
            DataTable dt = BLL.Tables.masalariGetir();
            int masaSayisi = dt.Rows.Count;
            dt.Clear();
            dt = BLL.Tables.acikMasalariGetir();
            int acikMasaSayisi = dt.Rows.Count;
            double dolulukOraniDouble = ((double)acikMasaSayisi / masaSayisi) * 100;
            int dolulukOrani = Convert.ToInt16(dolulukOraniDouble);
            dt.Clear();
            dt = BLL.Category.kategorileriGetir();
            int kategoriSayisi = dt.Rows.Count;
            dt.Clear();
            dt = BLL.Product.urunleriGetir();
            int urunSayisi = dt.Rows.Count;
            dt.Clear();
            dt = BLL.Users.kullanicilariGetir();
            int kullaniciSayisi = dt.Rows.Count;
            dt.Clear();
            dt = BLL.DayReport.guneAitRaporGetir(DateTime.Now.ToShortDateString());
            string anlikToplamGelir = "0";
            if (dt.Rows.Count > 0)
                anlikToplamGelir = dt.Rows[0]["income"].ToString();
            //
            dt.Clear();
            dt = BLL.DayReport.raporlariGetir();
            int calisilanGunSayisi = dt.Rows.Count;
            double toplamGelir = 0;
            int toplamAdisyonSayisi = 0;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    toplamGelir += Convert.ToDouble(row["income"]);
                    toplamAdisyonSayisi += Convert.ToInt16(row["tableCount"]);
                }
            }
            int gunlukOrtalamaAdisyonSayisi = toplamAdisyonSayisi / calisilanGunSayisi;
            int ortalamaAdisyonGeliri = (int)toplamGelir / toplamAdisyonSayisi;
            int gunlukOrtalamaGelir = (int)toplamGelir / calisilanGunSayisi;
            //
            button_kafedolulukorani.Text = "%" + dolulukOrani.ToString();
            button_aktifmasasayisi.Text = acikMasaSayisi.ToString();
            button_tarih.Text = DateTime.Now.ToString("dd MMMM yyyy");
            button_toplammasa.Text = masaSayisi.ToString();
            button_kategori.Text = kategoriSayisi.ToString();
            button_urun.Text = urunSayisi.ToString();
            button_toplamcalisan.Text = kullaniciSayisi.ToString();
            button_anliktoplamgelir.Text = anlikToplamGelir.ToString();
            button_toplamcalisilangun.Text = calisilanGunSayisi.ToString();
            button_toplamgelir.Text = toplamGelir.ToString("0.##");
            button_toplamadisyonsayisi.Text = toplamAdisyonSayisi.ToString();
            button_gunlukortalamadisyonsayisi.Text = gunlukOrtalamaAdisyonSayisi.ToString();
            button_ortalamaadisyongeliri.Text = ortalamaAdisyonGeliri.ToString();
            button_gunlukortalamagelir.Text = gunlukOrtalamaGelir.ToString();
        }
    }
}
