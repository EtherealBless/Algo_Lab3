using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Menus;
namespace Lab3.LabCollections.YunPart
{
    using Lab3.Menus;
    using System.Threading.Channels;

    class FileReaderOLD 
    {
        // МНЕ ПРИШЛОСЬ СКОПИПАСТИТЬ ВЕСЬ ТВОЙ КОД ИЗ TestLinkedListMenu
        // ПОТОМУ ЧТО Я НЕ СМОГ ПОДЦЕПИТЬСЯ
        // #@ С уважением, Мисье Говнокод.

        private Stack<object> list = new Stack<object>();

        private QueueList<object> qList = new QueueList<object>();

        private QueueQueue<object> queue = new QueueQueue<object>();

        delegate void Command(params object[] args);

        private Dictionary<int, Command> Commands;

        

        

        public FileReaderOLD(int numOfQueue) 
        {
            Console.WriteLine(" ");
            string[] lines = File.ReadAllLines("input.txt");
            if (numOfQueue == 1)
                InitializeCommandsSTACK();
            else if (numOfQueue == 2)
                InitializeCommandsQueueList();
            else if (numOfQueue == 3)
                InitializeCommandsQueueQueue();


            foreach (string line in lines)
            {
                RunMenuLogic(line);
            }

        }



        public void InitializeCommandsSTACK()
        {
            Commands = new Dictionary<int, Command>()
            {
                { 1, (args) => { Console.WriteLine("Executing \"1\" - Push(\"" + args[0] + "\")"); list.Push(args[0]); } },
                { 2, (args) => { Console.WriteLine("Executing \"2\" - Pop()"); list.Pop(); } },
                { 3, (args) => { Console.WriteLine("Executing \"3\" - Top()"); list.Top(); } },
                { 4, (args) => { Console.WriteLine("Executing \"4\" - isEmpty()"); list.IsEmpty(); } },
               // { 5, (args) => { Console.WriteLine("Executing \"5\" - Print():"); Console.WriteLine(" "); list.Print();  } },
            };
        }

        public void InitializeCommandsQueueList()
        {
            Commands = new Dictionary<int, Command>()
            {
                { 1, (args) => { Console.WriteLine("Executing \"1\" - Вставка(\"" + args[0] + "\")"); qList.Enqueue(args[0]); } },
                { 2, (args) => { Console.WriteLine("Executing \"2\" - Удаление()"); qList.Dequeue(); } },
                { 3, (args) => { Console.WriteLine("Executing \"3\" - Просмотр начала очереди()"); qList.First(); } },
                { 4, (args) => { Console.WriteLine("Executing \"4\" - Проверка на пустоту()"); qList.IsEmpty(); } },
               // { 5, (args) => { Console.WriteLine("Executing \"5\" - Печать():"); Console.WriteLine(" "); qList.Print();  } },
            };
        }

        public void InitializeCommandsQueueQueue()
        {
            Commands = new Dictionary<int, Command>()
            {
                { 1, (args) => { Console.WriteLine("Executing \"1\" - Вставка228(\"" + args[0] + "\")"); queue.Enqueue(args[0]); } },
                { 2, (args) => { Console.WriteLine("Executing \"2\" - Удаление()"); queue.Dequeue(); } },
                { 3, (args) => { Console.WriteLine("Executing \"3\" - Просмотр начала очереди()"); queue.First(); } },
                { 4, (args) => { Console.WriteLine("Executing \"4\" - Проверка на пустоту()"); queue.IsEmpty(); } },
                { 5, (args) => { Console.WriteLine("Executing \"5\" - Печать():"); Console.WriteLine(" "); queue.Print();  } },
            };
        }
        //3 4 1,56 1,7 1,cat 2 5 4

        public void RunMenuLogic(string input)
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


        public void FileReaderTest(int numOfQueue)
        {
            FileReaderOLD test = new(numOfQueue);
            string[] lines = File.ReadAllLines("input.txt");

            foreach (string line in lines)
            {
                RunMenuLogic(line);
            }

        }
    }
}

    

