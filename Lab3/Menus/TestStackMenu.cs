
namespace Lab3.Menus
{
    using Lab3.LabCollections;

    internal class TestStackMenu
    {
        private Stack<object> stack = new Stack<object>();

        delegate void Command(params object[] args);

        // 1 - Push(elem), 2 - Pop(), 3 - Top(), 4 - isEmpty(), 5 - Print()
        private Dictionary<int, Command> Commands;

        internal object? Push(object obj)
        {
            stack.Push(obj);
            return null;
        }


        private TestStackMenu()
        {
            Commands = new Dictionary<int, Command>()
            {
                { 1, (args) => stack.Push(args[0]) },
                { 2, (args) => stack.Pop() },
                { 3, (args) => stack.Top() },
                { 4, (args) => stack.IsEmpty() },
                { 5, (args) => stack.Print() },
            };
        }

        //3 4 1,56 1,7 1,cat 2 5 4
        private void RunMenu()
        {
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
                if (!Commands.ContainsKey(code))
                    Console.WriteLine("Invalid command");

                if (token[0] == '1')
                    Commands[code](args.Skip(1).ToArray());
                else
                    Commands[code]();
            }

        }

        public static void TestStack()
        {
            TestStackMenu test = new TestStackMenu();
            test.RunMenu();
        }
    }
}
