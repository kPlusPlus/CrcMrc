using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace CpuUsageManaged
{
	public class Example : System.Windows.Forms.Form
	{
		private PerformanceCounter IdleCpuUsage;
		private System.Windows.Forms.Timer Updater;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ListView ProcessList;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ListView ThreadList;
		private System.Windows.Forms.ColumnHeader Column1;
		private System.Windows.Forms.ColumnHeader Column2;
		private System.ComponentModel.IContainer components;

		public Example()
		{
			InitializeComponent();
			IdleCpuUsage = new PerformanceCounter("Process","% Processor Time","Idle");
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.Updater = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ThreadList = new System.Windows.Forms.ListView();
            this.Column1 = new System.Windows.Forms.ColumnHeader();
            this.Column2 = new System.Windows.Forms.ColumnHeader();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ProcessList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Updater
            // 
            this.Updater.Enabled = true;
            this.Updater.Interval = 1200;
            this.Updater.Tick += new System.EventHandler(this.Updater_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ThreadList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 238);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 128);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LemonChiffon;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Threads";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ThreadList
            // 
            this.ThreadList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ThreadList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Column1,
            this.Column2});
            this.ThreadList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ThreadList.FullRowSelect = true;
            this.ThreadList.Location = new System.Drawing.Point(0, 16);
            this.ThreadList.Name = "ThreadList";
            this.ThreadList.Size = new System.Drawing.Size(388, 108);
            this.ThreadList.TabIndex = 2;
            this.ThreadList.UseCompatibleStateImageBehavior = false;
            this.ThreadList.View = System.Windows.Forms.View.Details;
            // 
            // Column1
            // 
            this.Column1.Text = "ID";
            this.Column1.Width = 101;
            // 
            // Column2
            // 
            this.Column2.Text = "Cpu";
            this.Column2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Column2.Width = 90;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Goldenrod;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.ProcessList);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(392, 236);
            this.panel2.TabIndex = 3;
            // 
            // ProcessList
            // 
            this.ProcessList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.ProcessList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProcessList.FullRowSelect = true;
            this.ProcessList.Location = new System.Drawing.Point(0, 0);
            this.ProcessList.Name = "ProcessList";
            this.ProcessList.Size = new System.Drawing.Size(388, 232);
            this.ProcessList.TabIndex = 1;
            this.ProcessList.UseCompatibleStateImageBehavior = false;
            this.ProcessList.View = System.Windows.Forms.View.Details;
            this.ProcessList.DoubleClick += new System.EventHandler(this.ProcessList_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Process";
            this.columnHeader1.Width = 176;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Cpu";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 72;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "PID";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Example
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(392, 366);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(400, 376);
            this.Name = "Example";
            this.Text = "Cpu usage the managed way";
            this.Load += new System.EventHandler(this.Example_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new Example());
		}

		private void Updater_Tick(object sender, System.EventArgs e)
		{
			ProcessCpu.UpdateProcessList();
			ThreadCpu.UpdateThreadList();
		}

		private void OnNewProcess(ProcessInfo TempProcess)
		{
			ListViewItem NewProcess = ProcessList.Items.Add(TempProcess.Name);
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

			ProcessList.Items.Remove(CurrentProcess);			
		}

		private ListViewItem ProcessByID(int ID)
		{
			foreach (ListViewItem TempProcess in ProcessList.Items)
				if (TempProcess.SubItems[2].Text == ID.ToString())
					return TempProcess;
			
			return null;
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

		private ListViewItem ThreadByID(string ID)
		{
			if (ProcessList.Items == null) return null;

			foreach (ListViewItem TempThread in ThreadList.Items)
				if (TempThread.SubItems[0].Text == ID)
					return TempThread;
			return null;
		}

		private void Example_Load(object sender, System.EventArgs e)
		{
            // sets the process events
            ProcessCpu.CallNewProcess += new NewProcessEvent(OnNewProcess);
			ProcessCpu.CallProcessUpdate += new ProcessUpdateEvent(OnProcessUpdate);
			ProcessCpu.CallProcessClose += new ProcessCloseEvent(OnProcessClosed);
			ThreadCpu.CallNewThread += new NewThreadEvent(OnNewThread);
			ThreadCpu.CallThreadUpdate += new ThreadUpdateEvent(OnThreadUpdate);
			ThreadCpu.CallThreadClose += new ThreadCloseEvent(OnThreadClose);
		}

		private void ProcessList_DoubleClick(object sender, System.EventArgs e)
		{
			
			if (ProcessList.SelectedItems.Count > 0)
			{
				ThreadList.Items.Clear();
				ThreadCpu.UpdateThreadList(Convert.ToInt32(ProcessList.SelectedItems[0].SubItems[2].Text));
			}
		}
	}
}
