namespace Lab3.LabCollections
{
    public class BinaryTree
    {
        private int index = 0; // To track position in the string

        // Build the tree from a preorder string
        public BinaryTreeNode<char>? BuildTree(string preorder)
        {
            if (index >= preorder.Length || preorder[index] == '*')
            {
                index++;
                return null;
            }

            var node = new BinaryTreeNode<char>(preorder[index]);
            index++;

            node.Left = BuildTree(preorder);
            node.Right = BuildTree(preorder);

            return node;
        }

        // BFS using a queue
        public static void BFS(BinaryTreeNode<char>? root)
        {
            if (root == null) return;

            var queue = new Queue<BinaryTreeNode<char>>();
            queue.Enqueue(root);

            Console.WriteLine("BFS Traversal:");
            while (queue.Count > 0)
            {
                BinaryTreeNode<char> current = queue.Dequeue();
                Console.Write(current.Data + " ");

                if (current.Left != null)
                    queue.Enqueue(current.Left);
                if (current.Right != null)
                    queue.Enqueue(current.Right);
            }
            Console.WriteLine();
        }

        public static void DFS(BinaryTreeNode<char>? root)
        {
            if (root == null) return;

            var stack = new Stack<BinaryTreeNode<char>>();
            stack.Push(root);

            Console.WriteLine("DFS Traversal:");
            while (!stack.IsEmpty())
            {
                BinaryTreeNode<char> current = stack.Pop();
                Console.Write(current.Data + " ");

                if (current.Right != null)
                    stack.Push(current.Right);
                if (current.Left != null)
                    stack.Push(current.Left);
            }
            Console.WriteLine();
        }

        public static void PrintTree(BinaryTreeNode<char>? root, int level = 0)
        {
            if (root == null)
                return;

            PrintTree(root.Right, level + 1);

            Console.WriteLine(new string(' ', 4 * level) + root.Data);

            PrintTree(root.Left, level + 1);
        }
    }
}