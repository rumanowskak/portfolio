using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Lab3_hw
{
    public class Start_block : Block
    {
        public Start_block(Point mouseLocation, Size size, Size pictureBoxSize) : base(mouseLocation, size, pictureBoxSize)
        {
            // TODO -- Move to resources for localisation
            Text = "START";

            connectionPoints = new ConnectionPoint[1]
            {
                new ConnectionPoint(EndPoint.Out, new Point(size.Width / 2, size.Height), this),
            };

        }

        public override BlockType GetBlockType()
        {
            return BlockType.StartBlock;
        }

        public override void Draw(Graphics g)
        {
            Pen pen = EditModeEnabled ? Toolbox.limeDashPen : Toolbox.limePen;

            Rectangle rc = new Rectangle(Position, Size);
            g.FillEllipse(Brushes.White, rc);
            g.DrawEllipse(pen, rc);

            DrawCommon(g);
        }
    }
}
