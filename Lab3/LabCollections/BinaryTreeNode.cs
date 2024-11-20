namespace Lab3.LabCollections
{
    public class BinaryTreeNode<T> : TreeNode<T> where T : IComparable<T>
    {
        public new BinaryTreeNode<T>? Left
        {
            get => GetChildren().Count > 0 ? GetChildren()[0] as BinaryTreeNode<T> : null;
            set
            {
                if (GetChildren().Count > 0)
                    GetChildren()[0] = value;
                else if (value != null)
                    AddChild(value);
            }
        }

        public BinaryTreeNode<T>? Right
        {
            get => GetChildren().Count > 1 ? GetChildren()[1] as BinaryTreeNode<T> : null;
            set
            {
                if (GetChildren().Count > 1)
                    GetChildren()[1] = value;
                else if (value != null)
                {
                    if (GetChildren().Count == 0)
                        AddChild(null);
                    AddChild(value);
                }
            }
        }

        public BinaryTreeNode(T data) : base(data) { }

        public BinaryTreeNode(T data, BinaryTreeNode<T>? left, BinaryTreeNode<T>? right) : base(data)
        {
            if (left != null) AddChild(left);
            if (right != null) AddChild(right);
        }

        public override string ToString() => Data?.ToString() ?? "null";
    }

}