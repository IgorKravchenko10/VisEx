using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisEx
{
    public class MovingProgram
    {

        public MovingProgram(int screenHeight, int screenWidth)
        {
            this.Height = screenHeight;
            this.Width = screenWidth;
            this.MovingType = (MovingTypeEnum)Properties.Settings.Default.MovingType;

            GeneratePoints();
        }

        private void GeneratePoints()
        {
            if (this.Points == null)
            {
                this.Points = new List<Point>();
            }

            if (this.MovingType == MovingTypeEnum.Horizontal)
            {
                for (int i = 1; i <= 4; i++)
                {
                    this.Points.Add(new Point(i*(this.Width / 4), this.Height / 2));
                }
            }

            else if (this.MovingType == MovingTypeEnum.Vertical)
            {
                for (int i = 1; i <= 4; i++)
                {
                    this.Points.Add(new Point(this.Width / 2, i*(this.Height / 4)));
                }
            }

            else if (this.MovingType == MovingTypeEnum.Diagonal)
            {
                for (int i = 1; i <= 4; i++)
                {
                    this.Points.Add(new Point(this.Width / i, this.Height / i));
                }
            }
        }
        
        public List<Point> Points { get; set; }

        public MovingTypeEnum MovingType { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public Point CentalPoint
        {
            get
            {
                return (from qr in this.Points where (qr.X == this.Width / 2 && qr.Y == this.Height / 2) select qr).FirstOrDefault();
            }
        }

        public void ShowCentralPoint()
        {
            //Graphics graphics;
            //graphics.FillEllipse(new SolidBrush(Color.Yellow), new Rectangle(this.CentalPoint.X, this.CentalPoint.Y, 20, 20));
            //Thread.Sleep(Properties.Settings.Default.TimeDisplayEllipse);
            //graphics.Clear(Color.Black);
        }
    }
}
