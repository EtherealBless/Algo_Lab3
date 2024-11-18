using System;
using System.Collections.Generic;

namespace Lab3.LabCollections.YunPart.TREE_STACK_AND_OTHER.SuffixTree
{
    public class SuffixTreeNode
    {
        public Dictionary<char, SuffixTreeNode> Children { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public SuffixTreeNode SuffixLink { get; set; }

        public SuffixTreeNode(int start, int end)
        {
            Start = start;
            End = end;
            Children = new Dictionary<char, SuffixTreeNode>();
        }
    }
}
