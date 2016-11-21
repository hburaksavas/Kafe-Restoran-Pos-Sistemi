using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
    public class Product
    {
        public static string urunEkle(int catID, string productName, string price, string description)
        {
            if (!string.IsNullOrEmpty(productName) && !string.IsNullOrWhiteSpace(productName))
                if (Convert.ToDouble(price) > 0)
                {
                    if (DAL.Product.urunEkle(catID, productName, price, description) == 0)
                        return "False";
                    DAL.Category.kategoriProductSumGuncelle(catID);
                    Program.setDBVersion(0);
                    return "True";
                }
            return "Ürün ismi ve fiyat boş bırakılamaz!";
        }
        
        /// <summary>
        /// Ürün siparişler tablosunda yer arıyosa işlem yapmaz hata mesaji verir
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public static string urunSil(int productID)
        {
            //if (Orders.urunKontrol(productID)){
            //    return "Hata, ürün siparişlerde bulunmaktadır. Ürünü siparişleriyle sil metodunu kullanın";
            //}
            //else {
            //    DataRow row = urunBilgileriniGetir(productID);
            //    int catID = Convert.ToInt32(row["catID"]);
            //    if (DAL.Product.urunSil(productID) == 0)
            //        return "False";
            //    DAL.Category.kategoriProductSumGuncelle(catID);
            //    return "True";
            //}
            return "Bu Metod Düzeltilecek";
        }

        public static bool urunSiparisleriyleSil(int product)
        {
            if (Orders.urunKontrol(product))
                Orders.siparisUrunIDileSil(product);
            if (DAL.Product.urunSil(product) == 0)
                return false;
            Program.setDBVersion(0);
            return true;
        }

        /// <summary>
        /// catID alır o kategorideki tüm ürünleri siler
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public static bool kategoridekiUrunleriSil(int catID)
        {
            if (DAL.Product.kategoridekiUrunleriSil(catID) == 0)
                return false;
            Program.setDBVersion(0);
            return true;
        }
        public static string urunGuncelle(string productName, string price, int status, string description, int catID, int productID)
        {
            if (!string.IsNullOrEmpty(productName) && !string.IsNullOrWhiteSpace(productName))
                    if (Convert.ToDouble(price) > 0)
                    {
                        if (DAL.Product.urunGuncelle(productName,price,status,description,catID,productID) == 0)
                            return "False";
                        return "True";
                    }
            Program.setDBVersion(1);
            return "Ürün ismi ve fiyat boş bırakılamaz!";
        }

        /// <summary>
        /// Kategori ayırtetmeksizin tüm ürünler listelenir
        /// </summary>
        /// <returns></returns>
        public static DataTable urunleriGetir()
        {
            return DAL.Product.urunleriGetir();
        }

        public static DataTable akfitUrunleriGetir()
        {
            return DAL.Product.akfitUrunleriGetir();
        }

        public static DataTable kategoriyeGoreUrunleriGetir(int catID)
        {
            return DAL.Product.kategoriyeGoreUrunleriGetir(catID);
        }

        /// <summary>
        /// Ürünleri fiyata göre azalan sırada getirir
        /// </summary>
        /// <returns></returns>
        public static DataTable urunleriSiraliGetir()
        {
            return DAL.Product.urunleriSiraliGetir();
        }

        public static DataTable kategoriyeGoreUrunleriSiraliGetir(int catID)
        {
            return DAL.Product.kategoriyeGoreUrunleriSiraliGetir(catID);
        }

        public static DataTable urunBilgileriniGetir(int productID)
        {
            return DAL.Product.urunBilgileriniGetir(productID);
        }

        public static string urunFiyatGetir(int productID)
        {
            return DAL.Product.urunFiyatGetir(productID);
        }

        public static bool urunDurumGuncelle(int status, int productID)
        {
            if (DAL.Product.urunDurumGuncelle(status, productID) == 0)
                return false;
            Program.setDBVersion(0);
            return true;
        }

        public static bool kategoriyeAitUrunKontrol(int catID)
        {
            return DAL.Product.kategoriyeAitUrunKontrol(catID);
        }
        public static string urunIsmineGoreProductIdGetir(string productName)
        {
            return DAL.Product.urunIsmineGoreProductIdGetir(productName);
        }
    }
}
