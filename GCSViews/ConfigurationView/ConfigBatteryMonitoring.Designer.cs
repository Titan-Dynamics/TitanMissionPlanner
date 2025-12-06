using MissionPlanner.Controls;

namespace MissionPlanner.GCSViews.ConfigurationView
{
    partial class ConfigBatteryMonitoring
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.batteryMonitor1 = new MissionPlanner.Controls.BatteryMonitorGB();
            this.batteryMonitor2 = new MissionPlanner.Controls.BatteryMonitorGB();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            //
            // tableLayoutPanel1
            //
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.batteryMonitor1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.batteryMonitor2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel1.TabIndex = 0;
            //
            // batteryMonitor1
            //
            this.batteryMonitor1.BatteryNumber = 1;
            this.batteryMonitor1.BatteryPrefix = "BATT";
            this.batteryMonitor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.batteryMonitor1.Location = new System.Drawing.Point(3, 3);
            this.batteryMonitor1.Name = "batteryMonitor1";
            this.batteryMonitor1.ShowAdvancedOptions = true;
            this.batteryMonitor1.Size = new System.Drawing.Size(394, 594);
            this.batteryMonitor1.TabIndex = 0;
            //
            // batteryMonitor2
            //
            this.batteryMonitor2.BatteryNumber = 2;
            this.batteryMonitor2.BatteryPrefix = "BATT2";
            this.batteryMonitor2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.batteryMonitor2.Location = new System.Drawing.Point(403, 3);
            this.batteryMonitor2.Name = "batteryMonitor2";
            this.batteryMonitor2.ShowAdvancedOptions = false;
            this.batteryMonitor2.Size = new System.Drawing.Size(394, 594);
            this.batteryMonitor2.TabIndex = 1;
            //
            // ConfigBatteryMonitoring
            //
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ConfigBatteryMonitoring";
            this.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private BatteryMonitorGB batteryMonitor1;
        private BatteryMonitorGB batteryMonitor2;
    }
}
