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
    public class Operation_block:Block
    {

        public Operation_block(Point mouseLocation, Size size, Size pictureBoxSize) : base(mouseLocation, size, pictureBoxSize)
        {
            // TODO -- Move to resources for localisation
            Text = Properties.strings.OperationBlockText;

            connectionPoints = new ConnectionPoint[2]
            {
                new ConnectionPoint(EndPoint.Out, new Point(size.Width / 2, size.Height), this),
                new ConnectionPoint(EndPoint.In, new Point(size.Width / 2, 0), this)
            };

        }

        public override BlockType GetBlockType()
        {
            return BlockType.OperationBlock;
        }

        public override void Draw(Graphics g)
        {
            Pen pen = EditModeEnabled ? Toolbox.blackDashPen : Toolbox.blackPen;

            Rectangle rect = new Rectangle(Position.X, Position.Y, Size.Width, Size.Height);
            g.FillRectangle(Brushes.White, rect);
            g.DrawRectangle(pen, rect);

            DrawCommon(g);
        }
    }
}
