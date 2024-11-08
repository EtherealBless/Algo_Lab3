using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Menus
{
    internal class Menu : IMenu
    {


        Dictionary<int, Action> IMenu.Commands { get; set; } = new()
        {
            {1, () => Console.WriteLine("Hello, world!") },
        };

        void IMenu.PrintMenu()
        {
            Console.WriteLine("1. Hello, world!");
            Console.WriteLine("0. Exit");
        }
    }
}
