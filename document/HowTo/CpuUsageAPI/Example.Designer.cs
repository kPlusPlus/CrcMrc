namespace CpuUsageAPI
{
    partial class Example
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
            this.UsageTimer = new System.Windows.Forms.Timer(this.components);
            this.ProcessView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // UsageTimer
            // 
            this.UsageTimer.Enabled = true;
            this.UsageTimer.Interval = 1000;
            this.UsageTimer.Tick += new System.EventHandler(this.UsageTimer_Tick);
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
            this.ProcessView.Size = new System.Drawing.Size(388, 275);
            this.ProcessView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ProcessView.TabIndex = 0;
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
            // Example
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 275);
            this.Controls.Add(this.ProcessView);
            this.DoubleBuffered = true;
            this.Name = "Example";
            this.Text = "Cpu usage the API way";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer UsageTimer;
        private System.Windows.Forms.ListView ProcessView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

