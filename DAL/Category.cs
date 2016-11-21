using System;
using System.Data;

namespace DAL
{
    public class Category
    {
        public static DALBasic db = new DALBasic();
        public static string sorgu;

        public static int kategoriEkle(string catName)
        {
            sorgu = "INSERT INTO Category(catName) VALUES ('" + catName + "')";
            return db.cmd(sorgu);
        }

        public static int kategoriSil(int catID)
        {
            sorgu = "DELETE FROM Category WHERE catID = '" + catID + "'";
            return db.cmd(sorgu);
        }

        /// <summary>
        /// Kategoriye ait tüm ürünleri siler sonra kategoriyi siler
        /// </summary>
        /// <param name="catID"></param>
        /// <returns></returns>

        public static int kategoriGuncelle(string catName , int catID)
        {
            sorgu = "UPDATE Category SET catName = '" + catName + "' WHERE catID = '" + catID + "'";
            return db.cmd(sorgu);
        }

        public static DataTable kategoriBilgileriniGetir(int catID)
        {
            sorgu = "SELECT * FROM Category WHERE catID = '" + catID + "'";
            return db.GetDataTable(sorgu);
        }

        public static DataTable kategorileriGetir()
        {
            sorgu = "SELECT * FROM Category";
            return db.GetDataTable(sorgu);
        }

        /// <summary>
        /// Kategorileri productSum'a göre sıralayarak getirir
        /// </summary>
        /// <returns></returns>
        public static DataTable kategorileriSiraliGetir()
        {
            sorgu = "SELECT * FROM Category ORDER BY productSum DESC";
            return db.GetDataTable(sorgu);
        }

        /// <summary>
        /// Kategoriye ait ürün sayısını bulur kategorinin productSum alanını günceller işlem adımları;
        /// catID ile kategoriye ait ürün sayısını bulur
        /// kategori productSum bilgisini günceller
        /// </summary>
        public static void kategoriProductSumGuncelle(int catID)
        {
            sorgu = "SELECT COUNT(*) FROM Product WHERE catID = '" + catID + "'";
            int productSum = Int32.Parse(db.GetDataCell(sorgu));
            sorgu = "UPDATE Category SET productSum = '" + productSum + "' WHERE catID = '" + catID + "'";
            db.cmd(sorgu);
        }
    }
}