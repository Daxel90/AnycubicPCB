using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnycubicPCB.Utils
{
    class ImgUtils
    {
        public static Image GetImageFromPDF(string pPdfPath, int pDPI)
        {
            FileStream streamPDf = File.OpenRead(pPdfPath);
            byte[] png = Freeware.Pdf2Png.Convert(streamPDf, 1, pDPI);
            Stream streamPNG = new MemoryStream(png);
            return new Bitmap(streamPNG);
        }

        public static Bitmap ResizeImage(Image pImg, double pScale)
        {
            return ResizeImage(pImg, (int)(pImg.Width * pScale), (int)(pImg.Height * pScale));
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public static Bitmap RotateImage(Image bitmap, float angle)
        {
            int w, h, x, y;
            var dW = (double)bitmap.Width;
            var dH = (double)bitmap.Height;

            double degrees = Math.Abs(angle);
            if (degrees <= 90)
            {
                double radians = 0.0174532925 * degrees;
                double dSin = Math.Sin(radians);
                double dCos = Math.Cos(radians);
                w = (int)(dH * dSin + dW * dCos);
                h = (int)(dW * dSin + dH * dCos);
                x = (w - bitmap.Width) / 2;
                y = (h - bitmap.Height) / 2;
            }
            else
            {
                degrees -= 90;
                double radians = 0.0174532925 * degrees;
                double dSin = Math.Sin(radians);
                double dCos = Math.Cos(radians);
                w = (int)(dW * dSin + dH * dCos);
                h = (int)(dH * dSin + dW * dCos);
                x = (w - bitmap.Width) / 2;
                y = (h - bitmap.Height) / 2;
            }

            var rotateAtX = bitmap.Width / 2f;
            var rotateAtY = bitmap.Height / 2f;

            var bmpRet = new Bitmap(w, h);
            bmpRet.SetResolution(bitmap.HorizontalResolution, bitmap.VerticalResolution);
            using (var graphics = Graphics.FromImage(bmpRet))
            {
                graphics.Clear(Color.White);
                graphics.TranslateTransform(rotateAtX + x, rotateAtY + y);
                graphics.RotateTransform(angle);
                graphics.TranslateTransform(-rotateAtX - x, -rotateAtY - y);
                graphics.DrawImage(bitmap, new PointF(0 + x, 0 + y));
            }
            return bmpRet;
        }

    }
}
