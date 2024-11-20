
using System.ComponentModel.Design;
using System.Text;
using Lab3.LabCollections;

namespace Lab3.Menus
{
    public class TreeMenu : IMenu
    {
        public Dictionary<int, Action> Commands { get; set; }

        readonly BinaryTree tree = new();

        private BinaryTreeNode<char> treeRoot;

        public TreeMenu()
        {
            Commands = new() {
                { 1, (args) => treeRoot = tree.BuildTree((string)args[0]) },
                { 2, (args) => BinaryTree.BFS(treeRoot)},
                { 3, (args) => BinaryTree.DFS(treeRoot)},
                { 4, (args) => BinaryTree.PrintTree(treeRoot)},
            };
        }



        public void RunMenu()
        {
            while (true)
            {
                PrintMenu();
                var args = Console.ReadLine().Split(',');
                if (!int.TryParse(args[0], out int code))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                if (code == 0)
                    break;

                switch (args.Length - 1)
                {
                    case 0:
                        if (code == 1)
                        {
                            args = [.. args, "ABD*G***CE**FH**J**"];
                            Commands[code](args[1]);
                        }
                        else
                            Commands[code]();
                        break;
                    case 1:
                        if (code != 1)
                            Console.WriteLine("Invalid input");
                        else
                            Commands[code](args[1]);
                        break;
                }
            }
        }

        public void PrintMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("1 - Build Tree\n");
            sb.Append("2 - BFS\n");
            sb.Append("3 - DFS\n");
            sb.Append("4 - Print tree\n");
            sb.Append("0 - Exit\n");
            Console.WriteLine(sb.ToString());
        }

        public static void TestTree()
        {
            var treeMenu = new TreeMenu();
            treeMenu.RunMenu();
        }
    }
}