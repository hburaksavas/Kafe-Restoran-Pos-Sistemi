using System;
using System.Collections;
using System.Data;
using System.IO;

namespace BLL
{
    public class Program
    {
        public static string getDBVersion()
        {
            string veriler = "false";
            try
            {
                StreamReader sr = new StreamReader(@".\KafeServisDBVersion.txt"); //ServerAnaSayfa->Bin->Debug
                veriler = sr.ReadToEnd();
                sr.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Dosya Okuma Hatası>" + e.ToString());
            }
            return veriler;
        }
        public static void setDBVersion(int choose) // 0=DatabaseCreateDelete 1=DatabaseUpdate 
        {
            string dbVersion = "";
            dbVersion = getDBVersion();
            Random r = new Random();
            int rInt = r.Next(100000, 999999);
            string[] degerler = dbVersion.Split('#');
            string part1 = degerler[0]; //CreateDelete
            string part2 = degerler[1]; //Update
            if (choose == 0)
            {
                part1 = rInt.ToString();
            }
            else
            {
                part2 = rInt.ToString();
            }
            dbVersion = part1 + "#" + part2;
            StreamWriter file = new StreamWriter(@".\KafeServisDBVersion.txt");
            file.WriteLine(dbVersion);
            file.Close();
        }
        public static ArrayList dataRowToArrayList(DataRow row)
        {
            ArrayList list = new ArrayList();
            foreach (DataColumn col in row.Table.Columns)
            {
                list.Add(row[col]);
            }
            return list;
        }
        public static ArrayList dataTableToArrayList(DataTable table)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i <= table.Rows.Count - 1; i++)
            {
                for (int j = 0; j <= table.Columns.Count - 1; j++)
                {
                    list.Add(table.Rows[i][j].ToString());
                }
            }
            return list;
        }
        public static DataTable dataRowtoDataTable(DataRow row)
        {
            DataTable dt = new DataTable();
            foreach (DataColumn col in row.Table.Columns)
            {
                dt.Columns.Add(col.ColumnName, col.DataType, col.Expression);
            }
            dt.ImportRow(row);
            return dt;
        }        
    }
}
