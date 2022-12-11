using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnycubicPCB.AnycubicFormat
{
    class Machine
    {
        public static Dictionary<String, Machine> MachineList = new Dictionary<String, Machine>();

        public static Machine PhotonS = new Machine("Photon S", ".pws", 1440, 2560, 47.250);
        public static Machine Photon = new Machine("Photon", ".pws", 1440, 2560, 47.250);
        public static Machine PhotonZero = new Machine("Photon Zero", ".pw0", 480, 854, 115.50);
        public static Machine PhotonMono = new Machine("Photon Mono", ".pwmo", 1620, 2560, 51.0);
        public static Machine PhotonMono4K = new Machine("Photon Mono 4K", ".pwma", 3840, 2400, 35.0);
        public static Machine PhotonMonoSE = new Machine("Photon Mono SE", ".pwms", 1620, 2560, 51.0);
        public static Machine PhotonX = new Machine("Photon X", ".pwx", 2560, 1600, 75.0);
        public static Machine PhotonMonoX = new Machine("Photon Mono X", ".pwmx", 3840, 2400, 50.0);
        public static Machine PhotonMonoSQ = new Machine("Photon Mono SQ", ".pwsq", 2400, 2560, 50.0);
        public static Machine PhotonMonoX6K = new Machine("Photon Mono X 6K", ".pwmb", 5760, 3600, 34.4);


        public static Machine GetMachineWithName(string pName)
        {
            return MachineList[pName];
        }

        public static List<string> GetMachineList()
        {
            return new List<string>(MachineList.Keys);
        }

        //Instance Data
        public string Name;
        public string FileFormat;
        public int ScreenSizeX;
        public int ScreenSizeY;
        public double PixelSize;

        public Machine(string pName, string pFileFormat, int pScreenSizeX, int pScreenSizeY, double pPixelSize)
        {
            Name = pName;
            FileFormat = pFileFormat;
            ScreenSizeX = pScreenSizeX;
            ScreenSizeY = pScreenSizeY;
            PixelSize = pPixelSize;

            MachineList.Add(pName,this);
        }

        public int GetDPI()
        {
            return (int)(25400.0 / PixelSize);
        }

        public string GetTemplateFilePath()
        {
            return Path.Combine(Config.DataPath,"Machines", Name+FileFormat);
        }

    }
}
