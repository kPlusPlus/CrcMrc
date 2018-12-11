namespace CrcService
{
    partial class ServiceCrc
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.UsageTimer = new System.Windows.Forms.Timer(this.components);
            this.KeyTime = new System.Windows.Forms.Timer(this.components);
            this.TimerDB = new System.Windows.Forms.Timer(this.components);
            // 
            // UsageTimer
            // 
            this.UsageTimer.Tick += new System.EventHandler(this.UsageTimer_Tick);
            // 
            // KeyTime
            // 
            this.KeyTime.Tick += new System.EventHandler(this.KeyTime_Tick);
            // 
            // TimerDB
            // 
            this.TimerDB.Tick += new System.EventHandler(this.TimerDB_Tick);
            // 
            // ServiceCrc
            // 
            this.ServiceName = "ServiceCrc";

        }

        #endregion

        private System.Windows.Forms.Timer UsageTimer;
        private System.Windows.Forms.Timer KeyTime;
        private System.Windows.Forms.Timer TimerDB;
    }
}
