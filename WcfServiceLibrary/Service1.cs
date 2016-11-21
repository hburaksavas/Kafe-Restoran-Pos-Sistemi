using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BLL;
using System.Collections;

namespace WcfServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        DataTable dataTable;

        //Test Silinecek --------------------------------------------------------------------------------------------->

        public bool Test()
        {
            return true;
        }
        public DataTable TestDataTable()
        {
            dataTable = Category.kategorileriGetir();
            dataTable.TableName = "Test";
            return dataTable;
        }
        public string getDBVersion()
        {
            return BLL.Program.getDBVersion();
        }

        //Users -------------------------------------------------------------------------------------------------->

        public DataTable Users_garsonlariGetir()
        {
            dataTable = Users.garsonlariGetir();
            dataTable.TableName = "Users";
            return dataTable;
        }

        public string Users_kullaniciAdSoyadGetir(int userID)
        {
            return Users.kullaniciAdSoyadGetir(userID);
        }

        public DataTable Users_kullaniciBilgileriniGetir(int userID)
        {
            dataTable = Users.kullaniciBilgileriniGetir(userID);
            dataTable.TableName = "Users";
            return dataTable;
        }

        public string Users_kullaniciEkle(string firstName, string lastName, string tcNo, string password, int role, string mail, string phoneNo, string address, int gender)
        {
            return Users.kullaniciEkle(firstName, lastName, tcNo, password, role, mail, phoneNo, address, gender);
        }

        public bool Users_kullaniciGiris(int userID, string password)
        {
            return Users.kullaniciGiris(userID, password);
        }

        public string Users_kullaniciGuncelle(string firstName, string lastName, string tcNo, string password, int role, string mail, string phoneNo, string address, int gender, int userID)
        {
            return Users.kullaniciGuncelle(firstName, lastName, tcNo, password, role, mail, phoneNo, address, gender, userID);
        }

        public DataTable Users_kullanicilariGetir()
        {
            dataTable = Users.kullanicilariGetir();
            dataTable.TableName = "Users";
            return dataTable;
        }

        public bool Users_kullaniciSil(int userID)
        {
            return Users.kullaniciSil(userID);
        }

        public bool Users_kullaniciVarmi(int userID)
        {
            return Users.kullaniciVarmi(userID);
        }

        public DataTable Users_tumGarsonlarinAdSoyadlari()
        {
            dataTable = Users.tumGarsonlarinAdSoyadlari();
            dataTable.TableName = "Users";
            return dataTable;
        }

        public DataTable Users_yoneticileriGetir()
        {
            dataTable = Users.yoneticileriGetir();
            dataTable.TableName = "Users";
            return dataTable;
        }



        //Tables -------------------------------------------------------------------------------------------------->

        public DataTable Tables_acikMasalariGetir()
        {
            dataTable = Tables.acikMasalariGetir();
            dataTable.TableName = "Tables";
            return dataTable;
        }
        public DataTable Tables_bosMasalariGetir()
        {
            dataTable = Tables.bosMasalariGetir();
            dataTable.TableName = "Tables";
            return dataTable;
        }

        public bool Tables_masaAc(int userID, int tableID)
        {
            return Tables.masaAc(userID, tableID);
        }

        public DataTable Tables_masaBilgileriniGetir(int tableID)
        {
            dataTable = Tables.masaBilgileriniGetir(tableID);
            dataTable.TableName = "Tables";
            return dataTable;
        }

        public bool Tables_masaDurumGetir(int tableID)
        {
            return Tables.masaDurumGetir(tableID);
        }

        public string Tables_masaEkle(string tableNo, int capacity)
        {
            return Tables.masaEkle(tableNo, capacity);
        }

        public string Tables_masaGuncelle(string tableNo, int capacity, int tableID)
        {
            return Tables.masaGuncelle(tableNo, capacity, tableID);
        }

        public string Tables_masaHesapGetir(int tableID)
        {
            return Tables.masaHesapGetir(tableID);
        }

        public bool Tables_masaKapat(int tableID)
        {
            return Tables.masaKapat(tableID);
        }

        public DataTable Tables_masalariGetir()
        {
            dataTable = Tables.masalariGetir();
            dataTable.TableName = "Tables";
            return dataTable;
        }

        public bool Tables_masaSil(int tableID)
        {
            return Tables.masaSil(tableID);
        }



        //Product -------------------------------------------------------------------------------------------------->

        public string Product_urunEkle(int catID, string productName, string price, string description)
        {
            return Product.urunEkle(catID, productName, price, description);
        }

        public string Product_urunSil(int productID)
        {
            return Product.urunSil(productID);
        }

        public bool Product_urunSiparisleriyleSil(int product)
        {
            return Product.urunSiparisleriyleSil(product);
        }

        public bool Product_kategoridekiUrunleriSil(int catID)
        {
            return Product.kategoridekiUrunleriSil(catID);
        }

        public string Product_urunGuncelle(string productName, string price, int status, string description, int catID, int productID)
        {
            return Product.urunGuncelle(productName, price, status, description, catID, productID);
        }

        public DataTable Product_urunleriGetir()
        {
            dataTable = Product.urunleriGetir();
            dataTable.TableName = "Product";
            return dataTable;
        }

        public DataTable Product_akfitUrunleriGetir()
        {
            dataTable = Product.akfitUrunleriGetir();
            dataTable.TableName = "Product";
            return dataTable;
        }

        public DataTable Product_kategoriyeGoreUrunleriGetir(int catID)
        {
            dataTable = Product.kategoriyeGoreUrunleriGetir(catID);
            dataTable.TableName = "Product";
            return dataTable;
        }

        public DataTable Product_urunleriSiraliGetir()
        {
            dataTable = Product.urunleriSiraliGetir();
            dataTable.TableName = "Product";
            return dataTable;
        }

        public DataTable Product_kategoriyeGoreUrunleriSiraliGetir(int catID)
        {
            dataTable = Product.kategoriyeGoreUrunleriSiraliGetir(catID);
            dataTable.TableName = "Product";
            return dataTable;
        }

        public DataTable Product_urunBilgileriniGetir(int productID)
        {
            dataTable = Product.urunBilgileriniGetir(productID);
            dataTable.TableName = "Product";
            return dataTable;
        }

        public string Product_urunFiyatGetir(int productID)
        {
            return Product.urunFiyatGetir(productID);
        }

        public bool Product_urunDurumGuncelle(int status, int productID)
        {
            return Product.urunDurumGuncelle(status, productID);
        }

        public bool Product_kategoriyeAitUrunKontrol(int catID)
        {
            return Product.kategoriyeAitUrunKontrol(catID);
        }



        //Orders -------------------------------------------------------------------------------------------------->

        public bool Orders_siparisEkle(int tableID, int productID, int catID, int total)
        {
            return Orders.siparisEkle(tableID, productID, catID, total);
        }

        public string Orders_siparisSil(int tableID, int productID, int total)
        {
            return Orders.siparisSil(tableID, productID, total);
        }

        public bool Orders_siparisUrunIDileSil(int productID)
        {
            return Orders.siparisUrunIDileSil(productID);
        }

        public string Orders_siparisIDileSil(int orderID)
        {
            return Orders.siparisIDileSil(orderID);
        }

        public int Orders_siparisCATIDileSil(int catID)
        {
            return Orders.siparisCATIDileSil(catID);
        }

        public string Orders_masaninTümSiparisleriniSil(int tableID)
        {
            return Orders.masaninTümSiparisleriniSil(tableID);
        }

        public DataTable Orders_siparisleriGetir()
        {
            dataTable = Orders.siparisleriGetir();
            dataTable.TableName = "Orders";
            return dataTable;
        }

        public DataTable Orders_masayaAitSiparisleriGetir(int tableID)
        {
            dataTable = Orders.masayaAitSiparisleriGetir(tableID);
            dataTable.TableName = "Orders";
            return dataTable;
        }

        public bool Orders_urunKontrol(int productID)
        {
            return Orders.urunKontrol(productID);
        }

        public bool Orders_masaUrunKontrol(int productID, int tableID)
        {
            return Orders.masaUrunKontrol(productID, tableID);
        }



        //DayReport -------------------------------------------------------------------------------------------------->

        public DataTable DayReport_guneAitRaporGetir(string date)
        {
            dataTable = DayReport.guneAitRaporGetir(date);
            dataTable.TableName = "DayReport";
            return dataTable;
        }

        public DataTable DayReport_raporlariGetir()
        {
            dataTable = DayReport.raporlariGetir();
            dataTable.TableName = "DayReport";
            return dataTable;
        }

        public List<string> DayReport_guneAitCalisanIsimleri(string date)
        {
            return DayReport.guneAitCalisanIsimleri(date);
        }



        //Category -------------------------------------------------------------------------------------------------->


        public string Category_kategoriEkle(string catName)
        {
            return Category.kategoriEkle(catName);
        }

        public string Category_kategoriSil(int catID)
        {
            return Category.kategoriSil(catID);
        }

        public string Category_kategoriUrunleriyleSil(int catID)
        {
            return Category.kategoriUrunleriyleSil(catID);
        }

        public string Category_kategoriGuncelle(string catName, int catID)
        {
            return Category.kategoriGuncelle(catName, catID);
        }

        public DataTable Category_kategoriBilgileriniGetir(int catID)
        {
            dataTable = Category.kategoriBilgileriniGetir(catID);
            dataTable.TableName = "Category";
            return dataTable;
        }

        public DataTable Category_kategorileriGetir()
        {
            dataTable = Category.kategorileriGetir();
            dataTable.TableName = "Category";
            return dataTable;
        }
        
        public DataTable Category_kategorileriSiraliGetir()
        {
            dataTable = Category.kategorileriSiraliGetir();
            dataTable.TableName = "Category";
            return dataTable;
        }

    }
}
