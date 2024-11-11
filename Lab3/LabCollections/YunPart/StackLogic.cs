using System;
using System.Collections.Generic;

namespace Lab3.LabCollections.YunPart
{
    public class StackLogic : IExecuterLogic
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
                { 1, (args) => { Console.Write("Executing \"1\" - Push(\"" + args[0] + "\") -> "); list.Push(args[0]); Console.WriteLine(args[0] + " pushed to stack."); } },
                { 2, (args) => { Console.Write("Executing \"2\" - Pop() -> "); var popped = list.Pop(); Console.WriteLine(popped + " popped from stack."); } },
                { 3, (args) => { Console.Write("Executing \"3\" - Top() -> "); var top = list.Top(); Console.WriteLine("Top element is " + top); } },
                { 4, (args) => { Console.Write("Executing \"4\" - isEmpty() -> "); var isEmpty = list.IsEmpty(); Console.WriteLine("Stack is " + (isEmpty ? "empty" : "not empty")); } },
                { 5, (args) => { Console.Write("Executing \"5\" - Print() -> "); Console.WriteLine("Result:"); list.Print(); } },
            };
            commandExecutor = new CommandExecutor(commands);
        }

        public void ExecuteCommands(string input)
        {
            commandExecutor.ExecuteCommands(input);
        }
    }
}
