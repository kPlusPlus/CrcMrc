using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Device;
using System.Device.Location;
using System.Net;
using System.Net.Sockets;

namespace CrcMrc
{
    public partial class Form1 : Form
    {
        private string sCompName = "";
        private string sLogUser = "";
        private string sIP = "";
        private string sLocation = "";
        // The coordinate watcher.
        private GeoCoordinateWatcher Watcher = null;

        public Form1()
        {
            InitializeComponent();
            //PopulateLB();     //TODO: makni ovo
            InitInfo();       //TODO: ovo prepravi u finalnoj verziji
        }

        #region *****  F U N C T I O NS  *****

        private void InitInfo()
        {
            /*
            System.Device.Location.GeoCoordinateWatcher watcher = new System.Device.Location.GeoCoordinateWatcher();
            // Create the watcher.
            Watcher = new GeoCoordinateWatcher();
            // Catch the StatusChanged event.
            Watcher.StatusChanged += Watcher_StatusChanged;
            // Start the watcher.
            Watcher.Start();

            sCompName = Environment.MachineName;
            sLogUser = Environment.UserName;
            sIP = GetLocalIPAddress();
            */
            // watcher.Position.Location.IsUnknown
            //MessageBox.Show(" location: " + watcher.Position.Location.Longitude);
            //MessageBox.Show("coputer " + Environment.MachineName);
            //MessageBox.Show("user" + Environment.UserName);

            Updater.Interval = Convert.ToInt16( Properties.Settings.Default["TickTime"] );

        }

        private void PopulateLB()
        {
            Process[] prcs = Process.GetProcesses();
            

            foreach (Process pn in prcs)
            {
                if (IsProcc(pn.ProcessName))
                {
                    lvProcess.Items.Add(pn.ProcessName + "," + pn.Id);
                }
                
            }
        }


        public Boolean IsProcc(string sPrca)
        {
            if (sPrca.Contains("svchost"))
                return false;


            return true;
        }

        // The watcher's status has change. See if it is ready.
        public void Watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            if (e.Status == GeoPositionStatus.Ready)
            {
                // Display the latitude and longitude.
                if (Watcher.Position.Location.IsUnknown)
                {
                    sLocation = "";
                }
                else
                {
                    sLocation = Watcher.Position.Location.Latitude.ToString() + ";" + Watcher.Position.Location.Longitude.ToString();
                }
            }
        }


        public  string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        #endregion

        

        private void Updater_Tick(object sender, EventArgs e)
        {
            ProcessCpu.UpdateProcessList();
            ThreadCpu.UpdateThreadList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // sets the process events
            ProcessCpu.CallNewProcess += new NewProcessEvent(OnNewProcess);
            ProcessCpu.CallProcessUpdate += new ProcessUpdateEvent(OnProcessUpdate);
            ProcessCpu.CallProcessClose += new ProcessCloseEvent(OnProcessClosed);
            ThreadCpu.CallNewThread += new NewThreadEvent(OnNewThread);
            ThreadCpu.CallThreadUpdate += new ThreadUpdateEvent(OnThreadUpdate);
            ThreadCpu.CallThreadClose += new ThreadCloseEvent(OnThreadClose);
        }


        #region  *** *** *** *** *** ***
        private void OnNewProcess(ProcessInfo TempProcess)
        {
            ListViewItem NewProcess = lvProcess.Items.Add(TempProcess.Name);
            NewProcess.SubItems.Add(TempProcess.CpuUsage);
            NewProcess.SubItems.Add(TempProcess.ID.ToString());
        }


        private void OnProcessUpdate(ProcessInfo TempProcess)
        {
            ListViewItem CurrentProcess = ProcessByID(TempProcess.ID);

            if (CurrentProcess == null) return;

            CurrentProcess.SubItems[1].Text = TempProcess.CpuUsage;
        }


        private void OnProcessClosed(ProcessInfo TempProcess)
        {
            ListViewItem CurrentProcess = ProcessByID(TempProcess.ID);

            if (CurrentProcess == null) return;

            lvProcess.Items.Remove(CurrentProcess);
        }


        private void OnNewThread(ThreadInfo TempThread)
        {
            ListViewItem SelectedThread = ThreadList.Items.Add(TempThread.ID);
            SelectedThread.SubItems.Add(TempThread.CpuUsage);
        }

        private void OnThreadUpdate(ThreadInfo TempThread)
        {
            ListViewItem SelectedThread = ThreadByID(TempThread.ID);
            if (SelectedThread == null) return;

            SelectedThread.SubItems[1].Text = TempThread.CpuUsage;
        }

        private void OnThreadClose(ThreadInfo TempThread)
        {
            ListViewItem SelectedThread = ThreadByID(TempThread.ID);
            if (SelectedThread == null) return;

            ThreadList.Items.Remove(SelectedThread);
        }

        private ListViewItem ProcessByID(int ID)
        {
            foreach (ListViewItem TempProcess in lvProcess.Items)
                if (TempProcess.SubItems[2].Text == ID.ToString())
                    return TempProcess;

            return null;
        }

        private ListViewItem ThreadByID(string ID)
        {
            if (lvProcess.Items == null) return null;

            foreach (ListViewItem TempThread in ThreadList.Items)
                if (TempThread.SubItems[0].Text == ID)
                    return TempThread;
            return null;
        }


        #endregion



    }

    public class process_control
    {
        public int procID;
        public string procName = "";
        public string sCompName = "";
        public string sLogUser = "";
        public string sIP = "";
        public string sLocation = "";
    }

}
