using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
    public class DayReport
    {
        public static DataTable guneAitRaporGetir(string date)
        {
            return DAL.DayReport.guneAitRaporGetir(date);
        }

        public static DataTable raporlariGetir()
        {
            return DAL.DayReport.raporlariGetir();
        }

        public static List<String> guneAitCalisanIsimleri(string date)
        {
            return DayReport.guneAitCalisanIsimleri(date);
        }
    }
}
