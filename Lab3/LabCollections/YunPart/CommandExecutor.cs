using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3.LabCollections.YunPart
{
    public class CommandExecutor
    {
        public delegate void Command(params object[] args);

        private Dictionary<int, Command> Commands;

        public CommandExecutor(Dictionary<int, Command> commands)
        {
            Commands = commands;
        }

        public void ExecuteCommands(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Invalid input");
                return;
            }
            List<string> tokens = input.Split().ToList();
            foreach (string token in tokens)
            {
                string[] args = token.Split(',');
                int code = int.Parse(args[0]);
                if (!Commands.ContainsKey(code))
                    Console.WriteLine("Invalid command");

                if (token[0] == '1')
                    Commands[code](args.Skip(1).ToArray());
                else
                    Commands[code]();
            }
        }
    }
}
