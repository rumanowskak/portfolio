using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Lab3_hw
{
    class DecisionButton : System.Windows.Forms.Button
    {
        public DecisionButton()
        {
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DecisionButton_Paint);
        }
        private void DecisionButton_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            //custom drawing
            Pen pen = new Pen(Color.Black, 2);

            Rectangle rect = e.ClipRectangle;
            Point point1 = new Point(rect.X + 23, rect.Y + 6);
            Point point2 = new Point(rect.X + 40, rect.Y + 23);
            Point point3 = new Point(rect.X + 23,rect.Y + 40);
            Point point4 = new Point(rect.X + 6, rect.Y + 23);
            Point[] curvePoints =
            {
                    point1,
                    point2,
                    point3,
                    point4,
            };
            e.Graphics.DrawPolygon(pen, curvePoints);

        }
    }
}
