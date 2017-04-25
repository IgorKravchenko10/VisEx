using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisEx
{
    /// <summary>
    /// Точка с названием и уникальным идентификатором
    /// </summary>
    [Serializable]
    public class MyPoint
    {

        public string PointName
        {
            get
            {
                return this.X.ToString() + "; " + this.Y.ToString();
            }
        }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
