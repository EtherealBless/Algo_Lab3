
namespace Lab3.LabCollections
{
    public class FileSystemNode : TreeNode<string>
    {
        public FileSystemNode(string data) : base(data)
        {
        }

        public FileSystemNode(string data, List<TreeNode<string>> children) : base(data, children)
        {
        }
    }
}