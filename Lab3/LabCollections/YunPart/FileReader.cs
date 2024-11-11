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

    class FileReader 
    {
        // МНЕ ПРИШЛОСЬ СКОПИПАСТИТЬ ВЕСЬ ТВОЙ КОД ИЗ TestLinkedListMenu
        // ПОТОМУ ЧТО Я НЕ СМОГ ПОДЦЕПИТЬСЯ
        // #@ С уважением, Мисье Говнокод.

        private LinkedList<object> list = new LinkedList<object>();

        delegate void Command(params object[] args);

        private Dictionary<int, Command> Commands;

        

        public FileReader()
        {
            Console.WriteLine(" ");

            InitializeCommands();

            string[] lines = File.ReadAllLines("input.txt");

            foreach (string line in lines)
            {
                RunMenuLogic(line);
            }

        }

        internal object? Push(object obj)
        {
            list.Push(obj);
            return null;
        }


        public void InitializeCommands()
        {
            Commands = new Dictionary<int, Command>()
            {
                { 1, (args) => { Console.WriteLine("Executing \"1\" - Push(\"" + args[0] + "\")"); list.Push(args[0]); } },
                { 2, (args) => { Console.WriteLine("Executing \"2\" - Pop()"); list.PopBack(); } },
                { 3, (args) => { Console.WriteLine("Executing \"3\" - Top()"); list.Last(); } },
                { 4, (args) => { Console.WriteLine("Executing \"4\" - isEmpty()"); list.IsEmpty(); } },
                { 5, (args) => { Console.WriteLine("Executing \"5\" - Print():"); Console.WriteLine(" "); list.Print();  } },
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
            FileReader test = new FileReader();
            string[] lines = File.ReadAllLines("input.txt");

            foreach (string line in lines)
            {
                RunMenuLogic(line);
            }

        }
     }
}

    

