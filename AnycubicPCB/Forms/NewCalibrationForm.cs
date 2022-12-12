using AnycubicPCB.AnycubicFormat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnycubicPCB.Forms
{
    public partial class NewCalibrationForm : Form
    {
        Calibration Calib = new Calibration();
        public NewCalibrationForm()
        {
            InitializeComponent();

            List<string> Machines = Machine.GetMachineList();
            cbxMachineList.Items.AddRange(Machines.ToArray());

            if (Machines.Contains(Config.MachineName))
                cbxMachineList.SelectedItem = Config.MachineName;

            UpdateMachineSelection();

            giaraPictureBox1.SetLayerQty(1);
        }

        private void btnAddPoint_Click(object sender, EventArgs e)
        {
            int[] Point = new int[3];

            Point[0] = Int32.Parse(tbxX.Text);
            Point[1] = Int32.Parse(tbxY.Text);
            Point[2] = Int32.Parse(tbxSize.Text);

            Calib.Points.Add(Point);

            UpdatePointsList();
            giaraPictureBox1.SetImageLayer(0, Calib.GenerateLayer());
        }

        private void UpdatePointsList()
        {
            lblFidList.Text = "";
            foreach (int[] Point in Calib.Points)
            {
                lblFidList.Text += $"X:{Point[0]} Y:{Point[1]} Size:{Point[2]}"+Environment.NewLine;
            }
        }

        public void UpdateMachineSelection()
        {
            Machine m = Machine.GetMachineWithName((string)cbxMachineList.SelectedItem);

            Calib.MachineType = m.Name;
        }

        private void cbxMachineList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateMachineSelection();
        }
    }
}
