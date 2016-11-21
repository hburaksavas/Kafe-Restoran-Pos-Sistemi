using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerAnaSayfa
{
    public partial class Form_Kategori_Islemleri : Form
    {
        UyariPenceresi showMessage;
        int catIDGuncelle=-1;
        public Form_Kategori_Islemleri()
        {
            InitializeComponent();
        }

        private void Form_Kategori_Islemleri_Load(object sender, EventArgs e)
        {
            

            Rectangle r = new Rectangle(

           tabPage1.Left,

           tabPage1.Top,

           tabPage1.Width,

           tabPage1.Height);

            tabControl1.Region = new Region(r);

            dataGridViewsUpdate();
            lbl_lKategoriSilName.Text = "";
           
        }

        public void dataGridViewsUpdate()
        {

            DataTable dataTable = BLL.Category.kategorileriGetir();
            //-------------------------------------------------
            //tablolar yükleniyor
            dataGridView_Guncelle.DataSource = dataTable;
            dataGridView_Guncelle.Columns[0].HeaderText = "Kategori ID";
            dataGridView_Guncelle.Columns[1].HeaderText = "Kategori İsmi";
            dataGridView_Guncelle.Columns[2].HeaderText = "Toplam Ürün Sayısı";
            dataGridView_Sil.DataSource = dataTable;
            dataGridView_Sil.Columns[0].HeaderText = "Kategori ID";
            dataGridView_Sil.Columns[1].HeaderText = "Kategori İsmi";
            dataGridView_Sil.Columns[2].HeaderText = "Toplam Ürün Sayısı";

            dataGridView_Guncelle.Columns[0].Visible = false;
            dataGridView_Sil.Columns[0].Visible = false;
        }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        /// <summary>
        /// Ekleme Tabını aktif hale getirir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }
        /// <summary>
        /// Güncelleme Tabını aktif hale getirir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);

            DataTable dataTable = BLL.Category.kategorileriGetir();
            //-------------------------------------------------
            //tablolar yükleniyor
            dataGridView_Guncelle.DataSource = dataTable;
            dataGridView_Guncelle.Columns[0].HeaderText = "Kategori ID";
            dataGridView_Guncelle.Columns[1].HeaderText = "Kategori İsmi";
            dataGridView_Guncelle.Columns[2].HeaderText = "Toplam Ürün Sayısı";
  
        }
        /// <summary>
        /// Yeni Kategori Ekler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonKategoriEkle_Click(object sender, EventArgs e)
        {
            string catName = txtBox_yeniKategoriName.Text;
            string response;
            if (catName != null)
            {
                    response=BLL.Category.kategoriEkle(catName);
              
                     if (response.Equals("True"))
                     {
                    showMessage = new UyariPenceresi("Kategori Ekleme Başarılı");
                    showMessage.ShowDialog();
                    txtBox_yeniKategoriName.Text = "";
                    dataGridViewsUpdate();
                     }
                else
                        {
                    showMessage = new UyariPenceresi("Kategori Ekleme Başarısız");
                    showMessage.ShowDialog();
                }
            }
            else
            {
                showMessage = new UyariPenceresi("Kategori İsmi Boş Bırakılamaz");
                showMessage.ShowDialog();
            }

        }
        /// <summary>
        /// Kategori Eklemeyi İptal Eder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonKategoriEkleIptal_Click(object sender, EventArgs e)
        {
            txtBox_yeniKategoriName.Text = "";
        }

        private void buttonKategoriGuncelle_Click(object sender, EventArgs e)
        {
            catIDGuncelle = Convert.ToInt32(dataGridView_Guncelle.CurrentRow.Cells["catID"].Value);
            int control = 0;
            string mesaj = "";
            string yenicatName = txtBoxKategoriGuncelle.Text;
            if (label11.Text.Equals(""))
            {
                control++;
                mesaj += "Kategori Seçiniz";
            }
            if (yenicatName.Equals(""))
            {
                control++;
                mesaj += "\n\nKategori İsmi Giriniz";
            }
            if(control==0)
            {
              string response=  BLL.Category.kategoriGuncelle(yenicatName, catIDGuncelle);
                if (response.Equals("True"))
                {
                    mesaj = "Kategori Güncellendi";
                    dataGridViewsUpdate();
                }
                else
                {
                    mesaj = "Kategori Güncelleme Başarısız";
                }
            }
            showMessage = new UyariPenceresi(mesaj);
            showMessage.ShowDialog();
        }

        private void dataGridView_Guncelle_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //label11 güncellenecek kategori ismini gösterir
             label11.Text = dataGridView_Guncelle.CurrentRow.Cells["catName"].Value.ToString();
            
        }

        private void txtBoxKategoriGuncelle_MouseClick(object sender, MouseEventArgs e)
        {
            txtBoxKategoriGuncelle.Text = "";
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void buttonGuncelleIptal_Click(object sender, EventArgs e)
        {
            txtBoxKategoriGuncelle.Text = "";
        }

        private void buttonTabSilme_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
            DataTable dataTable = BLL.Category.kategorileriGetir();
            dataGridView_Sil.DataSource = dataTable;
            dataGridView_Sil.Columns[0].HeaderText = "Kategori ID";
            dataGridView_Sil.Columns[1].HeaderText = "Kategori İsmi";
            dataGridView_Sil.Columns[2].HeaderText = "Toplam Ürün Sayısı";
        }


        private void buttonKategoriSil_Click(object sender, EventArgs e)
        {
            int sil_catID =Convert.ToInt32(dataGridView_Sil.CurrentRow.Cells["catID"].Value);

            if (sil_catID != -1)
            {
                string response = BLL.Category.kategoriSil(sil_catID);
                if (response.Equals("True"))
                {
                    showMessage = new UyariPenceresi("Kategori Silindi");
                }
                else
                {
                    showMessage = new UyariPenceresi("Kategori Silinemiyor");
                }
            }
            else
            {
                showMessage = new UyariPenceresi("Kategori Seçimi Yapmadınız");
            }

            if(showMessage!=null)
            showMessage.ShowDialog();

        }

        private void dataGridView_Sil_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            lbl_lKategoriSilName.Text = dataGridView_Sil.CurrentRow.Cells["catName"].Value.ToString();
        }

        private void buttonKategoriSilIptal_Click(object sender, EventArgs e)
        {
            label5.Text = "";
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
