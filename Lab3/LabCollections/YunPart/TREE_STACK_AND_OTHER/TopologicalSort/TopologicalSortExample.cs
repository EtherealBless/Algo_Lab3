using System;
using System.Collections.Generic;

namespace Lab3.LabCollections.YunPart.TREE_STACK_AND_OTHER.TopologicalSort
{
    public static class TopologicalSortExample
    {
        public static void Run()
        {
            Graph graph = new Graph(6);
            graph.AddEdge(5, 2);
            graph.AddEdge(5, 0);
            graph.AddEdge(4, 0);
            graph.AddEdge(4, 1);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 1);

            TopologicalSort topologicalSort = new TopologicalSort();
            List<int> result = topologicalSort.Sort(graph);

            Console.WriteLine("Topological Sort of the given graph:");
            foreach (int vertex in result)
            {
                Console.Write(vertex + " ");
            }
            Console.WriteLine();
        }
    }
}
