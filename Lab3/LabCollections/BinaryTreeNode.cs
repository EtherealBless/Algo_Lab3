namespace Lab3.LabCollections
{
    public class BinaryTreeNode<T> where T : IComparable<T>
    {
        public T Data { get; set; }
        public TreeNode<T>? Left { get; set; }
        public TreeNode<T>? Right { get; set; }

        public BinaryTreeNode(T data)
        {
            Data = data;
        }

        public BinaryTreeNode(T data, TreeNode<T>? left, TreeNode<T>? right)
        {
            Data = data;
            Left = left;
            Right = right;
        }

        public override string ToString() => Data.ToString();
    }

}