using MissionPlanner.Controls;

namespace MissionPlanner.Controls
{
    partial class BatteryMonitorGB
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
            startup = true;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatteryMonitorGB));
            this.label47 = new System.Windows.Forms.Label();
            this.CMB_batmonsensortype = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.TXT_battcapacity = new System.Windows.Forms.TextBox();
            this.CMB_batmontype = new MissionPlanner.Controls.MavlinkComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.CMB_HWVersion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CHK_speechbattery = new System.Windows.Forms.CheckBox();
            this.TXT_measuredvoltage = new System.Windows.Forms.TextBox();
            this.TXT_voltage = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.TXT_divider_VOLT_MULT = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.TXT_AMP_PERVLT = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txt_current = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_meascurrent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxCalibrate = new System.Windows.Forms.GroupBox();
            this.btnCalcCurrent = new System.Windows.Forms.Button();
            this.btnCalcVoltage = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.groupBoxCalibrate.SuspendLayout();
            this.SuspendLayout();
            //
            // label47
            //
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(3, 86);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(67, 13);
            this.label47.TabIndex = 13;
            this.label47.Text = "Sensor Type";
            //
            // CMB_batmonsensortype
            //
            this.CMB_batmonsensortype.DropDownWidth = 200;
            this.CMB_batmonsensortype.FormattingEnabled = true;
            this.CMB_batmonsensortype.Items.AddRange(new object[] {
            "0: Other",
            "1: Atto 45",
            "2: Atto 90",
            "3: Atto 180",
            "4: 3DR IV",
            "5: 3DR 4in1 ESC",
            "6: 3DR HV - APM",
            "7: 3DR HV - PX4/Pixhawk",
            "8: Pixhack",
            "9: Holybro Pixhawk4"});
            this.CMB_batmonsensortype.Location = new System.Drawing.Point(110, 83);
            this.CMB_batmonsensortype.Name = "CMB_batmonsensortype";
            this.CMB_batmonsensortype.Size = new System.Drawing.Size(200, 21);
            this.CMB_batmonsensortype.TabIndex = 12;
            this.CMB_batmonsensortype.SelectedIndexChanged += new System.EventHandler(this.CMB_batmonsensortype_SelectedIndexChanged);
            //
            // label29
            //
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(3, 35);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(78, 13);
            this.label29.TabIndex = 11;
            this.label29.Text = "Monitor";
            //
            // label30
            //
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(3, 9);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(97, 13);
            this.label30.TabIndex = 10;
            this.label30.Text = "Capacity (mAh)";
            //
            // TXT_battcapacity
            //
            this.TXT_battcapacity.Location = new System.Drawing.Point(110, 6);
            this.TXT_battcapacity.Name = "TXT_battcapacity";
            this.TXT_battcapacity.Size = new System.Drawing.Size(100, 20);
            this.TXT_battcapacity.TabIndex = 9;
            this.TXT_battcapacity.Validated += new System.EventHandler(this.TXT_battcapacity_Validated);
            //
            // CMB_batmontype
            //
            this.CMB_batmontype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_batmontype.DropDownWidth = 200;
            this.CMB_batmontype.FormattingEnabled = true;
            this.CMB_batmontype.Items.AddRange(new object[] {
            "0: Disabled",
            "3: Battery Volts",
            "4: Voltage and Current"});
            this.CMB_batmontype.Location = new System.Drawing.Point(110, 32);
            this.CMB_batmontype.Name = "CMB_batmontype";
            this.CMB_batmontype.ParamName = null;
            this.CMB_batmontype.Size = new System.Drawing.Size(200, 21);
            this.CMB_batmontype.SubControl = null;
            this.CMB_batmontype.TabIndex = 8;
            this.CMB_batmontype.SelectedIndexChanged += new System.EventHandler(this.CMB_batmontype_SelectedIndexChanged);
            //
            // timer1
            //
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            //
            // CMB_HWVersion
            //
            this.CMB_HWVersion.DropDownWidth = 200;
            this.CMB_HWVersion.FormattingEnabled = true;
            this.CMB_HWVersion.Items.AddRange(new object[] {
            "0: APM1",
            "1: APM2",
            "2: APM2.5/2.6",
            "3: PX4",
            "4: Pixhawk/PX4-v2",
            "5: VR Brain 5",
            "6: VR Micro Brain",
            "7: VR Brain 4",
            "8: Cube Orange",
            "9: Durandal",
            "10: Pixhawk 6C/Pix32 v6"});
            this.CMB_HWVersion.Location = new System.Drawing.Point(110, 58);
            this.CMB_HWVersion.Name = "CMB_HWVersion";
            this.CMB_HWVersion.Size = new System.Drawing.Size(200, 21);
            this.CMB_HWVersion.TabIndex = 14;
            this.CMB_HWVersion.SelectedIndexChanged += new System.EventHandler(this.CMB_apmversion_SelectedIndexChanged);
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Board Version";
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 400);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Speech Battery Warning";
            //
            // CHK_speechbattery
            //
            this.CHK_speechbattery.AutoSize = true;
            this.CHK_speechbattery.Location = new System.Drawing.Point(140, 400);
            this.CHK_speechbattery.Name = "CHK_speechbattery";
            this.CHK_speechbattery.Size = new System.Drawing.Size(65, 17);
            this.CHK_speechbattery.TabIndex = 17;
            this.CHK_speechbattery.Text = "Enabled";
            this.CHK_speechbattery.UseVisualStyleBackColor = true;
            this.CHK_speechbattery.CheckedChanged += new System.EventHandler(this.CHK_speechbattery_CheckedChanged);
            //
            // TXT_measuredvoltage
            //
            this.TXT_measuredvoltage.Location = new System.Drawing.Point(115, 19);
            this.TXT_measuredvoltage.Name = "TXT_measuredvoltage";
            this.TXT_measuredvoltage.Size = new System.Drawing.Size(100, 20);
            this.TXT_measuredvoltage.TabIndex = 27;
            this.TXT_measuredvoltage.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TXT_measuredvoltage_PreviewKeyDown);
            this.TXT_measuredvoltage.Validating += new System.ComponentModel.CancelEventHandler(this.TXT_measuredvoltage_Validating);
            this.TXT_measuredvoltage.Validated += new System.EventHandler(this.TXT_measuredvoltage_Validated);
            //
            // TXT_voltage
            //
            this.TXT_voltage.AutoSize = true;
            this.TXT_voltage.Location = new System.Drawing.Point(112, 16);
            this.TXT_voltage.Name = "TXT_voltage";
            this.TXT_voltage.Size = new System.Drawing.Size(28, 13);
            this.TXT_voltage.TabIndex = 31;
            this.TXT_voltage.Text = "0.00";
            //
            // label35
            //
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(6, 16);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(99, 13);
            this.label35.TabIndex = 30;
            this.label35.Text = "Measured Voltage:";
            //
            // TXT_divider_VOLT_MULT
            //
            this.TXT_divider_VOLT_MULT.Location = new System.Drawing.Point(112, 68);
            this.TXT_divider_VOLT_MULT.Name = "TXT_divider_VOLT_MULT";
            this.TXT_divider_VOLT_MULT.Size = new System.Drawing.Size(100, 20);
            this.TXT_divider_VOLT_MULT.TabIndex = 29;
            this.TXT_divider_VOLT_MULT.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TXT_divider_PreviewKeyDown);
            this.TXT_divider_VOLT_MULT.Validating += new System.ComponentModel.CancelEventHandler(this.TXT_divider_Validating);
            this.TXT_divider_VOLT_MULT.Validated += new System.EventHandler(this.TXT_divider_Validated);
            //
            // label34
            //
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(6, 71);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(71, 13);
            this.label34.TabIndex = 28;
            this.label34.Text = "Volt Multiplier:";
            //
            // TXT_AMP_PERVLT
            //
            this.TXT_AMP_PERVLT.Location = new System.Drawing.Point(112, 42);
            this.TXT_AMP_PERVLT.Name = "TXT_AMP_PERVLT";
            this.TXT_AMP_PERVLT.Size = new System.Drawing.Size(100, 20);
            this.TXT_AMP_PERVLT.TabIndex = 27;
            this.TXT_AMP_PERVLT.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TXT_ampspervolt_PreviewKeyDown);
            this.TXT_AMP_PERVLT.Validating += new System.ComponentModel.CancelEventHandler(this.TXT_ampspervolt_Validating);
            this.TXT_AMP_PERVLT.Validated += new System.EventHandler(this.TXT_ampspervolt_Validated);
            //
            // label33
            //
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(6, 45);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(78, 13);
            this.label33.TabIndex = 26;
            this.label33.Text = "Amps per Volt:";
            //
            // label32
            //
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(6, 22);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(103, 13);
            this.label32.TabIndex = 25;
            this.label32.Text = "Measured Voltage:";
            //
            // groupBox4
            //
            this.groupBox4.Controls.Add(this.txt_current);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label33);
            this.groupBox4.Controls.Add(this.TXT_AMP_PERVLT);
            this.groupBox4.Controls.Add(this.label34);
            this.groupBox4.Controls.Add(this.TXT_divider_VOLT_MULT);
            this.groupBox4.Controls.Add(this.label35);
            this.groupBox4.Controls.Add(this.TXT_voltage);
            this.groupBox4.Location = new System.Drawing.Point(3, 110);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(310, 100);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Battery voltage/current";
            //
            // txt_current
            //
            this.txt_current.AutoSize = true;
            this.txt_current.Location = new System.Drawing.Point(218, 16);
            this.txt_current.Name = "txt_current";
            this.txt_current.Size = new System.Drawing.Size(28, 13);
            this.txt_current.TabIndex = 33;
            this.txt_current.Text = "0.00";
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Current (Amps):";
            //
            // txt_meascurrent
            //
            this.txt_meascurrent.Location = new System.Drawing.Point(115, 45);
            this.txt_meascurrent.Name = "txt_meascurrent";
            this.txt_meascurrent.Size = new System.Drawing.Size(100, 20);
            this.txt_meascurrent.TabIndex = 28;
            this.txt_meascurrent.Validated += new System.EventHandler(this.txt_meascurrent_Validated);
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Measured Current:";
            //
            // groupBoxCalibrate
            //
            this.groupBoxCalibrate.Controls.Add(this.btnCalcCurrent);
            this.groupBoxCalibrate.Controls.Add(this.btnCalcVoltage);
            this.groupBoxCalibrate.Controls.Add(this.txt_meascurrent);
            this.groupBoxCalibrate.Controls.Add(this.label3);
            this.groupBoxCalibrate.Controls.Add(this.TXT_measuredvoltage);
            this.groupBoxCalibrate.Controls.Add(this.label32);
            this.groupBoxCalibrate.Location = new System.Drawing.Point(3, 216);
            this.groupBoxCalibrate.Name = "groupBoxCalibrate";
            this.groupBoxCalibrate.Size = new System.Drawing.Size(310, 170);
            this.groupBoxCalibrate.TabIndex = 19;
            this.groupBoxCalibrate.TabStop = false;
            this.groupBoxCalibrate.Text = "Calibrate";
            //
            // btnCalcCurrent
            //
            this.btnCalcCurrent.Location = new System.Drawing.Point(115, 71);
            this.btnCalcCurrent.Name = "btnCalcCurrent";
            this.btnCalcCurrent.Size = new System.Drawing.Size(100, 23);
            this.btnCalcCurrent.TabIndex = 31;
            this.btnCalcCurrent.Text = "Calculate";
            this.btnCalcCurrent.UseVisualStyleBackColor = true;
            this.btnCalcCurrent.Click += new System.EventHandler(this.btnCalcCurrent_Click);
            //
            // btnCalcVoltage
            //
            this.btnCalcVoltage.Location = new System.Drawing.Point(115, 45);
            this.btnCalcVoltage.Name = "btnCalcVoltage";
            this.btnCalcVoltage.Size = new System.Drawing.Size(100, 23);
            this.btnCalcVoltage.TabIndex = 30;
            this.btnCalcVoltage.Text = "Calculate";
            this.btnCalcVoltage.UseVisualStyleBackColor = true;
            this.btnCalcVoltage.Click += new System.EventHandler(this.btnCalcVoltage_Click);
            //
            // BatteryMonitorGB
            //
            this.Controls.Add(this.groupBoxCalibrate);
            this.Controls.Add(this.CHK_speechbattery);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CMB_HWVersion);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.CMB_batmonsensortype);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.TXT_battcapacity);
            this.Controls.Add(this.CMB_batmontype);
            this.Name = "BatteryMonitorGB";
            this.Size = new System.Drawing.Size(320, 430);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBoxCalibrate.ResumeLayout(false);
            this.groupBoxCalibrate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.ComboBox CMB_batmonsensortype;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox TXT_battcapacity;
        private MavlinkComboBox CMB_batmontype;

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox CMB_HWVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox CHK_speechbattery;
        private System.Windows.Forms.TextBox TXT_measuredvoltage;
        private System.Windows.Forms.Label TXT_voltage;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox TXT_divider_VOLT_MULT;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox TXT_AMP_PERVLT;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label txt_current;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_meascurrent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBoxCalibrate;
        private System.Windows.Forms.Button btnCalcVoltage;
        private System.Windows.Forms.Button btnCalcCurrent;
    }
}
