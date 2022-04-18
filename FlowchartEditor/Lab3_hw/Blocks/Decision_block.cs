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
    public class Decision_block : Block
    {
        public Decision_block(Point mouseLocation, Size size, Size pictureBoxSize) : base(mouseLocation, size, pictureBoxSize)
        {
            // TODO -- Move to resources for localisation
            Text = Properties.strings.DecisionBlockText;

            connectionPoints = new ConnectionPoint[3]
            {
                new ConnectionPoint(EndPoint.Out, new Point(0, size.Height / 2), this),
                new ConnectionPoint(EndPoint.Out, new Point(size.Width, size.Height / 2), this),
                new ConnectionPoint(EndPoint.In, new Point(size.Width / 2, 0), this)
            };

        }

        public override BlockType GetBlockType()
        {
            return BlockType.DecisionBlock;
        }

        public override void Draw(Graphics g)
        {
            Pen pen = EditModeEnabled ? Toolbox.blackDashPen : Toolbox.blackPen;

            Point p1 = new Point(Position.X + Size.Width/2,Position.Y);
            Point p2 = new Point(Position.X + Size.Width, Position.Y + Size.Height / 2);
            Point p3 = new Point(Position.X + Size.Width / 2, Position.Y + Size.Height);
            Point p4 = new Point(Position.X, Position.Y + Size.Height / 2);
            Point[] curvePoints = { p1, p2, p3,  p4, };

            g.FillPolygon(Brushes.White, curvePoints);
            g.DrawPolygon(pen, curvePoints);

            DrawCommon(g);
        }
    
        protected override void DrawText(Graphics g)
        {
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            // Smaller rectangle so that text is contained inside the block

            Rectangle smallRc = new Rectangle(Position.X + Size.Width / 4, Position.Y + Size.Height / 4, Size.Width / 2, Size.Height /2 );
            g.DrawString(Text, font, Brushes.Black, smallRc, stringFormat);

            Rectangle trueLabelRc = new Rectangle(Position.X - 8, Position.Y + Size.Height / 2 - 20, 8, 8);
            g.DrawString("T", font, Brushes.Black, trueLabelRc, stringFormat);

            Rectangle falseLabelRc = new Rectangle(Position.X + Size.Width, Position.Y + Size.Height / 2 - 20, 8, 8);
            g.DrawString("F", font, Brushes.Black, falseLabelRc, stringFormat);

        }
    }
}
