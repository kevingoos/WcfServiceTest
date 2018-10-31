using System.ServiceProcess;

namespace WcfService
{
    public partial class WcfService : ServiceBase
    {
        private readonly StatusHost _wcfHost;

        public WcfService()
        {
            InitializeComponent();
            _wcfHost = new StatusHost();
        }

        protected override void OnStart(string[] args)
        {
            _wcfHost.Startup();
        }

        protected override void OnStop()
        {
            _wcfHost.Stop();
        }
    }
}
