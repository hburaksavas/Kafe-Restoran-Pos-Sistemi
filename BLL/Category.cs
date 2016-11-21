using System;
using System.Data;

namespace BLL
{
    public class Category
    {
        public static string kategoriEkle(string catName)
        {
            if (!string.IsNullOrEmpty(catName) && !string.IsNullOrWhiteSpace(catName))
            {
                if (DAL.Category.kategoriEkle(catName) == 0)
                    return "False";
                Program.setDBVersion(0);
                return "True";
            }
            else
                return "Kategori adı boş bırakılamaz";
                
        }

        public static string kategoriSil(int catID)
        {
            if (DAL.Product.kategoriyeAitUrunKontrol(catID))
                return "Kategoriye ait ürün bulunmaktadır. Kategori silinemez!";
            else
            {
                if (DAL.Category.kategoriSil(catID) == 0)
                    return "False";
                Program.setDBVersion(0);
                return "True";
            }
        }

        /// <summary>
        /// Kategoriye ait tüm ürünleri siler sonra kategoriyi siler
        /// </summary>
        /// <param name="catID"></param>
        /// <returns></returns>
        public static string kategoriUrunleriyleSil(int catID)
        {
            Orders.siparisCATIDileSil(catID);
            Product.kategoridekiUrunleriSil(catID);
            if (DAL.Category.kategoriSil(catID) == 0)
                return "False";
            Program.setDBVersion(0);
            return "True";
        }

        public static string kategoriGuncelle(string catName, int catID)
        {
            if (string.IsNullOrEmpty(catName) || string.IsNullOrWhiteSpace(catName))
                return "Kategori  ismi boş bırakılamaz!";
            else
            {
                if (DAL.Category.kategoriGuncelle(catName, catID) == 0)
                    return "False";
                Program.setDBVersion(0);
                return "True";
            }
        }

        public static DataTable kategoriBilgileriniGetir(int catID)
        {
            return DAL.Category.kategoriBilgileriniGetir(catID);
        }

        public static DataTable kategorileriGetir()
        {
            return DAL.Category.kategorileriGetir();
        }

        /// <summary>
        /// Kategorileri productSum'a göre sıralayarak getirir
        /// </summary>
        /// <returns></returns>
        public static DataTable kategorileriSiraliGetir()
        {
            return DAL.Category.kategorileriSiraliGetir();
        }
    }
}
