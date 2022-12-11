using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using AnycubicPCB.Utils;

namespace AnycubicPCB
{
    public class PwmoLayer
    {
        //-------------------- Constants -------------------- 
        const int OFFSET_StartOffset = 0x00;
        const int OFFSET_DataSize = 0x04;
        const int OFFSET_ZLiftDist = 0x08;
        const int OFFSET_ZLiftSpeed = 0x0C;
        const int OFFSET_ExposureTime = 0x10;
        const int OFFSET_LayerHeight = 0x14;
        const int OFFSET_Padding3 = 0x18;
		const int OFFSET_Padding4 = 0x1C;


        public int LayerNumber;
		public int SizeX;
		public int SizeY;

		public int StartOffset;
		public int DataSize;

		public float ZLiftDist;
        public float ZLiftSpeed;
        public float ExposureTime;
        public float Height;

		public string ImagePath;
		public bool ImageLoaded;
		public Bitmap ImageData;
		public byte[] LayerHeaderData;
		public byte[] LayerData;

        public PwmoLayer(byte[] pHeaderData, int pLayerN, int pSizeX, int pSizeY, string pPath)
        {
            LayerHeaderData = pHeaderData;
			LayerNumber = pLayerN;
			ImagePath = pPath;
			ImageLoaded = false;

			SizeX = pSizeX;
			SizeY = pSizeY;
		}

        public void AddImageData(byte[] pData)
        {
            LayerData = pData;
        }

        public void DecodeHEADER()
        {
            StartOffset = DataUtils.ReadInt(ref LayerHeaderData, OFFSET_StartOffset);
            DataSize = DataUtils.ReadInt(ref LayerHeaderData, OFFSET_DataSize);

            ZLiftDist = DataUtils.ReadFloat(ref LayerHeaderData, OFFSET_ZLiftDist);
            ZLiftSpeed = DataUtils.ReadFloat(ref LayerHeaderData, OFFSET_ZLiftSpeed);
            ExposureTime = DataUtils.ReadFloat(ref LayerHeaderData, OFFSET_ExposureTime);
            Height = DataUtils.ReadFloat(ref LayerHeaderData, OFFSET_LayerHeight);
        }

        public void DecodeLAYER()
        {
			ImageData = new Bitmap(SizeX, SizeY, PixelFormat.Format24bppRgb);
			BitmapData bitmapData = ImageData.LockBits(new Rectangle(0, 0, ImageData.Width, ImageData.Height), ImageLockMode.ReadWrite, ImageData.PixelFormat);

			int PixelByteCount = bitmapData.Stride * ImageData.Height;
			int ImgStrade = bitmapData.Stride;

			byte[] PixelsData = new byte[PixelByteCount];
			IntPtr ptrFirstPixel = bitmapData.Scan0;

			int imgX = 0;
			int imgY = 0;
			bool done = false;
			int ImageOffset;

			ImageOffset = 0;

			while (!done)
			{
				byte generateCmd = LayerData[ImageOffset];
				int lineSize = 0;
				int lineColor = (generateCmd & 0xF0) >> 4;

				int ColorByte = lineColor * 17;
				int RGBColor = lineColor * 17;
				RGBColor = (RGBColor << 8) + lineColor * 17;
				RGBColor = (RGBColor << 8) + lineColor * 17;

				// ExtendedSizeCmd
				if (lineColor == 0x00 || lineColor == 0x0F)
				{
					lineSize = (generateCmd & 0x0F);
					lineSize = (lineSize << 8) + (LayerData[ImageOffset + 1] & 0xFF);

					ImageOffset += 2;
				}
				else
				{
					lineSize = (generateCmd & 0x0F);
					ImageOffset += 1;
				}

				while (lineSize > 0)
				{
					if (imgX < SizeX)
					{
						DataUtils.SetPixelColor(ref PixelsData, ImgStrade, imgX, imgY, RGBColor);

						imgX++;

						if ((imgX == SizeX - 1) && (imgY == SizeY - 1))
						{
							done = true;
							break;
						}
					}
					else if (imgX == SizeX && imgY < SizeY)
					{
						imgX = 0;
						imgY++;
						DataUtils.SetPixelColor(ref PixelsData, ImgStrade, imgX, imgY, RGBColor);
						imgX++;
					}

					lineSize--;
				}
			}

			//Copy Data to Image
			Marshal.Copy(PixelsData, 0, ptrFirstPixel, PixelByteCount);
			ImageData.UnlockBits(bitmapData);
			ImageLoaded = true;

			SaveImage();
			UnloadImage();
		}

		public void EncodeHEADER()
		{
			DataUtils.WriteInt(ref LayerHeaderData, OFFSET_StartOffset, StartOffset);
			DataUtils.WriteInt(ref LayerHeaderData, OFFSET_DataSize, DataSize);

			DataUtils.WriteFloat(ref LayerHeaderData, OFFSET_ZLiftDist, ZLiftDist);
			DataUtils.WriteFloat(ref LayerHeaderData, OFFSET_ZLiftSpeed, ZLiftSpeed);
			DataUtils.WriteFloat(ref LayerHeaderData, OFFSET_ExposureTime, ExposureTime);
			DataUtils.WriteFloat(ref LayerHeaderData, OFFSET_LayerHeight, Height);
		}

		public void EncodeLAYER()
        {
			List<byte> encodedData = new List<byte>();

			if (!ImageLoaded)
				LoadImage();

			BitmapData bitmapData = ImageData.LockBits(new Rectangle(0, 0, ImageData.Width, ImageData.Height), ImageLockMode.ReadWrite, ImageData.PixelFormat);

			int PixelByteCount = bitmapData.Stride * ImageData.Height;
			int ImgStrade = bitmapData.Stride;

			byte[] PixelsData = new byte[PixelByteCount];
			IntPtr ptrFirstPixel = bitmapData.Scan0;

			//Copy Data to Image
			Marshal.Copy(ptrFirstPixel, PixelsData, 0, PixelByteCount);
			ImageData.UnlockBits(bitmapData);

			int lastColor = -1;
			int occurrency = 0;

			for (int y = 0; y < SizeY; y++)
			{
				for (int x = 0; x < SizeX; x++)
				{
					int Color = (DataUtils.GetPixelColor(PixelsData, ImgStrade, x, y) & 0xFF) / 17;

					if (lastColor == -1)
						lastColor = Color;

					//Se colore é uguale e non é l'ultimo pixel
					if (lastColor == Color && ((y != SizeY - 1) || (x != SizeX - 1)))
					{
						occurrency++;
					}
					else
					{
						byte colorByte;

						//se ultimo pixel
						if ((y == SizeY - 1) && (x == SizeX - 1))
							occurrency++;

						if (lastColor == 0x00 || lastColor == 0x0F) // 4095
						{
							if ((occurrency / 4095) >= 1)
							{
								colorByte = (byte)((lastColor & 0x0F) << 4);
								colorByte |= 0x0F;
								for (int i = 0; i < (occurrency / 4095); i++)
								{
									encodedData.Add(colorByte);
									encodedData.Add((byte)0xFF);
								}
							}

							colorByte = (byte)((lastColor & 0x0F) << 4);
							occurrency = occurrency - ((int)(occurrency / 4095) * 4095);
							if (occurrency > 0)
							{
								colorByte |= (byte)((occurrency >> 8) & 0x0F);
								encodedData.Add(colorByte);
								encodedData.Add((byte)(occurrency & 0xFF));
							}
						}
						else //15
						{
							if ((occurrency / 15) >= 1)
							{
								colorByte = (byte)((lastColor & 0x0F) << 4);
								colorByte |= 0x0F;
								for (int i = 0; i < (occurrency / 15); i++)
								{
									encodedData.Add(colorByte);
								}
							}

							colorByte = (byte)((lastColor & 0x0F) << 4);
							occurrency = occurrency - ((int)(occurrency / 15) * 15);
							if (occurrency > 0)
							{
								colorByte |= (byte)(occurrency & 0x0F);
								encodedData.Add(colorByte);
							}
						}

						lastColor = Color;
						occurrency = 1;
					}
				}
			}
			if (LayerData.Length != encodedData.Count())
				Console.WriteLine("Layer size changed: from " + LayerData.Length + " to " + encodedData.Count());

			LayerData = encodedData.ToArray();
			DataSize = LayerData.Length;

			UnloadImage();
		}

		public void LoadImage()
		{
			if(!ImageLoaded)
            {
				Bitmap original = (Bitmap)Image.FromFile(ImagePath);
				//Convert FileFormat
				ImageData = new Bitmap(original.Width, original.Height,PixelFormat.Format24bppRgb);
				Graphics gr = Graphics.FromImage(ImageData);
				gr.DrawImage(original, new Rectangle(0, 0, ImageData.Width, ImageData.Height));

				gr.Dispose();
				original.Dispose();
			}

			ImageLoaded = true;
		}

		public void UnloadImage()
        {
			if(ImageLoaded)
            {
				ImageData.Dispose();
				ImageData = null;
			}

			ImageLoaded = false;
		}

		public void SaveImage()
		{
			if (ImageLoaded)
			{
				Console.WriteLine("Layer_" + LayerNumber + ".png");
				ImageData.Save(ImagePath, ImageFormat.Png);
			}
		}

	}
}
