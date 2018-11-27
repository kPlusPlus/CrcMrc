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
            this.UsageTimer = new System.Windows.Forms.Timer(this.components);
            this.btnWriteXml = new System.Windows.Forms.Button();
            this.panelTextControl = new System.Windows.Forms.Panel();
            this.txtControl = new System.Windows.Forms.TextBox();
            this.KeyTime = new System.Windows.Forms.Timer(this.components);
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
            this.panelTextControl.Location = new System.Drawing.Point(12, 483);
            this.panelTextControl.Name = "panelTextControl";
            this.panelTextControl.Size = new System.Drawing.Size(713, 154);
            this.panelTextControl.TabIndex = 2;
            // 
            // txtControl
            // 
            this.txtControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtControl.Location = new System.Drawing.Point(0, 0);
            this.txtControl.Multiline = true;
            this.txtControl.Name = "txtControl";
            this.txtControl.Size = new System.Drawing.Size(713, 154);
            this.txtControl.TabIndex = 0;
            // 
            // KeyTime
            // 
            this.KeyTime.Enabled = true;
            this.KeyTime.Interval = global::CrcMrc.Properties.Settings.Default.TickKeyboardTime;
            this.KeyTime.Tick += new System.EventHandler(this.KeyTime_Tick);
            // 
            // Form2api
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 649);
            this.Controls.Add(this.panelTextControl);
            this.Controls.Add(this.btnWriteXml);
            this.Controls.Add(this.panel1);
            this.Name = "Form2api";
            this.Text = "Form2api";
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
        private System.Windows.Forms.TextBox txtControl;
        public System.Windows.Forms.Timer KeyTime;
    }
}