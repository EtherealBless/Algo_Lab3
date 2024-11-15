using System;
using System.Collections.Generic;

namespace Lab3.LabCollections.YunPart
{
    public class QueueListLogic : IExecuterLogic
    {
        private QueueList<object> qList = new QueueList<object>();
        private CommandExecutor commandExecutor;

        public QueueListLogic()
        {
            InitializeCommands();
        }

        public void InitializeCommands()
        {
            var commands = new Dictionary<int, CommandExecutor.Command>()
            {
                { 1, (args) => { Console.Write("Executing \"1\" - Вставка(\"" + args[0] + "\") -> "); qList.Enqueue(args[0]); Console.WriteLine(args[0] + " inserted into queue."); } },
                { 2, (args) => { Console.Write("Executing \"2\" - Удаление() -> "); var dequeued = qList.Dequeue(); Console.WriteLine(dequeued + " removed from queue."); } },
                { 3, (args) => { Console.Write("Executing \"3\" - Просмотр начала очереди() -> "); var first = qList.First(); Console.WriteLine("First element is " + first); } },
                { 4, (args) => { Console.Write("Executing \"4\" - Проверка на пустоту() -> "); var isEmpty = qList.IsEmpty(); Console.WriteLine("Queue is " + (isEmpty ? "empty" : "not empty")); } },
                { 5, (args) => { Console.Write("Executing \"5\" - Печать() -> "); Console.WriteLine("Result:"); qList.Print(); } },
            };
            commandExecutor = new CommandExecutor(commands);
        }

        public void ExecuteCommands(string input)
        {
            commandExecutor.ExecuteCommands(input);
        }
    }
}
