namespace kill_virus
{
    partial class Intrfc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Intrfc));
            this.Plist = new System.Windows.Forms.ListBox();
            this.Movepl = new System.Windows.Forms.Button();
            this.Selpl = new System.Windows.Forms.ListBox();
            this.kill = new System.Windows.Forms.Button();
            this.Rempl = new System.Windows.Forms.Button();
            this.Refresh = new System.Windows.Forms.Button();
            this.Suspend = new System.Windows.Forms.Button();
            this.Inform = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Plist
            // 
            this.Plist.Dock = System.Windows.Forms.DockStyle.Left;
            this.Plist.FormattingEnabled = true;
            this.Plist.Location = new System.Drawing.Point(0, 0);
            this.Plist.Name = "Plist";
            this.Plist.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.Plist.Size = new System.Drawing.Size(120, 338);
            this.Plist.Sorted = true;
            this.Plist.TabIndex = 0;
            this.Plist.SelectedIndexChanged += new System.EventHandler(this.Plist_SelectedIndexChanged);
            // 
            // Movepl
            // 
            this.Movepl.Location = new System.Drawing.Point(126, 138);
            this.Movepl.Name = "Movepl";
            this.Movepl.Size = new System.Drawing.Size(75, 32);
            this.Movepl.TabIndex = 1;
            this.Movepl.Text = "Move";
            this.Movepl.UseVisualStyleBackColor = true;
            this.Movepl.Click += new System.EventHandler(this.Movepl_Click);
            // 
            // Selpl
            // 
            this.Selpl.Dock = System.Windows.Forms.DockStyle.Right;
            this.Selpl.FormattingEnabled = true;
            this.Selpl.Location = new System.Drawing.Point(462, 0);
            this.Selpl.Name = "Selpl";
            this.Selpl.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.Selpl.Size = new System.Drawing.Size(120, 338);
            this.Selpl.Sorted = true;
            this.Selpl.TabIndex = 2;
            // 
            // kill
            // 
            this.kill.Location = new System.Drawing.Point(230, 58);
            this.kill.Name = "kill";
            this.kill.Size = new System.Drawing.Size(75, 23);
            this.kill.TabIndex = 3;
            this.kill.Text = "Kill";
            this.kill.UseVisualStyleBackColor = true;
            this.kill.Click += new System.EventHandler(this.kill_Click);
            // 
            // Rempl
            // 
            this.Rempl.Location = new System.Drawing.Point(381, 138);
            this.Rempl.Name = "Rempl";
            this.Rempl.Size = new System.Drawing.Size(75, 32);
            this.Rempl.TabIndex = 4;
            this.Rempl.Text = "Remove";
            this.Rempl.UseVisualStyleBackColor = true;
            this.Rempl.Click += new System.EventHandler(this.Rempl_Click);
            // 
            // Refresh
            // 
            this.Refresh.Location = new System.Drawing.Point(230, 100);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(75, 23);
            this.Refresh.TabIndex = 5;
            this.Refresh.Text = "Refresh";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // Suspend
            // 
            this.Suspend.Enabled = false;
            this.Suspend.Location = new System.Drawing.Point(230, 27);
            this.Suspend.Name = "Suspend";
            this.Suspend.Size = new System.Drawing.Size(75, 23);
            this.Suspend.TabIndex = 6;
            this.Suspend.Text = "Suspend";
            this.Suspend.UseVisualStyleBackColor = true;
            this.Suspend.Click += new System.EventHandler(this.Suspend_Click);
            // 
            // Inform
            // 
            this.Inform.Location = new System.Drawing.Point(126, 203);
            this.Inform.Multiline = true;
            this.Inform.Name = "Inform";
            this.Inform.Size = new System.Drawing.Size(330, 135);
            this.Inform.TabIndex = 7;
            // 
            // Intrfc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 338);
            this.Controls.Add(this.Inform);
            this.Controls.Add(this.Suspend);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.Rempl);
            this.Controls.Add(this.kill);
            this.Controls.Add(this.Selpl);
            this.Controls.Add(this.Movepl);
            this.Controls.Add(this.Plist);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Intrfc";
            this.Text = "Intrfc";
            this.Load += new System.EventHandler(this.Intrfc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Plist;
        private System.Windows.Forms.Button Movepl;
        private System.Windows.Forms.ListBox Selpl;
        private System.Windows.Forms.Button kill;
        private System.Windows.Forms.Button Rempl;
        private System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.Button Suspend;
        private System.Windows.Forms.TextBox Inform;

    }
}