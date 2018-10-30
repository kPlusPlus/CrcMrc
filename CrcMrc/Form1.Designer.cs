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
            this.lvProcess = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lvProcess
            // 
            this.lvProcess.Location = new System.Drawing.Point(12, 12);
            this.lvProcess.Name = "lvProcess";
            this.lvProcess.ShowItemToolTips = true;
            this.lvProcess.Size = new System.Drawing.Size(989, 528);
            this.lvProcess.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvProcess.TabIndex = 0;
            this.lvProcess.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 552);
            this.Controls.Add(this.lvProcess);
            this.Name = "Form1";
            this.Text = "Crc Mrc";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvProcess;
    }
}

