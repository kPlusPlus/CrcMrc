using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CrcService
{
    partial class ServCrc : ServiceBase
    {
        private static Timer aTimer;

        public ServCrc()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {            
            this.eventLog1.WriteEntry("[+] Kiklop start");
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 6000;
            aTimer.Elapsed += OnTimedEvent;
            aTimer.Enabled = true;
            aTimer.Start();

        }

        protected override void OnStop()
        {            
            this.eventLog1.WriteEntry("[-] Kiklop stop");
            aTimer.Stop();
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            this.eventLog1.WriteEntry("The Elapsed event was raised at " + DateTime.Now.ToString());
        }

    }
}
