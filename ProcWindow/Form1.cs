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
using System.Runtime.InteropServices;

namespace ProcWindow
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr parentWindow, IntPtr previousChildWindow, string windowClass, string windowTitle);

        [DllImport("user32")]
        private static extern UInt32 GetWindowThreadProcessId(Int32 hWnd, out Int32 lpdwProcessId);

        [DllImport("user32.dll")]
        static extern IntPtr GetActiveWindow();

        Process[] procesi;

        public Form1()
        {
            InitializeComponent();
        }

        public void GetProcWindows()
        {
            this.textBox1.Text = "";
            procesi = Process.GetProcesses();
            for(int i = 0; i < procesi.Length; i++)
            {
                Console.WriteLine("---------------------");
                Console.WriteLine(i + " " + procesi[i].ProcessName + " " + procesi[i].Id);
                textBox1.Text += "---------------------" + Environment.NewLine;
                textBox1.Text += i + " " + procesi[i].ProcessName + " " + procesi[i].Id + Environment.NewLine;

                IntPtr[] prozori = GetProcessWindows(procesi[i].Id);
                for(int j = 0; j < prozori.Length; j++)
                {
                    textBox1.Text += " window " + j + " " + prozori[j].ToInt32().ToString() + Environment.NewLine;
                }
            }
            Int32 hwnd = 0;
            hwnd = (Int32)GetActiveWindow();

            textBox1.Text += "*************************";
            textBox1.Text += hwnd.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetProcWindows();
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
    }
}
