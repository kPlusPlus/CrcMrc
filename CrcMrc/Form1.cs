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



namespace CrcMrc
{
    public partial class Form1 : Form
    {
        private string sCompName = "";
        private string sIP = "";
        private string sLocation = "";

        public Form1()
        {
            InitializeComponent();
            PopulateLB();
        }

        #region *****  F U N C T I O NS  *****

        private void InitInfo()
        {
            
        }

        private void PopulateLB()
        {
            Process[] prcs = Process.GetProcesses();
            lvProcess.Items.Clear();
            foreach (Process pn in prcs)
            {

                lvProcess.Items.Add(String.Format("{0}, ({1})", pn.ProcessName, pn.Id));
            }
        }

        #endregion
    }
}
