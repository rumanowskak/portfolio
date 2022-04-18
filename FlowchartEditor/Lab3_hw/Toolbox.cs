using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_hw
{
    public static class Toolbox
    {
        public static Pen blackPen;
        public static Pen limePen;
        public static Pen redPen;

        public static Pen blackDashPen;
        public static Pen limeDashPen;
        public static Pen redDashPen;

        public static Pen arrowPen;

        static Toolbox()
        {
            blackPen = new Pen(Color.Black, 2);
            limePen = new Pen(Color.Lime, 2);
            redPen = new Pen(Color.Red, 2);

            blackDashPen = new Pen(Color.Black, 2);
            blackDashPen.DashStyle = DashStyle.Dash;

            limeDashPen = new Pen(Color.Lime, 2);
            limeDashPen.DashStyle = DashStyle.Dash;

            redDashPen = new Pen(Color.Red, 2);
            redDashPen.DashStyle = DashStyle.Dash;

            arrowPen = new Pen(Color.Black, 2);
            AdjustableArrowCap arrow = new AdjustableArrowCap(8, 8);
            arrowPen.CustomEndCap = arrow;

        }

        // My helper function that moves a given point and returns it
        // Point.Offset doest not return the object and cannot be used with properties
        public static Point Move(this Point p, int dx, int dy)
        {
            return new Point(p.X + dx, p.Y + dy);
        }

    }
}
