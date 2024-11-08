using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Menus
{
    internal interface IMenu
    {
        protected Dictionary<int, Action> Commands { get; set; }

        protected virtual void PrintMenu()
        {
            foreach (var command in Commands)
                Console.WriteLine($"{command.Key}. {command.Value.Method.Name}");

            Console.WriteLine("0. Exit");
        }

        protected virtual int ProcessInput()
        {
            bool result = int.TryParse(Console.ReadLine(), out int code);
            if (!result)
            {
                Console.WriteLine("Invalid input");
                return -1;
            }

            if (!Commands.ContainsKey(code))
            {
                Console.WriteLine("Invalid command");
                return -1;
            }

            Commands[code]();
            return code;
        }

        public virtual void RunMenu()
        {
            while (true)
            {
                try
                {
                    PrintMenu();
                    int code = ProcessInput();

                    if (code == 0)
                        break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }
    }
}
