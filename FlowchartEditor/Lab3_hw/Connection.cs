using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_hw
{
    public class Connection
    {

        public ConnectionPoint From { get; set; }
        public ConnectionPoint To { get; set; }

        private Connection(ConnectionPoint from, ConnectionPoint to)
        {
            From = from;
            To = to;
            From.Connection = this;
            To.Connection = this;
        }

        public static Connection CreateConnection(ConnectionPoint from, ConnectionPoint to)
        {
            if (from.owner == to.owner)
                return null;
            return new Connection(from, to);
        }

        public void Disconnect()
        {
            From.Connection = null;
            To.Connection = null;
        }

        public void Draw(Graphics g)
        {
            g.DrawLine(Toolbox.arrowPen,
                From.RelativePosition.X + From.owner.Position.X,
                From.RelativePosition.Y + From.owner.Position.Y,
                To.RelativePosition.X + To.owner.Position.X,
                To.RelativePosition.Y + To.owner.Position.Y
            );
        }

        public (int, int) GetConnectionPointsIndices()
        {
            int p, q;
            for (p = 0; p < From.owner.connectionPoints.Length; p++)
                if (From.owner.connectionPoints[p].Connection == this) break;
            for (q = 0; q < To.owner.connectionPoints.Length; q++)
                if (To.owner.connectionPoints[q].Connection == this) break;
            return (p, q);
        }

    }

    public class ConnectionPoint
    {
        public static int RADIUS = 5;

        public EndPoint EndPoint { get; set; }
        public bool InUse { get; set; }
        public Point RelativePosition { get; set; }

        public Block owner;

        private Connection _connection;
        public Connection Connection
        {
            get { return _connection; }
            set
            {
                InUse = value != null;
                _connection = value;
            }
        }

        public ConnectionPoint(EndPoint endPoint, Point relativePosition, Block owner)
        {
            this.EndPoint = endPoint;
            InUse = false;
            this.RelativePosition = relativePosition;
            this.owner = owner;
            Connection = null;
        }

        public void Draw(Graphics g)
        {
            if (Connection != null)
                return;

            // Draw point only if not connected
            Rectangle rc = new Rectangle(
                owner.Position.X + RelativePosition.X - RADIUS,
                owner.Position.Y + RelativePosition.Y - RADIUS,
                2 * RADIUS, 2 * RADIUS
            );
            Brush brush = EndPoint == EndPoint.Out ? Brushes.Black : Brushes.White;
            g.FillEllipse(brush, rc);
            g.DrawEllipse(Toolbox.blackPen, rc);

        }

    }
}
