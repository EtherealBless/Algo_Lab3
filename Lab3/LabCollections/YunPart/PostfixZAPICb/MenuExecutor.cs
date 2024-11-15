using System;
using System.Collections.Generic;

namespace Lab3.Menus
{
    internal static class MenuExecutor
    {
        public static void ExecuteMenu(IMenu menu)
        {
            while (true)
            {
                menu.PrintMenu();
                Console.Write("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice == 0)
                    {
                        break;
                    }
                    else if (menu.Commands.ContainsKey(choice))
                    {
                        menu.Commands[choice]();
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
    }
}
