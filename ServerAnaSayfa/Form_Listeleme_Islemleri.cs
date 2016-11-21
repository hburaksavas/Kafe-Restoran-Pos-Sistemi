using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerAnaSayfa
{
   
    public partial class Form_Listeleme_Islemleri : Form
    {
        List<Kategoriler> listKategoriler = new List<Kategoriler>();
        
        public Form_Listeleme_Islemleri()
        {
            InitializeComponent();
        }

        private void Form_Listeleme_Islemleri_Load(object sender, EventArgs e)
        {
            KategoriListele();
            UrunListele();
            MasaListele();
            GarsonListele();
        }
        private DataTable GetDataTableFromDGV(DataGridView dgv)
        {
            int j = 0;
            var dt = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible)
                {
                    DataColumn col = new DataColumn(column.HeaderText);
                    dt.Columns.Add(col);
                    j++;
                }
            }
            object[] cellValues = new object[j];
            int k = 0;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (row.Cells[i].Visible)
                    {
                        cellValues[k] = row.Cells[i].Value;
                        k++;
                    }
                }
                k = 0;
                dt.Rows.Add(cellValues);
            }
            return dt;
        }
        public void dataTableToPdf(DataTable table,string path)
        {
           
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
            document.Open();
            BaseFont baseFont = BaseFont.CreateFont("C:\\windows\\fonts\\arial.ttf", "windows-1254", true);
            iTextSharp.text.Font font5 = new iTextSharp.text.Font(baseFont, 12);    
            PdfPTable pdftable = new PdfPTable(table.Columns.Count);
            pdftable.DefaultCell.Padding = 10;
            pdftable.WidthPercentage = 100;
            PdfPCell cell = new PdfPCell(new Phrase("Products"));
            cell.Colspan = table.Columns.Count;        
            foreach (DataColumn c in table.Columns)
            {
                pdftable.AddCell(new Phrase(c.ColumnName, font5));
            }
            foreach (DataRow r in table.Rows)
            {               
                if (table.Rows.Count > 0)
                {
                    for(int i = 0; i < r.ItemArray.Count(); i++)
                    {
                        pdftable.AddCell(new Phrase(r[i].ToString(), font5));
                    }                                
                }
            }
            document.Add(pdftable);
            document.Close();
        }
        public void KategoriListele()
        {
            DataTable tableCat = BLL.Category.kategorileriGetir();
            dataGridView_Kategori.DataSource = tableCat;
            dataGridView_Kategori.Columns[0].HeaderText = "Kategori ID";
            dataGridView_Kategori.Columns[1].HeaderText = "Kategori İsmi";
            dataGridView_Kategori.Columns[2].HeaderText = "Ürün Sayısı";
            
        }
        public void UrunListele()
        {
            DataTable tableUrun = BLL.Product.urunleriGetir();
            DataColumn columnMasaDurumu = new DataColumn("Stok Durumu");
            columnMasaDurumu.DataType = System.Type.GetType("System.String");
            tableUrun.Columns.Add(columnMasaDurumu);
            foreach (DataRow row in tableUrun.Rows)
            {
                if (row[4].Equals(true))
                {
                    row[6] = "Var";
                }
                else
                {
                    row[6] = "Yok";
                }
            }
            dataGridView_Urunler.DataSource = tableUrun;
            dataGridView_Urunler.Columns[0].HeaderText = "Ürün ID";
            dataGridView_Urunler.Columns[1].Visible = false;
            dataGridView_Urunler.Columns[2].HeaderText = "Ürün İsmi";
            dataGridView_Urunler.Columns[3].HeaderText = "Fiyat";
            dataGridView_Urunler.Columns[4].Visible = false;
            dataGridView_Urunler.Columns[5].HeaderText = "Ürün Açıklaması";

            DataTable table = BLL.Category.kategorileriGetir();
            listKategoriler.Clear();
            foreach (DataRow datarow in table.Rows)
            {
                object[] arr = datarow.ItemArray;
                for (int i = 0; i < arr.Length; i=i+3)
                {
                    listKategoriler.Add(new Kategoriler {catid=Convert.ToInt32(arr[i]),catName=arr[i+1].ToString() });
                }
            }
            comboBox_kategori.Items.Clear();
            comboBox_kategori.Text = "Kategoriye Göre";
            for (int i = 0; i < listKategoriler.Count; i++)
            {
                comboBox_kategori.Items.Add(listKategoriler[i].catName);
            }

        }
        public void MasaListele()
        {
            DataTable table = BLL.Tables.masalariGetir();
            DataColumn columnMasaDurumu = new DataColumn("Masa Durumu");
            columnMasaDurumu.DataType = System.Type.GetType("System.String");
            table.Columns.Add(columnMasaDurumu);
            foreach(DataRow row in table.Rows)
            {
                if (row[3].Equals(true))
                {
                    row[7] = "Açık";
                }
                else
                {
                    row[7] = "Kapalı";
                }
            }
            dataGridView_Masalar.DataSource = table;
            dataGridView_Masalar.Columns[0].Visible = false;
            dataGridView_Masalar.Columns[1].HeaderText = "Masa No";
            dataGridView_Masalar.Columns[2].HeaderText = "Masayı Açan Garson No";
            dataGridView_Masalar.Columns[3].Visible = false;
            dataGridView_Masalar.Columns[4].HeaderText = "Son Açılma Tarihi";
            dataGridView_Masalar.Columns[5].HeaderText = "Kapasite";
            dataGridView_Masalar.Columns[6].HeaderText = "Adisyon Tutar";
        }
        public void GarsonListele()
        {
            DataTable table = BLL.Users.garsonlariGetir();
            DataColumn cinsiyet = new DataColumn("CİNSİYET");
            cinsiyet.DataType = System.Type.GetType("System.String");
            table.Columns.Add(cinsiyet);
            foreach(DataRow row in table.Rows)
            {
                
                if (row[6].Equals(true))
                {
                    row[10] = "Erkek";
                }
                else
                {
                    row[10] = "Kadın";
                }
            }
            dataGridView_Garsonlar.DataSource = table;
            dataGridView_Garsonlar.Columns[0].Visible = false;
            dataGridView_Garsonlar.Columns[1].HeaderText = "İSİM";
            dataGridView_Garsonlar.Columns[2].HeaderText = "SOYİSİM";
            dataGridView_Garsonlar.Columns[3].HeaderText = "TC/PASAPORT NO";
            dataGridView_Garsonlar.Columns[4].HeaderText = "ŞİFRE";
            dataGridView_Garsonlar.Columns[5].Visible = false;
            dataGridView_Garsonlar.Columns[6].Visible = false;
            dataGridView_Garsonlar.Columns[7].HeaderText = "TEL NO";
            dataGridView_Garsonlar.Columns[8].HeaderText = "ADRES";
            dataGridView_Garsonlar.Columns[9].HeaderText = "MAİL";
        }
        /// <summary>
        /// Ürün Sayısına Göre Kategorileri Listeler , control parametresi=artan/azalan
        /// </summary>
        /// <param name="control"></param>
        public void urunSayisinaGore(string control)
        {
            if (control.Equals("azalan"))
            {
                DataTable table = BLL.Category.kategorileriSiraliGetir();
                dataGridView_Kategori.DataSource = table;
            }
            else
            {
                dataGridView_Kategori.Sort(dataGridView_Kategori.Columns[2], ListSortDirection.Ascending);
            }

        }
        /// <summary>
        /// Kategorileri Alfabetik Olarak Listeler , control parametresi =az/za
        /// </summary>
        /// <param name="control"></param>
        public void alfabetik(string control)
        {
            if (control.Equals("az"))
            {
                dataGridView_Kategori.Sort(dataGridView_Kategori.Columns[1], ListSortDirection.Ascending);
            }
            else
            {
                dataGridView_Kategori.Sort(dataGridView_Kategori.Columns[1], ListSortDirection.Descending);
            }
        }
        public void UrunleriOlcutlereGoreListele()
        {
            if (comboBox_kategori.SelectedIndex >= 0)
            {
            string kategori = comboBox_kategori.SelectedItem.ToString();
            int catId=-1;
            foreach(Kategoriler o in listKategoriler)
            {
                if (o.catName.Equals(kategori))
                {
                    catId = o.catid;
                }
            }
                try
                 {
                DataTable table = BLL.Product.kategoriyeGoreUrunleriGetir(catId);
                dataGridView_Urunler.DataSource = table;
                }catch(Exception e) {}
            }

            if (checkBox_fiyatArt.Checked)
            {
                dataGridView_Urunler.Sort(dataGridView_Urunler.Columns["price"], ListSortDirection.Ascending);
            }else if (checkBox_fiyatAz.Checked)
            {
                dataGridView_Urunler.Sort(dataGridView_Urunler.Columns["price"], ListSortDirection.Descending);
            }
           
            if (checkBox_aciklamaVar.Checked)
            {
                UrunListele();
                DataTable table = ((DataTable)dataGridView_Urunler.DataSource);
                    foreach(DataRow row in table.Rows)
                    {      
                    if (row[5].ToString().Length<1)
                    {
                        row.Delete();
                    }
                
                   }
                    dataGridView_Urunler.DataSource = table;
            }else if (checkBox_aciklamaYok.Checked)
            {
                UrunListele();
                DataTable table = ((DataTable)dataGridView_Urunler.DataSource);
                foreach (DataRow row in table.Rows)
                {
                    if (row[5].ToString().Length > 1)
                    {
                       row.Delete();
                    }

                }
                dataGridView_Urunler.DataSource = table;
            }
 
        }
        public void MasalariOlcutlereGoreListele()
        {
            if (checkBox_acikmasa.Checked)
            {
                DataTable table = (DataTable)dataGridView_Masalar.DataSource;
                foreach(DataRow row in table.Rows)
                {
                    if (!row[3].Equals(true))
                    {
                        row.Delete();
                    }
                }
                dataGridView_Masalar.DataSource = table;
            }else if (checkBox_kapalimasa.Checked)
            {
                DataTable table = (DataTable)dataGridView_Masalar.DataSource;
                foreach (DataRow row in table.Rows)
                {
                    if (row[3].Equals(true))
                    {
                        row.Delete();
                    }
                }
                dataGridView_Masalar.DataSource = table;
            }
            else
            {
                MasaListele();
            }
            //---------------------------
            if (checkBox_kapasiteArtan.Checked)
            {
                dataGridView_Masalar.Sort(dataGridView_Masalar.Columns["capacity"], ListSortDirection.Ascending);
            }else if (checkBox_kapasiteAzalan.Checked)
            {
                dataGridView_Masalar.Sort(dataGridView_Masalar.Columns["capacity"], ListSortDirection.Descending);

            }
        }
        public void GarsonlariOlcutlereGoreListele()
        {
            if (checkBox_kadin.Checked)
            {
                DataTable table = (DataTable)dataGridView_Garsonlar.DataSource;
                foreach(DataRow row in table.Rows)
                {
                    if (row[10].Equals("Erkek"))
                    {
                        row.Delete();
                    }
                }
                dataGridView_Garsonlar.DataSource = table;
            }else if (checkBox_erkek.Checked)
            {
                DataTable table = (DataTable)dataGridView_Garsonlar.DataSource;
                foreach (DataRow row in table.Rows)
                {
                    if (row[10].Equals("Kadın"))
                    {
                        row.Delete();
                    }
                }
                dataGridView_Garsonlar.DataSource = table;
            }
            else
            {
                GarsonListele();
            }
            if (checkBox_GarsonAZ.Checked)
            {
                dataGridView_Garsonlar.Sort(dataGridView_Garsonlar.Columns["firstName"], ListSortDirection.Ascending);
            }else if (checkBox_GarsonZA.Checked)
            {
                dataGridView_Garsonlar.Sort(dataGridView_Garsonlar.Columns["firstName"], ListSortDirection.Descending);
            }
        }
        private void button_SecenekleriTemizle_Click(object sender, EventArgs e)
        {
            radioButton_za.Checked = false;
            radioButton_azalan.Checked = false;
            radioButton_artan.Checked = false;
            radioButton_az.Checked = false;
        }
        /// <summary>
        /// Ürün Seçenekler Temizle Buton Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Temizle_Click(object sender, EventArgs e)
        {
            checkBox_aciklamaVar.Checked = false;
            checkBox_aciklamaYok.Checked = false;
            checkBox_fiyatArt.Checked = false;
            checkBox_fiyatAz.Checked = false;
            comboBox_kategori.SelectedIndex = -1;
            UrunListele();
        }
        private void button_masaTemizle_Click(object sender, EventArgs e)
        {
            checkBox_acikmasa.Checked = false;
            checkBox_hesapazalan.Checked = false;
            checkBox_kapalimasa.Checked = false;
            checkBox_hesapartan.Checked = false;
            checkBox_kapasiteArtan.Checked = false;
            checkBox_kapasiteAzalan.Checked = false;
            MasaListele();
        }
        private void button_KategoriListele_Click(object sender, EventArgs e)
        {
            if (radioButton_artan.Checked)
            {
                urunSayisinaGore("artan");
            }else if (radioButton_azalan.Checked)
            {
                urunSayisinaGore("azalan");
            }else if (radioButton_az.Checked)
            {
                alfabetik("az");
            }else if (radioButton_za.Checked)
            {
                alfabetik("za");
            }
            else
            {
              KategoriListele();
            }
        }
        private void button_UrunListele_Click(object sender, EventArgs e)
        {
           UrunleriOlcutlereGoreListele();
        }
        private void button_masaListele_Click(object sender, EventArgs e)
        {
            MasaListele();
            MasalariOlcutlereGoreListele();
        }

        private void checkBox_fiyatArt_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_fiyatArt.Checked)
            {
                checkBox_fiyatAz.Checked = false;
            }
        }
        private void checkBox_fiyatAz_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_fiyatAz.Checked)
            {
                checkBox_fiyatArt.Checked = false;
            }
        }
        private void checkBox_aciklamaVar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_aciklamaVar.Checked)
            {
                checkBox_aciklamaYok.Checked = false;
            }
        }
        private void checkBox_aciklamaYok_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_aciklamaYok.Checked)
            {
                checkBox_aciklamaVar.Checked = false;
            }
        }     
        private void checkBox_acikmasa_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_acikmasa.Checked)
            {
                checkBox_kapalimasa.Checked = false;
            }
        }

        private void checkBox_kapalimasa_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_kapalimasa.Checked)
            {
                checkBox_acikmasa.Checked = false;
            }
        }

        private void checkBox_hesapartan_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_hesapartan.Checked)
            {
                checkBox_hesapazalan.Checked = false;
            }
        }

        private void checkBox_hesapazalan_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_hesapazalan.Checked)
            {
                checkBox_hesapartan.Checked = false;
            }
        }
        private void checkBox_kapasiteArtan_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_kapasiteArtan.Checked)
            {
                checkBox_kapasiteAzalan.Checked = false;
            }
        }
        private void checkBox_kapasiteAzalan_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_kapasiteAzalan.Checked)
            {
                checkBox_kapasiteArtan.Checked = false;
            }
        }
        public class Kategoriler
        {
            public int catid { get; set; }
            public string catName { get; set; }
        }
        private void checkBox_erkek_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_erkek.Checked)
            {
                checkBox_kadin.Checked = false;
            }
        }

        private void checkBox_kadin_CheckedChanged(object sender, EventArgs e)
        {
            if ( checkBox_kadin.Checked)
            {
                checkBox_erkek.Checked = false;
            }
        }

        private void checkBox_GarsonAZ_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_GarsonAZ.Checked)
            {
                checkBox_GarsonZA.Checked = false;
            }
        }

        private void checkBox_GarsonZA_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_GarsonZA.Checked)
            {
                checkBox_GarsonAZ.Checked = false;
            }
        }

        private void button_GarsonListele_Click(object sender, EventArgs e)
        {
            GarsonListele();
            GarsonlariOlcutlereGoreListele();
        }

        private void button_kategoriToPdf_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Pdf Dosyası|*.pdf";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.CreatePrompt = false;
            saveFileDialog.FileName = "Kategoriler Tablosu.pdf";
            if (saveFileDialog.ShowDialog().Equals(DialogResult.OK))
            {
                string name=saveFileDialog.FileName;
                dataTableToPdf(GetDataTableFromDGV(dataGridView_Kategori),name);
            }
           
        }

        private void button_urun_pdf_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Pdf Dosyası|*.pdf";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.CreatePrompt = false;
            saveFileDialog.FileName = "Ürünler Tablosu.pdf";
            if (saveFileDialog.ShowDialog().Equals(DialogResult.OK))
            {
                string name = saveFileDialog.FileName;
                dataTableToPdf(GetDataTableFromDGV(dataGridView_Urunler),name);
            }
          
        }

        private void button_masapdf_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Pdf Dosyası|*.pdf";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.CreatePrompt = false;
            saveFileDialog.FileName = "Masalar Tablosu.pdf";
            if (saveFileDialog.ShowDialog().Equals(DialogResult.OK))
            {
                string name = saveFileDialog.FileName;
                dataTableToPdf(GetDataTableFromDGV(dataGridView_Masalar), name);
            }
           
        }

        private void button_garsonpdf_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Pdf Dosyası|*.pdf";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.CreatePrompt = false;
            saveFileDialog.FileName = "Garsonlar Tablosu.pdf";
            if (saveFileDialog.ShowDialog().Equals(DialogResult.OK))
            {
                string name = saveFileDialog.FileName;
                dataTableToPdf(GetDataTableFromDGV(dataGridView_Garsonlar), name);
            }          
        }
    }
}
