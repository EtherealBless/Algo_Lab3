using System;

namespace Lab3.LabCollections.YunPart.TREE_STACK_AND_OTHER.SuffixTree
{
    public static class SuffixTreeExample
    {
        public static void Run()
        {
            string text = "banana";
            SuffixTree suffixTree = new SuffixTree(text);

            string w = "ana";
            Console.WriteLine($"Does the string \"{text}\" contain the substring \"{w}\"? {suffixTree.Contains(w)}");

            w = "nan";
            Console.WriteLine($"Does the string \"{text}\" contain the substring \"{w}\"? {suffixTree.Contains(w)}");
        }
    }
}
