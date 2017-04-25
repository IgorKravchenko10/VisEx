using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisEx
{
    public enum MovingTypeEnum
    {
        Horizontal = 0,
        Vertical = 1,
        Diagonal = 2
    }

    public enum MovingProgramEnum
    {
        Automatic = 0,
        Manual = 1
    }

    public partial class FrmExperiment : Form
    {
        List<Point> _points;
        Graphics _graphics;
        MovingProgram _movingProgram;

        public FrmExperiment()
        {
            InitializeComponent();
            _points = new List<Point>();
            _graphics = this.CreateGraphics();

        }

        private void PrepareLight()
        {
            Graphics graphics = this.CreateGraphics();
            graphics.FillEllipse(new SolidBrush(Color.Yellow), new Rectangle(_movingProgram.CentalPoint.X, _movingProgram.CentalPoint.Y, 20, 20));
            Thread.Sleep(Properties.Settings.Default.TimeDisplayEllipse);
            graphics.Clear(Color.Black);
            Thread.Sleep(Properties.Settings.Default.Interval);
        }

        private void FrmExperiment_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            _movingProgram = new MovingProgram(this.Height, this.Width);
        }

        private void FrmExperiment_MouseClick(object sender, MouseEventArgs e)
        {
            //PrepareLight();
            RaiseLight();
        }

        public void RaiseLight()
        {
            foreach (var item in Context.SelectedStack.Points)
            {
                Graphics graphics = this.CreateGraphics();
                graphics.FillEllipse(new SolidBrush(Color.Yellow), new Rectangle(item.X, item.Y, 20, 20));
                Thread.Sleep(Properties.Settings.Default.TimeDisplayEllipse);
                graphics.Clear(Color.Black);
                Thread.Sleep(Properties.Settings.Default.Interval);
            }
        }

        private void FrmExperiment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            else if (e.KeyCode==Keys.Enter || e.KeyCode == Keys.Space)
            {
                RaiseLight();
            }
        }
    }
}
