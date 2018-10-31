using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using WcfConsole.Shared;

namespace WcfConsole
{
    public class StatusHost
    {
        private static readonly Uri BaseAddress = new Uri("http://localhost:9001/WcfConsole/");
        private ServiceHost _selfHost;

        public void Startup()
        {
            try
            {
                //Service host
                _selfHost = new ServiceHost(typeof(TestService), BaseAddress);

                // Add a service endpoint.
                _selfHost.AddServiceEndpoint(typeof(ITestService), new WSHttpBinding(), "StatusService");

                // Enable metadata exchange.
                var smb = new ServiceMetadataBehavior { HttpGetEnabled = true };
                _selfHost.Description.Behaviors.Add(smb);

                // Start the service.
                _selfHost.Open();
            }
            catch (CommunicationException ce)
            {
                _selfHost.Abort();
            }
        }

        public void Stop()
        {
            if (_selfHost != null)
            {
                _selfHost.Close();
                _selfHost = null;
            }
        }
    }
}
