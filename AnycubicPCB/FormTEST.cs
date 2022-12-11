using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnycubicPCB
{
    public partial class FormTEST : Form
    {
        public FormTEST()
        {
            InitializeComponent();

            giaraPictureBox1.SetLayerQty(2);
            giaraPictureBox1.SetImageLayer(0, new Bitmap(@"H:\test\PWMO\Layer_0.png"));
            giaraPictureBox1.SetImageLayer(1, new Bitmap(@"H:\test\PWMO\aa.png"));
            giaraPictureBox1.SetInterpolationMode(InterpolationMode.NearestNeighbor);

            giaraPictureBox1.SetLayerAlpha(0, 1f);
            giaraPictureBox1.SetLayerAlpha(1, 0.5f);
            giaraPictureBox1.SetLayerRotation(1,45);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            giaraPictureBox1.SetScale(0.5f);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            giaraPictureBox1.SetOffset(500,500);
        }
    
    }
}
