using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnycubicPCB.CustomComponents
{
    public partial class GiaraPictureBox : UserControl
    {
        //Visualizzation Data
        float ImgScale = 1.0f;
        Point ImgOffset = new Point(0,0);
        InterpolationMode ImgInterpolation = InterpolationMode.HighQualityBicubic;

        //Layers
        public Image[] LayerImages;
        public float[] LayerAlpha;
        public int[] LayerXOffset;
        public int[] LayerYOffset;

        //Stats
        bool Panning = false;
        Point StartingPoint = new Point(0, 0);

        public GiaraPictureBox()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }
        #region -------------------------------------------- Visualization --------------------------------------------

        public void SetScale(float pScale)
        {
            ImgScale = pScale;
            Invalidate();
        }

        public void SetOffset(int pOffsetX, int pOffsetY)
        {
            ImgOffset.X = pOffsetX;
            ImgOffset.Y = pOffsetY;

            Invalidate();
        }

        public void SetInterpolationMode(InterpolationMode pInterpolation)
        {
            ImgInterpolation = pInterpolation;
        }

        #endregion

        #region -------------------------------------------- Layers --------------------------------------------

        public void SetLayerQty(int pLayers)
        {
            LayerImages = new Image[pLayers];
            LayerAlpha = new float[pLayers];
            LayerXOffset = new int[pLayers];
            LayerYOffset = new int[pLayers];

            for (int i = 0; i < pLayers; i++)
            {
                LayerAlpha[i] = 1;
                LayerXOffset[i] = 0;
                LayerYOffset[i] = 0;
            }
            Invalidate();
        }

        public void SetImageLayer(int pLayer, Image pImage)
        {
            LayerImages[pLayer] = pImage;
            Invalidate();
        }

        public void SetLayerAlpha(int pLayer, float pAlpha)
        {
            LayerAlpha[pLayer] = pAlpha;
            Invalidate();
        }

        public void SetLayerOffset(int pLayer, int pOffsetX, int pOffsetY)
        {
            LayerXOffset[pLayer] = pOffsetX;
            LayerYOffset[pLayer] = pOffsetY;
            Invalidate();
        }

        #endregion


        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Panning = true;
            StartingPoint = new Point(e.Location.X, e.Location.Y);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Panning = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if(Panning)
            {
                ImgOffset = new Point(ImgOffset.X + (StartingPoint.X - e.Location.X) , ImgOffset.Y + (StartingPoint.Y - e.Location.Y) );

                StartingPoint = new Point(e.Location.X, e.Location.Y);
                Invalidate();
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            int WheelMoveQty = e.Delta / SystemInformation.MouseWheelScrollDelta;

            ImgScale += WheelMoveQty * 0.01f;

            if (ImgScale < 0.1f)
                ImgScale = 0.1f;


            if (ImgScale > 10)
                ImgScale = 10;

            Invalidate();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            // Call the OnPaint method of the base class.  
            base.OnPaint(e);

            if(LayerImages != null)
            {
                Graphics g = e.Graphics;
                Rectangle Screen = new Rectangle(0, 0, Width, Height);
                g.InterpolationMode = ImgInterpolation;

                for (int i = 0; i < LayerImages.Length; i++)
                {
                    if(LayerImages[i] != null)
                    {
                        //Calculate Color Matrix for apply Alpha Channel to Image
                        float[][] MatrixItems ={
                        new float[] {1, 0, 0, 0, 0},
                        new float[] {0, 1, 0, 0, 0},
                        new float[] {0, 0, 1, 0, 0},
                        new float[] {0, 0, 0, LayerAlpha[i], 0},
                        new float[] {0, 0, 0, 0, 1}};

                        ColorMatrix Colors = new ColorMatrix(MatrixItems);
                        ImageAttributes imageAtt = new ImageAttributes();
                        imageAtt.SetColorMatrix(Colors, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                        //Calculate Offset + Scaling
                        RectangleF ImgPiece = new RectangleF((ImgOffset.X / ImgScale), (ImgOffset.Y / ImgScale), (Width / ImgScale), (Height / ImgScale));

                        g.DrawImage(LayerImages[i], Screen, ImgPiece.X, ImgPiece.Y, ImgPiece.Width, ImgPiece.Height, GraphicsUnit.Pixel, imageAtt);
                    }   
                }
            }
        }
    }
}
