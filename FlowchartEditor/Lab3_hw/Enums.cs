using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_hw
{
    public enum BlockType { StartBlock, EndBlock, OperationBlock, DecisionBlock };

    public enum ActionType { None, PlaceBlock, RemoveBlock, ConnectBlocks};

    public enum EndPoint { Out, In };
}
