using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_hw
{
    public class SchemaData
    {
        public Size Size { get; set; }
        public List<BlockData> BlockData { get; set; }

        public SchemaData()
        {
            Size = new Size(0, 0);
            BlockData = new List<BlockData>();
        }

        public SchemaData(Size size, List<BlockData> blockData)
        {
            Size = size;
            BlockData = blockData;
        }
    }
}
