using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Menus;
using Lab3.LabCollections;

namespace Lab3.LabCollections.YunPart
{
    using Lab3.Menus;
    using System.Threading.Channels;

    class FileReaderQUEUE()
    {
        // МНЕ ПРИШЛОСЬ СКОПИПАСТИТЬ ВЕСЬ ТВОЙ КОД ИЗ TestLinkedListMenu
        // ПОТОМУ ЧТО Я НЕ СМОГ ПОДЦЕПИТЬСЯ
        // #@ С уважением, Мисье Говнокод.

        private QueueList<object> list = new QueueList<object>();

        private QueueQueue<object> queue = new QueueQueue<object>();

        delegate void Command(params object[] args);

        private Dictionary<int, Command> Commands;

        

        public FileReaderQUEUE(int numOfQueue) : this()
        {
            Console.WriteLine(" ");
            string[] lines = File.ReadAllLines("input.txt");
            if (numOfQueue == 1)
                InitializeCommandsList();
            else if (numOfQueue == 2)
                InitializeCommandsQueue();
            

            foreach (string line in lines)
            {
                RunMenuLogic(line);
            }

        }

        internal object? Push(object obj)
        {
            list.Enqueue(obj);
            return null;
        }


        public void InitializeCommandsList()
        {
            Commands = new Dictionary<int, Command>()
            {
                { 1, (args) => { Console.WriteLine("Executing \"1\" - Вставка(\"" + args[0] + "\")"); list.Enqueue(args[0]); } },
                { 2, (args) => { Console.WriteLine("Executing \"2\" - Удаление()"); list.Dequeue(); } },
                { 3, (args) => { Console.WriteLine("Executing \"3\" - Просмотр начала очереди()"); list.First(); } },
                { 4, (args) => { Console.WriteLine("Executing \"4\" - Проверка на пустоту()"); list.IsEmpty(); } },
                { 5, (args) => { Console.WriteLine("Executing \"5\" - Печать():"); Console.WriteLine(" "); list.Print();  } },
            };
        }

        public void InitializeCommandsQueue()
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


        public void FileReaderTest()
        {
            FileReaderSTACK test = new FileReaderSTACK();
            string[] lines = File.ReadAllLines("input.txt");

            foreach (string line in lines)
            {
                RunMenuLogic(line);
            }

        }
     }
}

    

