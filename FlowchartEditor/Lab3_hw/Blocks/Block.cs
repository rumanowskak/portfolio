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


    public abstract class Block
    {
        //protected static Pen blackPen = new Pen(Color.Black, 3);
        //protected static Pen greenPen = new Pen(Color.Green, 3);
        //protected static Pen redPen = new Pen(Color.Red, 3);
        protected static Font font = new Font("Arial", 6);

        // For serialisation purposes
        public int Id { get; set; }
        public static int maxId = 0;

        public Point Position { get; private set; }
        public Size Size { get; private set; }
        public static Size commonSize = new Size(120, 80);
        public bool EditModeEnabled { get; set; }
        public string Text { get; set; }

        public ConnectionPoint[] connectionPoints { get; set; }

        public Block(Point mouseLocation, Size size, Size pictureBoxSize)
        {
            Id = maxId++;

            Position = mouseLocation;
            Position = Position.Move(-size.Width / 2, -size.Height / 2);

            Position = new Point(Math.Max(Math.Min(pictureBoxSize.Width - size.Width, Position.X), 0),
                                Math.Max(Math.Min(pictureBoxSize.Height - size.Height, Position.Y), 0));


            
            this.Size = size;
            EditModeEnabled = false;
        }

        public void Move(int dX, int dY, Size pictureBoxSize)
        {
            if (Position.X + dX < 0 || Position.X + Size.Width + dX >= pictureBoxSize.Width)
                dX = 0;
            if (Position.Y + dY < 0 || Position.Y + Size.Height + dY >= pictureBoxSize.Height)
                dY = 0;
           

            Position = Position.Move(dX, dY);
        }

        public abstract void Draw(Graphics g);

        protected void DrawCommon(Graphics g)
        {
            DrawText(g);
            foreach (ConnectionPoint cp in connectionPoints)
                cp.Draw(g);
        }

        public void DrawConnections(Graphics g)
        {
            foreach (ConnectionPoint cp in connectionPoints)
            {
                if (cp.InUse && cp.EndPoint == EndPoint.Out)
                    cp.Connection.Draw(g);
            }
        }

        protected virtual void DrawText(Graphics g)
        {
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            Rectangle rc = new Rectangle(Position.X, Position.Y, Size.Width, Size.Height);
            g.DrawString(Text, font, Brushes.Black, rc, stringFormat);
        }

        public bool PointInBlock(Point point)
        {
            if (point.Y < Position.Y || point.X < Position.X)
                return false;
            if (point.Y > Position.Y + Size.Height || point.X > Position.X + Size.Width)
                return false;
            return true;
        }

        public ConnectionPoint GetConnectionAtPosition(Point position)
        {
            Point relativePosition = new Point(position.X - this.Position.X, position.Y - this.Position.Y);
            foreach (ConnectionPoint cp in connectionPoints)
            {
                // Rectangle around connection point instead of a circle
                if (Math.Abs(relativePosition.Y - cp.RelativePosition.Y) < ConnectionPoint.RADIUS &&
                    Math.Abs(relativePosition.X - cp.RelativePosition.X) < ConnectionPoint.RADIUS)
                    return cp;
            }
            return null;
        }

        public double GetSquareDistanceToPosition(Point position)
        {
            // Return square because it's only used to determine which one is the cloest one
            // And Sqaure Root is an expensive operation

            // This returns the distance to the **CENTER** of the block, not top-left corner

            return Math.Pow((Position.X + Size.Width / 2) - position.X, 2) + Math.Pow((Position.Y + Size.Height / 2) - position.Y, 2);
        }

        public static Block GetBlockOfType(BlockType type, Point mouseLocation, Size pictureBoxSize)
        {
            switch (type)
            {
                case BlockType.StartBlock:
                    return new Start_block(mouseLocation, commonSize, pictureBoxSize);
                case BlockType.EndBlock:
                    return new End_block(mouseLocation, commonSize, pictureBoxSize);
                case BlockType.DecisionBlock:
                    return new Decision_block(mouseLocation, commonSize, pictureBoxSize);
                case BlockType.OperationBlock:
                    return new Operation_block(mouseLocation, commonSize, pictureBoxSize);
            }
            return null;
        }

        public static Block GetBlockFromData(BlockData bd)
        {
            // Huge size because the blocks are well placed
            Block newBlock = GetBlockOfType(bd.Type, Point.Empty, new Size(int.MaxValue, int.MaxValue));

            newBlock.Id = bd.Id; maxId--; // ID was predefined and so maxID should not be affected
            newBlock.Position = bd.Position;
            newBlock.Size = bd.Size;
            newBlock.Text = bd.Text;
            newBlock.EditModeEnabled = bd.EditModeEnabled;

            return newBlock;
        }

        public abstract BlockType GetBlockType();

    }
}
