﻿namespace CrcMrc
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
            this.UsageTimer = new System.Windows.Forms.Timer(this.components);
            this.btnWriteXml = new System.Windows.Forms.Button();
            this.panelTextControl = new System.Windows.Forms.Panel();
            this.txtControl = new System.Windows.Forms.TextBox();
            this.KeyTime = new System.Windows.Forms.Timer(this.components);
            this.TimerDB = new System.Windows.Forms.Timer(this.components);
            this.btnUsageTimer = new System.Windows.Forms.Button();
            this.btnKeyTime = new System.Windows.Forms.Button();
            this.btnTimerDB = new System.Windows.Forms.Button();
            this.lvLog = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.panelTextControl.SuspendLayout();
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
            this.ProcessView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.ProcessView.Dock = System.Windows.Forms.DockStyle.Fill;
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
            // UsageTimer
            // 
            this.UsageTimer.Enabled = true;
            this.UsageTimer.Interval = global::CrcMrc.Properties.Settings.Default.TickTime;
            this.UsageTimer.Tick += new System.EventHandler(this.UsageTimer_Tick);
            // 
            // btnWriteXml
            // 
            this.btnWriteXml.Location = new System.Drawing.Point(731, 13);
            this.btnWriteXml.Name = "btnWriteXml";
            this.btnWriteXml.Size = new System.Drawing.Size(169, 30);
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
            this.txtControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtControl.Location = new System.Drawing.Point(0, 0);
            this.txtControl.Multiline = true;
            this.txtControl.Name = "txtControl";
            this.txtControl.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtControl.Size = new System.Drawing.Size(713, 49);
            this.txtControl.TabIndex = 0;
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
            // btnUsageTimer
            // 
            this.btnUsageTimer.Location = new System.Drawing.Point(731, 481);
            this.btnUsageTimer.Name = "btnUsageTimer";
            this.btnUsageTimer.Size = new System.Drawing.Size(107, 23);
            this.btnUsageTimer.TabIndex = 3;
            this.btnUsageTimer.Text = "UsageTimer";
            this.btnUsageTimer.UseVisualStyleBackColor = true;
            this.btnUsageTimer.Click += new System.EventHandler(this.btnUsageTimer_Click);
            // 
            // btnKeyTime
            // 
            this.btnKeyTime.Location = new System.Drawing.Point(731, 510);
            this.btnKeyTime.Name = "btnKeyTime";
            this.btnKeyTime.Size = new System.Drawing.Size(107, 23);
            this.btnKeyTime.TabIndex = 4;
            this.btnKeyTime.Text = "KeyTime";
            this.btnKeyTime.UseVisualStyleBackColor = true;
            this.btnKeyTime.Click += new System.EventHandler(this.btnKeyTime_Click);
            // 
            // btnTimerDB
            // 
            this.btnTimerDB.Location = new System.Drawing.Point(731, 539);
            this.btnTimerDB.Name = "btnTimerDB";
            this.btnTimerDB.Size = new System.Drawing.Size(107, 23);
            this.btnTimerDB.TabIndex = 5;
            this.btnTimerDB.Text = "TimerDB";
            this.btnTimerDB.UseVisualStyleBackColor = true;
            this.btnTimerDB.Click += new System.EventHandler(this.btnTimerDB_Click);
            // 
            // lvLog
            // 
            this.lvLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.lvLog.Location = new System.Drawing.Point(12, 481);
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
            // 
            // Form2api
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 763);
            this.Controls.Add(this.lvLog);
            this.Controls.Add(this.btnTimerDB);
            this.Controls.Add(this.btnKeyTime);
            this.Controls.Add(this.btnUsageTimer);
            this.Controls.Add(this.panelTextControl);
            this.Controls.Add(this.btnWriteXml);
            this.Controls.Add(this.panel1);
            this.Name = "Form2api";
            this.Text = "Form2api";
            this.Leave += new System.EventHandler(this.Form2api_Leave);
            this.panel1.ResumeLayout(false);
            this.panelTextControl.ResumeLayout(false);
            this.panelTextControl.PerformLayout();
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
    }
}