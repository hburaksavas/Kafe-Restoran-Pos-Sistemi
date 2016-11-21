using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ClientAnaSayfa
{
    public class Client
    {
        public static ServiceReference1.Service1Client wcfRequest()
        {
            try
            {
                NetTcpBinding myBinding = new NetTcpBinding();
                myBinding.Security.Mode = SecurityMode.None;
                string tcpUri = "net.tcp://192.168.1.99:7755/Service";
                EndpointAddress myEndpointAddress = new EndpointAddress(tcpUri);
                ServiceReference1.Service1Client client = new ServiceReference1.Service1Client(myBinding, myEndpointAddress);
                return client;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex);
                return null;
            }
        }
    }
}
