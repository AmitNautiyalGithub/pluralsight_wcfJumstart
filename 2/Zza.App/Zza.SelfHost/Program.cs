using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Zza.Services;

namespace Zza.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var principal = Thread.CurrentPrincipal;

                ServiceHost host = new ServiceHost(typeof(ZzaService));
                host.Open();

                Console.WriteLine("Host is started, Hit any key to exit!");
                Console.ReadKey();
                host.Close();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }
    }
}
