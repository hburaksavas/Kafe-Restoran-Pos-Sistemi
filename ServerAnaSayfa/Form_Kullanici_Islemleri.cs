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
    public partial class Form_Kullanici_Islemleri : Form
    {
        string ad, soyad, mail, tcno, telno, sifre, adres;
        int cinsiyet;
        public Form_Kullanici_Islemleri()
        {
            InitializeComponent();
            updateDataGridViews();
            buttonSilEvet.Enabled = false;
            buttonSilEvet.Enabled = false;
            labelKullaniciadsoyad.Text = "";
            buttonGuncelle.Enabled = false;
            buttonGuncelleIptal.Enabled = false;
            button_Kullanici_Ekle.Enabled = true;
        }

        private void Form_Kullanici_Islemleri_Load(object sender, EventArgs e)
        {
            Rectangle r = new Rectangle(tabPage1.Left,tabPage1.Top,tabPage1.Width,tabPage1.Height);
            tabControl1.Region = new Region(r);

        }

        /// <summary>
        /// Güncelle ve Sil Tabbed Pane'inde bulunan DataGridView'leri işlem sonrası update eder+başlangıçta tabloları doldurur.
        /// </summary>
        public void updateDataGridViews()
        {
            DataTable table = BLL.Users.garsonlariGetir();
            dataGridView_Guncelle.DataSource = table;
            dataGridViewSil.DataSource = table;
            dataGridView_Guncelle.Columns[0].Visible = false;
            dataGridViewSil.Columns[0].Visible = false;
            dataGridView_Guncelle.Columns[1].HeaderText = "Ad";
            dataGridView_Guncelle.Columns[2].HeaderText = "Soyad";
            dataGridView_Guncelle.Columns[3].HeaderText = "Tc/Pasaport";
            dataGridView_Guncelle.Columns[4].HeaderText = "Şifre";
            dataGridView_Guncelle.Columns[5].Visible = false;
            dataGridView_Guncelle.Columns[6].HeaderText = "Cinsiyet";
            dataGridView_Guncelle.Columns[7].HeaderText = "Tel No";
            dataGridView_Guncelle.Columns[8].HeaderText = "Adres";
            dataGridView_Guncelle.Columns[9].HeaderText = "Mail";

            dataGridViewSil.Columns[1].HeaderText = "Ad";
            dataGridViewSil.Columns[2].HeaderText = "Soyad";
            dataGridViewSil.Columns[3].HeaderText = "Tc/Pasaport";
            dataGridViewSil.Columns[4].HeaderText = "Şifre";
            dataGridViewSil.Columns[5].Visible = false;
            dataGridViewSil.Columns[6].HeaderText = "Cinsiyet";
            dataGridViewSil.Columns[7].HeaderText = "Tel No";
            dataGridViewSil.Columns[8].HeaderText = "Adres";
            dataGridViewSil.Columns[9].HeaderText = "Mail";

        }
        /// <summary>
        /// Kullanıcı Bilgileri Değişti mi Kontrolü,Değişirse BLL ile bağlantı kurulacak değişmezse kullanıcıya bildirilecek
        /// </summary>
        /// <returns></returns>
        public bool guncelleDegisiklikKontrol()
        {
            int gender;
            string ad = dataGridView_Guncelle.CurrentRow.Cells["firstName"].Value.ToString();
            string soyad= dataGridView_Guncelle.CurrentRow.Cells["lastName"].Value.ToString();
            string tcno= dataGridView_Guncelle.CurrentRow.Cells["tcNo"].Value.ToString();
            string sifre = dataGridView_Guncelle.CurrentRow.Cells["password"].Value.ToString();
            string cinsiyet = dataGridView_Guncelle.CurrentRow.Cells["gender"].Value.ToString();
            string telno = dataGridView_Guncelle.CurrentRow.Cells["phoneNo"].Value.ToString();
            string adres = dataGridView_Guncelle.CurrentRow.Cells["address"].Value.ToString();
            string mail= dataGridView_Guncelle.CurrentRow.Cells["mail"].Value.ToString();
            if (cinsiyet.Equals("True"))
            {
                gender = 1;
            }
            else
            {
                gender = 0;
            }
            if (ad.Equals(this.ad) && soyad.Equals(this.soyad) && tcno.Equals(this.tcno) && sifre.Equals(this.sifre) && telno.Equals(this.telno) && adres.Equals(this.adres) && mail.Equals(this.mail))
            {
                if (this.cinsiyet == gender)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        private void buttonTabKullaniciEkle_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void buttonTabKullaniciGuncelle_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void buttonTabKullaniciSil_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        /// <summary>
        /// Yeni Kullanıcı Ekleme Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Kullanici_Ekle_Click(object sender, EventArgs e)
        {
            string ad = textBox_newUserAd.Text;
            int control = 0;
            string message="";
            if (ad == "")
            {
               
                control++;
                message += control+ "- Ad alanı boş bırakılamaz \n";
            }
            string soyad = textBox_newUserSoyad.Text;
            if (soyad == ""){
                
                control++;message += control + "- Soyad alanı boş bırakılamaz \n";
            }
            string mail = textBox_newUserMail.Text;
            if (mail == "")
            {
               
                control++; message += control + "- Mail alanı boş bırakılamaz \n";
            }
            string tcno = textBox_newUserTc.Text;
            if (tcno=="")
            {
              
                control++;  message += control + "- Tc No alanı boş bırakılamaz \n";
            }
            string telno = maskedTextBox_newUserTel.Text;
            if (telno == "")
            {
            
                control++;    message += control + "- Telefon Numarası alanı boş bırakılamaz \n";
            }
            string adres = richTextBoxAdresBilgisi.Text;
            string sifre = textBox_newUserSifre.Text;
            if (sifre == "")
            {
            
                control++;    message += control + "- Şifre alanı boş bırakılamaz \n";
            }
            int role = 0;
            int cinsiyet;
            if (radioButtonErkek.Checked != false)
            {
                cinsiyet = 1;
            }
            else
            {
                cinsiyet = 0;
            }

            if (control == 0)
            {
                string response= BLL.Users.kullaniciEkle(ad,soyad,tcno,sifre,role,mail,telno,adres,cinsiyet);

                if (response.Equals("True"))
                 {
                UyariPenceresi showmes = new UyariPenceresi("Kullanıcı Başarıyla Eklendi");
                showmes.Show();
                    updateDataGridViews();
                    button_Kullanici_Ekle.Enabled = false;
                 }
                 else
                {
                UyariPenceresi showmes = new UyariPenceresi("Kullanıcı Ekleme Başarısız");
                showmes.Show();
                }
            }
            else
            {
                UyariPenceresi showmes = new UyariPenceresi(message);
                showmes.Show();
            }

        }

        private void button_Kullanici_Ekle_Iptal_Click(object sender, EventArgs e)
        {
            textBox_newUserAd.Text = "";
            textBox_newUserMail.Text = "";
            textBox_newUserSifre.Text = "";
            textBox_newUserSoyad.Text = "";
            textBox_newUserTc.Text = "";
            maskedTextBox_newUserTel.Text = "";
            richTextBoxAdresBilgisi.Text = "";
            radioButtonErkek.Select();
            button_Kullanici_Ekle.Enabled = false;
        }
        /// <summary>
        /// Kullanıcı Bilgilerini Güncelle Eventi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGuncelle_Click(object sender, EventArgs e)
        {
            int userid  =    Convert.ToInt32(dataGridView_Guncelle.CurrentRow.Cells["userID"].Value);
            string ad   =    textBox_guncelleAd.Text;
            this.ad = ad;
            int control =    0;
            string message = "";
            if (ad == "")
            {
                control++; message += control + "- Ad alanı boş bırakılamaz \n";
            }
            string soyad = textBox_guncelleSoyad.Text;
            this.soyad = soyad;
            if (soyad == "")
            {
                control++; message += control + "- Soyad alanı boş bırakılamaz \n";
            }
            string mail = textBox_GuncelleMail.Text;
            this.mail = mail;
            if (mail == "")
            {
                control++; message += control + "- Mail alanı boş bırakılamaz \n";
            }
            string tcno = textBox_GuncelleTc.Text;
            this.tcno = tcno;
            if (tcno == "")
            {
                control++; message += control + "- Tc No alanı boş bırakılamaz \n";
            }
            string telno = maskedTextBox_guncelleTel.Text;
            this.telno = telno;
            if (telno == "")
            {
                control++; message += control + "- Telefon Numarası alanı boş bırakılamaz \n";
            }
            string adres = richTextBox_guncelleAdres.Text;
            this.adres = adres;
            string sifre = textBox_GuncelleSifre.Text;
            this.sifre = sifre;
            if (sifre == "")
            {
                control++; message += control + "- Şifre alanı boş bırakılamaz \n";
            }
            int role = 0;
            int cinsiyet;
            if (radioButton_guncelleErkek.Checked != false)
            {
                cinsiyet = 1;
            }
            else
            {
                cinsiyet = 0;
            }
            this.cinsiyet = cinsiyet;
            if (control == 0)
            {
                if (guncelleDegisiklikKontrol().Equals(false))
                {
                    UyariPenceresi showmes = new UyariPenceresi("Kullanıcı Bilgilerinde Değişiklik Yapmadınız \n\nGüncelleme İşlemi İçin Kullanıcı Bilgilerini \nDeğiştirmeniz Gerekiyor");
                    showmes.ShowDialog();
                }
                else
                {
                    string response = BLL.Users.kullaniciGuncelle(ad, soyad, tcno, sifre, role, mail, telno, adres, cinsiyet,userid);

                 if (response.Equals("True"))
                    {
                    UyariPenceresi showmes = new UyariPenceresi("Kullanıcı Başarıyla Güncellendi");
                    showmes.Show();
                    updateDataGridViews();
                    }
                    else
                     {
                    UyariPenceresi showmes = new UyariPenceresi("Kullanıcı Güncelleme Başarısız");
                    showmes.Show();
                    }
                }

            }
            else
            {
                UyariPenceresi showmes = new UyariPenceresi(message);
                showmes.Show();
            }

        }

        private void dataGridView_Guncelle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonGuncelle.Enabled = true;
            buttonGuncelleIptal.Enabled = true;
        }

        private void buttonSilHayir_Click(object sender, EventArgs e)
        {
            labelKullaniciadsoyad.Text = "";
        }

        private void buttonGuncelleIptal_Click(object sender, EventArgs e)
        {
            textBox_guncelleAd.Text = "";
            textBox_GuncelleMail.Text = "";
            textBox_GuncelleSifre.Text = "";
            textBox_guncelleSoyad.Text = "";
            textBox_GuncelleTc.Text = "";
            maskedTextBox_guncelleTel.Text = "";
            richTextBox_guncelleAdres.Text = "";
            radioButton_guncelleErkek.Select();
            buttonGuncelle.Enabled = false;
            buttonGuncelleIptal.Enabled = false;
        }
        /// <summary>
        /// Güncelle Tablosu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_Guncelle_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
         
            buttonGuncelle.Enabled = true;
            buttonGuncelleIptal.Enabled = true;

            textBox_guncelleAd.Text = dataGridView_Guncelle.CurrentRow.Cells["firstName"].Value.ToString();
            textBox_guncelleSoyad.Text = dataGridView_Guncelle.CurrentRow.Cells["lastName"].Value.ToString();
            textBox_GuncelleTc.Text = dataGridView_Guncelle.CurrentRow.Cells["tcNo"].Value.ToString();
            textBox_GuncelleSifre.Text = dataGridView_Guncelle.CurrentRow.Cells["password"].Value.ToString();
            string cinsiyet = dataGridView_Guncelle.CurrentRow.Cells["gender"].Value.ToString();
            maskedTextBox_guncelleTel.Text = dataGridView_Guncelle.CurrentRow.Cells["phoneNo"].Value.ToString();
            richTextBox_guncelleAdres.Text = dataGridView_Guncelle.CurrentRow.Cells["address"].Value.ToString();
            textBox_GuncelleMail.Text = dataGridView_Guncelle.CurrentRow.Cells["mail"].Value.ToString();
            Console.WriteLine("Cinsiyet:" + cinsiyet);
            if (cinsiyet.Equals("True"))
            {
                radioButton_guncelleErkek.Select();
            }
            else
            {
                radioButton_guncelleKadin.Select();
            }
        }
        /// <summary>
        /// Tablodan Seçilen Kullanıcıyı Id sine göre Siler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSilEvet_Click(object sender, EventArgs e)
        {
            int userid = Convert.ToInt32(dataGridViewSil.CurrentRow.Cells["userID"].Value);
            bool response=BLL.Users.kullaniciSil(userid);
            if (response == true)
            {
                UyariPenceresi bildir = new UyariPenceresi(labelKullaniciadsoyad.Text + " kullanıcısı silinmiştir");
                bildir.ShowDialog();
                DataTable table = BLL.Users.garsonlariGetir();
                dataGridView_Guncelle.DataSource = table;
                dataGridViewSil.DataSource = table;
            }
            else
            {
                UyariPenceresi bildir = new UyariPenceresi(labelKullaniciadsoyad.Text + " kullanıcısı silinemiyor");
                bildir.ShowDialog();
            }
        }

        private void dataGridViewSil_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            buttonSilEvet.Enabled = true;
            buttonSilEvet.Enabled = true;
            string isim=dataGridViewSil.CurrentRow.Cells["firstName"].Value.ToString();
            string soyisim = dataGridViewSil.CurrentRow.Cells["lastName"].Value.ToString();
            labelKullaniciadsoyad.Text = isim + " " + soyisim;
        }

        private void textBox_GuncelleTc_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void maskedTextBox_newUserTel_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            button_Kullanici_Ekle.Enabled = true;
        }
    }
}
