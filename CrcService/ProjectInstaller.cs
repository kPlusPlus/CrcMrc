using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CrcService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        private void serviceInstaller1_Committed(object sender, InstallEventArgs e)
        {
            StreamWriter sw;
            sw = File.AppendText("sashidhar.txt");
            sw.WriteLine( DateTime.Now +  " radimmmmm ");
            SetInterActWithDeskTop(); //WORKING
            sw.WriteLine(DateTime.Now + " setiran ");
            sw.Close();
        }


        private static void SetInterActWithDeskTop()
        {
            var service = new System.Management.ManagementObject(
                    String.Format("WIN32_Service.Name='{0}'", "ServiceCrc"));
            try
            {
                var paramList = new object[11];
                paramList[5] = true;
                service.InvokeMethod("Change", paramList);
            }
            finally
            {
                service.Dispose();
            }
        }
    }
}
