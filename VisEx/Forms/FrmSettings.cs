using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisEx.Helpers;

namespace VisEx
{
    public partial class FrmSettings : Form
    {
        FrmAddStack frmAddStack;

        public FrmSettings()
        {
            InitializeComponent();
            frmAddStack = new FrmAddStack();

            foreach (var item in Context.PointStacks)
            {
                cmbStack.Items.Add(item);
            }

            cmbStack.SelectedItem = (from qr in Context.PointStacks where qr.StackName == Context.SelectedStack.StackName select qr).FirstOrDefault();

            this.SetData();

            Properties.Settings.Default.TimeDisplayEllipse = 500;
            Properties.Settings.Default.Interval = 500;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.TimeDisplayEllipse = Convert.ToInt32(numericUpDown1.Value);
            Properties.Settings.Default.MovingProgram = cmbMovingProgram.SelectedIndex;
            Properties.Settings.Default.Interval = Convert.ToInt32(numericUpDown2.Value);

            if (cmbStack.SelectedItem != null)
            {
                Context.SelectedStack = (PointStack)cmbStack.SelectedItem;
            }
            if (Context.SelectedStack != null)
            {
                Serializer.SerializeSelectedStack(Context.SelectedStack);
            }
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = Properties.Settings.Default.TimeDisplayEllipse;
            cmbMovingProgram.SelectedIndex = Properties.Settings.Default.MovingProgram;
            numericUpDown2.Value = Properties.Settings.Default.Interval;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (frmAddStack.ShowDialog() == DialogResult.OK)
            {
                this.AddStack();
            }
        }

        private void SetData()
        {
            cmbStack.ValueMember = "StackName";
            cmbStack.DisplayMember = "StackName";
        }

        private void AddStack()
        {
            this.SetData();
            if (Context.PointStacks != null)
            {
                cmbStack.Items.Add(Context.PointStacks.Last());
                cmbStack.SelectedItem = Context.PointStacks.Last();

                Serializer.SerializeStacks(Context.PointStacks);

            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
