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
    public partial class FrmAddStack : Form
    {

        private List<MyPoint> _points = new List<MyPoint>();

        public FrmAddStack()
        {
            InitializeComponent();

            foreach (var item in Context.Points)
            {
                cmbPoint.Items.Add(item);
            }
        }

        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            using (FrmAddPoint frmAddPoint = new FrmAddPoint())
            {
                if (frmAddPoint.ShowDialog(this) == DialogResult.OK)
                {
                    this.AddPoint();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text == string.Empty || _points.Count == 0)
            {
                MessageBox.Show("Name field or points collection are empty.", "Error");
            }
            else
            {
                PointStack pointStack = new PointStack(textEdit1.Text, _points);
                if (Context.PointStacks == null)
                {
                    Context.PointStacks = new List<PointStack>();
                }
                Context.PointStacks.Add(pointStack);
            }

        }

        private void FrmAddStack_Load(object sender, EventArgs e)
        {
            FillListBox();
            SetData();
        }

        /// <summary>
        /// Присваивает источнику данных список точек
        /// </summary>
        private void FillListBox()
        {
            listBoxPoints.DataSource = _points;
            listBoxPoints.DisplayMember = "PointName";
        }

        /// <summary>
        /// Устанавливает данные для отображения
        /// </summary>
        private void SetData()
        {
            cmbPoint.ValueMember = "PointName";
            cmbPoint.DisplayMember = "PointName";

        }

        /// <summary>
        /// Добавляет точку в выпадающий список
        /// </summary>
        private void AddPoint()
        {
            if (Context.Points != null)
            {
                cmbPoint.Items.Add(Context.Points.Last());
                cmbPoint.SelectedItem = Context.Points.Last();

                Serializer.SerializePoints(Context.Points);
            }
        }

        /// <summary>
        /// Заполнить конечный список новой точкой
        /// </summary>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (cmbPoint.SelectedItem == null)
            {
                MessageBox.Show("Select point from combo box or create new point.", "Error");
            }
            _points.Add((MyPoint)cmbPoint.SelectedItem);
            listBoxPoints.Refresh();
        }

        /// <summary>
        /// Убрать точку из конечного списка
        /// </summary>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            _points.Remove((MyPoint)listBoxPoints.SelectedItem);
            listBoxPoints.Refresh();
        }
    }
}
