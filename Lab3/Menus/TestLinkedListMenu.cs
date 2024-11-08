using System.Text;
using System.Threading.Tasks;

namespace Lab3.Menus
{
    using Lab3.LabCollections;

    internal class TestLinkedListMenu
    {
        private LinkedList<object> list = new LinkedList<object>();

        delegate void Command(params object[] args);

        // 1 - Push(elem), 2 - Pop(), 3 - Top(), 4 - isEmpty(), 5 - Print()
        private Dictionary<int, Command> Commands;

        internal object? Push(object obj)
        {
            list.Push(obj);
            return null;
        }


        private TestLinkedListMenu()
        {
            Commands = new Dictionary<int, Command>()
            {
                { 1, (args) => list.Push(args[0]) },
                { 2, (args) => list.Pop() },
                { 3, (args) => list.Top() },
                { 4, (args) => list.IsEmpty() },
                { 5, (args) => list.Print() },
            };
        }

        //3 4 1,56 1,7 1,cat 2 5 4
        private void RunMenu()
        {
            string input = Console.ReadLine();
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

        public static void TestLinkedList()
        {
            TestLinkedListMenu test = new TestLinkedListMenu();
            test.RunMenu();
        }
    }
}
