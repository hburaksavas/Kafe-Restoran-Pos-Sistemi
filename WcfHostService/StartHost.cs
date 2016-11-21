using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WcfHostService
{
    public class StartHost
    {
        ServiceHost host;
        public void startHost()
        {
            host = new ServiceHost(typeof(WcfServiceLibrary.Service1), new Uri("net.tcp://192.168.1.99:7755/Service"));
            host.AddServiceEndpoint(typeof(WcfServiceLibrary.IService1), new NetTcpBinding(SecurityMode.None, false), "");
            ServiceMetadataBehavior smb = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
            if (smb == null)
                smb = new ServiceMetadataBehavior();           
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            host.Description.Behaviors.Add(smb);     
            host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName,
              MetadataExchangeBindings.CreateMexTcpBinding(),"mex");
            host.Open();
        }
        
        public void closeHost()
        {
            host.Close();
        }
    }
}
