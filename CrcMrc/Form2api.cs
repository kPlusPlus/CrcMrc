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


        ArrayList ProcessDataList = new ArrayList();
        ArrayList IDList = new ArrayList();
        ListViewItem IdleProcessItem;
        dsProcess.ProcessDataTable pdt;
        common comm;


        public Form2api()
        {
            InitializeComponent();
            comm = new common();
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
                row.IP = GetIPAddress();
                row.ProcesName = TempProcess.Name;
                row.CPUUse = TempProcess.CpuUsage;
                row.ProcTime = dt;
                row.ProcID = (Int32) TempProcess.ID;                                

                Int32 hwnd = 0;
                hwnd = (Int32) GetActiveWindow();
                Int32 actproc = 0;
                actproc = GetWindowProcessID_(hwnd);
                IntPtr handle;
                handle = GetForegroundWindow();

                if (row.ProcID == actproc)
                {
                    Console.WriteLine((IntPtr)row.ProcID);
                    Console.WriteLine(actproc);
                }
                else
                {
                    Console.WriteLine("*" + (IntPtr)row.ProcID);
                    Console.WriteLine("*" + actproc + "*");
                    Process localById = Process.GetProcessById(actproc);
                    Console.WriteLine(localById.ProcessName);
                }

                Console.WriteLine("____________");
                
                pdt.AddProcessRow(row);
                

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
            GetUsage();
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
                GetWindowThreadProcessId(pLast, out iProcess_);
                if (iProcess_ == process) apRet[iCount++] = pLast;
            } while (pLast != IntPtr.Zero);
            System.Array.Resize(ref apRet, iCount);
            return apRet;
        }

        private string GetCompname()
        {
            return Environment.MachineName + "|" + Dns.GetHostName();
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
        

    }
}