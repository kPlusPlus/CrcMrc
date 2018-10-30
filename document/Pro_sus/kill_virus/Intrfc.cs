using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;

namespace kill_virus
{
    public partial class Intrfc : Form
    {
        KernelCalls kc = new KernelCalls();
        bool IsSuspended=false;
        List<int> SusLis = new List<int>();
        
        public Intrfc()
        {
            InitializeComponent();
            Timer tmrCallBgWorker = new System.Windows.Forms.Timer();
            tmrCallBgWorker.Interval = 1000;
            File.Delete(@"Proc.log");
            tmrCallBgWorker.Tick += new EventHandler(tmrCallBgWorker_Tick);
            tmrCallBgWorker.Start();
            
            

        }

        void tmrCallBgWorker_Tick(object sender, EventArgs e)
        {
            dump();
        }

        private void Intrfc_Load(object sender, EventArgs e)
        {
            populateLB();
        }

        private void Movepl_Click(object sender, EventArgs e)
        {
            System.Collections.IEnumerator enumerator = Plist.SelectedItems.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Object p = (Object)enumerator.Current;
                Selpl.Items.Add(Plist.GetItemText(p));
            }
            UpdateContrls();          
           
        }

        private void Rempl_Click(object sender, EventArgs e)
        {
            Object[] divoba=new Object[Selpl.SelectedItems.Count];           
            Selpl.SelectedItems.CopyTo(divoba, 0);
            foreach(Object disval in divoba)
            {
                Selpl.Items.Remove(disval);
            }
            
        }

        private void kill_Click(object sender, EventArgs e)
        {
            ActionType(2);
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            populateLB();
        }

        private void populateLB()
        {
            Process[] prcs = Process.GetProcesses();
            Plist.Items.Clear();
            foreach (Process pn in prcs)
            {
                
                Plist.Items.Add(String.Format("{0}, ({1})",pn.ProcessName, pn.Id ));
            }
        }

        private void Plist_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
               
                String[] prvl = (Plist.GetItemText(Plist.SelectedItem)).Split(','); 
                int start=prvl[1].IndexOf('(');
                int prid = int.Parse(prvl[1].Substring(start+1,prvl[1].IndexOf(')')-(start+1) ));
                Process piin = Process.GetProcessById(prid);
                ProcessModule spm = piin.MainModule;
                Inform.Text = String.Format("Filename:{0}\r\nMemory Size:{1}\r\nCreation Time:{2}", spm.FileName, spm.ModuleMemorySize, File.GetCreationTime(spm.FileName));               
                
            }
            catch { }
        }

        private void Suspend_Click(object sender, EventArgs e)
        {
            if (IsSuspended)
            { ActionType(0); }
            else { ActionType(1); }
        }

        private void ActionType(int level)
        {
            List<int> pidtk = new List<int>();
            try
            {
                foreach (Object sobj in Selpl.Items)
                {
                    String[] prvl = (Plist.GetItemText(sobj)).Split(',');
                    
                    int prid = int.Parse((prvl[1].Replace('(', ' ')).Replace(')', ' '));
                    pidtk.Add(prid);
                                   
                }

                if ((level == 0) & (IsSuspended))
                {
                    
                    foreach (int prd in SusLis)
                    {
                        try
                        {
                            if (!Process.GetProcessById(prd).HasExited)
                            {
                                kc.ResumeProcess(prd);                                
                            }

                        }
                        catch { }
                    }
                    SusLis.Clear();
                    IsSuspended = false;
                    
                }

                if ((level == 1 | level == 2) & (!IsSuspended))
                {
                    SusLis.Clear();
                    foreach (int prd in pidtk)
                    {
                        try
                        {
                            if (!Process.GetProcessById(prd).HasExited)
                            {
                                kc.SuspendProcess(prd);
                                SusLis.Add(prd);
                            }
                                
                        }
                        catch { }
                    }
                    IsSuspended = true;
                }

                if (level == 2)
                {

                    foreach (int prd in pidtk)
                    {
                        try
                        {
                            if (!Process.GetProcessById(prd).HasExited)
                                Process.GetProcessById(prd).Kill();
                        }
                        catch { }
                    }
                    IsSuspended = false;
                    Selpl.Items.Clear();
                }

                UpdateContrls();

            }
            catch { }
            
        }

        private void UpdateContrls()
        {
            if (IsSuspended)
            {
                Suspend.Text = "Resume";
            }
            else { Suspend.Text = "Suspend"; }
            if (Selpl.Items.Count > 0 & !Suspend.Enabled)
            {
                Suspend.Enabled = true;
            }
            if (Selpl.Items.Count <1) 
            {
                Suspend.Enabled = false;
            }
        }

        private List<int> ProcLis = new List<int>();
        private void dump()
        {
            Process[] prcs = Process.GetProcesses(); 
            
            foreach (Process pn in prcs)
            {
                if (!ProcLis.Contains(pn.Id))
                {
                    try
                    {
                        ProcLis.Add(pn.Id);
                        File.AppendAllText(@"Proc.log", String.Format("{0}\t\t\t{1}\r\n", pn.ProcessName, pn.MainModule.FileName));
                    }
                    catch { }
                }
                
            }


        }

       
    }
}
