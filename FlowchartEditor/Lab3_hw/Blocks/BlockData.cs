using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_hw
{
    // Used for serialisation
    public class BlockData
    {
        public int Id { get; set; }
        public Point Position { get; set; }
        public Size Size { get; set; }
        public string Text { get; set; }
        public List<int> Connections { get; set; }
        public BlockType Type { get; set; }

        public bool EditModeEnabled { get; set; }

        public BlockData()
        {
            Id = -1;
            Position = Point.Empty;
            Size = Size.Empty;
            Text = string.Empty;
            Connections = null;
            Type = BlockType.StartBlock;
            EditModeEnabled = false;
        }

        public BlockData(Block block)
        {
            Id = block.Id;
            Position = block.Position;
            Size = block.Size;
            Text = block.Text;
            Type = block.GetBlockType();
            EditModeEnabled = block.EditModeEnabled;

            Connections = new List<int>();
            for (int i = 0; i < block.connectionPoints.Length; i++)
            {
                ConnectionPoint cp = block.connectionPoints[i];
                if (cp.InUse && cp.EndPoint == EndPoint.Out)
                {
                    (int, int) endPointsIndieces = cp.Connection.GetConnectionPointsIndices();
                    Connections.Add(cp.Connection.To.owner.Id);
                    Connections.Add(endPointsIndieces.Item1);
                    Connections.Add(endPointsIndieces.Item2);
                }

            }

        }
    }
}
