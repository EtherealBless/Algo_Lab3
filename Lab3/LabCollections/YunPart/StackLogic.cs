using System;
using System.Collections.Generic;
using static Lab3.LabCollections.YunPart.CommandExecutor;

namespace Lab3.LabCollections.YunPart
{
    public class StackLogic
    {
        private Stack<object> list = new Stack<object>();
        private CommandExecutor commandExecutor;
 

        public StackLogic()
        {
            InitializeCommands();
        }

        public void InitializeCommands()
        {
            var commands = new Dictionary<int, CommandExecutor.Command>()
            {
                { 1, (args) => { Console.WriteLine("Executing \"1\" - Push(\"" + args[0] + "\")"); list.Push(args[0]); } },
                { 2, (args) => { Console.WriteLine("Executing \"2\" - Pop()"); list.Pop(); } },
                { 3, (args) => { Console.WriteLine("Executing \"3\" - Top()"); list.Top(); } },
                { 4, (args) => { Console.WriteLine("Executing \"4\" - isEmpty()"); list.IsEmpty(); } },
                { 5, (args) => { Console.WriteLine("Executing \"5\" - Print():"); Console.WriteLine(" "); list.Print();  } },
            };
            commandExecutor = new CommandExecutor(commands);

        }

        public void ExecuteCommands(string input)
        {
            commandExecutor.ExecuteCommands(input);
        }
    }
}
