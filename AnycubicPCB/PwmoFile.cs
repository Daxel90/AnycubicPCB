using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AnycubicPCB
{
    public class PwmoFile
    {
		//-------------------- Constants -------------------- 
		// ------HEADER OFFSET------
		// 0x06; 80?
		// 0x0A; 51?
		const int OFFSET_LayerThickness = 0x0E;
		const int OFFSET_ExposureTime = 0x12;
		const int OFFSET_OffTime = 0x16;
		const int OFFSET_BottomExposureTime = 0x1A;
		const int OFFSET_BottomLayers = 0x1E;
		const int OFFSET_ZLift = 0x22;
		const int OFFSET_ZSpeed = 0x26;
		const int OFFSET_ZRetract = 0x2A;
		// 0x2E; 6.024?
		// 0x32; 1?
		const int OFFSET_ScreenX = 0x36;
		const int OFFSET_ScreenY = 0x3A;
		// 0x3E; 6.024?
		// 0x42; 2.401?
		// 0x42; 2.401?

		// ------LAYERDEF OFFSET------
		int OFFSET_LayerQty = 0x08;
		int OFFSET_FirstLayer = 0x0C;
		int SIZE_SingleLayerData = 0x20;


		//-------------------- Configurations -------------------- 
		string FilePath;
		string FolderCache;
		byte[] FileContent;

		//-------------------- File Info -------------------- 
		int OFFSET_ANYCUBIC = 0;
		int OFFSET_HEADER = 0;
		int OFFSET_PREVIEW = 0;
		int OFFSET_LAYERDEF = 0;
		int OFFSET_LAYERDEF_DATA = 0;

		//-------------------- File Data -------------------- 
		//Header Data
		float LayerThickness;
		float ExposureTime;
		float OffTime;
		float BottomExposureTime;
		float BottomLayers;
		float ZLift;
		float ZSpeed;
		float ZRetract;
		int ScreenX;
		int ScreenY;

		//Layer Data
		int LayerQty;
		public PwmoLayer[] Layers;

		public PwmoFile(string pPath, string pCacheFolder)
        {
            FilePath = pPath;
			FolderCache = pCacheFolder;
			FileContent = File.ReadAllBytes(pPath);
        }

        public int Decode()
        {
			int Error = 0;

			OFFSET_ANYCUBIC = SearchData(FileContent, Encoding.UTF8.GetBytes("ANYCUBIC")); 
			OFFSET_HEADER   = SearchData(FileContent, Encoding.UTF8.GetBytes("HEADER"));    
			OFFSET_PREVIEW  = SearchData(FileContent, Encoding.UTF8.GetBytes("PREVIEW"));  
			OFFSET_LAYERDEF = SearchData(FileContent, Encoding.UTF8.GetBytes("LAYERDEF"));

			DecodeHEADER();
			DecodeLAYERDEF();
			return Error;
        }

		private void DecodeHEADER()
        {
			LayerThickness = Utils.ReadFloat(ref FileContent, OFFSET_HEADER + OFFSET_LayerThickness);
			ExposureTime = Utils.ReadFloat(ref FileContent, OFFSET_HEADER + OFFSET_ExposureTime);
			OffTime = Utils.ReadFloat(ref FileContent, OFFSET_HEADER + OFFSET_OffTime);

			BottomExposureTime = Utils.ReadFloat(ref FileContent, OFFSET_HEADER + OFFSET_BottomExposureTime);
			BottomLayers = Utils.ReadFloat(ref FileContent, OFFSET_HEADER + OFFSET_BottomLayers);
			ZLift = Utils.ReadFloat(ref FileContent, OFFSET_HEADER + OFFSET_ZLift);
			ZSpeed = Utils.ReadFloat(ref FileContent, OFFSET_HEADER + OFFSET_ZSpeed);
			ZRetract = Utils.ReadFloat(ref FileContent, OFFSET_HEADER + OFFSET_ZRetract);

			ScreenX = Utils.ReadInt(ref FileContent, OFFSET_HEADER + OFFSET_ScreenX);
			ScreenY = Utils.ReadInt(ref FileContent, OFFSET_HEADER + OFFSET_ScreenY);
		}

		public void DecodeLAYERDEF()
		{
			LayerQty = Utils.ReadInt(ref FileContent, OFFSET_LAYERDEF + OFFSET_LayerQty);
			Layers = new PwmoLayer[LayerQty];

			int LayerOff = OFFSET_LAYERDEF + OFFSET_FirstLayer;

			for (int layerN = 0; layerN < LayerQty; layerN++)
			{
				byte[] LayerHeader = new byte[SIZE_SingleLayerData];
				byte[] LayerData;

				Array.Copy(FileContent, LayerOff, LayerHeader, 0, SIZE_SingleLayerData);

				PwmoLayer Layer = new PwmoLayer(LayerHeader, layerN, ScreenX, ScreenY, Path.Combine(FolderCache, "Layer_" + layerN + ".png"));

				Layer.DecodeHEADER();
				LayerData = new byte[Layer.DataSize];

				Array.Copy(FileContent, Layer.StartOffset, LayerData, 0, Layer.DataSize);

				Layer.AddImageData(LayerData);

				Layers[layerN] = Layer;
				LayerOff += SIZE_SingleLayerData;
			}

			// Start Read LayerImage
			OFFSET_LAYERDEF_DATA = LayerOff;

			int i = 0;
			for (int layerN = 0; layerN < LayerQty; layerN++)
			{
				Layers[layerN].DecodeLAYER();
				Layers[layerN].UnloadImage();			
			}
		}


		public void EncodeLAYERDEF()
        {
			int total_size = OFFSET_LAYERDEF_DATA;

			// Encode Layers
			for (int i = 0; i < LayerQty; i++)
			{
				Layers[i].EncodeLAYER();
				Console.WriteLine("LayerEncode: " + i);
				total_size += Layers[i].LayerData.Length;
			}

			// ricalcolo posizioni layer data
			for (int i = 0; i < LayerQty; i++)
			{
				if (i > 0)
				{
					Layers[i].StartOffset = Layers[i - 1].StartOffset + Layers[i - 1].DataSize;
				}
			}

			byte[] newContent = new byte[total_size];
			int progress = OFFSET_LAYERDEF_DATA;

			// copio prima parte del file fino a LAYERDEF_DATA
			Array.Copy(FileContent, 0, newContent, 0, OFFSET_LAYERDEF_DATA);

			// copio dati layers
			for (int i = 0; i < LayerQty; i++)
			{
				// sovrascrivo info del layer
				int layerHederOffset = OFFSET_LAYERDEF + OFFSET_FirstLayer + (SIZE_SingleLayerData * i);

				Layers[i].EncodeHEADER();

				Array.Copy(Layers[i].LayerHeaderData, 0, newContent, layerHederOffset, SIZE_SingleLayerData);

				// scrivo data file
				Array.Copy(Layers[i].LayerData, 0, newContent, progress, Layers[i].LayerData.Length);

				progress += Layers[i].LayerData.Length;
			}
			File.WriteAllBytes(@"C:\\Users\\Giara\\Desktop\\OutputFile.pwmo", newContent);
		}
	

	#region -------------------- Utils ----------------------------------

	/// <summary>
	/// Search bytes sequence inside bytes array
	/// </summary>
	/// <param name="source"></param>
	/// <param name="toSearch"></param>
	/// <returns></returns>
	private int SearchData(byte[] pSource, byte[] pToSearch)
		{
			bool found = false;
			for (int i = 0; i < pSource.Length; i++)
			{
				found = true;

				for (int j = 0; j < pToSearch.Length; j++)
				{
					if (pSource[i + j] != pToSearch[j])
					{
						found = false;
						break;
					}
				}

				if (found)
					return i + pToSearch.Length;
			}

			return -1;
		}

	#endregion

	}
}
