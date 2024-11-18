using Lab3.LabCollections.YunPart;
using Lab3.LabCollections;
using System;
using System.Collections.Generic;

namespace Lab3.Menus
{
    internal class DebugMenu : IMenu
    {
        public Dictionary<int, Action> Commands { get; set; } = new Dictionary<int, Action>()
        {
            {1, TestLinkedListMenu.TestLinkedList },
            {2, () => new FileReader(1)},
            {3, () => new FileReader(2)},
            {4, () => new FileReader(3)},
            {5, () => InputX.ExecuteTask5()},
            {6, () => InputE.ExecuteTask6()},
            {7, () => InputE7.ExecuteTask7()},
            {8, () => InputF.ExecuteTask8()},
            {10, () => PostfixFileReader.ReadAndCalculate()},
            {11, () => Lab3.LabCollections.YunPart.TREE_STACK_AND_OTHER.TopologicalSort.TopologicalSortExample.Run()},
            {12, () => Lab3.LabCollections.YunPart.TREE_STACK_AND_OTHER.LRUCache.LRUCacheExample.Run()},
            {13, () => Lab3.LabCollections.YunPart.TREE_STACK_AND_OTHER.RequestQueue.RequestQueueExample.Run()},
            {14, () => Lab3.LabCollections.YunPart.TREE_STACK_AND_OTHER.SuffixTree.SuffixTreeExample.Run()}
        };

        public void PrintMenu()
        {
            Console.WriteLine(" ");
            Console.WriteLine("1. Test LinkedList");
            Console.WriteLine("2. Read File STACK: \"input.txt\"");
            Console.WriteLine("3. Read File QUEUE: \"input.txt\"");
            Console.WriteLine("4. Read File OUR-QUEUE: \"input.txt\"");
            Console.WriteLine("5. Task 5 - Insert list after first X.");
            Console.WriteLine("6. Task 6 - Insert element, maintaining order.");
            Console.WriteLine("7. Task 7 - Remove all elements E.");
            Console.WriteLine("8. Task 8 - Insert F before first E.");
            Console.WriteLine("10. Read and Calculate Postfix Expression from File");
            Console.WriteLine("11. Topological Sort Example");
            Console.WriteLine("12. LRU Cache Example");
            Console.WriteLine("13. Request Queue Example");
            Console.WriteLine("14. Suffix Tree Example");
            Console.WriteLine(" ");
            Console.WriteLine("0. Exit");
            Console.WriteLine(" ");
        }
    }
}
