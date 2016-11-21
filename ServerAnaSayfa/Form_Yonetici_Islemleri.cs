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
    public partial class Form_Yonetici_Islemleri : Form
    {
        int userID;
        public Form_Yonetici_Islemleri(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            BLL.Users.kullaniciBilgileriniGetir(userID);
            DataTable table = BLL.Users.yoneticileriGetir();
            DataColumn[] data = { table.Columns["userID"] };
            table.PrimaryKey = data;
            DataRow row = table.Rows.Find(userID);

            string ad = row["firstName"].ToString();
            string soyad = row["lastName"].ToString();
            string tcno = row["tcNo"].ToString();
            string telno = row["phoneNo"].ToString();
            string mail = row["mail"].ToString();
            string adres = row["address"].ToString();
            string cinsiyet = row["gender"].ToString();
            string sifre = row["password"].ToString();

            textBoxAD.Text = ad;
            textBoxTCNO.Text = tcno;
            textBoxSoyad.Text = soyad;
            textBoxMil.Text = mail;
            textBoxSifre.Text = sifre;
            richTextBoxAdres.Text = adres;
            maskedTextBoxTelNO.Text = telno;
            if (!cinsiyet.Equals("True"))
            {
                radioButton2.Select();
            }
      
        }
        private void Form_Yonetici_Islemleri_Load(object sender, EventArgs e)
        {
            Rectangle r = new Rectangle(tabPage1.Left, tabPage1.Top, tabPage1.Width, tabPage1.Height);
            tabControl1.Region = new Region(r);
        }

        private void buttonGuncelle_Click(object sender, EventArgs e)
        {
            string ad = textBoxAD.Text;
            string tcno = textBoxTCNO.Text;
            string soyad = textBoxSoyad.Text;
            string mail = textBoxMil.Text;
            string sifre = textBoxSifre.Text;
            string adres = richTextBoxAdres.Text; 
            string telno = maskedTextBoxTelNO.Text;
            int gender = 0;
            if (radioButton1.Checked.Equals(true))
            {
                gender = 1;
            }
           string response= BLL.Users.kullaniciGuncelle(ad, soyad, tcno, sifre, gender, mail, telno, adres, 1, this.userID);
            if (response.Equals("True"))
            {
                UyariPenceresi pencere = new UyariPenceresi("Bilgileriniz Güncellendi");
                pencere.ShowDialog();
            }
            else
            {
                UyariPenceresi pencere = new UyariPenceresi("Güncelleme Başarısız");
                pencere.ShowDialog();
            }
        }

        private void buttonYeniYonetici_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void buttonYeniYoneticiIptal_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
            textBox_yeniAd.Text="";
            textBoxt_yeniTc.Text="";
            textBox_yeniSoyad.Text="";
            textBox_yeniMail.Text="";
            textBox_yeniSifre.Text="";
            richTextBox_yeniAdres.Text="";
             maskedTextBox_yeniTel.Text="";
        }

        private void button_yeniEkle_Click(object sender, EventArgs e)
        {
            string ad = textBox_yeniAd.Text;
            string tcno = textBoxt_yeniTc.Text;
            string soyad = textBox_yeniSoyad.Text;
            string mail = textBox_yeniMail.Text;
            string sifre = textBox_yeniSifre.Text;
            string adres = richTextBox_yeniAdres.Text;
            string telno = maskedTextBox_yeniTel.Text;
            int gender = 0;
            if (radioButton_YeniErk.Checked.Equals(true))
            {
                gender = 1;
            }
            string response=BLL.Users.kullaniciEkle(ad, soyad, tcno, sifre, 1, mail, telno, adres,gender);
            if (response.Equals("True"))
            {
                UyariPenceresi pencere = new UyariPenceresi("Yeni Yönetici Oluşturuldu");
                pencere.ShowDialog();
                tabControl1.SelectTab(0);
                textBox_yeniAd.Text = "";
                textBoxt_yeniTc.Text = "";
                textBox_yeniSoyad.Text = "";
                textBox_yeniMail.Text = "";
                textBox_yeniSifre.Text = "";
                richTextBox_yeniAdres.Text = "";
                maskedTextBox_yeniTel.Text = "";
            }
            else
            {
                UyariPenceresi pencere = new UyariPenceresi("Alanlar Boş Bırakılamaz");
                pencere.ShowDialog();
            }
        }
    }
}
