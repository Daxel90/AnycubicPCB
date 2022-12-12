using AnycubicPCB.AnycubicFormat;
using AnycubicPCB.Forms;
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

        WorkSpace Ws;
        public MainForm()
        {
            InitializeComponent();

            Text = "AnycubicPCB by Giara Rel. " + Config.Release;

            List<string> Machines = Machine.GetMachineList();
            cbMachines.Items.AddRange(Machines.ToArray());

            if(Machines.Contains(Config.MachineName))
                cbMachines.SelectedItem = Config.MachineName;

            UpdateMachineSelection();

            giaraPictureBox1.SetLayerQty(2);
            giaraPictureBox1.SetLayerAlpha(1, 0.5f);
        }

        public void UpdateMachineSelection()
        {
            Machine m = Machine.GetMachineWithName((string)cbMachines.SelectedItem);

            lblMachine.Text = "Printer: " + m.Name;
            lblImgSize.Text = "Screen Size: " + m.ScreenSizeX + "x" + m.ScreenSizeY;
            lblDPI.Text = "Px Size: " + m.PixelSize + "um  DPI: " + m.GetDPI();
        }


        private void btnLoadPcb_Click(object sender, EventArgs e)
        {
            Ws = new WorkSpace();
            Ws.SelectMachine(Config.MachineName);

            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Title = "Select PDF with Pcb Layer";
            Dialog.Filter = "pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
            Dialog.FilterIndex = 2;
            Dialog.RestoreDirectory = true;

            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                Ws.LoadPdf(Dialog.FileName);
                Ws.LoadAnycubicTemplate();

                giaraPictureBox1.SetImageLayer(0,Ws.PcbLayerData);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

        }

        private void cbMachines_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.MachineName = (string)cbMachines.SelectedItem;
            Config.SaveConfig();

            UpdateMachineSelection();
        }

        private void calibrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewCalibrationForm Form = new NewCalibrationForm();

            Form.Show();
        }
    }
}
