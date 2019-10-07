using System;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Description;
using WcfService.Shared;

namespace WcfService
{
    public class StatusHost
    {
        private static readonly Uri BaseAddress = new Uri("http://localhost:9002/WcfService/");
        private ServiceHost _selfHost;

        public void Startup()
        {
            try
            {
                //Service host
                _selfHost = new ServiceHost(typeof(TestService));

                // Add a service endpoint.
                _selfHost.AddServiceEndpoint(typeof(ITestService), new WSHttpBinding(), BaseAddress);
                _selfHost.AddServiceEndpoint(typeof(ICarService), new WSHttpBinding(), BaseAddress);

                // Enable metadata exchange.
                var smb = new ServiceMetadataBehavior
                {
                    HttpGetEnabled = true
                };
                _selfHost.Description.Behaviors.Add(smb);

                // Start the service.
                _selfHost.Open();
                _selfHost.Faulted += _selfHost_Faulted;
            }
            catch (CommunicationException ce)
            {
                _selfHost.Abort();
            }
        }

        private void _selfHost_Faulted(object sender, EventArgs e)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry("Log message example", EventLogEntryType.Error, 101, 1);
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
