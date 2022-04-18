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
    class StartButton : System.Windows.Forms.Button
    {
        public StartButton()
        {
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.StartButton_Paint);
        }

        private void StartButton_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            //custom drawing

            Pen pen = new Pen(Color.LimeGreen, 2);
            Rectangle rect=e.ClipRectangle;
            rect.X = rect.X + 4;
            rect.Y = rect.Y + 10;
            rect.Height = rect.Height - 20;
            rect.Width = rect.Width - 8;
            
            e.Graphics.DrawEllipse(pen, rect);
            
        }
    }
}
