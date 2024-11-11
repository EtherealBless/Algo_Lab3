using System;
using System.Collections.Generic;
using static Lab3.LabCollections.YunPart.CommandExecutor;

namespace Lab3.LabCollections.YunPart
{
    public class QueueListLogic
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
                { 1, (args) => { Console.WriteLine("Executing \"1\" - Вставка(\"" + args[0] + "\")"); qList.Enqueue(args[0]); } },
                { 2, (args) => { Console.WriteLine("Executing \"2\" - Удаление()"); qList.Dequeue(); } },
                { 3, (args) => { Console.WriteLine("Executing \"3\" - Просмотр начала очереди()"); qList.First(); } },
                { 4, (args) => { Console.WriteLine("Executing \"4\" - Проверка на пустоту()"); qList.IsEmpty(); } },
                { 5, (args) => { Console.WriteLine("Executing \"5\" - Печать():"); Console.WriteLine(" "); qList.Print();  } },
            };
            commandExecutor = new CommandExecutor(commands);
        }

        public void ExecuteCommands(string input)
        {
            commandExecutor.ExecuteCommands(input);
        }
    }
}
