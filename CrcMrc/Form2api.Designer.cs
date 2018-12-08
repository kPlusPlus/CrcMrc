namespace CrcMrc
{
    partial class Form2api
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ProcessView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnWriteXml = new System.Windows.Forms.Button();
            this.panelTextControl = new System.Windows.Forms.Panel();
            this.txtControl = new System.Windows.Forms.TextBox();
            this.btnUsageTimer = new System.Windows.Forms.Button();
            this.btnKeyTime = new System.Windows.Forms.Button();
            this.btnTimerDB = new System.Windows.Forms.Button();
            this.lvLog = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblProcess = new System.Windows.Forms.Label();
            this.lblDataSet = new System.Windows.Forms.Label();
            this.lblKeyLog = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelCounters = new System.Windows.Forms.Panel();
            this.lblDBCount = new System.Windows.Forms.Label();
            this.lblDBState = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkScrollActivity = new System.Windows.Forms.CheckBox();
            this.UsageTimer = new System.Windows.Forms.Timer(this.components);
            this.KeyTime = new System.Windows.Forms.Timer(this.components);
            this.TimerDB = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panelTextControl.SuspendLayout();
            this.panelCounters.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ProcessView);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(713, 465);
            this.panel1.TabIndex = 0;
            // 
            // ProcessView
            // 
            this.ProcessView.BackColor = System.Drawing.Color.Gray;
            this.ProcessView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProcessView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.ProcessView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProcessView.ForeColor = System.Drawing.Color.LemonChiffon;
            this.ProcessView.FullRowSelect = true;
            this.ProcessView.Location = new System.Drawing.Point(0, 0);
            this.ProcessView.Name = "ProcessView";
            this.ProcessView.Size = new System.Drawing.Size(713, 465);
            this.ProcessView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ProcessView.TabIndex = 1;
            this.ProcessView.UseCompatibleStateImageBehavior = false;
            this.ProcessView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Process Name";
            this.columnHeader1.Width = 202;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "PID";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 77;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Cpu Usage %";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 104;
            // 
            // btnWriteXml
            // 
            this.btnWriteXml.Location = new System.Drawing.Point(4, 12);
            this.btnWriteXml.Name = "btnWriteXml";
            this.btnWriteXml.Size = new System.Drawing.Size(107, 30);
            this.btnWriteXml.TabIndex = 1;
            this.btnWriteXml.Text = "Spremi";
            this.btnWriteXml.UseVisualStyleBackColor = true;
            this.btnWriteXml.Click += new System.EventHandler(this.btnWriteXml_Click);
            // 
            // panelTextControl
            // 
            this.panelTextControl.Controls.Add(this.txtControl);
            this.panelTextControl.Location = new System.Drawing.Point(12, 702);
            this.panelTextControl.Name = "panelTextControl";
            this.panelTextControl.Size = new System.Drawing.Size(713, 49);
            this.panelTextControl.TabIndex = 2;
            // 
            // txtControl
            // 
            this.txtControl.AcceptsTab = true;
            this.txtControl.BackColor = System.Drawing.Color.Black;
            this.txtControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtControl.ForeColor = System.Drawing.Color.Yellow;
            this.txtControl.Location = new System.Drawing.Point(0, 0);
            this.txtControl.Multiline = true;
            this.txtControl.Name = "txtControl";
            this.txtControl.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtControl.Size = new System.Drawing.Size(713, 49);
            this.txtControl.TabIndex = 0;
            // 
            // btnUsageTimer
            // 
            this.btnUsageTimer.Location = new System.Drawing.Point(4, 611);
            this.btnUsageTimer.Name = "btnUsageTimer";
            this.btnUsageTimer.Size = new System.Drawing.Size(107, 23);
            this.btnUsageTimer.TabIndex = 3;
            this.btnUsageTimer.Text = "UsageTimer";
            this.btnUsageTimer.UseVisualStyleBackColor = true;
            this.btnUsageTimer.Click += new System.EventHandler(this.btnUsageTimer_Click);
            // 
            // btnKeyTime
            // 
            this.btnKeyTime.Location = new System.Drawing.Point(4, 640);
            this.btnKeyTime.Name = "btnKeyTime";
            this.btnKeyTime.Size = new System.Drawing.Size(107, 23);
            this.btnKeyTime.TabIndex = 4;
            this.btnKeyTime.Text = "KeyTime";
            this.btnKeyTime.UseVisualStyleBackColor = true;
            this.btnKeyTime.Click += new System.EventHandler(this.btnKeyTime_Click);
            // 
            // btnTimerDB
            // 
            this.btnTimerDB.Location = new System.Drawing.Point(3, 669);
            this.btnTimerDB.Name = "btnTimerDB";
            this.btnTimerDB.Size = new System.Drawing.Size(107, 23);
            this.btnTimerDB.TabIndex = 5;
            this.btnTimerDB.Text = "TimerDB";
            this.btnTimerDB.UseVisualStyleBackColor = true;
            this.btnTimerDB.Click += new System.EventHandler(this.btnTimerDB_Click);
            // 
            // lvLog
            // 
            this.lvLog.BackColor = System.Drawing.Color.Gray;
            this.lvLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.lvLog.ForeColor = System.Drawing.Color.Yellow;
            this.lvLog.Location = new System.Drawing.Point(12, 481);
            this.lvLog.MultiSelect = false;
            this.lvLog.Name = "lvLog";
            this.lvLog.Size = new System.Drawing.Size(713, 223);
            this.lvLog.TabIndex = 6;
            this.lvLog.UseCompatibleStateImageBehavior = false;
            this.lvLog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Time";
            this.columnHeader4.Width = 230;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Desc";
            this.columnHeader5.Width = 463;
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcess.Location = new System.Drawing.Point(1, 153);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(61, 16);
            this.lblProcess.TabIndex = 7;
            this.lblProcess.Text = "Procesi";
            // 
            // lblDataSet
            // 
            this.lblDataSet.AutoSize = true;
            this.lblDataSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataSet.Location = new System.Drawing.Point(93, 153);
            this.lblDataSet.Name = "lblDataSet";
            this.lblDataSet.Size = new System.Drawing.Size(64, 16);
            this.lblDataSet.TabIndex = 8;
            this.lblDataSet.Text = "DataSet";
            // 
            // lblKeyLog
            // 
            this.lblKeyLog.AutoSize = true;
            this.lblKeyLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeyLog.Location = new System.Drawing.Point(182, 153);
            this.lblKeyLog.Name = "lblKeyLog";
            this.lblKeyLog.Size = new System.Drawing.Size(56, 16);
            this.lblKeyLog.TabIndex = 9;
            this.lblKeyLog.Text = "Keylog";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Process            DataSet          KeyLog";
            // 
            // panelCounters
            // 
            this.panelCounters.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelCounters.Controls.Add(this.lblDBCount);
            this.panelCounters.Controls.Add(this.lblDBState);
            this.panelCounters.Controls.Add(this.label2);
            this.panelCounters.Controls.Add(this.chkScrollActivity);
            this.panelCounters.Controls.Add(this.label1);
            this.panelCounters.Controls.Add(this.lblProcess);
            this.panelCounters.Controls.Add(this.btnTimerDB);
            this.panelCounters.Controls.Add(this.btnWriteXml);
            this.panelCounters.Controls.Add(this.lblKeyLog);
            this.panelCounters.Controls.Add(this.btnKeyTime);
            this.panelCounters.Controls.Add(this.lblDataSet);
            this.panelCounters.Controls.Add(this.btnUsageTimer);
            this.panelCounters.Location = new System.Drawing.Point(731, 12);
            this.panelCounters.Name = "panelCounters";
            this.panelCounters.Size = new System.Drawing.Size(264, 739);
            this.panelCounters.TabIndex = 11;
            // 
            // lblDBCount
            // 
            this.lblDBCount.AutoSize = true;
            this.lblDBCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDBCount.Location = new System.Drawing.Point(93, 216);
            this.lblDBCount.Name = "lblDBCount";
            this.lblDBCount.Size = new System.Drawing.Size(47, 16);
            this.lblDBCount.TabIndex = 14;
            this.lblDBCount.Text = "Count";
            // 
            // lblDBState
            // 
            this.lblDBState.AutoSize = true;
            this.lblDBState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDBState.Location = new System.Drawing.Point(3, 216);
            this.lblDBState.Name = "lblDBState";
            this.lblDBState.Size = new System.Drawing.Size(44, 16);
            this.lblDBState.TabIndex = 13;
            this.lblDBState.Text = "State";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "DB State          DB count";
            // 
            // chkScrollActivity
            // 
            this.chkScrollActivity.AutoSize = true;
            this.chkScrollActivity.Checked = true;
            this.chkScrollActivity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkScrollActivity.Location = new System.Drawing.Point(4, 469);
            this.chkScrollActivity.Name = "chkScrollActivity";
            this.chkScrollActivity.Size = new System.Drawing.Size(86, 17);
            this.chkScrollActivity.TabIndex = 11;
            this.chkScrollActivity.Text = "ScrollActivity";
            this.chkScrollActivity.UseVisualStyleBackColor = true;
            // 
            // UsageTimer
            // 
            this.UsageTimer.Enabled = true;
            this.UsageTimer.Interval = global::CrcMrc.Properties.Settings.Default.TickTime;
            this.UsageTimer.Tick += new System.EventHandler(this.UsageTimer_Tick);
            // 
            // KeyTime
            // 
            this.KeyTime.Enabled = true;
            this.KeyTime.Interval = global::CrcMrc.Properties.Settings.Default.TickKeyboardTime;
            this.KeyTime.Tick += new System.EventHandler(this.KeyTime_Tick);
            // 
            // TimerDB
            // 
            this.TimerDB.Enabled = true;
            this.TimerDB.Interval = global::CrcMrc.Properties.Settings.Default.dbTime;
            this.TimerDB.Tick += new System.EventHandler(this.TimerDB_Tick);
            // 
            // Form2api
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 763);
            this.Controls.Add(this.panelCounters);
            this.Controls.Add(this.lvLog);
            this.Controls.Add(this.panelTextControl);
            this.Controls.Add(this.panel1);
            this.Name = "Form2api";
            this.Text = "Crc2api";
            this.Leave += new System.EventHandler(this.Form2api_Leave);
            this.panel1.ResumeLayout(false);
            this.panelTextControl.ResumeLayout(false);
            this.panelTextControl.PerformLayout();
            this.panelCounters.ResumeLayout(false);
            this.panelCounters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView ProcessView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Timer UsageTimer;
        private System.Windows.Forms.Button btnWriteXml;
        private System.Windows.Forms.Panel panelTextControl;
        public System.Windows.Forms.Timer KeyTime;
        private System.Windows.Forms.Timer TimerDB;
        public System.Windows.Forms.TextBox txtControl;
        private System.Windows.Forms.Button btnUsageTimer;
        private System.Windows.Forms.Button btnKeyTime;
        private System.Windows.Forms.Button btnTimerDB;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.Label lblDataSet;
        private System.Windows.Forms.Label lblKeyLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelCounters;
        private System.Windows.Forms.CheckBox chkScrollActivity;
        private System.Windows.Forms.Label lblDBCount;
        private System.Windows.Forms.Label lblDBState;
        private System.Windows.Forms.Label label2;
    }
}