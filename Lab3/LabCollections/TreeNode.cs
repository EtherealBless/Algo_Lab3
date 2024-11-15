namespace Lab3.LabCollections
{
    public class TreeNode<T>
    {
        public T Data { get; set; }
        private List<TreeNode<T>> _children = new List<TreeNode<T>>();

        public void AddChild(TreeNode<T> child) => _children.Add(child);

        public List<TreeNode<T>> GetChildren() => _children;

        public TreeNode(T data) => Data = data;

        public TreeNode(T data, List<TreeNode<T>> children) : this(data)
        {
            _children = children;
        }

        public void PrintTree(string indent = "")
        {
            Console.WriteLine(indent + this);
            foreach (var child in _children)
            {
                child.PrintTree(indent + "  ");
            }
        }
        public override string ToString() => Data.ToString();
    }
}