using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.LabCollections.YunPart;

namespace Lab3.Menus
{
    internal class Menu : IMenu
    {


        Dictionary<int, Action> IMenu.Commands { get; set; } = new()
        {
            {1, () => Console.WriteLine("Hello, world!") },
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
