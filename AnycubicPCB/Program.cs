using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AnycubicPCB
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Config.LoadConfig();

            Image aa = Utils.GetImageFromPDF(@"H:\test\PWMO\Trace.pdf", 498);
            aa.Save(@"H:\test\PWMO\aa.png");


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormTEST());
        }
    }
}
