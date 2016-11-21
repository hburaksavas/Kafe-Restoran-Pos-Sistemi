using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Android
{
    public class TcpServer
    {
        AndroidIstekKontrol android_istek_kontrol;
        public static TcpListener serverSocket;
        TcpClient clientSocket;
        private IPAddress IPLOCALADRES = IPAddress.Any;
        private int SOCKETPORT = 12346;
        bool serverOpened;
        public TcpServer()
        {
            serverSocket = new TcpListener(IPLOCALADRES, SOCKETPORT);
            android_istek_kontrol = new AndroidIstekKontrol();
            serverOpened = false;
        }
        public void run()
        {
            serverSocket.Start();
            Console.WriteLine("Server Başladı:" + IPLOCALADRES + ":" + SOCKETPORT);
            while (!serverOpened)
            {
                try
                {
                    clientSocket = serverSocket.AcceptTcpClient(); //Bir client bağlandı
                    NetworkStream stream = clientSocket.GetStream();
                    byte[] gelenMesajByte = new byte[clientSocket.ReceiveBufferSize]; //gelen mesajın boyutu kadar byte dizisi
                    stream.Read(gelenMesajByte, 0, gelenMesajByte.Length);//mesaj okunuyor ve gelenMesajByte dizisine atılıyor
                    String gelenMesajString = Encoding.UTF8.GetString(gelenMesajByte).Replace("\0", null);//stringe çevriliyor..

                    /**
                    Burada client isteğine gönderilecek mesaj için önce gelen mesajı analiz edicez
                    Sonrasında gelen isteğe cevap oluşturcaz 
                    **/

                    //Android gönderilecek mesaj oluşturuluyor
                    String responseMessage = android_istek_kontrol.androidMesajOlustur(gelenMesajString);
                    byte[] responsemsg = Encoding.UTF8.GetBytes(responseMessage);
                    stream.Write(responsemsg, 0, responsemsg.Length);
                    clientSocket.Close();
                }
                catch (Exception ex)
                {
                    if (ex.Message.ToString().Equals("Engelleyici bir işlem, bir WSACancelBlockingCall çağrısıyla kesildi"))
                    {
                        Console.WriteLine("Server Durduruldu");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("class tcpServer -> while döngüsü içerisinde hata : " + ex.Message.ToString());
                        Console.WriteLine("İstemci bağlantıyı kapattı");
                    }
                }
            }
        }
        public void serverKapat()
        {
            serverOpened = true;
            serverSocket.Stop();
        }
    }
}
