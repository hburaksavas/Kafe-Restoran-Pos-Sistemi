using System;
using System.Data;

namespace DAL
{
    public class Users
    {
        public static DALBasic db = new DALBasic();
        public static string sorgu;

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
        public static int kullaniciEkle(string firstName, string lastName, string tcNo, string password, int role,
            string mail, string phoneNo, string address, int gender)
        {
            sorgu = "INSERT INTO Users(firstName,lastName,tcNo,password,role,mail,phoneNo,address,gender)"
                + "VALUES ('" + firstName + "','" + lastName + "','" + tcNo + "','" + password + "','" + role + "','" + mail + "' ,'" + phoneNo + "','" + address + "','" + gender + "')";
            return db.cmd(sorgu);
        }

        public static int kullaniciSil(int userID)
        {
            sorgu = "DELETE FROM Users WHERE userID = " + userID;
            return db.cmd(sorgu);
        }

        public static int kullaniciGuncelle(string firstName, string lastName, string tcNo, string password, int role,
            string mail, string phoneNo, string address, int gender, int userID)
        {
            sorgu = "UPDATE Users SET firstName = '" + firstName + "' , lastName = '" + lastName + "' , tcNo = '" + tcNo + "' , password = '" + password + "' , role = '" + role + "' " +
                ", mail = '" + mail + "' , phoneNo = '" + phoneNo + "' , address = '" + address + "' , gender = '" + gender + "' WHERE userID = '" + userID + "'";
            return db.cmd(sorgu);
        }

        public static DataTable kullanicilariGetir()
        {
            sorgu = "SELECT * FROM Users";
            return db.GetDataTable(sorgu);
        }

        public static DataTable garsonlariGetir()
        {
            sorgu = "SELECT * FROM Users WHERE role = 0";
            return db.GetDataTable(sorgu);
        }

        public static DataTable yoneticileriGetir()
        {
            sorgu = "SELECT * FROM Users WHERE role = 1";
            return db.GetDataTable(sorgu);
        }

        public static bool kullaniciGiris(int userID, string password)
        {
            sorgu = "SELECT * FROM Users WHERE userID = '" + userID + "' AND password = '" + password + "'";
            return db.CheckRecord(sorgu);
        }
        public static bool kullaniciVarmi(int userID)
        {
            sorgu = "SELECT firstName FROM Users WHERE userID= '" + userID + "'";
            return db.CheckRecord(sorgu);
        }
        public static DataTable kullaniciBilgileriniGetir(int userID)
        {
            sorgu = "SELECT * FROM Users WHERE userID= '" + userID + "'";
            return db.GetDataTable(sorgu);
        }

        public static string kullaniciAdSoyadGetir(int userID)
        {
            sorgu = "SELECT firstName +' '+ lastName AdSoyad FROM Users WHERE userID= '" + userID + "'";
            return db.GetDataCell(sorgu);
        }

        public static DataTable tumGarsonlarinAdSoyadlari()
        {
            sorgu = "SELECT firstName +' '+ lastName AdSoyad FROM Users WHERE role = 0";
            return db.GetDataTable(sorgu);
        }
    }
}
