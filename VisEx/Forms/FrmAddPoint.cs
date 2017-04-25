using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisEx
{
    public partial class FrmAddPoint : Form
    {

        public FrmAddPoint()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyPoint point = new MyPoint()
            {
                X = Convert.ToInt32(Convert.ToDouble(textEdit1.Text) / 100 * Properties.Settings.Default.ScreenWidth),
                Y = Convert.ToInt32(Convert.ToDouble(textEdit2.Text) / 100 * Properties.Settings.Default.ScreenHeight)
            };

            if (Context.Points == null)
            {
                Context.Points = new List<MyPoint>();
            }
            Context.Points.Add(point);
            this.Close();
        }
    }
}
