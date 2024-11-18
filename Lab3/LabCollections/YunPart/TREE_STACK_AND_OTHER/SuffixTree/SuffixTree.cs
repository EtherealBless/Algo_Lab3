using System;
using System.Collections.Generic;

namespace Lab3.LabCollections.YunPart.TREE_STACK_AND_OTHER.SuffixTree
{
    public class SuffixTree
    {
        private string text;
        private SuffixTreeNode root;
        private int leafEnd;
        private int size;
        private int remainingSuffixCount;

        public SuffixTree(string text)
        {
            this.text = text;
            root = new SuffixTreeNode(-1, -1);
            leafEnd = -1;
            size = -1;
            remainingSuffixCount = 0;
            BuildSuffixTree();
        }

        private void BuildSuffixTree()
        {
            size = text.Length;
            leafEnd = size - 1;
            remainingSuffixCount = size;
            root.SuffixLink = root;

            for (int i = 0; i < size; i++)
            {
                ExtendSuffixTree(i);
            }
        }

        private void ExtendSuffixTree(int pos)
        {
            SuffixTreeNode lastNewNode = null;
            SuffixTreeNode currentNode = root;
            int end = pos;
            int i = pos;

            while (remainingSuffixCount > 0)
            {
                if (end == leafEnd)
                {
                    if (currentNode.Children.ContainsKey(text[pos]))
                    {
                        currentNode = currentNode.Children[text[pos]];
                        end = currentNode.End;
                        i = pos + (end - currentNode.Start) + 1;
                    }
                    else
                    {
                        leafEnd++;
                        remainingSuffixCount--;

                        if (remainingSuffixCount == 0)
                        {
                            break;
                        }

                        currentNode.Children[text[pos]] = new SuffixTreeNode(pos, leafEnd);

                        if (lastNewNode != null)
                        {
                            lastNewNode.SuffixLink = currentNode;
                            lastNewNode = null;
                        }

                        currentNode = root;
                        end = pos;
                        i = pos;
                    }
                }
                else
                {
                    if (i <= end)
                    {
                        if (currentNode.Children.ContainsKey(text[i]))
                        {
                            currentNode = currentNode.Children[text[i]];
                            end = currentNode.End;
                            i++;
                        }
                        else
                        {
                            leafEnd++;
                            remainingSuffixCount--;

                            if (remainingSuffixCount == 0)
                            {
                                break;
                            }

                            currentNode.Children[text[i]] = new SuffixTreeNode(i, leafEnd);

                            if (lastNewNode != null)
                            {
                                lastNewNode.SuffixLink = currentNode;
                                lastNewNode = null;
                            }

                            currentNode = root;
                            end = pos;
                            i = pos;
                        }
                    }
                    else
                    {
                        leafEnd++;
                        remainingSuffixCount--;

                        if (remainingSuffixCount == 0)
                        {
                            break;
                        }

                        SuffixTreeNode splitEnd = new SuffixTreeNode(currentNode.Start, i - 1);
                        currentNode.Start = i;

                        SuffixTreeNode newNode = new SuffixTreeNode(pos, leafEnd);
                        splitEnd.Children[text[i]] = newNode;

                        currentNode.Children[text[pos]] = splitEnd;

                        if (lastNewNode != null)
                        {
                            lastNewNode.SuffixLink = splitEnd;
                        }

                        lastNewNode = newNode;

                        currentNode = root;
                        end = pos;
                        i = pos;
                    }
                }
            }
        }

        public bool Contains(string w)
        {
            SuffixTreeNode currentNode = root;
            int i = 0;

            while (i < w.Length)
            {
                if (currentNode.Children.ContainsKey(w[i]))
                {
                    currentNode = currentNode.Children[w[i]];
                    int len = currentNode.End - currentNode.Start + 1;
                    if (i + len <= w.Length && w.Substring(i, len) == text.Substring(currentNode.Start, len))
                    {
                        i += len;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
