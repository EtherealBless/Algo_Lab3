using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.LabCollections;
using Lab3.LabCollections.YunPart;

namespace Lab3.Menus
{
    internal class Menu : IMenu
    {


        public Dictionary<int, Action> Commands { get; set; } = [];

        public Menu()
        {
            Commands = new Dictionary<int, Action>()
            {
                {1, (args) => TestLinkedListMenu.TestLinkedList()},
                {2, (args) => new FileReader(1)},
                {3, (args) => new FileReader(2)},
                {4, (args) => new FileReader(3)},
            };
        }

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
