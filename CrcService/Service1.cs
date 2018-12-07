using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace CrcService
{
    public partial class ServiceCrc : ServiceBase
    {
        public ServiceCrc()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            UsageTimer.Interval = CrcService.Properties.Settings.Default.TickTime;
            KeyTime.Interval = CrcService.Properties.Settings.Default.TickKeyboardTime;
            TimerDB.Interval = CrcService.Properties.Settings.Default.dbTime;

            UsageTimer.Enabled = true;
            KeyTime.Enabled = true;
            TimerDB.Enabled = true;

            UsageTimer.Start();
            //KeyTime.Start();
            TimerDB.Start();
        }

        protected override void OnStop()
        {
        }
    }
}
