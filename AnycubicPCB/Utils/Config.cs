using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnycubicPCB
{
    class Config
    {
        public static string Release = "1.00";
        public static string ConfigFilePath;
        public static string TmpPath;
        public static string DataPath;
        public static string CalibrationPath;
        public static string MachineName;

        public static void LoadConfig()
        {
            ConfigFilePath = Path.Combine(Application.StartupPath, "Config.ini");

            TmpPath = IniUtils.ReadString("Config", "TempPath", Path.Combine(Application.StartupPath, "Temp"), ConfigFilePath);
            DataPath = IniUtils.ReadString("Config", "DataPath", Path.Combine(Application.StartupPath, "Data"), ConfigFilePath);
            CalibrationPath = IniUtils.ReadString("Config", "CalibPath", Path.Combine(DataPath, "Calibrations"), ConfigFilePath);
            MachineName = IniUtils.ReadString("Config", "MachineName", "Photon Mono", ConfigFilePath);

            if (!Directory.Exists(TmpPath))
                Directory.CreateDirectory(TmpPath);

            if (!Directory.Exists(DataPath))
                Directory.CreateDirectory(DataPath);

            SaveConfig();
        }

        public static void SaveConfig()
        {
            IniUtils.WriteString("Config", "TmpPath", TmpPath, ConfigFilePath);
            IniUtils.WriteString("Config", "DataPath", DataPath, ConfigFilePath);
            IniUtils.WriteString("Config", "MachineName", MachineName, ConfigFilePath);
            IniUtils.WriteString("Config", "CalibPath", CalibrationPath, ConfigFilePath);
        }
    }
}
