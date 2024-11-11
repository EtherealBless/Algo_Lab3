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
            {2, () => new FileReader()}
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
