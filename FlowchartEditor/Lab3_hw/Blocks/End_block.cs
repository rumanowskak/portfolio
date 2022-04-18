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
    public class End_block : Block
    {
        public End_block(Point mouseLocation, Size size, Size pictureBoxSize) : base(mouseLocation, size, pictureBoxSize)
        {
            // TODO -- Move to resources for localisation
            Text = "STOP";

            connectionPoints = new ConnectionPoint[1]
            {
                new ConnectionPoint(EndPoint.In, new Point(size.Width / 2, 0), this),
            };

        }

        public override BlockType GetBlockType()
        {
            return BlockType.EndBlock;
        }

        public override void Draw(Graphics g)
        {
            Pen pen = EditModeEnabled ? Toolbox.redDashPen : Toolbox.redPen;

            Rectangle rc = new Rectangle(Position, Size);
            g.FillEllipse(Brushes.White, rc);
            g.DrawEllipse(pen, rc);

            DrawCommon(g);
        }
    }
}
