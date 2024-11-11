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
            { 1, TestLinkedListMenu.TestLinkedList },
            {2, () => new FileReader()},
            
        };

        void IMenu.PrintMenu()
        {
            Console.WriteLine(" ");
            Console.WriteLine("2. Read File: \"input.txt\"");
            Console.WriteLine("1. Test LinkedList");
            Console.WriteLine("0. Exit");
            Console.WriteLine(" ");
        }
    }
}
