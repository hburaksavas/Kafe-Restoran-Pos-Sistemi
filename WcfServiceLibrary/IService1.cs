using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        bool Test();

        [OperationContract]
        DataTable TestDataTable();

        [OperationContract]
        string getDBVersion();
        //Users -------------------------------------------------------------------------------------------------->

        [OperationContract]
        string Users_kullaniciEkle(string firstName, string lastName, string tcNo, string password, int role,
    string mail, string phoneNo, string address, int gender);

        [OperationContract]
        bool Users_kullaniciSil(int userID);

        [OperationContract]
        string Users_kullaniciGuncelle(string firstName, string lastName, string tcNo, string password, int role,
            string mail, string phoneNo, string address, int gender, int userID);

        [OperationContract]
        DataTable Users_kullanicilariGetir();

        [OperationContract]
        DataTable Users_garsonlariGetir();

        [OperationContract]
        DataTable Users_yoneticileriGetir();

        [OperationContract]
        bool Users_kullaniciGiris(int userID, string password);

        [OperationContract]
        bool Users_kullaniciVarmi(int userID);

        [OperationContract]
        DataTable Users_kullaniciBilgileriniGetir(int userID);

        [OperationContract]
        string Users_kullaniciAdSoyadGetir(int userID);

        [OperationContract]
        DataTable Users_tumGarsonlarinAdSoyadlari();



        //Tables -------------------------------------------------------------------------------------------------->

        [OperationContract]
        string Tables_masaEkle(string tableNo, int capacity);

        [OperationContract]
        bool Tables_masaSil(int tableID);

        [OperationContract]
        string Tables_masaGuncelle(string tableNo, int capacity, int tableID);

        [OperationContract]
        DataTable Tables_masalariGetir();

        [OperationContract]
        DataTable Tables_acikMasalariGetir();
        [OperationContract]
        DataTable Tables_bosMasalariGetir();

        [OperationContract]
        DataTable Tables_masaBilgileriniGetir(int tableID);

        [OperationContract]
        bool Tables_masaAc(int userID, int tableID);

        [OperationContract]
        string Tables_masaHesapGetir(int tableID);

        [OperationContract]
        bool Tables_masaDurumGetir(int tableID);

        [OperationContract]
        bool Tables_masaKapat(int tableID);



        //Product -------------------------------------------------------------------------------------------------->

        [OperationContract]
        string Product_urunEkle(int catID, string productName, string price, string description);

        [OperationContract]
        string Product_urunSil(int productID);

        [OperationContract]
        bool Product_urunSiparisleriyleSil(int product);

        [OperationContract]
        bool Product_kategoridekiUrunleriSil(int catID);

        [OperationContract]
        string Product_urunGuncelle(string productName, string price, int status, string description, int catID, int productID);

        [OperationContract]
        DataTable Product_urunleriGetir();

        [OperationContract]
        DataTable Product_akfitUrunleriGetir();

        [OperationContract]
        DataTable Product_kategoriyeGoreUrunleriGetir(int catID);

        [OperationContract]
        DataTable Product_urunleriSiraliGetir();

        [OperationContract]
        DataTable Product_kategoriyeGoreUrunleriSiraliGetir(int catID);

        [OperationContract]
        DataTable Product_urunBilgileriniGetir(int productID);

        [OperationContract]
        string Product_urunFiyatGetir(int productID);

        [OperationContract]
        bool Product_urunDurumGuncelle(int status, int productID);

        [OperationContract]
        bool Product_kategoriyeAitUrunKontrol(int catID);



        //Orders -------------------------------------------------------------------------------------------------->

        [OperationContract]
        bool Orders_siparisEkle(int tableID, int productID, int catID, int total);

        [OperationContract]
        string Orders_siparisSil(int tableID, int productID, int total);

        [OperationContract]
        bool Orders_siparisUrunIDileSil(int productID);

        [OperationContract]
        string Orders_siparisIDileSil(int orderID);

        [OperationContract]
        int Orders_siparisCATIDileSil(int catID);

        [OperationContract]
        string Orders_masaninTümSiparisleriniSil(int tableID);

        [OperationContract]
        DataTable Orders_siparisleriGetir();

        [OperationContract]
        DataTable Orders_masayaAitSiparisleriGetir(int tableID);

        [OperationContract]
        bool Orders_urunKontrol(int productID);

        [OperationContract]
        bool Orders_masaUrunKontrol(int productID, int tableID);



        //DayReport -------------------------------------------------------------------------------------------------->

        [OperationContract]
        DataTable DayReport_guneAitRaporGetir(string date);

        [OperationContract]
        DataTable DayReport_raporlariGetir();

        [OperationContract]
        List<String> DayReport_guneAitCalisanIsimleri(string date);



        //Category -------------------------------------------------------------------------------------------------->

        [OperationContract]
        string Category_kategoriEkle(string catName);

        [OperationContract]
        string Category_kategoriSil(int catID);

        [OperationContract]
        string Category_kategoriUrunleriyleSil(int catID);

        [OperationContract]
        string Category_kategoriGuncelle(string catName, int catID);

        [OperationContract]
        DataTable Category_kategoriBilgileriniGetir(int catID);

        [OperationContract]
        DataTable Category_kategorileriGetir();

        [OperationContract]
        DataTable Category_kategorileriSiraliGetir();

    }
}
