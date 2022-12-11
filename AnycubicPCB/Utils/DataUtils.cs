using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace AnycubicPCB.Utils
{
    class DataUtils
    {
		public static float ReadFloat(ref byte[] pData, int pOffset)
		{
			return BitConverter.ToSingle(pData, pOffset);
		}

		public static int ReadInt(ref byte[] pData, int pOffset)
		{
			return BitConverter.ToInt32(pData, pOffset);
		}

		public static void WriteFloat(ref byte[] pBuffer, int pOffset, float pValue)
		{
			byte[] EncodedBytes = BitConverter.GetBytes(pValue);

			pBuffer[pOffset] = EncodedBytes[0];
			pBuffer[pOffset + 1] = EncodedBytes[1];
			pBuffer[pOffset + 2] = EncodedBytes[2];
			pBuffer[pOffset + 3] = EncodedBytes[3];
		}

		public static void WriteInt(ref byte[] pBuffer, int pOffset, int pValue)
		{
			byte[] EncodedBytes = BitConverter.GetBytes(pValue);

			pBuffer[pOffset] = EncodedBytes[0];
			pBuffer[pOffset + 1] = EncodedBytes[1];
			pBuffer[pOffset + 2] = EncodedBytes[2];
			pBuffer[pOffset + 3] = EncodedBytes[3];
		}

		public static void SetPixelColor(ref byte[] pPixelsData, int pImgStrade, int x, int y, int RGBcolor)
		{
			int index = y * pImgStrade + (x * 3) + 2;

			//RGB
			pPixelsData[index--] = (byte)((RGBcolor >> 16) & 0xFF);
			pPixelsData[index--] = (byte)((RGBcolor >> 8) & 0xFF);
			pPixelsData[index--] = (byte)((RGBcolor) & 0xFF);
		}

		public static int GetPixelColor(byte[] pPixelsData, int pImgStrade, int x, int y)
		{
			int index = y * pImgStrade + (x * 3) + 2;

			int RGBColor = pPixelsData[index--] << 16;
			RGBColor |= pPixelsData[index--] << 8;
			RGBColor |= pPixelsData[index--];

			return RGBColor;
		}
	}
}
