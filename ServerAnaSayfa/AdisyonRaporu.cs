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
    public partial class AdisyonRaporu : Form
    {

        public AdisyonRaporu()
        {
            InitializeComponent();
            DataTable dt = BLL.DayReport.raporlariGetir();
            if (dt.Rows.Count > 0)
            {
                comboBox_periyot.DataSource = dt;
                comboBox_periyot.ValueMember = "reportID";
                comboBox_periyot.DisplayMember = "date";
            }
        }
        private void button_gelirToplamlari_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = BLL.DayReport.raporlariGetir();
                chart1.Titles.Clear();
                chart1.Series.Clear();
                chart1.Series.Add("Gelirler");
                chart1.Series[0].Color = Color.Red;
                chart1.Series[0].ToolTip = "Gelir: #VALY";
                foreach (DataRow row in dt.Rows)
                {
                    chart1.Series[0].Points.AddXY(Convert.ToDateTime(row["date"]), Convert.ToDouble(row["income"])); //Tarih , Gelir
                }
                chart1.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Grafik Çizim Hatası: " + ex);
            }
        }
        private void button_adisyonToplamlari_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = BLL.DayReport.raporlariGetir();
                chart1.Titles.Clear();
                chart1.Series.Clear();
                chart1.Series.Add("Adisyon Sayısı");
                chart1.Series.Add("Ortalama Adisyon Geliri");
                chart1.Series[0].Color = Color.Red;
                chart1.Series[0].ToolTip = "Adisyon Sayısı: #VALY";
                chart1.Series[1].Color = Color.Blue;
                chart1.Series[1].ToolTip = "Ortalama Adisyon Geliri: #VALY";
                foreach (DataRow row in dt.Rows)
                {
                    chart1.Series[0].Points.AddXY(Convert.ToDateTime(row["date"]), Convert.ToInt16(row["tableCount"])); //Tarih , AdisyonSayısı
                    double ortalamaGelir = 0;
                    double adisyonSayisi = Convert.ToDouble(row["tableCount"]);
                    double toplamGelir = Convert.ToDouble(row["income"]);
                    ortalamaGelir = toplamGelir / adisyonSayisi;
                    chart1.Series[1].Points.AddXY(Convert.ToDateTime(row["date"]), ortalamaGelir); //Tarih , AdisyonOrtalamaGelir
                }
                chart1.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Grafik Çizim Hatası: " + ex);
            }
        }
        private void button_calisanIstatistikleri_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = BLL.DayReport.raporlariGetir();
                chart1.Titles.Clear();
                chart1.Series.Clear();
                chart1.Series.Add("Çalışan Sayısı");
                chart1.Series[0].Color = Color.Red;
                chart1.Series[0].ToolTip = "Garson Sayısı: #VALY";
                foreach (DataRow row in dt.Rows)
                {
                    string workers = row["workers"].ToString();
                    string[] calisanlar = workers.Split('#');
                    chart1.Series[0].Points.AddXY(Convert.ToDateTime(row["date"]), calisanlar.Length - 1); //Tarih , GarsonSayısı
                }
                chart1.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Grafik Çizim Hatası: " + ex);
            }
        }
        private void combobox_periyot_selectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)comboBox_periyot.SelectedItem;
            string date = drv["date"].ToString(); 
            if (date != null)
            {

                DataTable dt = BLL.DayReport.guneAitRaporGetir(date);
                if (dt.Rows.Count > 0)
                {
                    label_tarih.Text = dt.Rows[0]["date"].ToString();
                    double bill = Convert.ToDouble(dt.Rows[0]["income"]);
                    label_gelir.Text = bill.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                    label_adisyonSayisi.Text = dt.Rows[0]["tableCount"].ToString();
                    double ortalamaGelir = 0;
                    double adisyonSayisi = Convert.ToDouble(dt.Rows[0]["tableCount"]);
                    double toplamGelir = Convert.ToDouble(dt.Rows[0]["income"]);
                    ortalamaGelir = toplamGelir / adisyonSayisi;
                    label_ortalamaAdisyonGeliri.Text = ortalamaGelir.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                    string workers = dt.Rows[0]["workers"].ToString();
                    string[] calisanlar = workers.Split('#');
                    label_calisanSayisi.Text = (calisanlar.Length - 1).ToString();
                }
            }
        }
    }
}
