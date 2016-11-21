using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class Orders
    {
        public static DALBasic db = new DALBasic();
        public static string sorgu;

        /// <summary>
        /// Siparişi ekler sonrasında ürün fiyatını alır masanın hesabına ekler
        /// </summary>
        /// <param name="tableID"></param>
        /// <param name="productID"></param>
        /// <param name="catID"></param>
        /// <param name="total"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int yeniSiparisEkle(int tableID, int productID, int catID, int total, string date)
        {
            sorgu = "INSERT INTO Orders(tableID,productID,catID,total,date) VALUES ('" + tableID + "','" + productID + "','" + catID + "','" + total + "','" + date + "')";
            double price;
            double.TryParse(Product.urunFiyatGetir(productID).Replace(".", ","), out price);
            Tables.masaFiyatEkle((price * total).ToString(), tableID);
            return db.cmd(sorgu);
        }

        public static int sipariseEkle(int tableID, int productID, int total , string date)
        {
            total += siparisUrunAdetAlMasaBilgisineGore(productID, tableID);
            sorgu = "UPDATE Orders SET total = '" + total + "' , date = '" + date + "' WHERE productID = '"+productID+"' AND tableID = '"+tableID+"'";
            double price;
            double.TryParse(Product.urunFiyatGetir(productID).Replace(".", ","), out price);
            Tables.masaFiyatEkle((price * total).ToString(), tableID);
            return db.cmd(sorgu);
        }

        /// <summary>
        /// tableID ve productID ile adet kadar sipariş siler
        /// </summary>
        /// <param name="tableID"></param>
        /// <param name="productID"></param>
        /// <returns></returns>
        public static int siparisSil(int tableID, int productID,int total)
        {
            int totalEski = siparisUrunAdetAlMasaBilgisineGore(productID, tableID);
            sorgu = "SELECT orderID FROM Orders WHERE productID = '" + productID + "' AND tableID = '" + tableID + "'";
            int orderID = Int32.Parse(db.GetDataCell(sorgu));
            if (totalEski <= total)
            {
                double price;
                double.TryParse(Product.urunFiyatGetir(productID).Replace(".", ","), out price);
                Tables.masaFiyatCikar((price * total).ToString(), tableID);
                return siparisIDileSil(orderID);
            }
            else
            {
                double price;
                double.TryParse(Product.urunFiyatGetir(productID).Replace(".", ","), out price);
                Tables.masaFiyatCikar((price * total).ToString(), tableID);
                total = totalEski - total;
                sorgu = "UPDATE Orders SET total ='" + total + "' WHERE orderID = '" + orderID + "'";
                return db.cmd(sorgu);
            }

        }

        public static int siparisUrunIDileSil(int productID)
        {
            sorgu = "DELETE FROM Orders WHERE productID = '" + productID + "'";
            return db.cmd(sorgu);
        }

        /// <summary>
        /// orderID ile sipariş siler
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public static int siparisIDileSil(int orderID)
        {
            sorgu = "DELETE FROM Orders WHERE orderID = '" + orderID + "'";
            return db.cmd(sorgu);
        }

        public static int siparisCATIDileSil(int catID)
        {
            sorgu = "DELETE FROM Orders WHERE catID = '" + catID + "'";
            return db.cmd(sorgu);
        }

        public static int masaninTümSiparisleriniSil(int tableID)
        {
            sorgu = "DELETE FROM Orders WHERE tableID = '" + tableID + "'";
            return db.cmd(sorgu);
        }

        /// <summary>
        /// Masa ayırtetmeksizin tüm siparişleri getiri
        /// </summary>
        /// <returns></returns>
        public static DataTable siparisleriGetir()
        {
            sorgu = "SELECT * FROM Orders";
            return db.GetDataTable(sorgu);
        }

        public static DataTable masayaAitSiparisleriGetir(int tableID)
        {
            sorgu = "SELECT * FROM Orders WHERE tableID = '" + tableID + "'";
            return db.GetDataTable(sorgu);
        }

        public static bool urunKontrol(int productID)
        {
            sorgu = "SELECT * FROM Orders WHERE productID = '" + productID + "'";
            return db.CheckRecord(sorgu);
        }

        public static bool masaUrunKontrol(int productID, int tableID)
        {
            sorgu = "SELECT * FROM Orders WHERE productID = '"+productID+"' AND tableID = '"+tableID+"'";
            return db.CheckRecord(sorgu);
        }
        
        /// <summary>
        /// Masadaki belirli bir ürünün total alanını getirir. productID ve tableID ile Ordersta sorgulama yapar
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="tableID"></param>
        /// <returns></returns>
        private static int siparisUrunAdetAlMasaBilgisineGore(int productID, int tableID)
        {
            sorgu = "SELECT total FROM Orders WHERE productID = '" + productID + "' AND tableID = '" + tableID + "'";
            return Convert.ToInt32(db.GetDataCell(sorgu));
        }
    }
}
