using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ServerAnaSayfa
{
    public partial class AnaSayfa : Form
    {
        WcfHostService.StartHost startHost = new WcfHostService.StartHost();
        Android.TcpServer startTcp = new Android.TcpServer();
        int userID = 1;
       
        public AnaSayfa()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        private void button_serverStart_Click(object sender, EventArgs e)
        {
            try
            {
                startHost.startHost();
                Thread tcp = new Thread(startTcp.run);
                tcp.Start();
                button_serverStart.Enabled = false;
                button_serverStop.Enabled = true;
                label_serverDurumu.Text = "Açık";
                label_serverDurumu.ForeColor = Color.Green;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Server Başlatma Hata Mesajı:" + ex.ToString());
            }
        }
        private void button_serverStop_Click(object sender, EventArgs e)
        {
            try
            {
                startHost.closeHost();
                startTcp.serverKapat();
                button_serverStop.Enabled = false;
                button_serverStart.Enabled = true;
                label_serverDurumu.Text = "Kapalı";
                label_serverDurumu.ForeColor = Color.Red;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Server Kapatma Hata Mesajı:" + ex.ToString());
            }
        }
        private void button_anaSayfa_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            YoneticiAnasayfa form = new YoneticiAnasayfa();
            form.TopLevel = false;
            form.AutoScroll = true;
            panel1.Controls.Add(form);
            form.Show();
        }
        private void button_adisyon_raporu_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            AdisyonRaporu form = new AdisyonRaporu();
            form.TopLevel = false;
            form.AutoScroll = true;
            panel1.Controls.Add(form);
            form.Show();
        }
        private void button_kafe_durum_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Form_Restorant_Durum form = new Form_Restorant_Durum();
            form.TopLevel = false;
            form.AutoScroll = true;
            panel1.Controls.Add(form);
            form.Show();
        }
        private void button_kategori_islemleri_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Form_Kategori_Islemleri form = new Form_Kategori_Islemleri();
            form.TopLevel = false;
            form.AutoScroll = true;
            panel1.Controls.Add(form);
            form.Show();
        }
        private void button_urun_islemleri_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Form_Urun_Islemleri form = new Form_Urun_Islemleri();
            form.TopLevel = false;
            form.AutoScroll = true;
            panel1.Controls.Add(form);
            form.Show();
        }
        private void button_masa_islemleri_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Form_Masa_Islemleri form = new Form_Masa_Islemleri(); 
            form.TopLevel = false;
            form.AutoScroll = true;
            panel1.Controls.Add(form);
            form.Show();
        }
        private void button_kullanici_islemleri_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Form_Kullanici_Islemleri form = new Form_Kullanici_Islemleri();
            form.TopLevel = false;
            form.AutoScroll = true;
            panel1.Controls.Add(form);
            form.Show();
        }
        private void button_yonetici_islemleri_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Form_Yonetici_Islemleri form = new Form_Yonetici_Islemleri(userID);
            form.TopLevel = false;
            form.AutoScroll = true;
            panel1.Controls.Add(form);
            form.Show();
        }
        private void button_listeleme_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Form_Listeleme_Islemleri form = new Form_Listeleme_Islemleri();
            form.TopLevel = false;
            form.AutoScroll = true;
            panel1.Controls.Add(form);
            form.Show();
        }
    }
}
