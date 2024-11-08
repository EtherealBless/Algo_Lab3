﻿using System;
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
        };

        void IMenu.PrintMenu()
        {
            Console.WriteLine("1. Test LinkedList");
            Console.WriteLine("0. Exit");
        }
    }
}
