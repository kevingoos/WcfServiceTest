using System;

namespace WcfConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var statusHost = new StatusHost();
            statusHost.Startup();

            Console.WriteLine("Press key to stop...");
            Console.ReadKey();
            statusHost.Stop();
        }
    }
}
