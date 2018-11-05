namespace CrcMrc
{
    partial class Form1
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
            this.txtTerminal = new System.Windows.Forms.TextBox();
            this.lvProcess = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Updater = new System.Windows.Forms.Timer(this.components);
            this.ThreadList = new System.Windows.Forms.ListView();
            this.Column1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Column2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // txtTerminal
            // 
            this.txtTerminal.BackColor = System.Drawing.Color.Black;
            this.txtTerminal.ForeColor = System.Drawing.Color.White;
            this.txtTerminal.Location = new System.Drawing.Point(886, 415);
            this.txtTerminal.Multiline = true;
            this.txtTerminal.Name = "txtTerminal";
            this.txtTerminal.Size = new System.Drawing.Size(264, 125);
            this.txtTerminal.TabIndex = 1;
            // 
            // lvProcess
            // 
            this.lvProcess.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvProcess.FullRowSelect = true;
            this.lvProcess.GridLines = true;
            this.lvProcess.Location = new System.Drawing.Point(12, 12);
            this.lvProcess.Name = "lvProcess";
            this.lvProcess.Size = new System.Drawing.Size(868, 397);
            this.lvProcess.TabIndex = 2;
            this.lvProcess.UseCompatibleStateImageBehavior = false;
            this.lvProcess.View = System.Windows.Forms.View.Details;
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
            // Updater
            // 
            this.Updater.Enabled = true;
            this.Updater.Interval = 1200;
            this.Updater.Tick += new System.EventHandler(this.Updater_Tick);
            // 
            // ThreadList
            // 
            this.ThreadList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ThreadList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Column1,
            this.Column2});
            this.ThreadList.FullRowSelect = true;
            this.ThreadList.GridLines = true;
            this.ThreadList.Location = new System.Drawing.Point(12, 415);
            this.ThreadList.Name = "ThreadList";
            this.ThreadList.Size = new System.Drawing.Size(868, 125);
            this.ThreadList.TabIndex = 3;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 552);
            this.Controls.Add(this.ThreadList);
            this.Controls.Add(this.lvProcess);
            this.Controls.Add(this.txtTerminal);
            this.Name = "Form1";
            this.Text = "Crc Mrc";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtTerminal;
        private System.Windows.Forms.ListView lvProcess;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Timer Updater;
        private System.Windows.Forms.ListView ThreadList;
        private System.Windows.Forms.ColumnHeader Column1;
        private System.Windows.Forms.ColumnHeader Column2;
    }
}

