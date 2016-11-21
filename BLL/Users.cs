using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
    public class Users
    {

        /// <summary>
        /// Kullanıcı eklerken {role => 0->Garson 1->Çalışan} , {male => 0->Kadın 1->Erkek}
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="tcNo"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <param name="mail"></param>
        /// <param name="phoneNo"></param>
        /// <param name="address"></param>
        /// <param name="male"></param>
        /// <returns></returns>
        public static string kullaniciEkle(string firstName, string lastName, string tcNo, string password, int role,
            string mail, string phoneNo, string address, int gender)
        {
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrWhiteSpace(firstName))
                if (!string.IsNullOrEmpty(lastName) && !string.IsNullOrWhiteSpace(lastName))
                    if (!string.IsNullOrEmpty(tcNo) && !string.IsNullOrWhiteSpace(tcNo))
                        if (!string.IsNullOrEmpty(password) && !string.IsNullOrWhiteSpace(password))
                            if (!string.IsNullOrEmpty(mail) && !string.IsNullOrWhiteSpace(mail))
                                if (!string.IsNullOrEmpty(phoneNo) && !string.IsNullOrWhiteSpace(phoneNo))
                                    if (!string.IsNullOrEmpty(address) && !string.IsNullOrWhiteSpace(address))
                                    {
                                        if (DAL.Users.kullaniciEkle(firstName, lastName, tcNo, password, role, mail, phoneNo, address, gender) == 0)
                                            return "False";
                                        Program.setDBVersion(0);
                                        return "True";
                                    }
            return "Ekleme için veri girişi hatalı alanlar boş bırakılamaz";
        }

        public static bool kullaniciSil(int userID)
        {
            if (DAL.Users.kullaniciSil(userID) == 0)
                return false;
            Program.setDBVersion(0);
            return true;
        }

        public static string kullaniciGuncelle(string firstName, string lastName, string tcNo, string password, int role,
            string mail, string phoneNo, string address, int gender, int userID)
        {
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrWhiteSpace(firstName))
                if (!string.IsNullOrEmpty(lastName) && !string.IsNullOrWhiteSpace(lastName))
                    if (!string.IsNullOrEmpty(tcNo) && !string.IsNullOrWhiteSpace(tcNo))
                        if (!string.IsNullOrEmpty(password) && !string.IsNullOrWhiteSpace(password))
                            if (!string.IsNullOrEmpty(mail) && !string.IsNullOrWhiteSpace(mail))
                                if (!string.IsNullOrEmpty(phoneNo) && !string.IsNullOrWhiteSpace(phoneNo))
                                    if (!string.IsNullOrEmpty(address) && !string.IsNullOrWhiteSpace(address))
                                    {
                                        if (DAL.Users.kullaniciGuncelle(firstName, lastName, tcNo, password, role, mail, phoneNo, address, gender, userID) == 0)
                                            return "False";
                                        return "True";
                                    }
            return "Güncelleme hatalı alanlar boş bırakılamaz";
        }

        public static DataTable kullanicilariGetir()
        {
            return DAL.Users.kullanicilariGetir();
        }

        public static DataTable garsonlariGetir()
        {
            return DAL.Users.garsonlariGetir();
        }

        public static DataTable yoneticileriGetir()
        {
            return DAL.Users.yoneticileriGetir();
        }

        /// <summary>
        /// password boş yada null ise false döner, şifre ve parola uyuşmazlığında da false döner
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool kullaniciGiris(int userID, string password)
        {
            if (!string.IsNullOrEmpty(password) && !string.IsNullOrWhiteSpace(password))
                return DAL.Users.kullaniciGiris(userID, password);
            return false;
        }
        public static bool kullaniciVarmi(int userID)
        {
            return DAL.Users.kullaniciVarmi(userID);
        }

        public static DataTable kullaniciBilgileriniGetir(int userID)
        {
            return DAL.Users.kullaniciBilgileriniGetir(userID);
        }

        /// <summary>
        /// Kullanicinin ad ve soyad bilgilerini (firstName lastName) şeklinde getirir
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static string kullaniciAdSoyadGetir(int userID)
        {
            return DAL.Users.kullaniciAdSoyadGetir(userID);
        }

        public static DataTable tumGarsonlarinAdSoyadlari()
        {
            return DAL.Users.tumGarsonlarinAdSoyadlari();
        }
    }
}
