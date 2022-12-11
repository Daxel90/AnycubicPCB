using AnycubicPCB.AnycubicFormat;
using AnycubicPCB.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnycubicPCB
{
    class WorkSpace
    {
        public Machine Printer;
        public string PDFPath;
        public Image PcbLayerData;
        public PwmoFile AnycubicFile;

        public void SelectMachine(string pMachineName)
        {
            Printer = Machine.GetMachineWithName(pMachineName);
        }

        public void LoadPdf(string pPath)
        {
            PDFPath = pPath;
            Image TmpImg = ImgUtils.GetImageFromPDF(pPath, Printer.GetDPI() * 4);
            TmpImg = ImgUtils.ResizeImage(TmpImg, 0.25);
            TmpImg.Save(Path.Combine(Config.TmpPath,"PcbLayerData.png"), ImageFormat.Png);
            PcbLayerData = TmpImg;
        }

        public void LoadAnycubicTemplate()
        {
            AnycubicFile = new PwmoFile(Printer.GetTemplateFilePath(), Path.Combine(Config.TmpPath,"Layers"));

            AnycubicFile.Decode();
        }

    }
}
