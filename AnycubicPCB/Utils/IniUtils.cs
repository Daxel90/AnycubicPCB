using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AnycubicPCB
{
    class IniUtils
    {
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);


        public static void WriteString(string Section, string Key, string Value, string FilePath)
        {
            WritePrivateProfileString(Section, Key, Value, FilePath);
        }

        public static string ReadString(string Section, string Key, string Default, string FilePath)
        {
            StringBuilder RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section, Key, Default, RetVal,255, FilePath);

            return RetVal.ToString();
        }

        public static void WriteInt(string Section, string Key, int Value, string FilePath)
        {
            WritePrivateProfileString(Section, Key, Value.ToString(), FilePath);
        }

        public static int ReadInt(string Section, string Key, int Default, string FilePath)
        {
            StringBuilder RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section, Key, Default.ToString(), RetVal, 255, FilePath);

            return Int32.Parse(RetVal.ToString());
        }

        public static void WriteDouble(string Section, string Key, double Value, string FilePath)
        {
            WritePrivateProfileString(Section, Key, Value.ToString(), FilePath);
        }

        public static double ReadDouble(string Section, string Key, double Default, string FilePath)
        {
            StringBuilder RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section, Key, Default.ToString(), RetVal, 255, FilePath);

            return Double.Parse(RetVal.ToString());
        }


    }
}
