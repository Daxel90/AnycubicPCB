using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AnycubicPCB
{
    public partial class MainForm : Form
    {
        PwmoFile File;

        public MainForm()
        {
            InitializeComponent();


            //OpenFileDialog Dialog = new OpenFileDialog();

            //if (Dialog.ShowDialog() == DialogResult.OK)
            //{
            //    File = new PwmoFile(Dialog.FileName, @"H:\test\PWMO");

            //    new Thread(() => File.Decode()).Start();
            //}

            //new Thread(() => File.EncodeLAYERDEF()).Start();
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {


        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
           
        }
    }
}
