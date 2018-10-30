using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace kill_virus
{
    class KernelCalls
    {
       
        [DllImport("kernel32.dll")]
        static extern IntPtr OpenThread(Int32 dwDesiredAccess, bool bInheritHandle, UInt32 dwThreadId);
        //http://msdn.microsoft.com/en-us/library/windows/desktop/ms684335(v=vs.85).aspx
        [DllImport("kernel32.dll")]
        static extern UInt32 SuspendThread(IntPtr hThread);
        [DllImport("kernel32.dll")]
        static extern UInt32 ResumeThread(IntPtr hThread);



        public void SuspendProcess(int PID)
        {
            Process proc = Process.GetProcessById(PID);

            if (proc.ProcessName == string.Empty)
                return;

            foreach (ProcessThread procthr in proc.Threads)
            {
                IntPtr pOpenThread = OpenThread(0x0002, false, (UInt32)procthr.Id);

                if (pOpenThread == IntPtr.Zero)
                {
                    break;
                }

                SuspendThread(pOpenThread);
            }
        }

        public void ResumeProcess(int PID)
        {
            Process proc = Process.GetProcessById(PID);

            if (proc.ProcessName == string.Empty)
                return;

            foreach (ProcessThread procthr in proc.Threads)
            {
                IntPtr pOpenThread = OpenThread(0x0002, false, (UInt32)procthr.Id);

                if (pOpenThread == IntPtr.Zero)
                {
                    break;
                }

                ResumeThread(pOpenThread);
            }
        }

    }
}
