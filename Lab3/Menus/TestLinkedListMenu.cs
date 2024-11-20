using System.Text;
using System.Threading.Tasks;

namespace Lab3.Menus
{
    using System;
    using Lab3.LabCollections;

    internal class TestLinkedListMenu : IMenu
    {
        private LinkedList<object> list = new LinkedList<object>();

        delegate void Command(params object[] args);

        // 1 - Push(elem), 2 - Pop(), 3 - Top(), 4 - isEmpty(), 5 - Print()
        // 6 - Reverse(), 7 - SwapFirstAndLast(), 8 - CountUniqueInts()
        // 9 - RemoveAllOccurrences(value), 10 - InsertSelfAfter(value)
        // 11 - InsertInSortedOrder(value), 12 - InsertBeforeFirstOccurrence(valueToInsert,valueToFind)
        // 13 - RemoveDuplicates(), 14 - Join(values), 15 - Split(splitFactor)
        // 16 - Double(), 17 - Swap(firstIndex,secondIndex)
        public Dictionary<int, Action> Commands { get; set; } = new();

        internal object? Push(object obj)
        {
            list.Push(obj);
            return null;
        }


        private TestLinkedListMenu()
        {
            Commands = new()
            {
                { 1, (args) => list.Push(args[0]) },
                { 2, (args) => list.PopBack() },
                { 3, (args) => list.Last() },
                { 4, (args) => Console.WriteLine(list.IsEmpty()) },
                { 5, (args) => Console.WriteLine(list.Print()) },
                { 6, (args) => list.Reverse() },
                { 7, (args) => list.SwapFirstAndLast() },
                { 8, (args) => {
                    int count = list.CountUniqueInts();
                    Console.WriteLine(count);
                }},
                { 9, (args) => list.RemoveAllOccurrences(args[0]) },
                { 10, (args) => list.InsertSelfAfter(args[0]) },
                { 11, (args) => list.InsertInSortedOrder(args[0]) },
                { 12, (args) => list.InsertBeforeFirstOccurrence(args[0], args[1]) },
                { 13, (args) => list.RemoveDuplicates() },
                { 14, (args) => list.Join(args) },
                { 15, (args) => {
                    var (list1, list2) = list.Split(args[0]);
                    Console.WriteLine("First list:");
                    list1.Print();
                    Console.WriteLine("Second list:");
                    list2.Print();
                }},
                { 16, (args) => list.Double() },
                { 17, (args) => list.Swap(int.Parse((string)args[0]), int.Parse((string)args[1])) },
                { 18, (args) => list = new LinkedList<object>() },
            };
        }

        public void PrintMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("1 - Push(elem), 2 - Pop(), 3 - Top(), 4 - isEmpty(), 5 - Print()\n");
            sb.Append("6 - Reverse(), 7 - SwapFirstAndLast(), 8 - CountUniqueInts()\n");
            sb.Append("9 - RemoveAllOccurrences(value), 10 - InsertSelfAfter(value)\n");
            sb.Append("11 - InsertInSortedOrder(value), 12 - InsertBeforeFirstOccurrence(valueToInsert,valueToFind)\n");
            sb.Append("13 - RemoveDuplicates(), 14 - Join(values), 15 - Split(splitFactor)\n");
            sb.Append("16 - Double(), 17 - Swap(firstIndex,secondIndex), 18 - Clear()\n");
            sb.Append("0 - Exit\n");
            Console.WriteLine(sb.ToString());
        }

        //3 4 1,56 1,7 1,cat 2 5 4
        private void RunMenu()
        {
            while (true)
            {
                IMenu menu = this;
                menu.PrintMenu();
                string? input = Console.ReadLine();
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
                    if (code == 0)
                    {
                        return;
                    }
                    if (!Commands.ContainsKey(code))
                    {
                        Console.WriteLine("Invalid command");
                        continue;
                    }
                    if (code == 14)
                    {
                        Commands[code](args.Skip(1).ToArray());
                        continue;
                    }
                    switch (args.Length - 1)
                    {
                        case 0:
                            if (code == 1 || code == 9 || code == 10 || code == 11 || code == 12 || code == 14 || code == 17)
                                Console.WriteLine("Invalid command");
                            else
                                Commands[code]();
                            break;
                        case 1:
                            if (code == 1 || code == 9 || code == 10 || code == 11 || code == 13 || code == 15 || code == 16)
                                Commands[code](args[1]);
                            else
                                Console.WriteLine("Invalid command");
                            break;
                        case 2:
                            if (code == 12 || code == 17)
                                Commands[code](args[1], args[2]);
                            else
                                Console.WriteLine("Invalid command");
                            break;
                    }
                }
            }
        }

        public static void TestLinkedList()
        {
            TestLinkedListMenu test = new();
            test.RunMenu();
        }
    }
}
