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
        public static string CachePath;
        public static string DataPath;

        public static void LoadConfig()
        {
            ConfigFilePath = Path.Combine(Application.StartupPath, "Config.ini");

            CachePath = IniUtils.ReadString("Config", "CachePath", Path.Combine(Application.StartupPath, "Cache"), ConfigFilePath);
            DataPath = IniUtils.ReadString("Config", "DataPath", Path.Combine(Application.StartupPath, "Data"), ConfigFilePath);

            SaveConfig();
        }

        public static void SaveConfig()
        {
            IniUtils.WriteString("Config", "CachePath", CachePath, ConfigFilePath);
            IniUtils.WriteString("Config", "DataPath", DataPath, ConfigFilePath);
        }
    }
}
