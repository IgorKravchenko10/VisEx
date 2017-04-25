using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisEx
{
    /// <summary>
    /// Класс с данными
    /// </summary>
    public class Context
    {
        /// <summary>
        /// Выбранный список точек
        /// </summary>
        public static PointStack SelectedStack { get; set; }

        /// <summary>
        /// Все точки
        /// </summary>
        public static List<MyPoint> Points { get; set; }

        /// <summary>
        /// Все списки точек
        /// </summary>
        public static List<PointStack> PointStacks { get; set; }

    }
}
