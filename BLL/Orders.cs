using System;
using System.Data;

namespace BLL
{
    public class Orders
    {
        public static bool siparisEkle(int tableID, int productID, int catID, int total)
        {
            if (!masaUrunKontrol(productID, tableID))
            {
                if (DAL.Orders.yeniSiparisEkle(tableID, productID, catID, total, DateTime.Now.ToString()) == 0)
                    return false;
                Program.setDBVersion(1);
                return true;
            }
            if (DAL.Orders.sipariseEkle(tableID, productID, total, DateTime.Now.ToString()) == 0)
                return false;
            Program.setDBVersion(1);
            return true;

        }

        /// <summary>
        /// tableID ve productID ile sipariş siler
        /// </summary>
        /// <param name="tableID"></param>
        /// <param name="productID"></param>
        /// <returns></returns>
        public static string siparisSil(int tableID, int productID,int total)
        {
            if (DAL.Orders.siparisSil(tableID, productID,total) == 0)
                return "False";
            Program.setDBVersion(1);
            return "True";
        }

        public static bool siparisUrunIDileSil(int productID)
        {
            if (DAL.Orders.siparisUrunIDileSil(productID) == 0)
                return false;
            Program.setDBVersion(1);
            return true;
        }
        /// <summary>
        /// orderID ile sipariş siler
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public static string siparisIDileSil(int orderID)
        {
            if (DAL.Orders.siparisIDileSil(orderID) == 0)
                return "False";
            Program.setDBVersion(1);
            return "True";
        }

        public static int siparisCATIDileSil(int catID)
        {
            Program.setDBVersion(1);
            return DAL.Orders.siparisCATIDileSil(catID);
        }
        public static string masaninTümSiparisleriniSil(int tableID)
        {
            if (DAL.Orders.masaninTümSiparisleriniSil(tableID) == 0)
                return "False";
            Program.setDBVersion(1);
            return "True";
        }

        /// <summary>
        /// Masa ayırtetmeksizin tüm siparişleri getiri
        /// </summary>
        /// <returns></returns>
        public static DataTable siparisleriGetir()
        {
            return DAL.Orders.siparisleriGetir();
        }

        public static DataTable masayaAitSiparisleriGetir(int tableID)
        {
            return DAL.Orders.masayaAitSiparisleriGetir(tableID);
        }

        public static bool urunKontrol(int productID)
        {
            return DAL.Orders.urunKontrol(productID);
        }

        public static bool masaUrunKontrol(int productID, int tableID)
        {
            return DAL.Orders.masaUrunKontrol(productID, tableID);
        }
    }
}
