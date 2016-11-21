using System;
using System.Data;

namespace DAL
{
    public class Product
    {
        public static DALBasic db = new DALBasic();
        public static string sorgu;

        public static int urunEkle(int catID, string productName, string price, string description)
        {
            sorgu = "INSERT INTO Product(catID,productName,price,description) VALUES ('" + catID + "','" + productName + "','" + price + "','" + description + "')";
            return db.cmd(sorgu);
        }

        public static int urunSil(int productID)
        {
            sorgu = "DELETE FROM Product WHERE productID = '" + productID + "'";
            return db.cmd(sorgu);
        }

        public static int urunSiparisleriyleSil(int productID)
        {
            sorgu = "DELETE FROM Product WHERE productID = '" + productID + "'";
            return db.cmd(sorgu);
        }

        /// <summary>
        /// catID alır o kategorideki tüm ürünleri siler
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public static int kategoridekiUrunleriSil(int catID)
        {
            sorgu = "DELETE FROM Product WHERE catID = " + catID;
            return db.cmd(sorgu);
        }
        public static int urunGuncelle(string productName, string price, int status, string description, int catID, int productID)
        {
            sorgu = "UPDATE Product SET productName = '" + productName + "' , price ='" + price + "', status ='" + status + "', description ='" + description + "' , catID = '" + catID + "' WHERE productID ='" + productID + "'";
            return db.cmd(sorgu);
        }

        /// <summary>
        /// Kategori ayırtetmeksizin tüm ürünler listelenir
        /// </summary>
        /// <returns></returns>
        public static DataTable urunleriGetir()
        {
            sorgu = "SELECT * FROM Product";
            return db.GetDataTable(sorgu);
        }

        public static DataTable akfitUrunleriGetir()
        {
            sorgu = "SELECT * FROM Product WHERE status = 1";
            return db.GetDataTable(sorgu);
        }

        public static DataTable kategoriyeGoreUrunleriGetir(int catID)
        {
            sorgu = "SELECT * FROM Product WHERE catID= '" + catID + "'";
            return db.GetDataTable(sorgu);
        }

        /// <summary>
        /// Ürünleri fiyata göre azalan sırada getirir
        /// </summary>
        /// <returns></returns>
        public static DataTable urunleriSiraliGetir()
        {
            sorgu = "SELECT * FROM Product ORDER BY price DESC";
            return db.GetDataTable(sorgu);
        }

        public static DataTable kategoriyeGoreUrunleriSiraliGetir(int catID)
        {
            sorgu = "SELECT * FROM Product WHERE catID = '" + catID + "' ORDER BY price DESC";
            return db.GetDataTable(sorgu);
        }

        public static DataTable urunBilgileriniGetir(int productID)
        {            
            sorgu = "SELECT * FROM Product WHERE productID= '" + productID + "'";
            return db.GetDataTable(sorgu);
        }

        public static string urunFiyatGetir(int productID)
        {
            sorgu = "SELECT price FROM Product WHERE productID = '" + productID + "'";
            return db.GetDataCell(sorgu);
        }

        public static int urunDurumGuncelle(int status  , int productID)
        {
            sorgu = "UPDATE Product SET status = '" + status + "' WHERE productID = '" + productID + "'";
            return db.cmd(sorgu);
        }

        public static bool kategoriyeAitUrunKontrol(int catID)
        {
            sorgu = "SELECT * FROM Product WHERE catID= '" + catID + "'";
            return db.CheckRecord(sorgu);
        }
        public static string urunIsmineGoreProductIdGetir(string productName)
        {
            sorgu = "SELECT productID FROM Product WHERE productName = '" + productName + "'";
            return db.GetDataCell(sorgu);
        }
    }
}
