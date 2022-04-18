using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace Lab3_hw
{

        

    public class Blocks_handler
    {
        List<Block> Blocks { get; set;  }

        public bool HasStartBlock;

        private Block _activeBlock;
        public Block ActiveBlock
        {
            get
            {
                return _activeBlock;
            }
            set
            {
                if (_activeBlock != null)
                    _activeBlock.EditModeEnabled = false;
                if (value != null)
                    value.EditModeEnabled = true;
                _activeBlock = value;
            }
        }



        public Blocks_handler()
        {
            Blocks = new List<Block>();
            HasStartBlock = false;
        }

        public void AddBlock(Block blockToAdd)
        {
            Blocks.Add(blockToAdd);
            if (blockToAdd.GetBlockType() == BlockType.StartBlock)
                HasStartBlock = true;
        }

        public void RemoveBlock(Block blockToRemove)
        {
            foreach (ConnectionPoint cp in blockToRemove.connectionPoints)
                cp.Connection?.Disconnect(); // '.?' to invoke only if not null
            if (blockToRemove == ActiveBlock)
                ActiveBlock = null;
            if (blockToRemove.GetBlockType() == BlockType.StartBlock)
                HasStartBlock = false;
            Blocks.Remove(blockToRemove);
        }

        public void DrawBlocks(Graphics g)
        {
            foreach (Block b in Blocks)
            {
                b.Draw(g);
            }
            
            // Draw connections later so that ther are on top of the blocks
            foreach (Block b in Blocks)
            {
                b.DrawConnections(g);
            }

        }

        // Gets block from a given position
        // If multiple blocks cover the same position
        // The block returned is the oldest one
        // Returns null if no block found
        public Block GetBlockAtPosition(Point position)
        {
            // List of blocks at given position
            // if Count > 1 select the closest one
            List<Block> blocksAtPosition = new List<Block>();
            foreach (Block b in Blocks)
            {
                if (b.PointInBlock(position))
                    blocksAtPosition.Add(b);
            }
            if (blocksAtPosition.Count == 0)
                return null;
            if (blocksAtPosition.Count == 1)
                return blocksAtPosition.First();

            double minDistance = double.MaxValue;
            Block closestBlock = null;
            foreach (Block b in blocksAtPosition)
            {
                double distance = b.GetSquareDistanceToPosition(position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestBlock = b;
                }
            }
            return closestBlock;


        }

        public ConnectionPoint GetConnectionPointAtPosition(Point position)
        {
            foreach (Block b in Blocks)
            {
                ConnectionPoint cp = b.GetConnectionAtPosition(position);
                if (cp != null) 
                    return cp;
            }
            return null;
        }


        public List<BlockData> GetBlockData()
        {
            List<BlockData> blockData = new List<BlockData>();
            foreach (Block b in Blocks)
                blockData.Add(new BlockData(b));
            return blockData;
        }

        public bool TryLoadBlockData(List<BlockData> blockData)
        {
            try
            {
                // Convert blockData to blocks

                Dictionary<int, Block> blocksById = new Dictionary<int, Block>();
                foreach (BlockData bd in blockData)
                {
                    blocksById.Add(bd.Id, Block.GetBlockFromData(bd));
                    // Block.maxId = Math.Max(Block.maxId, bd.Id); // Do not do this now in case something goes wrong and we have to retore data
                }

                // Create Connections
                foreach (BlockData bd in blockData)
                {
                    int i = 0;
                    while (i < bd.Connections.Count)
                    {
                        int targetId = bd.Connections[i++];
                        int originConnectionPointIndex = bd.Connections[i++];
                        int targetConnectionPointIndex = bd.Connections[i++];

                        Connection.CreateConnection(blocksById[bd.Id].connectionPoints[originConnectionPointIndex],
                                        blocksById[targetId].connectionPoints[targetConnectionPointIndex]);
                    }
                }

                // If everything went right - update and show message box

                // Convert to list
                Blocks.Clear();
                Blocks = blocksById.Values.ToList();

                // Restore max id
                Block.maxId = 0;
                foreach (Block b in Blocks)
                    Block.maxId = Math.Max(Block.maxId, b.Id);
                Block.maxId++;


                // Restore active block
                ActiveBlock = null;
                foreach (Block b in Blocks)
                {
                    if (b.EditModeEnabled)
                    {
                        ActiveBlock = b;
                        break;
                    }
                }

                // Check if contains start block
                foreach (Block b in Blocks)
                {
                    if (b.GetBlockType() == BlockType.StartBlock)
                    {
                        HasStartBlock = true;
                        break;
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
