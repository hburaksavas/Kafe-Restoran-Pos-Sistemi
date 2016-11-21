using System;
using System.Data;

namespace DAL
{
    public class Tables
    {
        public static DALBasic db = new DALBasic();
        public static string sorgu;

        public static int masaEkle(string tableNo , int capacity)
        {
            sorgu = "INSERT INTO Tables(tableNo,capacity) VALUES ('" + tableNo + "','"+capacity+"')";
            return db.cmd(sorgu);
        }

        public static int masaSil(int tableID)
        {
            sorgu = "DELETE FROM Tables WHERE tableID = '" + tableID + "'";
            return db.cmd(sorgu);
        }

        public static int masaGuncelle(string tableNo, int capacity, int tableID)
        {
            sorgu = "UPDATE Tables SET tableNo = '" + tableNo + "' ,  capacity = '"+ capacity +"' WHERE tableID = '" + tableID + "'";
            return db.cmd(sorgu);
        }

        public static DataTable masalariGetir()
        {
            sorgu = "SELECT * FROM Tables";
            return db.GetDataTable(sorgu);
        }

        public static DataTable acikMasalariGetir()
        {
            sorgu = "SELECT * FROM Tables WHERE status = 1";
            return db.GetDataTable(sorgu);
        }
        public static DataTable bosMasalariGetir()
        {
            sorgu = "SELECT * FROM Tables WHERE status = 0";
            return db.GetDataTable(sorgu);
        }

        public static DataTable masaBilgileriniGetir(int tableID)
        {
            sorgu = "SELECT * FROM Tables WHERE tableID = '" + tableID + "'";
            return db.GetDataTable(sorgu);
        }

        /// <summary>
        /// Tarihi ve userID yi masa açarken alır ve kaydeder, status'e 1 , bill'e 0 otomatik değer verir
        /// </summary>
        /// <param name="date"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static int masaAc(string date , int userID , int tableID)
        {
            sorgu = "UPDATE Tables SET status = 1 , bill = 0 , userID = '" + userID + "' , date = '"+ date +"' WHERE tableID = '" + tableID + "'";
            return db.cmd(sorgu);
        }

        public static string masaHesapGetir(int tableID)
        {
            sorgu = "SELECT bill FROM Tables WHERE tableID = '" + tableID + "'";
            return db.GetDataCell(sorgu);
        }

        /// <summary>
        /// input olarak gönderilen bill değerini masanın bill değerine ekler
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="tableID"></param>
        /// <returns></returns>
        public static int masaFiyatEkle(string bill , int tableID)
        {
            string hesap = (float.Parse(masaHesapGetir(tableID)) + float.Parse(bill)).ToString();
            sorgu = "UPDATE Tables Set bill = '" + hesap + "' WHERE tableID = '" + tableID + "'";
            return db.cmd(sorgu);
        }

        public static int masaFiyatCikar(string bill, int tableID)
        {
            float fiyat = float.Parse(db.GetDataCell("SELECT bill FROM Tables WHERE tableID='" + tableID + "'"));
            float sonuc = fiyat - float.Parse(bill);
            if (sonuc < 0) { sonuc = 0; }
            sorgu = "UPDATE Tables SET bill ='" + sonuc.ToString() + "'WHERE tableID='" + tableID + "'";
            return db.cmd(sorgu);
        }

        /// <summary>
        /// Masa Açıksa true değeri döner kapalıysa false status alanı kontrol edilir
        /// </summary>
        /// <param name="tableID"></param>
        /// <returns></returns>
        public static bool masaDurumGetir(int tableID)
        {
            sorgu = "SELECT status FROM Tables WHERE tableID = " + tableID;
            if (db.GetDataCell(sorgu).Equals("True"))
                return true;
            return false;
        }

        /// <summary>
        /// Hesap alındıktan sonra masa kapanacak masa kapanırken dayreportsa bill ve userID gönderilecek
        /// Masaya ait  tüm siparişler Orderstan silinecek
        /// Masa kapatılacak bill=0 userID=1 status =0 date =0 ile
        /// </summary>
        /// <param name="date"></param>
        /// <param name="userID"></param>
        /// <param name="tableID"></param>
        /// <returns></returns>
        public static int masaKapat(int tableID)
        {
            DataTable table = masaBilgileriniGetir(tableID);
            string bill = table.Rows[0]["bill"].ToString();
            int userID = Int32.Parse(table.Rows[0]["userID"].ToString());
            DayReport.raporMasaKapat(bill, userID);
            Orders.masaninTümSiparisleriniSil(tableID);
            sorgu = "UPDATE Tables SET status = 0 , bill = 0 , userID = 0 , date = 0 WHERE tableID = '" + tableID + "'";
            return db.cmd(sorgu);
        }
    }
}
