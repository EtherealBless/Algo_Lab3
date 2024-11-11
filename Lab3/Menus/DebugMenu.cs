using Lab3.LabCollections.YunPart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Menus
{
    internal class DebugMenu : IMenu
    {

        Dictionary<int, Action> IMenu.Commands { get; set; } = new Dictionary<int, Action>()
        {
            {1, TestLinkedListMenu.TestLinkedList },
            {2, () => new FileReader(1)},
            {3, () => new FileReader(2)},
            {4, () => new FileReader(3)},
        };

        void IMenu.PrintMenu()
        {
            Console.WriteLine(" ");
            Console.WriteLine("1. Test LinkedList");
            Console.WriteLine("2. Read File STACK: \"input.txt\"");
            Console.WriteLine("3. Read File QUEUE: \"input.txt\"");
            Console.WriteLine("4. Read File OUR-QUEUE: \"input.txt\"");
            Console.WriteLine(" ");
            Console.WriteLine("0. Exit");
            Console.WriteLine(" ");
        }
    }
}
