using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisEx
{
    /// <summary>
    /// Список точек
    /// </summary>
    [Serializable()]
    public class PointStack
    {
        /// <summary>
        /// Название
        /// </summary>
        public string StackName { get; set; }

        /// <summary>
        /// Точки
        /// </summary>
        public List<MyPoint> Points { get; set; }

        public PointStack()
        {

        }

        public PointStack(string name)
        {
            this.StackName = name;
            this.Points = new List<MyPoint>();
        }

        public PointStack(string name, List<MyPoint> points)
        {
            this.StackName = name;
            this.Points = new List<MyPoint>();
            this.Points.AddRange(points);
        }
    }
}
