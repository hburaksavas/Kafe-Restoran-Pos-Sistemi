using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Android
{
    public class AndroidIstekKontrol
    {
        private const String FORMAT_KATEGORI_LIST = "getkategorilist";
        private const String FORMAT_URUN_LIST = "geturunlist";
        private const String FORMAT_MASA_LIST = "getmasalist";
        private const String FORMAT_YENI_SIPARIS = "yenisiparis";
        private const String FORMAT_MASA_AC = "masaac";
        private const String FORMAT_GIRIS_ONAY = "girisonay";
        private const String FORMAT_VERSİYON_KONTROL = "versiyonkontrol";

        String serverMessage = ""; //SERVER CEVAP
        String androidMessage = "";//ANDROID MESSAGE
        public String androidMesajOlustur(String androidMessage)
        {
            this.androidMessage = androidMessage;
            veriAnaliz(androidMessage);

            return serverMessage;
        }
        private void veriAnaliz(String androidMessage)
        {
            String[] gelenVeri;

            if (androidMessage.Length > 0)
            {
                gelenVeri = androidMessage.Split('#');
                if (gelenVeri.Length < 2) gelenVeri[0] = "Mesaj Yok";
            }
            else
            {
                gelenVeri = new String[1];
                gelenVeri[0] = "Mesaj Yok";
            }

            String format = gelenVeri[0];

            switch (format)
            {
                case FORMAT_KATEGORI_LIST: kategoriListeGonder(); break;
                case FORMAT_URUN_LIST: urunListeGonder(); break;
                case FORMAT_MASA_LIST: masaListeGonder(); break;
                case FORMAT_YENI_SIPARIS: yeniSiparisEkle(); break;
                case FORMAT_MASA_AC: masaAc(); break;
                case FORMAT_GIRIS_ONAY: girisOnay(); break;
                case FORMAT_VERSİYON_KONTROL: versiyonKontrol(); break;
                default: androidHataGonder(); break;
            }

        }
        private void kategoriListeGonder()
        {
            try
            {
                DataTable table = BLL.Category.kategorileriGetir();
                StringBuilder sb = new StringBuilder("setkategorilist");

                foreach (DataRow datarow in table.Rows)
                {
                    object[] arr = datarow.ItemArray;
                    for (int i = 0; i < arr.Length; i++)
                    {
                        sb.Append("#");
                        sb.Append(Convert.ToString(arr[i]));

                    }
                }
                Console.Write(sb.ToString());
                serverMessage = sb.ToString();
            }
            catch (Exception e)
            {
                androidHataGonder();
                return;
            }

        }
        private void urunListeGonder()
        {
            try
            {
                DataTable dataTable = BLL.Product.urunleriGetir();
                StringBuilder sb = new StringBuilder("seturunlist");
                foreach (DataRow datarow in dataTable.Rows)
                {
                    object[] arr = datarow.ItemArray;
                    for (int i = 0; i < arr.Length; i++)
                    {
                        sb.Append("#");
                        sb.Append(Convert.ToString(arr[i]));

                    }
                }
                Console.Write(sb.ToString());
                serverMessage = sb.ToString();
            }
            catch (Exception e)
            {
                androidHataGonder();
                return;
            }


        }
        private void masaListeGonder()
        {
            try
            {
                DataTable dataTable = BLL.Tables.masalariGetir();
                StringBuilder sb = new StringBuilder("setmasalist");
                foreach (DataRow datarow in dataTable.Rows)
                {
                    object[] arr = datarow.ItemArray;
                    for (int i = 0; i < arr.Length; i++)
                    {
                        sb.Append("#");
                        sb.Append(Convert.ToString(arr[i]));
                    }
                }
                Console.Write(sb.ToString());
                serverMessage = sb.ToString();
            }
            catch (Exception e)
            {
                androidHataGonder();
                return;
            }

        }
        private void yeniSiparisEkle()
        {
            try
            {
                serverMessage = "siparisekleonayi#";
                Console.WriteLine(androidMessage);
                string response;
                String[] siparisBilgileri = this.androidMessage.Split('#');
                Console.WriteLine(siparisBilgileri.Length);
                int i = 1;
                while (i < siparisBilgileri.Length)
                {
                    int tableID = int.Parse(siparisBilgileri[i]);
                    Console.WriteLine("table:" + tableID);
                    int productID = int.Parse(siparisBilgileri[++i]);
                    Console.WriteLine("pro:" + productID);
                    int catID = int.Parse(siparisBilgileri[++i]);
                    Console.WriteLine("cat:" + catID);
                    int total = int.Parse(siparisBilgileri[++i]);
                    Console.WriteLine("total" + total);
                    i++;
                    response = Convert.ToString(BLL.Orders.siparisEkle(tableID, productID, catID, total));
                    if (response.Equals("false"))
                    {
                        serverMessage += "false";
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                androidHataGonder();
                Console.WriteLine(e.ToString());
                return;
            }
            serverMessage += "true";
        }
        private void masaAc()
        {
            try
            {
                String[] masaBilgileri = this.androidMessage.Split('#');
                Console.WriteLine(androidMessage);
                bool response = BLL.Tables.masaAc(int.Parse(masaBilgileri[1]), int.Parse(masaBilgileri[2]));
                serverMessage = "masaaconayi#";
                serverMessage += response.ToString();
                Console.WriteLine(serverMessage);
            }
            catch (Exception e)
            {
                androidHataGonder();
                Console.WriteLine(e.ToString());
                return;
            }

        }
        private void girisOnay()
        {
            try
            {
                String[] userBilgileri = this.androidMessage.Split('#');
                bool response = BLL.Users.kullaniciGiris(int.Parse(userBilgileri[1]), userBilgileri[2]);
                serverMessage = "girisonay#";
                serverMessage += response.ToString();
            }
            catch (Exception e)
            {
                androidHataGonder();
                return;
            }

        }
        private void versiyonKontrol()
        {
            try
            {
                String[] veri = this.androidMessage.Split('#');
                String dbversiyon = BLL.Program.getDBVersion();
                String[] versiyon = dbversiyon.Split('#');
                String response = versiyon[0];
                if (veri[1].Equals(versiyon[0]))
                {
                    serverMessage = "versiyonkontrol#" + "True";
                }
                else
                {
                    serverMessage = "versiyonkontrol#" + response;
                }

                Console.WriteLine(serverMessage);
            }
            catch (Exception e)
            {
                androidHataGonder();
                return;
            }
        }
        private void androidHataGonder()
        {
            serverMessage = "defaulthata#SERVER MESAJI ANLAYAMADI";
        }
    }
}
