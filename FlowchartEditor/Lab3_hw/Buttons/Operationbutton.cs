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
    class OperationButton : System.Windows.Forms.Button
    {
        public OperationButton()
        {
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OperationButton_Paint);
        }
        private void OperationButton_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            //custom drawing
            Pen pen = new Pen(Color.Black, 2);
            Rectangle rect = e.ClipRectangle;
            rect.X = rect.X + 7;
            rect.Y = rect.Y + 14;
            rect.Height = rect.Height - 28;
            rect.Width = rect.Width - 14;

            e.Graphics.DrawRectangle(pen, rect);

        }
    }
}
