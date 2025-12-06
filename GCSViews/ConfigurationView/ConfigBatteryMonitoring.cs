using MissionPlanner.Controls;
using System;
using System.Windows.Forms;

namespace MissionPlanner.GCSViews.ConfigurationView
{
    public partial class ConfigBatteryMonitoring : MyUserControl, IActivate, IDeactivate
    {
        public ConfigBatteryMonitoring()
        {
            InitializeComponent();
        }

        public void Activate()
        {
            batteryMonitor1.BatteryPrefix = "BATT";
            batteryMonitor1.BatteryNumber = 1;
            batteryMonitor1.ShowAdvancedOptions = true;
            batteryMonitor1.LoadParameters();

            batteryMonitor2.BatteryPrefix = "BATT2";
            batteryMonitor2.BatteryNumber = 2;
            batteryMonitor2.ShowAdvancedOptions = false;
            batteryMonitor2.LoadParameters();
        }

        public void Deactivate()
        {
            batteryMonitor1.StopTimer();
            batteryMonitor2.StopTimer();
        }
    }
}
