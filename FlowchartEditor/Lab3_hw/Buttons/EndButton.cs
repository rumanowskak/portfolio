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
    class EndButton : System.Windows.Forms.Button
    {
        public EndButton()
        {
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.EndButton_Paint);
        }

        private void EndButton_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            //custom drawing
            Pen pen = new Pen(Color.Red, 2);
            Rectangle rect = e.ClipRectangle;
            rect.X = rect.X + 4;
            rect.Y = rect.Y + 10;
            rect.Height = rect.Height - 20;
            rect.Width = rect.Width - 8;

            e.Graphics.DrawEllipse(pen, rect);

        }
    }
}
