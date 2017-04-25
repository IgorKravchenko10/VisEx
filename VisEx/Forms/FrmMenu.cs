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
    public partial class FrmMenu : Form
    {
        FrmExperiment _frmExperiment;
        FrmSettings _frmSettings;
        AboutBox1 _frmAbout;

        public FrmMenu()
        {
            InitializeComponent();
            this.LoadSettings();
            _frmExperiment = new FrmExperiment();
            _frmSettings = new FrmSettings();
            _frmAbout = new AboutBox1();

            _frmExperiment.WindowState = FormWindowState.Maximized;
            _frmExperiment.TopMost = true;
            _frmExperiment.FormBorderStyle = FormBorderStyle.None;

            Screen myScreen = Screen.FromControl(_frmExperiment);
            Rectangle area = myScreen.WorkingArea;

            Properties.Settings.Default.ScreenWidth = area.Width;
            Properties.Settings.Default.ScreenHeight = area.Height;
        }

        public void LoadSettings()
        {
            Context.PointStacks = Serializer.DeserializeStacks();
            Context.Points = Serializer.DeserializePoints();
            Context.SelectedStack = Serializer.DeserializeSelectedStack();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExperiment_Click(object sender, EventArgs e)
        {
            if (Context.SelectedStack != null)
            {
                _frmExperiment.ShowDialog();
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            _frmSettings.ShowDialog();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            _frmAbout.ShowDialog();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
        }
    }
}
