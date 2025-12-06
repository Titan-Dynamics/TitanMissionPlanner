using MissionPlanner.Controls;
using MissionPlanner.Utilities;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MissionPlanner.Controls
{
    public partial class BatteryMonitorGB : MyUserControl
    {
        private bool startup;
        private string _batteryPrefix = "BATT";
        private int _batteryNumber = 1;
        private bool _showAdvancedOptions = true;

        [Category("Battery Config")]
        [Description("Battery parameter prefix (BATT or BATT2)")]
        [DefaultValue("BATT")]
        public string BatteryPrefix
        {
            get => _batteryPrefix;
            set
            {
                _batteryPrefix = value;
                UpdateParameterNames();
            }
        }

        [Category("Battery Config")]
        [Description("Battery number for CS values (1 or 2)")]
        [DefaultValue(1)]
        public int BatteryNumber
        {
            get => _batteryNumber;
            set => _batteryNumber = value;
        }

        [Category("Battery Config")]
        [Description("Show advanced options (sensor type, hardware version)")]
        [DefaultValue(true)]
        public bool ShowAdvancedOptions
        {
            get => _showAdvancedOptions;
            set
            {
                _showAdvancedOptions = value;
                UpdateAdvancedVisibility();
            }
        }

        public BatteryMonitorGB()
        {
            InitializeComponent();
        }

        private void UpdateParameterNames()
        {
            // Update labels to show correct parameter names
            if (label30 != null)
                label30.Text = $"{_batteryPrefix}_CAPACITY (mAh)";
            if (label29 != null)
                label29.Text = $"{_batteryPrefix}_MONITOR";
        }

        private void UpdateAdvancedVisibility()
        {
            if (CMB_batmonsensortype != null)
                CMB_batmonsensortype.Visible = _showAdvancedOptions;
            if (label47 != null)
                label47.Visible = _showAdvancedOptions;
            if (CMB_HWVersion != null)
                CMB_HWVersion.Visible = _showAdvancedOptions;
            if (label1 != null)
                label1.Visible = _showAdvancedOptions;
        }

        public void LoadParameters()
        {
            if (!MainV2.comPort.BaseStream.IsOpen || !MainV2.comPort.MAV.param.ContainsKey($"{_batteryPrefix}_MONITOR"))
            {
                Enabled = false;
                return;
            }

            startup = true;

            CMB_batmontype.setup(
                ParameterMetaDataRepository.GetParameterOptionsInt($"{_batteryPrefix}_MONITOR",
                    MainV2.comPort.MAV.cs.firmware.ToString()), $"{_batteryPrefix}_MONITOR", MainV2.comPort.MAV.param);

            if (MainV2.comPort.MAV.param[$"{_batteryPrefix}_CAPACITY"] != null)
                TXT_battcapacity.Text = MainV2.comPort.MAV.param[$"{_batteryPrefix}_CAPACITY"].ToString();

            TXT_voltage.Text = _batteryNumber == 1
                ? MainV2.comPort.MAV.cs.battery_voltage.ToString()
                : MainV2.comPort.MAV.cs.battery_voltage2.ToString();
            TXT_measuredvoltage.Text = string.Empty;

            if (MainV2.comPort.MAV.param[$"{_batteryPrefix}_AMP_PERVLT"] != null)
                TXT_AMP_PERVLT.Text = MainV2.comPort.MAV.param[$"{_batteryPrefix}_AMP_PERVLT"].ToString();

            if (MainV2.comPort.MAV.param[$"{_batteryPrefix}_VOLT_MULT"] != null)
                TXT_divider_VOLT_MULT.Text = MainV2.comPort.MAV.param[$"{_batteryPrefix}_VOLT_MULT"].ToString();

            if (MainV2.comPort.MAV.param[$"{_batteryPrefix}_AMP_PERVOLT"] != null)
                TXT_AMP_PERVLT.Text = MainV2.comPort.MAV.param[$"{_batteryPrefix}_AMP_PERVOLT"].ToString();

            // old param names
            if (_batteryPrefix == "BATT" && MainV2.comPort.MAV.param["VOLT_DIVIDER"] != null)
                TXT_divider_VOLT_MULT.Text = MainV2.comPort.MAV.param["VOLT_DIVIDER"].ToString();

            if (_batteryPrefix == "BATT" && MainV2.comPort.MAV.param["AMP_PER_VOLT"] != null)
                TXT_AMP_PERVLT.Text = MainV2.comPort.MAV.param["AMP_PER_VOLT"].ToString();

            if (Settings.Instance.GetBoolean("speechbatteryenabled") && Settings.Instance.GetBoolean("speechenable"))
                CHK_speechbattery.Checked = true;
            else
                CHK_speechbattery.Checked = false;

            if (_showAdvancedOptions)
            {
                LoadSensorType();
                LoadHardwareVersion();
            }

            startup = false;

            CMB_batmontype_SelectedIndexChanged(null, null);
            if (_showAdvancedOptions)
                CMB_batmonsensortype_SelectedIndexChanged(null, null);

            timer1.Start();
        }

        private void LoadSensorType()
        {
            // determine the sensor type
            if (TXT_AMP_PERVLT.Text == (13.6612).ToString() && TXT_divider_VOLT_MULT.Text == (4.127115).ToString())
                CMB_batmonsensortype.SelectedIndex = 1;
            else if (TXT_AMP_PERVLT.Text == (27.3224).ToString() && TXT_divider_VOLT_MULT.Text == (15.70105).ToString())
                CMB_batmonsensortype.SelectedIndex = 2;
            else if (TXT_AMP_PERVLT.Text == (54.64481).ToString() && TXT_divider_VOLT_MULT.Text == (15.70105).ToString())
                CMB_batmonsensortype.SelectedIndex = 3;
            else if (TXT_AMP_PERVLT.Text == (18.0018).ToString() && TXT_divider_VOLT_MULT.Text == (10.10101).ToString())
                CMB_batmonsensortype.SelectedIndex = 4;
            else if (TXT_AMP_PERVLT.Text == (17).ToString() && TXT_divider_VOLT_MULT.Text == (12.02).ToString())
                CMB_batmonsensortype.SelectedIndex = 5;
            else if (TXT_AMP_PERVLT.Text == (24).ToString() && TXT_divider_VOLT_MULT.Text == (12.02).ToString())
                CMB_batmonsensortype.SelectedIndex = 6;
            else if (TXT_AMP_PERVLT.Text == (39.877).ToString() && TXT_divider_VOLT_MULT.Text == (12.02).ToString())
                CMB_batmonsensortype.SelectedIndex = 7;
            else if (TXT_AMP_PERVLT.Text == (24).ToString() && TXT_divider_VOLT_MULT.Text == (18).ToString())
                CMB_batmonsensortype.SelectedIndex = 8;
            else if (TXT_AMP_PERVLT.Text == (36.364).ToString() && TXT_divider_VOLT_MULT.Text == (18.182).ToString())
                CMB_batmonsensortype.SelectedIndex = 9;
            else
                CMB_batmonsensortype.SelectedIndex = 0;
        }

        private void LoadHardwareVersion()
        {
            if (MainV2.comPort.MAV.param[$"{_batteryPrefix}_VOLT_PIN"] != null)
            {
                CMB_HWVersion.Enabled = true;

                var value = (double)MainV2.comPort.MAV.param[$"{_batteryPrefix}_VOLT_PIN"];
                if (value == 0) CMB_HWVersion.SelectedIndex = 0;  // apm1
                else if (value == 1) CMB_HWVersion.SelectedIndex = 1;  // apm2
                else if (value == 13) CMB_HWVersion.SelectedIndex = 2;  // apm2.5
                else if (value == 100) CMB_HWVersion.SelectedIndex = 3;  // px4
                else if (value == 2) CMB_HWVersion.SelectedIndex = 4;  // pixhawk
                else if (value == 6) CMB_HWVersion.SelectedIndex = 7;  // vrbrain4
                else if (value == 10)
                {
                    if ((double)MainV2.comPort.MAV.param[$"{_batteryPrefix}_CURR_PIN"] == 11)
                        CMB_HWVersion.SelectedIndex = 5;
                    else
                        CMB_HWVersion.SelectedIndex = 6;
                }
                else if (value == 14) CMB_HWVersion.SelectedIndex = 8;  // cubeorange
                else if (value == 16) CMB_HWVersion.SelectedIndex = 9;  // durandal
                else if (value == 8) CMB_HWVersion.SelectedIndex = 10;  // Pixhawk 6C/Pix32 v6
            }
            else
            {
                CMB_HWVersion.Enabled = false;
            }
        }

        public void StopTimer()
        {
            timer1.Stop();
            startup = true;
        }

        private void TXT_battcapacity_Validated(object sender, EventArgs e)
        {
            if (startup || ((TextBox)sender).Enabled == false)
                return;
            try
            {
                if (MainV2.comPort.MAV.param[$"{_batteryPrefix}_CAPACITY"] == null)
                {
                    CustomMessageBox.Show(Strings.ErrorFeatureNotEnabled, Strings.ERROR);
                }
                else
                {
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent,
                        $"{_batteryPrefix}_CAPACITY", float.Parse(TXT_battcapacity.Text));
                }
            }
            catch
            {
                CustomMessageBox.Show($"Set {_batteryPrefix}_CAPACITY Failed", Strings.ERROR);
            }
        }

        private void CMB_batmontype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (startup)
                return;
            try
            {
                if (MainV2.comPort.MAV.param[$"{_batteryPrefix}_MONITOR"] == null)
                {
                    CustomMessageBox.Show(Strings.ErrorFeatureNotEnabled, Strings.ERROR);
                }
                else
                {
                    var selection = (int)CMB_batmontype.SelectedValue;

                    if (_showAdvancedOptions)
                        CMB_batmonsensortype.Enabled = true;

                    if (selection == 0)
                    {
                        if (_showAdvancedOptions)
                        {
                            CMB_batmonsensortype.Enabled = false;
                            CMB_HWVersion.Enabled = false;
                        }
                        groupBox4.Enabled = false;
                        if (groupBoxCalibrate != null) groupBoxCalibrate.Enabled = false;
                        MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, $"{_batteryPrefix}_VOLT_PIN", -1);
                        MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, $"{_batteryPrefix}_CURR_PIN", -1);
                    }
                    else if (selection == 4)
                    {
                        if (_showAdvancedOptions)
                        {
                            CMB_batmonsensortype.Enabled = true;
                            CMB_HWVersion.Enabled = true;
                        }
                        groupBox4.Enabled = true;
                        if (groupBoxCalibrate != null) groupBoxCalibrate.Enabled = true;
                        TXT_AMP_PERVLT.Enabled = true;
                    }
                    else if (selection == 3)
                    {
                        groupBox4.Enabled = true;
                        if (groupBoxCalibrate != null) groupBoxCalibrate.Enabled = true;
                        if (_showAdvancedOptions)
                        {
                            CMB_batmonsensortype.Enabled = false;
                            CMB_HWVersion.Enabled = true;
                        }
                        TXT_AMP_PERVLT.Enabled = false;
                        TXT_measuredvoltage.Enabled = true;
                        TXT_divider_VOLT_MULT.Enabled = true;
                    }

                    if (MainV2.comPort.MAV.param.ContainsKey($"{_batteryPrefix}_MONITOR") &&
                        MainV2.comPort.MAV.param[$"{_batteryPrefix}_MONITOR"].Value == 0 &&
                        selection != 0)
                    {
                        MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, $"{_batteryPrefix}_MONITOR", selection);
                        MainV2.comPort.getParamList();
                        this.LoadParameters();
                    }
                    else
                    {
                        MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, $"{_batteryPrefix}_MONITOR", selection);
                    }
                }
            }
            catch
            {
                CustomMessageBox.Show($"Set {_batteryPrefix}_MONITOR,{_batteryPrefix}_VOLT_PIN,{_batteryPrefix}_CURR_PIN Failed", Strings.ERROR);
            }
        }

        private void TXT_measuredvoltage_Validating(object sender, CancelEventArgs e)
        {
            float ans = 0;
            e.Cancel = !float.TryParse(TXT_measuredvoltage.Text, out ans);
        }

        private void TXT_measuredvoltage_Validated(object sender, EventArgs e)
        {
            if (startup || ((TextBox)sender).Enabled == false)
                return;
            try
            {
                var measuredvoltage = float.Parse(TXT_measuredvoltage.Text);
                var voltage = float.Parse(TXT_voltage.Text);
                var divider = float.Parse(TXT_divider_VOLT_MULT.Text);
                if (voltage == 0)
                    return;
                var new_divider = (measuredvoltage * divider) / voltage;
                TXT_divider_VOLT_MULT.Text = new_divider.ToString();
            }
            catch
            {
                CustomMessageBox.Show(Strings.InvalidNumberEntered, Strings.ERROR);
                return;
            }

            try
            {
                var paramNames = _batteryPrefix == "BATT"
                    ? new[] { "VOLT_DIVIDER", $"{_batteryPrefix}_VOLT_MULT" }
                    : new[] { $"{_batteryPrefix}_VOLT_MULT" };
                MainV2.comPort.setParam(paramNames, float.Parse(TXT_divider_VOLT_MULT.Text));
            }
            catch
            {
                if (MainV2.comPort.MAV.param.ContainsKey($"{_batteryPrefix}_MONITOR") &&
                    (MainV2.comPort.MAV.param[$"{_batteryPrefix}_MONITOR"].Value == 3 ||
                     MainV2.comPort.MAV.param[$"{_batteryPrefix}_MONITOR"].Value == 4))
                {
                    CustomMessageBox.Show($"Set {_batteryPrefix}_VOLT_MULT Failed", Strings.ERROR);
                }
            }
        }

        private void TXT_divider_Validating(object sender, CancelEventArgs e)
        {
            float ans = 0;
            e.Cancel = !float.TryParse(TXT_divider_VOLT_MULT.Text, out ans);
        }

        private void TXT_divider_Validated(object sender, EventArgs e)
        {
            if (startup || ((TextBox)sender).Enabled == false)
                return;
            try
            {
                var paramNames = _batteryPrefix == "BATT"
                    ? new[] { "VOLT_DIVIDER", $"{_batteryPrefix}_VOLT_MULT" }
                    : new[] { $"{_batteryPrefix}_VOLT_MULT" };
                MainV2.comPort.setParam(paramNames, float.Parse(TXT_divider_VOLT_MULT.Text));
            }
            catch
            {
                if (MainV2.comPort.MAV.param.ContainsKey($"{_batteryPrefix}_MONITOR") &&
                    (MainV2.comPort.MAV.param[$"{_batteryPrefix}_MONITOR"].Value == 3 ||
                     MainV2.comPort.MAV.param[$"{_batteryPrefix}_MONITOR"].Value == 4))
                {
                    CustomMessageBox.Show($"Set {_batteryPrefix}_VOLT_MULT Failed", Strings.ERROR);
                }
            }
        }

        private void TXT_ampspervolt_Validating(object sender, CancelEventArgs e)
        {
            float ans = 0;
            e.Cancel = !float.TryParse(TXT_AMP_PERVLT.Text, out ans);
        }

        private void TXT_ampspervolt_Validated(object sender, EventArgs e)
        {
            if (startup || ((TextBox)sender).Enabled == false)
                return;
            try
            {
                var paramNames = _batteryPrefix == "BATT"
                    ? new[] { "AMP_PER_VOLT", $"{_batteryPrefix}_AMP_PERVOLT", $"{_batteryPrefix}_AMP_PERVLT" }
                    : new[] { $"{_batteryPrefix}_AMP_PERVOLT", $"{_batteryPrefix}_AMP_PERVLT" };
                MainV2.comPort.setParam(paramNames, float.Parse(TXT_AMP_PERVLT.Text));
            }
            catch
            {
                if (MainV2.comPort.MAV.param.ContainsKey($"{_batteryPrefix}_MONITOR") &&
                    (MainV2.comPort.MAV.param[$"{_batteryPrefix}_MONITOR"].Value == 3 ||
                     MainV2.comPort.MAV.param[$"{_batteryPrefix}_MONITOR"].Value == 4))
                {
                    CustomMessageBox.Show($"Set {_batteryPrefix}_AMP_PERVOLT Failed", Strings.ERROR);
                }
            }
        }

        private void CMB_batmonsensortype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_showAdvancedOptions)
                return;

            var selection = int.Parse(CMB_batmonsensortype.Text.Substring(0, 1));

            if (selection == 1) // atto 45
            {
                var maxvolt = 13.6f;
                var maxamps = 44.7f;
                var mvpervolt = 242.3f;
                var mvperamp = 73.20f;

                var topvolt = (maxvolt * mvpervolt) / 1000;
                var topamps = (maxamps * mvperamp) / 1000;

                TXT_divider_VOLT_MULT.Text = (maxvolt / topvolt).ToString();
                TXT_AMP_PERVLT.Text = (maxamps / topamps).ToString();
            }
            else if (selection == 2) // atto 90
            {
                var maxvolt = 50f;
                var maxamps = 89.4f;
                var mvpervolt = 63.69f;
                var mvperamp = 36.60f;

                var topvolt = (maxvolt * mvpervolt) / 1000;
                var topamps = (maxamps * mvperamp) / 1000;

                TXT_divider_VOLT_MULT.Text = (maxvolt / topvolt).ToString();
                TXT_AMP_PERVLT.Text = (maxamps / topamps).ToString();
            }
            else if (selection == 3) // atto 180
            {
                var maxvolt = 50f;
                var maxamps = 178.8f;
                var mvpervolt = 63.69f;
                var mvperamp = 18.30f;

                var topvolt = (maxvolt * mvpervolt) / 1000;
                var topamps = (maxamps * mvperamp) / 1000;

                TXT_divider_VOLT_MULT.Text = (maxvolt / topvolt).ToString();
                TXT_AMP_PERVLT.Text = (maxamps / topamps).ToString();
            }
            else if (selection == 4) // 3dr iv
            {
                var maxvolt = 50f;
                var maxamps = 90f;
                var mvpervolt = 99f;
                var mvperamp = 55.55f;

                var topvolt = (maxvolt * mvpervolt) / 1000;
                var topamps = (maxamps * mvperamp) / 1000;

                TXT_divider_VOLT_MULT.Text = (maxvolt / topvolt).ToString();
                TXT_AMP_PERVLT.Text = (maxamps / topamps).ToString();
            }
            else if (selection == 5) // 3dr 4 in one esc
            {
                TXT_divider_VOLT_MULT.Text = (12.02).ToString();
                TXT_AMP_PERVLT.Text = (17).ToString();
            }
            else if (selection == 6) // hv 3dr apm
            {
                TXT_divider_VOLT_MULT.Text = (12.02).ToString();
                TXT_AMP_PERVLT.Text = (24).ToString();
            }
            else if (selection == 7) // hv 3dr px4 cube
            {
                TXT_divider_VOLT_MULT.Text = (12.02).ToString();
                TXT_AMP_PERVLT.Text = (39.877).ToString();
            }
            else if (selection == 8) // pixhack
            {
                TXT_divider_VOLT_MULT.Text = (18).ToString();
                TXT_AMP_PERVLT.Text = (24).ToString();
            }
            else if (selection == 9) // Holybro Pixhawk4
            {
                TXT_divider_VOLT_MULT.Text = (18.182).ToString();
                TXT_AMP_PERVLT.Text = (36.364).ToString();
            }

            // enable to update
            TXT_divider_VOLT_MULT.Enabled = true;
            TXT_AMP_PERVLT.Enabled = true;
            TXT_measuredvoltage.Enabled = true;

            // update
            TXT_ampspervolt_Validated(TXT_AMP_PERVLT, null);
            TXT_divider_Validated(TXT_divider_VOLT_MULT, null);

            // disable
            TXT_divider_VOLT_MULT.Enabled = false;
            TXT_AMP_PERVLT.Enabled = false;
            TXT_measuredvoltage.Enabled = false;

            //reenable if needed
            if (selection == 0)
            {
                TXT_divider_VOLT_MULT.Enabled = true;
                TXT_AMP_PERVLT.Enabled = true;
                TXT_measuredvoltage.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TXT_voltage.Text = _batteryNumber == 1
                ? MainV2.comPort.MAV.cs.battery_voltage.ToString()
                : MainV2.comPort.MAV.cs.battery_voltage2.ToString();
            txt_current.Text = _batteryNumber == 1
                ? MainV2.comPort.MAV.cs.current.ToString()
                : MainV2.comPort.MAV.cs.current2.ToString();
        }

        private void CMB_apmversion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (startup || !_showAdvancedOptions)
                return;

            var selection = int.Parse(CMB_HWVersion.Text.Substring(0, 2).Replace(":", ""));

            try
            {
                if (selection == 0)
                {
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, $"{_batteryPrefix}_VOLT_PIN", 0);
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, $"{_batteryPrefix}_CURR_PIN", 1);
                }
                else if (selection == 1)
                {
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, $"{_batteryPrefix}_VOLT_PIN", 1);
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, $"{_batteryPrefix}_CURR_PIN", 2);
                }
                else if (selection == 2)
                {
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, $"{_batteryPrefix}_VOLT_PIN", 13);
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, $"{_batteryPrefix}_CURR_PIN", 12);
                }
                else if (selection == 3)
                {
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, $"{_batteryPrefix}_VOLT_PIN", 100);
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, $"{_batteryPrefix}_CURR_PIN", 101);
                }
                else if (selection == 4)
                {
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, $"{_batteryPrefix}_VOLT_PIN", 2);
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, $"{_batteryPrefix}_CURR_PIN", 3);
                }
                else if (selection == 5)
                {
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, $"{_batteryPrefix}_VOLT_PIN", 10);
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, $"{_batteryPrefix}_CURR_PIN", 11);
                }
                else if (selection == 6)
                {
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, $"{_batteryPrefix}_VOLT_PIN", 10);
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, $"{_batteryPrefix}_CURR_PIN", -1);
                }
                else if (selection == 7)
                {
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, $"{_batteryPrefix}_VOLT_PIN", 6);
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, $"{_batteryPrefix}_CURR_PIN", 7);
                }
                else if (selection == 8)
                {
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, $"{_batteryPrefix}_VOLT_PIN", 14);
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, $"{_batteryPrefix}_CURR_PIN", 15);
                }
                else if (selection == 9)
                {
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, $"{_batteryPrefix}_VOLT_PIN", 16);
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, $"{_batteryPrefix}_CURR_PIN", 17);
                }
                else if (selection == 10)
                {
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, $"{_batteryPrefix}_VOLT_PIN", 8);
                    MainV2.comPort.setParam((byte)MainV2.comPort.sysidcurrent, (byte)MainV2.comPort.compidcurrent, $"{_batteryPrefix}_CURR_PIN", 4);
                }
            }
            catch
            {
                CustomMessageBox.Show($"Set {_batteryPrefix}_????_PIN Failed", Strings.ERROR);
            }
        }

        private void btnCalcVoltage_Click(object sender, EventArgs e)
        {
            TXT_measuredvoltage_Validated(TXT_measuredvoltage, EventArgs.Empty);
        }

        private void btnCalcCurrent_Click(object sender, EventArgs e)
        {
            txt_meascurrent_Validated(txt_meascurrent, EventArgs.Empty);
        }

        private void CHK_speechbattery_CheckedChanged(object sender, EventArgs e)
        {
            if (startup)
                return;

            Settings.Instance["speechbatteryenabled"] = ((CheckBox)sender).Checked.ToString();
            Settings.Instance["speechenable"] = true.ToString();

            if (((CheckBox)sender).Checked)
            {
                var speechstring = "WARNING, Battery at {batv} Volt, {batp} percent";
                if (Settings.Instance["speechbattery"] != null)
                    speechstring = Settings.Instance["speechbattery"].ToString();
                if (DialogResult.Cancel ==
                    InputBox.Show("Notification", "What do you want it to say?", ref speechstring))
                    return;
                Settings.Instance["speechbattery"] = speechstring;

                speechstring = "9.6";
                if (Settings.Instance["speechbatteryvolt"] != null)
                    speechstring = Settings.Instance["speechbatteryvolt"].ToString();
                if (DialogResult.Cancel ==
                    InputBox.Show("Battery Level", "What Voltage do you want to warn at?", ref speechstring))
                    return;
                Settings.Instance["speechbatteryvolt"] = speechstring;

                speechstring = "20";
                if (Settings.Instance["speechbatterypercent"] != null)
                    speechstring = Settings.Instance["speechbatterypercent"].ToString();
                if (DialogResult.Cancel ==
                    InputBox.Show("Battery Level", "What percentage do you want to warn at?", ref speechstring))
                    return;
                Settings.Instance["speechbatterypercent"] = speechstring;
            }
        }

        private void TXT_measuredvoltage_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                TXT_measuredvoltage_Validated(sender, e);
        }

        private void TXT_ampspervolt_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                TXT_ampspervolt_Validated(sender, e);
        }

        private void TXT_divider_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                TXT_divider_Validated(sender, e);
        }

        private void txt_meascurrent_Validated(object sender, EventArgs e)
        {
            if (startup || ((TextBox)sender).Enabled == false)
                return;
            try
            {
                var measuredcurrent = float.Parse(txt_meascurrent.Text);
                var current = float.Parse(txt_current.Text);
                var divider = float.Parse(TXT_AMP_PERVLT.Text);
                if (current == 0)
                    return;
                var new_divider = (measuredcurrent * divider) / current;
                TXT_AMP_PERVLT.Text = new_divider.ToString();
            }
            catch
            {
                CustomMessageBox.Show(Strings.InvalidNumberEntered, Strings.ERROR);
                return;
            }

            try
            {
                var paramNames = _batteryPrefix == "BATT"
                    ? new[] { "AMP_PER_VOLT", $"{_batteryPrefix}_AMP_PERVOLT", $"{_batteryPrefix}_AMP_PERVLT" }
                    : new[] { $"{_batteryPrefix}_AMP_PERVOLT", $"{_batteryPrefix}_AMP_PERVLT" };
                MainV2.comPort.setParam(paramNames, float.Parse(TXT_AMP_PERVLT.Text));
            }
            catch
            {
                if (MainV2.comPort.MAV.param.ContainsKey($"{_batteryPrefix}_MONITOR") &&
                    (MainV2.comPort.MAV.param[$"{_batteryPrefix}_MONITOR"].Value == 3 ||
                     MainV2.comPort.MAV.param[$"{_batteryPrefix}_MONITOR"].Value == 4))
                {
                    CustomMessageBox.Show($"Set {_batteryPrefix}_AMP_PERVOLT Failed", Strings.ERROR);
                }
            }
        }
    }
}
