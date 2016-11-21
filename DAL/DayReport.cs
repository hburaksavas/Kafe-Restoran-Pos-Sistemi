using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class DayReport
    {
        public static DALBasic db = new DALBasic();
        public static string sorgu;

        /// <summary>
        /// Masa hesap alınıp kapatıldıktan sonra güne ait rapor varsa bill ve userID eklenecek tablecount arttırılacak
        /// Güne ait rapor yoksa yeni kayıt acılacak ve yeni kayıda eklenecek
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="userID"></param>
        public static void raporMasaKapat(string bill, int userID)
        {
            string date = DateTime.Now.ToShortDateString();
            sorgu = "SELECT * FROM DayReport WHERE date = '" + date + "'";
            if (db.CheckRecord(sorgu))
                raporGuncelle(date, bill, userID);
            else
                yeniRaporEkle(bill, userID);
        }

        public static void yeniRaporEkle(string bill, int userID)
        {
            string income = bill;
            string date = DateTime.Now.ToShortDateString();
            string workers = userID.ToString() + "#";
            sorgu = "INSERT INTO DayReport(date,income,workers,tableCount) VALUES ('" + date + "','" + income + "','" + workers + "',1)";
            db.cmd(sorgu);
        }

        /// <summary>
        /// O tarihe ait kayıdın bill değeri income'a eklenir tablecount arttırılır userID eklenir workersa
        /// </summary>
        /// <param name="date"></param>
        /// <param name="bill"></param>
        /// <param name="userID"></param>
        public static void raporGuncelle(string date, string bill, int userID)
        {
            DataTable table = guneAitRaporGetir(date);
            string income = (Convert.ToDouble(table.Rows[0]["income"]) + Convert.ToDouble(bill)).ToString();
            string workers = table.Rows[0]["workers"].ToString();
            if (!guneAitCalisanKontrol(date, userID))
                workers += userID.ToString() + "#";
            int tableCount = Convert.ToInt32(table.Rows[0]["tableCount"]) + 1;
            sorgu = "UPDATE DayReport SET income = '" + income + "' , workers = '" + workers + "' , tableCount = '" + tableCount + "'  WHERE date = '" + date + "'";
            db.cmd(sorgu);
        }

        /// <summary>
        /// Girilen tarihte çalışanın workers'a kayıtlı olup olmadığını kontrol eder
        /// </summary>
        /// <param name="date"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        private static bool guneAitCalisanKontrol(string date, int userID)
        {
            DataTable table = guneAitRaporGetir(date);
            string workers = table.Rows[0]["workers"].ToString();
            string[] calisanlar = workers.Split('#');
            foreach (string calisan in calisanlar)
            {
                if (calisan == userID.ToString())
                    return true;
            }
            return false;
        }

        public static List<String> guneAitCalisanIsimleri(string date)
        {
            List<String> calisanIsimleri = new List<String>();
            DataTable table = guneAitRaporGetir(date);
            string workers = table.Rows[0]["workers"].ToString();
            string[] calisanlar = workers.Split('#');
            foreach (string calisan in calisanlar)
            {
                calisanIsimleri.Add(Users.kullaniciAdSoyadGetir(Int32.Parse(calisan)));
            }
            return calisanIsimleri;
        }

        public static DataTable guneAitRaporGetir(string date)
        {
            sorgu = "SELECT * FROM DayReport WHERE date = '" + date + "'";
            return db.GetDataTable(sorgu);
        }

        public static DataTable raporlariGetir()
        {
            sorgu = "SELECT * FROM DayReport";
            return db.GetDataTable(sorgu);
        }
    }
}
