using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnycubicPCB.AnycubicFormat
{
    class Calibration
    {
        public string Name;
        public string MachineType;
        public List<int[]> Points = new List<int[]>();

        public Image GenerateLayer()
        {
            Machine Printer = Machine.GetMachineWithName(MachineType);
            Bitmap Img = new Bitmap(Printer.ScreenSizeX, Printer.ScreenSizeY);
            Graphics gr = Graphics.FromImage(Img);
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            gr.SmoothingMode = SmoothingMode.AntiAlias;
            gr.FillRectangle(blackBrush, 0, 0, Printer.ScreenSizeX, Printer.ScreenSizeY);

            foreach(int[] Point in Points)
            {
                double Xpx = Point[0] / Printer.PixelSize;
                double Ypx = Point[1] / Printer.PixelSize;
                double Sizepx = Point[2] / Printer.PixelSize;
                gr.FillEllipse(whiteBrush, (float)(Xpx - (Sizepx/2)), (float)(Ypx - (Sizepx / 2)), (float)Sizepx, (float)Sizepx);
            }

            return Img;
        }



    }
}
