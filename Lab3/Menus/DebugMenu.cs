using Lab3.LabCollections.YunPart;
using Lab3.LabCollections;
using System;
using System.Collections.Generic;

namespace Lab3.Menus
{
    internal class DebugMenu : IMenu
    {
        public Dictionary<int, Action> Commands { get; set; } = [];


        public DebugMenu()
        {
            Commands = new Dictionary<int, Action>()
            {
                {1, (args) => TestLinkedListMenu.TestLinkedList()},
                {2, (args) => new FileReader(1)},
                {3, (args) => new FileReader(2)},
                {4, (args) => new FileReader(3)},
                {5, (args) => PostfixFileReader.ReadAndCalculate()},
                {6, (args) => LabCollections.YunPart.TREE_STACK_AND_OTHER.TopologicalSort.TopologicalSortExample.Run()},
                {7, (args) => LabCollections.YunPart.TREE_STACK_AND_OTHER.LRUCache.LRUCacheExample.Run()},
                {8, (args) => LabCollections.YunPart.TREE_STACK_AND_OTHER.RequestQueue.RequestQueueExample.Run()},
                {9, (args) => LabCollections.YunPart.TREE_STACK_AND_OTHER.SuffixTree.SuffixTreeExample.Run()},
                {10, (args) => TreeMenu.TestTree()},
            };
        }
        public void PrintMenu()
        {
            Console.WriteLine(" ");
            Console.WriteLine("1. Test LinkedList");
            Console.WriteLine("2. Read File STACK: \"input.txt\"");
            Console.WriteLine("3. Read File QUEUE: \"input.txt\"");
            Console.WriteLine("4. Read File OUR-QUEUE: \"input.txt\"");
            Console.WriteLine("5. Read and Calculate Postfix Expression from File");
            Console.WriteLine("6. Topological Sort Example");
            Console.WriteLine("7. LRU Cache Example");
            Console.WriteLine("8. Request Queue Example");
            Console.WriteLine("9. Suffix Tree Example");
            Console.WriteLine("10. Tree build and traversal");
            Console.WriteLine(" ");
            Console.WriteLine("0. Exit");
            Console.WriteLine(" ");
        }
    }
}
