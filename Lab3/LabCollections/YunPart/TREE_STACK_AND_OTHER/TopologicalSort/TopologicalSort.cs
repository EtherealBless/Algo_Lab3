using System;
using System.Collections.Generic;
using Lab3.LabCollections;

namespace Lab3.LabCollections.YunPart.TREE_STACK_AND_OTHER.TopologicalSort
{
    public class TopologicalSort
    {
        private Stack<int> stack;

        public TopologicalSort()
        {
            stack = new Stack<int>();
        }

        public void TopologicalSortUtil(int v, bool[] visited, List<int>[] adjacencyList)
        {
            visited[v] = true;
            foreach (int i in adjacencyList[v])
            {
                if (!visited[i])
                {
                    TopologicalSortUtil(i, visited, adjacencyList);
                }
            }
            stack.Push(v);
        }

        public List<int> Sort(Graph graph)
        {
            bool[] visited = new bool[graph.GetVertices()];
            for (int i = 0; i < graph.GetVertices(); i++)
            {
                if (!visited[i])
                {
                    TopologicalSortUtil(i, visited, graph.GetAdjacencyList());
                }
            }

            List<int> result = new List<int>();
            while (!stack.IsEmpty())
            {
                result.Add(stack.Pop());
            }
            return result;
        }
    }
}
