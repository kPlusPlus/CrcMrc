using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace CrcService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {

            //ServiceBase service = new ServiceCrc();
            //ServiceBase.Run(service);

            //ServiceBase service = new SampleService();
            //ServiceBase.Run(service);

            ServiceBase service = new ServCrc();
            ServiceBase.Run(service);

/*
            ServiceBase[] ServicesToRun;

            ServicesToRun = new ServiceBase[]
            {
                            new ServiceCrc()
            };
            ServiceBase.Run(ServicesToRun);
*/


        }
    }
}
