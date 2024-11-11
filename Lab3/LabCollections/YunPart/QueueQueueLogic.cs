using System;
using System.Collections.Generic;

namespace Lab3.LabCollections.YunPart
{
    public class QueueQueueLogic
    {
        private QueueQueue<object> queue = new QueueQueue<object>();
        private CommandExecutor commandExecutor;

        public QueueQueueLogic()
        {
            InitializeCommands();
        }

        public void InitializeCommands()
        {
            var commands = new Dictionary<int, CommandExecutor.Command>()
            {
                { 1, (args) => { Console.WriteLine("Executing \"1\" - Вставка228(\"" + args[0] + "\")"); queue.Enqueue(args[0]); } },
                { 2, (args) => { Console.WriteLine("Executing \"2\" - Удаление()"); queue.Dequeue(); } },
                { 3, (args) => { Console.WriteLine("Executing \"3\" - Просмотр начала очереди()"); queue.First(); } },
                { 4, (args) => { Console.WriteLine("Executing \"4\" - Проверка на пустоту()"); queue.IsEmpty(); } },
                { 5, (args) => { Console.WriteLine("Executing \"5\" - Печать():"); Console.WriteLine(" "); queue.Print();  } },
            };
            commandExecutor = new CommandExecutor(commands);
        }

        public void ExecuteCommands(string input)
        {
            commandExecutor.ExecuteCommands(input);
        }
    }
}
