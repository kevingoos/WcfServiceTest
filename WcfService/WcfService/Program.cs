using System.ServiceProcess;

namespace WcfService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var servicesToRun = new ServiceBase[]
            {
                new WcfService()
            };
            ServiceBase.Run(servicesToRun);
        }
    }
}
