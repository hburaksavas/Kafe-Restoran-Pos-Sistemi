using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
    public class Tables
    {
        public static string masaEkle(string tableNo, int capacity)
        {
            if (!string.IsNullOrEmpty(tableNo) && !string.IsNullOrWhiteSpace(tableNo))
            {
                if (DAL.Tables.masaEkle(tableNo, capacity) == 0)
                    return "False";
                Program.setDBVersion(0);
                return "True";
            }
            else
                return "Masa adı boş bırakılamaz";
        }

        public static bool masaSil(int tableID)
        {
            if (DAL.Tables.masaSil(tableID) == 0)
                return false;
            Program.setDBVersion(0);
            return true;
        }

        public static string masaGuncelle(string tableNo, int capacity, int tableID)
        {
            if (!string.IsNullOrEmpty(tableNo) && !string.IsNullOrWhiteSpace(tableNo))
            {
                if (DAL.Tables.masaGuncelle(tableNo, capacity, tableID) == 0)
                    return "False";
                Program.setDBVersion(0);
                return "True";
            }
            return "Masa adı boş bırakılamaz";
        }

        public static DataTable masalariGetir()
        {
            return DAL.Tables.masalariGetir();
        }

        public static DataTable acikMasalariGetir()
        {
            return DAL.Tables.acikMasalariGetir();
        }
        public static DataTable bosMasalariGetir()
        {
            return DAL.Tables.bosMasalariGetir();
        }
        public static DataTable masaBilgileriniGetir(int tableID)
        {
            return DAL.Tables.masaBilgileriniGetir(tableID);
        }

        /// <summary>
        /// Tarihi ve userID yi masa açarken alır ve kaydeder, status'e 1 , bill'e 0 otomatik değer verir
        /// </summary>
        /// <param name="date"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static bool masaAc(int userID, int tableID)
        {
            if (DAL.Tables.masaAc(DateTime.Now.ToString(), userID, tableID) == 0)
                return false;
            Program.setDBVersion(1);
            return true;
        }

        public static string masaHesapGetir(int tableID)
        {
            return DAL.Tables.masaHesapGetir(tableID);
        }

        /// <summary>
        /// Masa Açıksa true değeri döner kapalıysa false status alanı kontrol edilir
        /// </summary>
        /// <param name="tableID"></param>
        /// <returns></returns>
        public static bool masaDurumGetir(int tableID)
        {
            return DAL.Tables.masaDurumGetir(tableID);
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
        public static bool masaKapat(int tableID)
        {
            if (DAL.Tables.masaKapat(tableID) == 0)
                return false;
            Program.setDBVersion(1);
            return true;
        }
    }
}
